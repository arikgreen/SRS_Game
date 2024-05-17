using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Stereotyping
{
  /// <summary>
  /// Oznaczenie właściwości dodawanej przez stereotyp
  /// </summary>
  [AttributeUsage(AttributeTargets.Field, Inherited=true, AllowMultiple=true)]
  public partial class AddedPropertyAttribute: Attribute
  {
    /// <summary>
    /// Nazwa właściwości - pod taką nazwą zapisywane są dane w słowniku <see cref="AccessProperty"/>
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Typ właściwości
    /// </summary>
    public Type Type { get; set; }
    /// <summary>
    /// Nazwa właściwości typu <c>Dictionary&lt;string,object&gt;</c>. 
    /// Klucz kolekcji jest nazwą dodanej właściwości.
    /// Wartość jest typu podanego przez <see cref="Type"/>
    /// </summary>
    public string AccessProperty { get; set; }
  }
}
