using Iml.Foundation;
using System.Windows.Markup;
using System;

namespace Iml.Documentation
{

  /// <summary>
  /// Lista elementów klasy <see cref="Block"/>
  /// </summary>
  //[ContentWrapper (typeof (Run))]
  //[WhitespaceSignificantCollection]
  //[ContentWrapper (typeof (Block))]
  public partial class BlockList : ItemList<Block>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public BlockList() { }

    /// <summary>
    /// Konstruktor właściwy dla listy elementów.
    /// </summary>
    /// <param name="owner"></param>
    public BlockList(object owner) : base(owner) { }

    /// <summary>
    /// Obiekt właścicielski musi być typu <c>Element</c>
    /// </summary>
    public new Element Owner 
    {
      get { return (Element)base.Owner; }
    }
  }
}
