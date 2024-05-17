using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace Iml
{
  /// <summary>
  /// Klasa pomocnicza do formatowania i rozpoznawania elementów języka
  /// </summary>
  public static class FormatHelper
  {
    /// <summary>
    /// Separator łańcuchowy umieszczany między elementami listy
    /// </summary>
    public const string ListSeparator = ", ";

    /// <summary>
    /// Separator umieszczany na początku listy
    /// </summary>
    public const string ListStartSeparator = "(";

    /// <summary>
    /// Separator umieszczany na końcu listy
    /// </summary>
    public const string ListEndSeparator = ")";

    /// <summary>
    /// Separator oddzielający nazwę od właściwości
    /// </summary>
    public const char NameValueSeparator = '=';

    /// <summary>
    /// Próba podziału łańcucha wg separatora listy. Przed podziałem obcinane są separatory skrajne listy
    /// </summary>
    /// <param name="str">łańcuch wejściowy</param>
    /// <returns></returns>
    public static string[] TrySplitList (this string str)
    {
      string[] output;
      str = TryTrimListSeparators(str);
      output = SplitList(str);
      return output;
    }


    /// <summary>
    /// Próba obcięcia separatora początkowego i końcowego listy z podanego łańcucha
    /// </summary>
    /// <param name="str">łańcuch wejściowy</param>
    /// <returns></returns>
    public static string TryTrimListSeparators(this string str)
    {
      string output = str;
      if (str.StartsWith(ListStartSeparator) && str.EndsWith(ListEndSeparator))
        output = str.Substring(ListEndSeparator.Length, str.Length - ListStartSeparator.Length - ListEndSeparator.Length);
      return output;
    }

    /// <summary>
    /// Podział łańcucha wg separatora listy.
    /// Lista nie powinna już mieć separatorów skrajnych.
    /// Separatory skrajne listy wewnątrz łańcucha są zliczane tak, 
    /// aby cały łańcuch wewnątrz pary separatorów był potraktowany jako całość.
    /// Z separatorów rozpoznawane są tylko pierwsze znaki.
    /// Każdy element jest przycinany ze spacji skrajnych.
    /// </summary>
    /// <param name="str">łańcuch wejściowy</param>
    /// <returns></returns>
    public static string[] SplitList (this string str)
    {
      List<string> result = new List<string>();
      int m = 0; // pozycja początkowa elementu łańcucha
      int n = 0; // liczba znaków w elemencie łańcucha
      int l = 0; // licznik separatorów skrajnych listy
      for (int i = 0; i < str.Length; i++ )
      {
        if (str[i] == ListStartSeparator[0] && (i==0 || str[i-1]!='\\'))
        {
          l++;
          n++;
        }
        else if (str[i] == ListEndSeparator[0] && (i == 0 || str[i - 1] != '\\'))
        {
           l--;
          n++;
        }
        else if (l == 0 && str[i]== ListSeparator[0])
        {
          result.Add(str.Substring(m,n).Trim());
          m+=n+1;
          n=0;
        }
        else
          n++;
      }
      if (n>0)
        result.Add(str.Substring(m, n).Trim());
      for (int i = 0; i < result.Count; i++)
      {
        result[i] = result[i].TryTrimListSeparators().Trim();
      }
      return result.ToArray();
    }  

    /// <summary>
    /// Wypisanie właściwości publicznych obiektu do łańcucha
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string ToString(object obj)
    {
      StringBuilder sb = new StringBuilder();
      Type objectType = obj.GetType();
      PropertyInfo[] props = objectType.GetProperties();
      int n=0;
      foreach (PropertyInfo prop in props)
      {
        bool shouldSerialize = TryInvokeShouldSerialize(obj, prop.Name);
        bool xmlIgnore = prop.GetCustomAttribute<XmlIgnoreAttribute>(true) != null;
        if (shouldSerialize && !xmlIgnore)
        {
          if (prop.GetCustomAttribute(typeof(XmlArrayAttribute)) != null)
          {
            MethodInfo getMethod = prop.GetGetMethod();
            if (getMethod != null)
            {
              {
                object value = getMethod.Invoke(obj, new object[0]);
                if (value != null)
                {
                  if (n++ != 0)
                    sb.Append(ListSeparator);
                  sb.Append(prop.Name);
                  sb.Append(NameValueSeparator);
                  sb.Append(WriteEnumerable(value as IEnumerable, true));
                }
              }
            }
          }
          else
          {
            MethodInfo getMethod = prop.GetGetMethod();
            MethodInfo setMethod = prop.GetSetMethod();
            if (getMethod != null && setMethod != null)
            {
              ParameterInfo[] parameters = getMethod.GetParameters();
              if (parameters.Length == 0)
              {
                object value = getMethod.Invoke(obj, new object[0]);
                if (value != null)
                {
                  if (!(prop.Name == "Id" && value is String && (value as string) == "00000000"))
                  {
                    if (n++ != 0)
                      sb.Append(ListSeparator);
                    sb.Append(WritePropertyValue(prop, value));
                  }
                }
              }
            }
          }
        }
      }
      if (obj is IEnumerable)
      {
        if (n++!=0)
          sb.Append(ListSeparator);
        sb.Append(WriteEnumerable(obj as IEnumerable, true));
      }
      return sb.ToString();
    }

    /// <summary>
    /// Wypisanie wartości właściwości
    /// </summary>
    /// <param name="prop"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    private static string WritePropertyValue(PropertyInfo prop, object value)
    {
      StringBuilder sb = new StringBuilder();
      sb.Append(prop.Name);
      sb.Append(NameValueSeparator);
      Type propType = value.GetType();
      if (propType == typeof(string))
        sb.Append(WriteString((string)value));
      else if (propType.IsClass)
        sb.Append(WriteClassValue(prop, value));
      else
        sb.Append(value.ToString());
      return sb.ToString();
    }

    /// <summary>
    /// Wypisanie łańcucha. Pusty łańcuch jest wypisywany jako "()".
    /// Łańcuch zawierający nawiasy lub przecinek jest kodowany i również zamykany w nawiasach
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private static string WriteString(string str)
    {
      if (str == "")
        return "()";
      if (str.Contains(',') || str.Contains('(') || str.Contains('('))
        return "(" + EncodeString(str) + ")";
      else
        return str;
    }

    /// <summary>
    /// Wypisanie wartości typu obiektowego
    /// </summary>
    /// <param name="prop"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    private static string WriteClassValue(PropertyInfo prop, object value)
    {
      bool ok = false;
      StringBuilder sb = new StringBuilder();
      Type propType = prop.PropertyType;
      TypeConverterAttribute convAttr = (TypeConverterAttribute)propType.GetCustomAttribute(typeof(TypeConverterAttribute));
      if (convAttr != null && convAttr.ConverterTypeName!=null)
      {
        sb.Append(WriteWithConverter(convAttr.ConverterTypeName, value));
        ok = true;
      }
      if (!ok && value is IEnumerable)
      {
        sb.Append(WriteEnumerable(value as IEnumerable, true));
        ok = true;
      }
      if (!ok)
      {
        sb.Append(ListStartSeparator);
        sb.Append(ToString(value));
        sb.Append(ListEndSeparator);
      }
      return sb.ToString();
    }

    private static string WriteWithConverter(string convTypeName, object value)
    {
      StringBuilder sb = new StringBuilder();
      {
        convTypeName = convTypeName.Split(',')[0];
        Assembly ass = Assembly.GetExecutingAssembly();
        Type converterType = ass.GetType(convTypeName);
        if (converterType == null)
        {
          IEnumerable<Type> converterTypes = from item in ass.GetTypes() where item.FullName == convTypeName select item;
        }
        if (converterType != null)
        {
          TypeConverter converter = (TypeConverter)converterType.GetConstructor(new Type[0]).Invoke(new object[0]);
          string s = converter.ConvertToString(value);
          if (s.Contains(','))
          {
            sb.Append("(");
            sb.Append(s);
            sb.Append(")");
          }
          else
            sb.Append(s);
        }
      }
      return sb.ToString();
    }

    /// <summary>
    /// Sprawdzenie metody "ShouldSerialize..."
    /// </summary>
    /// <param name="obj">obiekt macierzysty właściwości</param>
    /// <param name="propName">nazwa właściwości</param>
    /// <returns></returns>
    private static bool TryInvokeShouldSerialize(object obj, string propName)
    {
      Type objectType = obj.GetType();
      MethodInfo method = objectType.GetMethod("ShouldSerialize" + propName);
      bool shouldSerialize = true;
      if (method != null)
        shouldSerialize = (bool)method.Invoke(obj, new object[0]);
      return shouldSerialize;
    }

    /// <summary>
    /// Konwersja listy elementów na łańcuch
    /// </summary>
    /// <param name="value"></param>
    /// <param name="enclose">czy zamknąć w nawiasach</param>
    /// <returns></returns>
    public static string WriteEnumerable (IEnumerable value, bool enclose = true)  
    {
      StringBuilder sb = new StringBuilder();
      sb.Append(FormatHelper.ListStartSeparator);
      int m = 0;
      foreach (object item in value as IEnumerable)
      {
        if (m++ != 0)
          sb.Append(ListSeparator);
        if (enclose)
          sb.Append(FormatHelper.ListStartSeparator);
        sb.Append(ToString(item));
        if (enclose)
          sb.Append(FormatHelper.ListEndSeparator);
      }
      sb.Append(FormatHelper.ListEndSeparator);
      return sb.ToString();
    }

    /// <summary>
    /// Próba konwersji obiektu z łańcucha
    /// </summary>
    /// <typeparam name="ObjectType"></typeparam>
    /// <param name="str"></param>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool TryParse<ObjectType>(string str, out ObjectType obj) where ObjectType: class
    {
      Type objectType = typeof(ObjectType);
      obj = null;
      object result;
      bool isList = false;
      bool ok = false;
      Type itemType = null;
      Type iList = typeof(ObjectType).GetInterface("IList`1", false);
      if (iList != null)
      {
        isList = true;
        itemType = iList.GenericTypeArguments[0];
      }
      if (isList)
      {
        if (str.StartsWith("(("))
        {
          ok = TryParseList(str, objectType, itemType, out result);
        }
        else
        {
          ok = TryParseListWithProperties(str, objectType, itemType, out result);
        }
      }
      else
      {
        ok = TryParse(str, typeof(ObjectType), out result);
      }
      if (ok)
        obj = (ObjectType)result;
      return ok;
    }


    /// <summary>
    /// Próba konwersji listy z właściwościami
    /// </summary>
    /// <param name="objectType"></param>
    /// <param name="itemType"></param>
    /// <param name="str"></param>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool TryParseListWithProperties (string str, Type objectType, Type itemType, out object obj)
    {
      obj = null;
      if (!TryCreateObject(objectType, out obj))
        return false;
      str  = str.TryTrimListSeparators();
      string[] ss = str.TrySplitList();
      StringBuilder sb = new StringBuilder();
      int n=0;
      foreach (string s in ss)
      {
        if (s.StartsWith("("))
        {
          if (!TryParse(sb.ToString(), objectType, out obj)) 
            return false;
          return TryParseListItems("("+s+")", objectType, itemType, ref obj);
        }
        if (n++ != 0)
          sb.Append(ListSeparator);
        sb.Append(s);
      } 
      return TryParse(str, objectType, out obj);
    }

    /// <summary>
    /// Próba konwersji listy z łańcucha
    /// </summary>
    /// <param name="ObjectType"></param>
    /// <param name="ItemType"></param>
    /// <param name="str"></param>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool TryParseList (string str, Type ObjectType, Type ItemType, out object obj)
    {
      obj = null;
      if (!TryCreateObject(ObjectType, out obj))
        return false;
      //str = str.TryTrimListSeparators();
      if (!TryParseListItems(str, ObjectType, ItemType, ref obj))
        return false;
      return obj != null;
    }

    /// <summary>
    /// Próba konwersji listy z łańcucha
    /// </summary>
    /// <param name="objectType"></param>
    /// <param name="itemType"></param>
    /// <param name="str"></param>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool TryParseListItems (string str, Type objectType, Type itemType, ref object obj)
    {
      string[] ss = str.TrySplitList();
      foreach (string s in ss)
      {
        object val;
        if (!InvokeTryParse(itemType, s, out val))
          return false;
        (obj as IList).Add(val);
      }
      return obj != null;
    }

    /// <summary>
    /// Próba utworzenia obiektu podanego typu
    /// </summary>
    /// <param name="objectType"></param>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool TryCreateObject(Type objectType, out object obj)
    {
      ConstructorInfo cons = objectType.GetConstructor(new Type[0]);
      obj = null;
      if (cons == null)
        return false;
      obj = cons.Invoke(new object[0]);
      return true;
    }

    /// <summary>
    /// Próba konwersji obiektu z łańcucha.
    /// </summary>
    /// <param name="objectType"></param>
    /// <param name="str"></param>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool TryParse(string str, Type objectType, out object obj)
    {
      obj = null;
      if (!TryCreateObject(objectType, out obj))
        return false;
      string[] ss = SplitList(str);
      foreach (string s in ss)
      {
        int k = s.IndexOf(NameValueSeparator);
        if (k<=0 || k>=s.Length-1)
          return false;
        string propName = s.Substring(0,k);
        string propValueStr = s.Substring(k + 1);
        PropertyInfo prop = objectType.GetProperty(propName);
        if (prop == null)
          return false;
        if (prop.GetCustomAttribute(typeof(XmlArrayAttribute)) != null)
        {
          MethodInfo getMethod = prop.GetGetMethod();
          if (getMethod == null)
            return false;
          object collection = getMethod.Invoke(obj, new object[0]);
          if (collection == null)
            return false;
          if (!(collection is IList))
            return false;
          XmlArrayItemAttribute itemAttr = (XmlArrayItemAttribute)prop.GetCustomAttribute(typeof(XmlArrayItemAttribute));
          if (itemAttr == null)
            return false;
          Type itemType = itemAttr.Type;
          if (itemType == null)
            return false;
          string[] ss2 = TrySplitList(propValueStr);
          foreach (string s2 in ss2)
          {
            object item;
            if (!TryParse(s2, itemType, out item))
              return false;
            (collection as IList).Add(item);
          }
        }
        else
        {
          MethodInfo setMethod = prop.GetSetMethod();
          if (setMethod == null)
            return false;
          object propValue = null;
          Type propType = prop.PropertyType;
          if (propType.Name == "Nullable`1")
          {
            propType = propType.GenericTypeArguments[0];
          }

          if (propType == typeof(int))
          {
            int n;
            if (!int.TryParse(propValueStr, out n))
              return false;
            propValue = n;
          }
          else if (propType == typeof(bool))
          {
            bool b;
            if (!bool.TryParse(propValueStr, out b))
              return false;
            propValue = b;
          }
          else if (propType == typeof(string))
          {
            if (propValueStr.StartsWith("(") && propValueStr.EndsWith(")"))
              propValue = DecodeString(propValueStr.Substring(1, propValueStr.Length - 2));
            else
              propValue = propValueStr;
          }
          else if (propType.IsEnum)
          {
            int n = -1;
            foreach (string env in propType.GetEnumNames())
            {
              n++;
              if (String.Compare(propValueStr, env, true) == 0)
                break;
            }
            if (n == -1)
              return false;
            propValue = propType.GetEnumValues().GetValue(n);
          }
          else if (propType.IsClass)
          {
            if (prop.Name == "Substitutes")
              Debug.Assert(true);

            bool ok = false;
            TypeConverterAttribute convAttr = (TypeConverterAttribute)propType.GetCustomAttribute(typeof(TypeConverterAttribute));
            if (convAttr!=null)
            {
              string convTypeName = convAttr.ConverterTypeName;
              if (convTypeName != null)
              {
                convTypeName = convTypeName.Split(',')[0];
                Assembly ass = Assembly.GetExecutingAssembly();
                Type converterType = ass.GetType(convTypeName);
                if (converterType==null)
                {
                  IEnumerable<Type> converterTypes = from item in ass.GetTypes() where item.FullName==convTypeName select item;
                }
                if (converterType != null)
                {
                  TypeConverter converter = (TypeConverter)converterType.GetConstructor(new Type[0]).Invoke(new object[0]);
                  propValue = converter.ConvertFromString(propValueStr.TryTrimListSeparators());
                  ok = propValue != null;
                }
              }
            }
            if (!ok)
            {
              IEnumerable<MethodInfo> methods = from item in propType.GetMethods(BindingFlags.Public | BindingFlags.Static) where item.Name == "TryParse" select item;
              foreach (MethodInfo method in methods)
              {
                ParameterInfo[] parameters = method.GetParameters();
                if (parameters.Length == 3 && parameters[0].ParameterType == typeof(string)
                                 && parameters[1].ParameterType == typeof(IFormatProvider))
                {
                  object[] arguments = new object[] { propValueStr, CultureInfo.InvariantCulture, null };
                  if (!(bool)method.Invoke(null, arguments))
                    return false;
                  propValue = arguments[2];
                  ok = true;
                  break;
                }
              }
              if (!ok)
                foreach (MethodInfo method in methods)
                {
                  ParameterInfo[] parameters = method.GetParameters();
                  if (parameters.Length == 2 && parameters[0].ParameterType == typeof(string))
                  {
                    object[] arguments = new object[] { propValueStr, null };
                    if (!(bool)method.Invoke(null, arguments))
                      return false;
                    propValue = arguments[1];
                    ok = true;
                    break;
                  }
                }
              if (!ok)
              {
                propValueStr = propValueStr.TryTrimListSeparators();
                if (!TryParse(propValueStr, propType, out propValue))
                  return false;
              }
            }
          }
          else
            return false;
          setMethod.Invoke(obj, new object[] { propValue });
        }
      }
      return true;
    }

    /// <summary>
    /// Wywołanie statycznej metody "TryParse" z podanego typu
    /// </summary>
    /// <param name="ObjectType"></param>
    /// <param name="propValueStr"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool InvokeTryParse(Type ObjectType, string propValueStr, out object value) 
    {
      bool ok = false;
      value = null;
      IEnumerable<MethodInfo> methods = from item in ObjectType.GetMethods(BindingFlags.Public | BindingFlags.Static) where item.Name == "TryParse" select item;
      foreach (MethodInfo method in methods)
      {
        ParameterInfo[] parameters = method.GetParameters();
        if (parameters.Length == 3 && parameters[0].ParameterType == typeof(string)
                          && parameters[1].ParameterType == typeof(IFormatProvider))
        {
          object[] arguments = new object[] { propValueStr, CultureInfo.InvariantCulture, null };
          if (!(bool)method.Invoke(null, arguments))
            return false;
          value = arguments[2];
          ok = true;
          break;
        }
      }
      if (!ok)
        foreach (MethodInfo method in methods)
        {
          ParameterInfo[] parameters = method.GetParameters();
          if (parameters.Length == 2 && parameters[0].ParameterType == typeof(string))
          {
            object[] arguments = new object[] { propValueStr, null };
            if (!(bool)method.Invoke(null, arguments))
              return false;
            value = arguments[1];
            ok = true;
            break;
          }
        }
      return ok;
    }

    /// <summary>
    /// Zakodowanie łańcucha zawierającego '(', ')' lub '\'
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string EncodeString(string s)
    {
      StringBuilder sb = new StringBuilder();
      foreach (char ch in s)
      {
        if (ch == '(' || ch == ')' || ch == '\\')
          sb.Append('\\');
        sb.Append(ch);
      }
      return sb.ToString();
    }

    /// <summary>
    /// Zakodowanie łańcucha zawierającego '(', , ')' lub '\'
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string DecodeString (string s)
    {
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i< s.Length; i++)
      {
        char ch = s[i];
        if (ch == '\\' && i<s.Length-1)
        {
          ch = s[i + 1];
          if (ch == '(' || ch == ')' || ch == '\\')
          {
            sb.Append(ch);
            i++;
            continue;
          }
        }
        sb.Append(ch);
      }
      return sb.ToString();
    }

    /// <summary>
    /// Pobranie pierwszego wyrazu z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string GetFirstWord(ref string str)
    {
      if (String.IsNullOrEmpty(str))
        return null;
      string result;
      int k = str.IndexOf(' ');
      if (k < 0)
      {
        result = str;
        str = null;
      }
      result = str.Substring(0, k);
      if (k < str.Length)
        str = str.Substring(k + 1).TrimStart();
      else
        str = null;
      return result;
    }
  }
}
