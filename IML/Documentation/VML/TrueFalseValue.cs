using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.VML
{
  /// <summary>
  /// Klasa VML reprezentująca wartość logiczną i rozpoznająca wartości "t" i "f"
  /// </summary>
  public partial class TrueFalseValue
  {
    /// <summary>
    /// Przehowywana wartość logiczna
    /// </summary>
    protected bool Value { get; set; }

    /// <summary>
    ///  Niejawna konwersja na typ bool
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator bool (TrueFalseValue value)
    {
      return value.Value;
    }

    /// <summary>
    /// Niejawna konwersja z typu bool
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator TrueFalseValue (bool value)
    {
      return new TrueFalseValue { Value = value };
    }

    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      if (Value == true)
        return "t";
      if (Value == false)
        return "f";
      return null;
    }

    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static TrueFalseValue Parse (string str)
    {
      TrueFalseValue val;
      if (TryParse(str, out val))
        return val;
      throw new FormatException(String.Format("Can't convert string \"{0}\" to a TrueFalseValue", str));
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse(string str, out TrueFalseValue result)
    {
      if (String.Compare(str, "t", true) == 0)
      {
        result = true;
        return true;
      }
      if (String.Compare(str, "f", true) == 0)
      {
        result = false;
        return true;
      }
      if (String.Compare(str, "true", true) == 0)
      {
        result = true;
        return true;
      }
      if (String.Compare(str, "false", true) == 0)
      {
        result = false;
        return true;
      }
      if (String.Compare(str, "on", true) == 0)
      {
        result = true;
        return true;
      }
      if (String.Compare(str, "off", true) == 0)
      {
        result = false;
        return true;
      }
      if (String.Compare(str, "1", true) == 0)
      {
        result = true;
        return true;
      }
      if (String.Compare(str, "0", true) == 0)
      {
        result = false;
        return true;
      }
      result = null;
      return false;
    }
  }
}
