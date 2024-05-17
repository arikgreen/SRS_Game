using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
  public partial class ValueType
  {
    /// <summary>
    /// Niejawna konwersja z typu wyliczeniowego
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static implicit operator ValueType(ValueTypes type)
    {
      return new ValueType { Type = type };
    }

    /// <summary>
    /// Niejawna konwersja na typ wyliczeniowy
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator ValueTypes (ValueType value)
    {
      return value.Type;
    }
  }
}
