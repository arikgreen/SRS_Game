using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
  public partial class VariantValue
  {
    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <param name="type">oczekiwany typ elementu </param>
    /// <returns></returns>
    public new static VariantValue Parse (string str, ValueType type)
    {
      VariantValue result;
      if (TryParse(str, type, out result))
        return result;
      throw new FormatException(String.Format("Cannot parse VectorValue from string \"{0}\"", str));
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <param name="value"></param>
    /// <param name="itemType">oczekiwany typ elementu</param>
    /// <returns></returns>
    public static bool TryParse (string str, ValueType itemType, out VariantValue value)
    {
      value = null;
      int k = str.IndexOf('(');
      if (k>=0)
      {
        string s = str.Substring(0, k);
        str = str.Substring(k + 1, str.Length - k - 2);
        ValueType type;
        if (!String.IsNullOrEmpty(s))
        {
          if (!ValueType.TryParse(s, out type))
            return false;
          else
            itemType = type;
        }
        Value val;
        if (!Value.TryParse(str, itemType, out val))
          return false;
        value = new VariantValue { Type = ValueTypes.Variant, Content = val };
        return true;
      }
      return false;
    }

    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return Content.Type.ToString() + "(" + Content.ToString() + ")";
    }
  }
}
