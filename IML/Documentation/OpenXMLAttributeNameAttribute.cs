using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Atrybut używany dla oznaczenia nazwy atrybutu w pliku OpenXML
  /// </summary>
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
  public partial class OpenXMLAttributeNameAttribute : Attribute
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    /// <param name="name">nazwa atrybutu</param>
    /// <param name="type">nazwa typu atrybutu</param>
    /// <param name="order">opcjonalna kolejność atrybutu</param>
    public OpenXMLAttributeNameAttribute (string name, string type, int order=0)
    {
      Name = name;
      Type = type;
      Order = order;
    }
    /// <summary>
    /// Nazwa atrybutu
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Typ wartości wg specyfikacji OpenXML
    /// </summary>
    public string Type { get; private set; }

    /// <summary>
    /// Kolejność atrybutu (jeśli określona)
    /// </summary>
    public int Order { get; private set; }
  }
}
