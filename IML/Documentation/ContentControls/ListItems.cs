using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Lista elementów listy wyboru
  /// </summary>
  public partial class ListItems: ItemList<ListItem>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public ListItems () { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public ListItems (Item owner) : base(owner) { }

    ///// <summary>
    ///// Wartość domyślna
    ///// </summary>
    //public string DefaultValue { get; set; }

    ///// <summary>
    ///// Czy lista jest pusta. Sprawdza <see cref="DefaultValue"/>
    ///// </summary>
    ///// <returns></returns>
    //public override bool IsEmpty ()
    //{
    //  return DefaultValue == null && base.IsEmpty();
    //}
  }
}
