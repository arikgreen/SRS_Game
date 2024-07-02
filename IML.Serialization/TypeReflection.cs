using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml.Serialization;
using System.Windows;
using System.Windows.Markup;
using System.Xml;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace Iml.Serialization
{

  public class TypeReflection: Dictionary<XmlQualifiedName, TypeInfo>
  {

    private class HiddenPropertyInfo
    {
      public string TypeName;
      public string PropertyName;
    }

    private static List<HiddenPropertyInfo> HiddenProperties = new List<HiddenPropertyInfo>(new HiddenPropertyInfo[]
    {
      new HiddenPropertyInfo { TypeName = "Run", PropertyName = "FontFamily"},
      new HiddenPropertyInfo { TypeName = "Run", PropertyName = "FontSize"},
      new HiddenPropertyInfo { TypeName = "Paragraph", PropertyName = "FontFamily"},
      new HiddenPropertyInfo { TypeName = "Paragraph", PropertyName = "FontSize"},
      new HiddenPropertyInfo { TypeName = "Paragraph", PropertyName = "TextAlignment"},
    });

    private class DefaultValueInfo
    {
      public string TypeName;
      public string PropertyName;
      public object PropertyValue;
    }

    private static List<DefaultValueInfo> DefaultValues = new List<DefaultValueInfo>(new DefaultValueInfo[]
    { 
      new DefaultValueInfo { TypeName = "Bold", PropertyName = "FontWeight" , PropertyValue = FontWeights.Bold},
      new DefaultValueInfo { TypeName = "Italic", PropertyName = "FontStyle" , PropertyValue = FontStyles.Italic},
      new DefaultValueInfo { TypeName = "Underline", PropertyName = "TextDecorations" , PropertyValue = new TextDecorationCollection{ TextDecorations.Underline}} 
    });


    private class ObjectAliasInfo
    {
      public Type Type;
      public string AliasName;
      public Object Value;
    }

    private static List<ObjectAliasInfo> ObjectAliases = new List<ObjectAliasInfo> ( new ObjectAliasInfo[] 
    { 
      new ObjectAliasInfo { Type = typeof(TextDecoration), AliasName = "Underline", Value = TextDecorations.Underline.First()}, 
      new ObjectAliasInfo { Type = typeof(TextDecoration), AliasName = "Baseline", Value = TextDecorations.Baseline.First()}, 
      new ObjectAliasInfo { Type = typeof(TextDecoration), AliasName = "Strikethrough", Value = TextDecorations.Strikethrough.First()}, 
      new ObjectAliasInfo { Type = typeof(TextDecoration), AliasName = "OverLine", Value = TextDecorations.OverLine.First()}, 
    });

    private class TypeConverterInfo
    {
      public String TypeName;
      public String ConverterName;
    }

    private static List<TypeConverterInfo> ExtraConverters = new List<TypeConverterInfo> ( new TypeConverterInfo[]
    {
      new TypeConverterInfo { TypeName = "Inline", ConverterName = "InlineConverter" }
    });

    public Dictionary<string, TypeConverter> Converters = new Dictionary<string, TypeConverter>();

    public ImlNamespaceManager NamespaceManager = new ImlNamespaceManager();

    public TypeInfo Reflect(Type aType)
    {
      return Reflect(aType, null, false);
    }

    public TypeInfo Reflect(Type aType, PropertyInfo propInfo)
    {
      ImlItemInfo imlPropInfo = null;
      string elementName = null;
      if (aType.Name.IndexOf('`') > 0)
      {
        if (TryGetPropertyAttribute(propInfo, typeof(XmlElementAttribute), ref imlPropInfo)
        || TryGetPropertyAttribute(propInfo, typeof(ImlDictionaryAttribute), ref imlPropInfo)
        || TryGetPropertyAttribute(propInfo, typeof(XmlArrayAttribute), ref imlPropInfo))
          elementName = imlPropInfo.ImlName;
      }
      return Reflect(aType, elementName);
    }

    public TypeInfo Reflect(Type aType, string elementName)
    {
      return Reflect(aType, elementName, false);
    }

    public TypeInfo Reflect(Type aType, string elementName, bool recursive)
    {
      //if (aType == typeof(System.Object))
      //  Debug.Assert(true);
      TypeInfo result = null;
      if (elementName != null)
        TryGetValue(elementName, out result);
      else
        result = FindTypeInfo(aType, recursive);
      if (result == null)
      {
        Debug.WriteLine(aType.FullName);
        Assembly aAssembly = aType.Assembly;
        NamespaceManager.AddNamespace(aAssembly);
        string prefix = NamespaceManager.LookupPrefix(aAssembly);
        string typeName = TypeName(aType);
        XmlQualifiedName aElementName = new XmlQualifiedName(typeName, prefix);
        if (!ContainsKey(aElementName))
        {
          result = new TypeInfo
          {
            Type = aType,
            ElementName = typeName,
            ElementPrefix = prefix,
            ElementNs = NamespaceManager.LookupNamespace(prefix)
          };
          Add(aElementName, result);
          GetRootAttributes(result, aType);
          if ((aType.BaseType != null) && (aType.BaseType != typeof(System.Object))
             && aType.BaseType.Name.IndexOf('`') < 0)
            result.BaseType = Reflect(aType.BaseType);

          if (!result.IsList)
            if (!TryGetListInterface(result, aType))
              TryGetDictionaryInterface(result, aType);

          if (aType.IsSubclassOf(typeof(DependencyObject)))
            ReflectDependencyProperties(result, aType);

          ReflectProperties(result, aType);

          //if (result.Attributes != null)
          //  result.Attributes.Sort();
          //if (result.Elements != null)
          //  result.Elements.Sort();

          result.IsConstructable = aType.GetConstructor(new Type[] { }) != null;

          GetSubtypes(result);
          if (result.ConverterTypeName == null)
            result.ConverterTypeName = (from item in ExtraConverters where item.TypeName == aType.Name select item.ConverterName).FirstOrDefault();
          GetConverters(result);
          if ((from item in ObjectAliases where item.Type == result.Type select item).FirstOrDefault() != null)
            result.HasAliases = true;
        }
      }
      return result;
    }

    public TypeInfo Reflect(string prefix, string localName)
    {
      Assembly[] assemblies = NamespaceManager.LookupAssemblies(prefix);
      foreach (Assembly assembly in assemblies)
      {
        Type[] Types = (from type in assembly.GetTypes() 
                       where String.Equals(type.Name, localName, StringComparison.InvariantCultureIgnoreCase)
                       select type).ToArray();
        if (Types.Length == 1)
          return Reflect(Types[0]);
        foreach (Type aType in Types)
        {
          string aName = aType.FullName;
          string[] ss = aName.Split('.');
          if (String.Equals(ss[ss.Length - 1], localName, StringComparison.InvariantCultureIgnoreCase))
            return Reflect(aType);
        }
      }
      return null;
    }

    private TypeInfo FindTypeInfo(Type aType, bool recursive)
    {
      var TypeInfos = from item in this.Values where item.Type == aType select item;
      TypeInfo aTypeInfo = TypeInfos.FirstOrDefault();
      if (aTypeInfo == null && recursive && aType.BaseType != null)
        return FindTypeInfo(aType.BaseType, recursive);
      else
        return aTypeInfo;
    }

    public string TypeName(Type aType)
    {
      string result = aType.Name;
      int n = result.IndexOf('`');
      if (n>0)
      {
        bool firstParam = true;
        result = result.Substring(0, n);
        string s = TitleCase(aType.FullName);
        n = s.IndexOf('[');
        if (n > 0 && s.EndsWith("]"))
        {
          s = s.Substring(n + 1, s.Length - n - 2);
          s = s.Replace("],[", "];[");
          string[] ss = s.Split(';');
          foreach (string s1 in ss)
          {
            string s2 = s1;
            if (s1.StartsWith("[") && s1.EndsWith("]"))
              s2 = s1.Substring(1, s1.Length - 2);
            string[] ss2 = s2.Split(',');
            if (ss2.Length > 0)
            {
              string s3 = ss2[0];
              string[] ss3 = s3.Split('.');
              if (ss3.Length > 0)
              {
                if (firstParam)
                {
                  result += "Of";
                  firstParam = false;
                }
                else
                  result += "And";
                result += TitleCase(ss3[ss3.Length - 1]);
              }
            }
          }
        }
      }
      return result;
    }

    private static string TitleCase(string s)
    {
      if (Char.IsUpper(s[0]) || !Char.IsLetter(s[0]))
        return s;
      else
        return Char.ToUpper(s[0])+s.Substring(1);
    }

    private void GetConverters(TypeInfo aTypeInfo)
    {
      if (aTypeInfo.ConverterTypeName != null)
        GetConverter(aTypeInfo.Type, aTypeInfo.ConverterTypeName);
      if (aTypeInfo.Attributes != null)
      foreach (ImlItemInfo aAttributeInfo in aTypeInfo.Attributes)
      {
        if (aAttributeInfo.ConverterTypeName != null)
          GetConverter(aAttributeInfo.Property.PropertyType, aAttributeInfo.ConverterTypeName);
        TypeInfo PropTypeInfo = Reflect(aAttributeInfo.Property.PropertyType);
        if (PropTypeInfo.ConverterTypeName != null)
          GetConverter(aAttributeInfo.Property.PropertyType, PropTypeInfo.ConverterTypeName);
      }
      if (aTypeInfo.Elements != null)
        foreach (ImlItemInfo aElementInfo in aTypeInfo.Elements)
        {
          if (aElementInfo.ConverterTypeName != null)
            GetConverter(aElementInfo.Property.PropertyType, aElementInfo.ConverterTypeName);
          TypeInfo PropTypeInfo = Reflect(aElementInfo.Property.PropertyType);
          if (PropTypeInfo.ConverterTypeName != null)
            GetConverter(aElementInfo.Property.PropertyType, PropTypeInfo.ConverterTypeName);
        }
    }

    private void GetConverter(Type aType, string ConverterTypeName)
    {
      string[] ss = ConverterTypeName.Split(',');
      if (!Converters.ContainsKey(aType.Name))
      {
        Type converterType = null;
        if (ss.Length > 1)
        {
          string aSearchName = String.Join(",", ss, 1, ss.Length - 1);
          AssemblyName aAssemblyName = new AssemblyName(aSearchName);
          Assembly assembly = Assembly.Load(aAssemblyName);
          converterType = assembly.GetType(ss[0]);
        }
        else
        {
          Assembly[] assemblies = NamespaceManager.GetAllAssemblies();
          foreach (Assembly assembly in assemblies)
          {
            converterType = assembly.GetType(ConverterTypeName, false);
            if (converterType != null)
              break;
          }
        }
        if (converterType == null)
        {
          Assembly assembly = Assembly.GetExecutingAssembly();
          converterType = assembly.GetType("Iml.Serialization."+ss[0]);
        }
        if (converterType == null)
          throw new SerializationException(
                String.Format("TypeConverter '{0}' not found", ConverterTypeName));
        ConstructorInfo aInfo = converterType.GetConstructor(new Type[] { });
        TypeConverter aConverter = aInfo.Invoke(new object[] { }) as TypeConverter;
        Converters.Add(aType.Name, aConverter);
      }
    }

    public string GetObjectAlias(Type aType, object value)
    {
      return (from item in ObjectAliases 
              where item.Type == aType && item.Value.Equals(value) 
              select item.AliasName).FirstOrDefault();
    }

    private bool TryGetListInterface(TypeInfo aTypeInfo, Type aType)
    {
      aTypeInfo.IsList = aType.GetInterface("IList", false) != null;
      if (aTypeInfo.IsList)
      {
        Type[] Interfaces = aType.GetInterfaces();
        foreach (Type aInterface in Interfaces)
        {
          if (aInterface.Name.StartsWith("IList"))
          {
            if (aInterface.IsGenericType)
            {
              Type[] Arguments = aInterface.GetGenericArguments();
              if (Arguments.Length == 1)
              {
                if (Arguments[0] != typeof(object))
                {
                  aTypeInfo.ItemType = Reflect(Arguments[0]);
                }
              }
            }
          }
        }
      }
      return aTypeInfo.IsList;
    }

    private bool TryGetDictionaryInterface(TypeInfo aTypeInfo, Type aType)
    {
      aTypeInfo.IsList = aTypeInfo.IsDictionary = 
                   aType.GetInterface("IDictionary", false) != null;
      if (aTypeInfo.IsDictionary)
      {
        Type[] Interfaces = aType.GetInterfaces();
        foreach (Type aInterface in Interfaces)
        {
          if (aInterface.Name.StartsWith("IDictionary"))
          {
            if (aInterface.IsGenericType)
            {
              Type[] Arguments = aInterface.GetGenericArguments();
              if (Arguments.Length == 2)
              {
                if (Arguments[0] != null && Arguments[0] != typeof(object))
                  aTypeInfo.KeyType = Reflect(Arguments[0]);
                if (Arguments[1] != null && Arguments[1] != typeof(object))
                  aTypeInfo.ItemType = Reflect(Arguments[1]);
              }
            }
          }
        }
      }
      return aTypeInfo.IsDictionary;
    }

    private void GetSubtypes(TypeInfo aTypeInfo)
    {
      if (aTypeInfo.Elements != null)
      {
        foreach (ImlItemInfo aItem in aTypeInfo.Elements)
        {
          Type bType = aItem.Property.PropertyType;
          TypeInfo bTypeInfo = Reflect(bType,aItem.Property);
          if (bTypeInfo != null)
          {
            if (bTypeInfo.IsDictionary)
              GetDictionaryAttributes(bTypeInfo,aItem.Property);
            if (bTypeInfo.IsList)
              GetArrayItems(aItem.Property);
          }
        }
      }
      if (aTypeInfo.IsList && aTypeInfo.ItemType != null)
      {
        Reflect(aTypeInfo.ItemType.Type);
      }
      if (aTypeInfo.ContentWrappers!=null)
        foreach (Type wrappedType in aTypeInfo.ContentWrappers)
          Reflect(wrappedType);
    }

    private void GetRootAttributes(TypeInfo aTypeInfo, Type aType)
    {
      foreach (Attribute aAttribute in aType.GetCustomAttributes(true))
      {
        Type atrType = aAttribute.GetType();
        if (atrType == typeof(XmlRootAttribute))
          SetXmlRootAttribute(aTypeInfo, aAttribute as XmlRootAttribute);
        else
        if (atrType == typeof(XmlLangPropertyAttribute))
          SetXmlLangPropertyAttribute(aTypeInfo, aAttribute as XmlLangPropertyAttribute);
        else
        if (atrType == typeof(DataContractAttribute))
          SetDataContractAttribute(aTypeInfo, aAttribute as DataContractAttribute);
        else
        if (atrType == typeof(ContentPropertyAttribute))
          SetContentPropertyAttribute(aTypeInfo, aAttribute as ContentPropertyAttribute);
        else
        if (atrType == typeof(TypeConverterAttribute))
          SetTypeConverterAttribute(aTypeInfo, aAttribute as TypeConverterAttribute);
        else
        if (atrType == typeof(DefaultValueAttribute))
          SetDefaultValueAttribute(aTypeInfo, aAttribute as DefaultValueAttribute);
        else
        if (atrType == typeof(ImlDictionaryKeyAttribute))
          SetImlDictionaryKeyAttribute(aTypeInfo, aAttribute as ImlDictionaryKeyAttribute);
        else
        if (atrType == typeof(ImlDictionaryValueAttribute))
          SetImlDictionaryValueAttribute(aTypeInfo, aAttribute as ImlDictionaryValueAttribute);
        else
        if (atrType == typeof(CollectionDataContractAttribute))
          SetCollectionDataContractAttribute(aTypeInfo, aAttribute as CollectionDataContractAttribute);
        else
        if (atrType == typeof(ContentWrapperAttribute))
          SetContentWrapperAttribute(aTypeInfo, aAttribute as ContentWrapperAttribute);
      }
    }

    public void SetXmlRootAttribute(TypeInfo aTypeInfo, XmlRootAttribute aAttribute)
    {
      if (!String.IsNullOrEmpty(aAttribute.ElementName))
        aTypeInfo.ElementName = aAttribute.ElementName;
    }

    public void SetXmlLangPropertyAttribute(TypeInfo aTypeInfo, XmlLangPropertyAttribute aAttribute)
    {
      if (!String.IsNullOrEmpty(aAttribute.Name))
      {
        aTypeInfo.XmlLangProperty = aTypeInfo.Type.GetProperty(aAttribute.Name);
      }
    }

    public void SetDataContractAttribute(TypeInfo aTypeInfo, DataContractAttribute aAttribute)
    {
      if (!String.IsNullOrEmpty(aAttribute.Name))
        aTypeInfo.ElementName = aAttribute.Name;
    }

    public void SetTypeConverterAttribute(TypeInfo aTypeInfo, TypeConverterAttribute aAttribute)
    {
      if (!String.IsNullOrEmpty(aAttribute.ConverterTypeName))
        aTypeInfo.ConverterTypeName = aAttribute.ConverterTypeName;
    }

    public void SetDefaultValueAttribute(TypeInfo aTypeInfo, DefaultValueAttribute aAttribute)
    {
      aTypeInfo.DefaultValue = aAttribute.Value;
    }

    public void SetImlDictionaryKeyAttribute(TypeInfo aTypeInfo, ImlDictionaryKeyAttribute aAttribute)
    {
      if (!String.IsNullOrEmpty(aAttribute.AttributeName))
      {
        ImlItemInfo aInfo = new ImlItemInfo();
        aInfo.ImlName = aAttribute.AttributeName;
        aInfo.AsAttribute = true;
        aTypeInfo.KeyAttribute = aInfo;
      }
    }

    public void SetImlDictionaryValueAttribute(TypeInfo aTypeInfo, ImlDictionaryValueAttribute aAttribute)
    {
      if (!String.IsNullOrEmpty(aAttribute.AttributeName))
      {
        ImlItemInfo aInfo = new ImlItemInfo();
        aInfo.ImlName = aAttribute.AttributeName;
        aInfo.AsAttribute = true;
        aTypeInfo.ValueAttribute = aInfo;
      }
    }

    public void SetContentPropertyAttribute(TypeInfo aTypeInfo, ContentPropertyAttribute aAttribute)
    {
      if (!String.IsNullOrEmpty(aAttribute.Name))
      {
        aTypeInfo.ContentProperty = aTypeInfo.Type.GetProperty(aAttribute.Name,
          BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (aTypeInfo.ContentProperty == null)
          throw new InvalidDataContractException(String.Format("Property {0} not found in class {1}", aAttribute.Name, aTypeInfo.Type.Name));
        Type aType = aTypeInfo.ContentProperty.PropertyType;
        bool aIsList = aType.GetInterface("IList", false) != null;
        if (aIsList)
        {
          Type[] Interfaces = aType.GetInterfaces();
          foreach (Type aInterface in Interfaces)
          {
            if (aInterface.Name.StartsWith("IList"))
            {
              Type aItemType = typeof(Object);
              if (aInterface.IsGenericType)
              {
                Type[] Arguments = aInterface.GetGenericArguments();
                if (Arguments.Length == 1)
                  aItemType = Arguments[0];
              }
              if (aTypeInfo.ItemType == null || aItemType.IsSubclassOf(aTypeInfo.ItemType.Type))
                aTypeInfo.ItemType = Reflect(aItemType);
            }
          }
        }
      }
    }

    public void SetCollectionDataContractAttribute(TypeInfo aTypeInfo, CollectionDataContractAttribute aAttribute)
    {
      if (TryGetListInterface(aTypeInfo, aTypeInfo.Type))
      {
        if (aAttribute.ItemName!=null)
          aTypeInfo.ItemType.ElementName = aAttribute.ItemName;
      }
    }

    public void SetContentWrapperAttribute(TypeInfo aTypeInfo, ContentWrapperAttribute aAttribute)
    {
      if (aAttribute.ContentWrapper != null)
      {
        if (aTypeInfo.ContentWrappers == null)
          aTypeInfo.ContentWrappers = new List<Type>();
        aTypeInfo.ContentWrappers.Add(aAttribute.ContentWrapper);
      }
    }

    private void ReflectDependencyProperties(TypeInfo aTypeInfo, Type aType)
    {
      foreach (FieldInfo aField in aType.GetFields
        (BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy))
      {
        if (aField.FieldType == typeof(DependencyProperty))
        {
          DependencyProperty aFieldProperty = aField.GetValue(null) as DependencyProperty;
          if (!aFieldProperty.ReadOnly)
          {
            string s = aFieldProperty.Name;
            PropertyInfo aProperty = aType.GetProperty(s);
            if (aProperty!=null)
            {
              ImlItemInfo aPropertyInfo = ReflectProperty(aProperty);
              if (aPropertyInfo != null)
              {

                DefaultValueInfo dvi = 
                  (from item in DefaultValues 
                   where item.TypeName == aType.Name && item.PropertyName == s select item).FirstOrDefault();
                if (dvi != null)
                {
                  aPropertyInfo.DefaultValue = dvi.PropertyValue;
                  aPropertyInfo.SpanDefaultValue = true;
                }
                else
                {
                  if (aPropertyInfo.DefaultValue == null && aFieldProperty.DefaultMetadata != null)
                    aPropertyInfo.DefaultValue = aFieldProperty.DefaultMetadata.DefaultValue;
                }

                aTypeInfo.AddImlItemInfo(aPropertyInfo);
                aPropertyInfo.TypeInfo = Reflect(aProperty.PropertyType);
              }
            }
          }
        }
      }
    }

    private void ReflectProperties(TypeInfo aTypeInfo, Type aType)
    {
      foreach (PropertyInfo aProperty in GetProperties(aType))
      {
        ImlItemInfo aPropertyInfo = ReflectProperty(aProperty);
        if (aPropertyInfo != null)
        {
          if (aPropertyInfo.Property.CanWrite)
          {
            if (aProperty.GetSetMethod()!=null)
            {
              aTypeInfo.AddImlItemInfo(aPropertyInfo);
              aPropertyInfo.TypeInfo = Reflect(aProperty.PropertyType);
            }
          }
        }
      }
    }

    private IEnumerable<PropertyInfo> GetProperties(Type aType)
    {
      List<PropertyInfo> result = new List<PropertyInfo>();
      if (aType.BaseType != null)
        result.AddRange(GetProperties(aType.BaseType));
      result.AddRange(aType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly));
      return result;
    }

    private ImlItemInfo ReflectProperty(PropertyInfo aProperty)
    {
      var prop = (from item in HiddenProperties
                  where item.TypeName == aProperty.ReflectedType.Name && item.PropertyName == aProperty.Name
                  select item).FirstOrDefault();
      if (prop != null)
         return null;
      ImlItemInfo aImlItemInfo = null;
      if (TryGetPropertyAttribute(aProperty, typeof(ImlAttributeAttribute), ref aImlItemInfo)
       || TryGetPropertyAttribute(aProperty, typeof(XmlAttributeAttribute), ref aImlItemInfo))
      {
        TryGetPropertyAttribute(aProperty, typeof(DataMemberAttribute), ref aImlItemInfo);
        TryGetPropertyAttribute(aProperty, typeof(TypeConverterAttribute), ref aImlItemInfo);
        TryGetPropertyAttribute(aProperty, typeof(DefaultValueAttribute), ref aImlItemInfo);
      }
      else
      {
        ImlItemInfo aValueInfo = null;
        if (TryGetPropertyAttribute(aProperty, typeof(XmlTextAttribute), ref aValueInfo))
        {
          TryGetPropertyAttribute(aProperty, typeof(DataMemberAttribute), ref aValueInfo);
          return aValueInfo;
        }
        else
        {
          if (TryGetPropertyAttribute(aProperty, typeof(XmlElementAttribute), ref aImlItemInfo))
          {
            TryGetPropertyAttribute(aProperty, typeof(DataMemberAttribute), ref aImlItemInfo);
            TryGetPropertyAttribute(aProperty, typeof(TypeConverterAttribute), ref aImlItemInfo);
            TryGetPropertyAttribute(aProperty, typeof(DefaultValueAttribute), ref aImlItemInfo);
          }
          else
          {
            bool ignore = false;
            foreach (Attribute aAttribute in aProperty.GetCustomAttributes(true))
            {
              if (aAttribute is XmlIgnoreAttribute || aAttribute is IgnoreDataMemberAttribute
                || (aAttribute is DesignerSerializationVisibilityAttribute 
                && (aAttribute as DesignerSerializationVisibilityAttribute).Visibility==DesignerSerializationVisibility.Hidden))
                ignore = true;
            }
            if (!ignore)
            {
              aImlItemInfo = null;
              TryGetPropertyAttribute(aProperty, typeof(XmlArrayAttribute), ref aImlItemInfo);
              if (aImlItemInfo == null && aProperty.CanRead)
              {
                if (aProperty.CanWrite || aProperty.PropertyType.GetInterface("IList", false) != null)
                {
                  TryGetPropertyAttribute(aProperty, typeof(DataMemberAttribute), ref aImlItemInfo);
                  if (aImlItemInfo == null)
                  {
                    aImlItemInfo = new ImlItemInfo(aProperty);
                    aImlItemInfo.IsImplicit = true;
                  }
                  TryGetPropertyAttribute(aProperty, typeof(TypeConverterAttribute), ref aImlItemInfo);
                  if (IsSimpleType(aProperty.PropertyType))
                    aImlItemInfo.AsAttribute = true;
                  TryGetPropertyAttribute(aProperty, typeof(ImlDictionaryAttribute), ref aImlItemInfo);
                  if (TryGetPropertyAttribute(aProperty, typeof(DataMemberAttribute), ref aImlItemInfo))
                    TryGetPropertyAttribute(aProperty, typeof(TypeConverterAttribute), ref aImlItemInfo);
                }
              }
            }
          }
        }
      }
      return aImlItemInfo;
    }
  
    public void GetDictionaryAttributes(TypeInfo aTypeInfo, PropertyInfo aProperty)
    {
      ImlItemInfo aImlKeyInfo = null;
      if (TryGetPropertyAttribute(aProperty, typeof(ImlDictionaryKeyAttribute), ref aImlKeyInfo))
        aTypeInfo.KeyAttribute = aImlKeyInfo;
      ImlItemInfo aImlValueInfo = null;
      if (TryGetPropertyAttribute(aProperty, typeof(ImlDictionaryValueAttribute), ref aImlValueInfo))
        aTypeInfo.ValueAttribute = aImlValueInfo;
    }

    private bool TryGetPropertyAttribute(PropertyInfo aProperty, Type attributeType, ref ImlItemInfo aImlItemInfo)
    {
      foreach (Attribute aAttribute in aProperty.GetCustomAttributes(true))
      {
        if (aAttribute.GetType() == attributeType)
        {
          if (aImlItemInfo == null)
            aImlItemInfo = new ImlItemInfo(aProperty);
          aImlItemInfo.SetAttribute(aAttribute);
          return true;
        }
      }
      return false;
    }

    private bool TryGetPropertyAttribute(PropertyInfo aProperty, Type attributeType, ref Attribute result)
    {
      foreach (Attribute aAttribute in aProperty.GetCustomAttributes(true))
      {
        if (aAttribute.GetType() == attributeType)
        {
          result = aAttribute;
          return true;
        }
      }
      return false;
    }

    public void GetArrayItems(PropertyInfo aProperty)
    {
      foreach (Attribute aAttribute in aProperty.GetCustomAttributes(true))
      {
        if (aAttribute.GetType() == typeof(XmlArrayItemAttribute))
        {
          Type aType = (aAttribute as XmlArrayItemAttribute).Type;
          TypeInfo aTypeInfo = Reflect(aType);
        }
      }
    }

    static public bool IsValueType(TypeInfo aTypeInfo)
    {
      return IsSimpleType(aTypeInfo.Type);
    }

    static public bool IsSimpleType(Type aType)
    {
      if (aType.IsValueType)
        return true;
      if (aType.IsPrimitive)
        return true;
      if (aType == typeof(string))
        return true;
      if (aType == typeof(DateTime))
        return true;
      return false;
    }

    public new bool TryGetValue(string elementName, out TypeInfo value)
    {
      value = null;
      if (elementName == "")
        return false;
      string[] ss = elementName.Split(':');
      string prefix = null;
      string localName = elementName;
      if (ss.Length == 2)
      {
        prefix = ss[0];
        localName = ss[1];
      }
      if (base.TryGetValue(new XmlQualifiedName(elementName, prefix), out value))
        return true;
      if (prefix!=null)
      {
        value = Reflect(prefix, localName);
        return value != null;
      }
      else
      {
        Assembly[] assemblies = NamespaceManager.GetAllAssemblies();
        foreach (Assembly assembly in assemblies)
        {
          Type[] Types = (from type in assembly.GetTypes()
                          where String.Equals(type.Name, elementName, StringComparison.InvariantCultureIgnoreCase)
                          select type).ToArray();
          if (Types.Length == 1)
          {
            value = Reflect(Types[0]);
            return value != null;
          }
          foreach (Type aType in Types)
          {
            string aName = aType.FullName;
            ss = aName.Split('.');
            if (String.Equals(ss[ss.Length - 1], elementName, StringComparison.InvariantCultureIgnoreCase))
            {
              value = Reflect(aType);
              return value != null;
            }
          }
        }
        return false;
      }
    }

    public bool TryGetValue(string prefix, string elementName, out TypeInfo value)
    {
      value = Reflect(prefix, elementName);
      return value != null;
    }

  }


}
