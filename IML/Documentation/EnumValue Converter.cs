using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Utils
{
  /// <summary>
  /// Klasa do prostej konwersji z jednego typu wyliczeniowego do drugiego
  /// </summary>
  public static class EnumValueConverter
  {
    /// <summary>
    /// Prosta konwersja przez nazwę.
    /// </summary>
    /// <typeparam name="NewEnumType"></typeparam>
    /// <param name="Value"></param>
    /// <returns></returns>
    public static NewEnumType ToEnum<NewEnumType> (this object Value) where NewEnumType: struct 
    {
      NewEnumType val;
      if (Enum.TryParse<NewEnumType>(Value.ToString(), out val))
        return val;
      throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"{1}\" type", Value, typeof(NewEnumType).Name));
    }  
  }
}
