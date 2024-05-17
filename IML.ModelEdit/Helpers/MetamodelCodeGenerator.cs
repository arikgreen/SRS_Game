using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MyLib.OrdNumbers;

namespace IML.ModelEdit
{
  /// <summary>
  /// Generator kodu w C#
  /// </summary>
  public class MetamodelCodeGenerator: BaseCodeGenerator
  {
    /// <summary>
    /// Konstruktor domyślny przekazujący wyjście do generatora bazowego
    /// </summary>
    /// <param name="writer"></param>
    public MetamodelCodeGenerator(TextWriter writer): base(writer)
    {
    }

    /// <summary>
    /// Przenumerowanie typów zadeklarowanych w metamodelu
    /// </summary>
    /// <param name="metamodel"></param>
    protected void RenumberTypes (Metamodel metamodel)
    {
      OrdNum ordNum = new OrdNum(0);
      foreach (Metatype item in metamodel.RootTypes)
      {
        RenumberMetatype(item, ref ordNum);
      }
    }

    /// <summary>
    /// Przypisanie numeru porządkowego do metatypu i zwiększenie numeru porządkowego.
    /// Jeśli metatyp jest klasą i ta klasa ma podklasy, to dostają one numery zagnieżdżone.
    /// </summary>
    /// <param name="metamodel"></param>
    protected void RenumberMetatype (Metatype metatype, ref OrdNum ordNum)
    {
      metatype.Order = ordNum;
      if (metatype is Metaclass && (metatype as Metaclass).Subclasses != null && (metatype as Metaclass).Subclasses.Count() > 0)
      {
        OrdNum subNum = ordNum.ToString() + ".1";
        foreach (Metatype item in (metatype as Metaclass).Subclasses)
        {
          RenumberMetatype(item, ref subNum);
        }
      }
      ordNum = ++ordNum;
    }

    /// <summary>
    /// Generowanie kodu źródłowego
    /// </summary>
    /// <param name="metamodel"></param>
    /// <param name="Output"></param>
    public void GenerateCode (Metamodel metamodel)
    {
      RenumberTypes(metamodel);
      WriteUsings();
      WriteLine();
      WriteLine("namespace {0}", metamodel.Namespace);
      WriteLine("{");
      Indent++;
      GenerateModelClass(metamodel);
      foreach (Metatype item in metamodel.RootTypes)
      {
        GenerateMetatype(item);
        WriteLine();
      }
      Indent--;
      WriteLine("}");
    }


    protected List<string> Usings = new List<string>
    {
      "System",
      "System.Collections.Generic",
      "Iml.Foundation",
      "Iml.Modeling",
    };

    protected List<string> DefaultTypes = new List<string>
    {
      "Type = System.Type",
      "String = System.String",
    };

    /// <summary>
    /// Wypisanie wykorzystywanych przestrzeni nazw
    /// </summary>
    protected void WriteUsings ()
    {
      foreach (string str in Usings)
        WriteLine("using {0};", str);
      foreach (string str in DefaultTypes)
        WriteLine("using {0};", str);
    }

    /// <summary>
    /// Generowanie klasy reprezentującej metamodel. 
    /// Klasa ta ma tylko jedną właściwość statyczną "Metatypes",
    /// która udostępnia rozpoznane metatypy zadeklarowane w kodzie.
    /// </summary>
    protected void GenerateModelClass (Metamodel metamodel)
    {
      WriteLine();
      WriteLine("public class {0}Model: Iml.Modeling.Metamodel", metamodel.Name);
      WriteLine("{");
      Indent++;
      WriteLine("private static List<Type> metatypes;");
      WriteLine("public new static List<Type> Metatypes ");
      WriteLine("{");
      Indent++;
      WriteLine("get");
      WriteLine("{");
      Indent++;
      WriteLine("if (metatypes == null)");
      Indent++;
      WriteLine("metatypes = Iml.Modeling.Metamodel.GetMetatypes();");
      Indent--;
      WriteLine("return metatypes;");
      Indent--;
      WriteLine("}");
      Indent--;
      WriteLine("}");
      Indent--;
      WriteLine("}");
    }

    /// <summary>
    /// Generowanie klasy lub typu reprezentującego metatyp. 
    /// W zależności od rodzaju metatypu wywoływana jest 
    /// metoda <see cref="GenerateMetaclass"/> lub <see cref="GenerateEnumType"/>
    /// </summary>
    protected void GenerateMetatype (Metatype metatype)
    {
      if (metatype is Metaclass)
        GenerateMetaclassWithSubclasses((Metaclass)metatype);
      else if (metatype is EnumType)
        GenerateEnumType((EnumType)metatype);
    }

    /// <summary>
    /// Wygenerowanie kodu metaklasy i wszystkich jej klas potomnych
    /// (na tym samym poziomie zagłębienia w kodzie).
    /// </summary>
    /// <param name="metaclass"></param>
    protected void GenerateMetaclassWithSubclasses (Metaclass metaclass)
    {
      GenerateMetaclass(metaclass);
      if (metaclass.Subclasses != null)
        foreach (Metaclass subclass in metaclass.Subclasses)
          GenerateMetaclassWithSubclasses(subclass);
    }

    /// <summary>
    /// Wygenerowanie kodu metaklasy z jej wszystkimi właściwościami
    /// </summary>
    /// <param name="metaclass"></param>
    protected void GenerateMetaclass (Metaclass metaclass)
    {
      WriteLine();
      WriteDescription(metaclass.Description);
      WriteLine("[Metaclass(Order = \"{0}\")]",metaclass.Order);
      if (metaclass.IsAbstract)
        WriteLine("[IsAbstract]");
      WriteLine("public class {0}: {1}", metaclass.Name, (metaclass.BaseType != null) ? metaclass.BaseType.TargetName : "Iml.Modeling.Metamodel");
      WriteLine("{");
      Indent++;
      if (metaclass.Properties != null)
        foreach (ClassProperty property in metaclass.Properties)
          if (!property.IsInherited)
            GenerateClassProperty(property);
      Indent--;
      WriteLine("}");
    }


    /// <summary>
    /// Wygenerowanie właściwości klasy
    /// </summary>
    /// <param name="metaclass"></param>
    protected void GenerateClassProperty (ClassProperty property)
    {
      WriteDescription(property.Description);
      WriteLine("public {0} {1} {{ get; set; }}", property.Type!=null ? property.Type.TargetName : "object", property.Name);
    }

    /// <summary>
    /// Wygenerowanie kodu typu wyliczeniowego z jego wszystkimi wartościami
    /// </summary>
    /// <param name="metaclass"></param>
    protected void GenerateEnumType (EnumType enumType)
    {
      WriteLine();
      WriteDescription(enumType.Description);
      WriteLine("[Metaclass(Order = \"{0}\")]", enumType.Order);
      WriteLine("public enum {0}", enumType.Name);
      WriteLine("{");
      Indent++;
      if (enumType.Values != null)
        foreach (EnumValue item in enumType.Values)
          GenerateEnumValue(item);
      Indent--;
      WriteLine("}");
    }

    /// <summary>
    /// Wygenerowanie wartości wyliczeniowej
    /// </summary>
    /// <param name="metaclass"></param>
    protected void GenerateEnumValue (EnumValue enumValue)
    {
      WriteDescription(enumValue.Description);
      if (enumValue.Value != null)
        WriteLine("{0} = {1},", enumValue.Name, enumValue.Value);
      else
        WriteLine("{0},", enumValue.Name);
    }

    /// <summary>
    /// Wygenerowanie opisu metatypu w formie komentarzy dokumentacyjnych
    /// </summary>
    /// <param name="metatype"></param>
    protected void WriteDescription(string description)
    {
      if (description!=null)
      {
        WriteLine("/// <summary>");
        foreach (string str in SplitToLines(description, 72))
          WriteLine("/// " + str);
        WriteLine("/// </summary>");
      }
    }

    /// <summary>
    /// Podział dłuższego tekstu na linie o określonej długości.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="limit">limit długości linii - nie musi być dotrzymany</param>
    /// <returns></returns>
    protected IEnumerable<string> SplitToLines(string text, int limit)
    {
      List<string> result = new List<string>();
      int m = 0;
      int n = 0;
      while ((n=FindSplitPos(text, m, limit))>0)
      {
        result.Add(text.Substring(m, n).Trim());
        m += n;
      }
      string s = text.Substring(m).Trim();
      if (s.Length>0)
        result.Add(s);
      return result;
    }

    /// <summary>
    /// Znalezienie miejsca podziału łańcucha
    /// </summary>
    /// <param name="text">dzielony tekst</param>
    /// <param name="startPos">pozycja początkowa szukania miejsca podziału</param>
    /// <param name="limit">ograniczenie długość (dodawane do pozycji początkowej)</param>
    /// <returns></returns>
    protected int FindSplitPos(string text, int startPos, int limit)
    {
      int endPos = startPos + limit;
      if (endPos > text.Length)
        return -1;
      for (int i=endPos-1; i>startPos + limit*3/4; i--)
      {
        if (text[i] == '.' || text[i] == ',' || text[i] == ';' || text[i] == '!' || text[i] == '?')
        {
          if (!(text[i]=='.' && i>1 && text.Substring(i-2,2).ToLower()=="np"))
            return i - startPos + 1;
        }
      }
      for (int i = endPos - 1; i > startPos + limit/2; i--)
      {
        if (text[i] == ')' || text[i] == ']' || text[i] == '}')
          return i - startPos +1;
      }
      for (int i = endPos - 1; i > startPos; i--)
      {
        if (text[i] == ' ' || text[i] == '-' || text[i] == '#')
          return i - startPos;
      }
      return -1;
    }
  }
}
