using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IML = Iml.Documentation;

namespace Iml.Documentation
{
  /// <summary>
  /// Schemat kolorów
  /// </summary>
  public partial class ColorScheme: NamedItemIndex<ColorDef>  
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public ColorScheme(){}

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public ColorScheme (object owner) : base(owner) { }

    /// <summary>
    /// Dodawanie elementu do indeksu
    /// </summary>
    /// <param name="item"></param>
    public override void Add (ColorDef item)
    {
      Add(item.Name, item);
    }
  }
}
