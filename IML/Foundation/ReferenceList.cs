using System.Linq;

namespace Iml.Foundation
{
  /// <summary>
  /// Lista referencji. Redefiniuje operacje na identyfikatorach
  /// </summary>
  public partial class ReferenceList: ElementList<Reference>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public ReferenceList()
    { }

    /// <summary>
    /// Konstruktor właściwy dla listy elementów
    /// </summary>
    /// <param name="aOwner"></param>
    public ReferenceList(Element aOwner) : base(aOwner) { }

    /// <summary>
    /// Przepisanie identyfikatorów referencji z innej listy.
    /// Skojarzenie następuje wg <c>Semantics</c>, <c>TargetID</c> i <c>Subreference</c>.
    /// </summary>
    public override void MergeIDs(ElementList<Reference> otherList)
    {
      for (int i = 0; i < Count; i++)
      {
        Reference thisItem = this[i];
        Reference otherItem = (from item in otherList
                               where item.Equals(thisItem)
                               select item).FirstOrDefault();
        if (otherItem != null)
          thisItem.MergeID(otherItem);
      }
    }
  }
}
