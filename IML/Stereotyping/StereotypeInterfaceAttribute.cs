using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Stereotyping
{
  /// <summary>
  /// Referencja do interfejsu opisującego stereotyp dla określonej wartości typu wyliczeniowego
  /// </summary>
  [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
  public partial class StereotypeInterfaceAttribute : Attribute
  {
    /// <summary>
    /// Typ interfejsowy
    /// </summary>
    public Type Type { get; set; }
  }
}
