using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Lista elementów rysunku
  /// </summary>
  public partial class DrawingItemList: ItemList<DrawingItem>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public DrawingItemList () : base() { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public DrawingItemList(Item owner): base(owner){}
  }
}
