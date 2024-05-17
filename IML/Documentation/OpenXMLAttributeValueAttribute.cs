using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Atrybut używany dla oznaczenia wartości atrybutu w pliku OpenXML
  /// </summary>
  [AttributeUsage (AttributeTargets.Field, AllowMultiple=false)]
  public partial class OpenXMLAttributeValueAttribute: Attribute
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    /// <param name="value"></param>
    public OpenXMLAttributeValueAttribute(string value)
    {
      Value = value;
    }
    /// <summary>
    /// Wartość tekstowa atrybutu
    /// </summary>
    public string Value { get; private set; }
  }
}
