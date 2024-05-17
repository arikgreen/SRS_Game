using System.Collections.Generic;
using System.Linq;

namespace Iml.Foundation
{
  /// <summary>
  /// Lista elementów semantycznych.
  /// Potrafi rozwiązać referencje swoich elementów.
  /// </summary>
  public partial class SemanticElements: ElementList<SemanticElement>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public SemanticElements()
    { }

    /// <summary>
    /// Konstruktor właściwy dla listy elementów
    /// </summary>
    /// <param name="owner"></param>
    public SemanticElements(object owner): base(owner) { }

    /// <summary>
    /// Rozwiązanie referencji elementów składowych
    /// </summary>
    /// <param name="referencedItems">przeglądana lista elementów</param>
    public void ResolveReferences(IEnumerable<IReferencedElement> referencedItems)
    {
      foreach (SemanticElement aElement in referencedItems)
      {
        if (aElement.HasUnresolvedReferences)
        {
          aElement.ResolveReferences(this);
        }
      }
    }

    /// <summary>
    /// Przepisanie identyfikatorów ID z innej listy.
    /// Skojarzenie następuje wg <c>RefID</c>.
    /// Jeśli nie da rady, to wg kolejności
    /// </summary>
    public override void MergeIDs(ElementList<SemanticElement> otherList)
    {
      bool done = false;
      for (int i = 0; i < Count; i++)
      {
        SemanticElement thisItem = this[i];
        SemanticElement otherItem = (from item in otherList
                                     where item.RefID!=null && item.RefID == thisItem.RefID
                                     select item).FirstOrDefault();
        if (otherItem != null)
        {
          thisItem.MergeID(otherItem);
          done = true;
        }
      }
      if (!done && Count>0)
        base.MergeIDs(otherList);
    }

    /// <summary>
    /// Przepisanie identyfikatorów referencji z innej listy.
    /// Skojarzenie następuje wg <c>RefID</c>.
    /// Musi być wywołane po <c>MergeIDs</c>
    /// </summary>
    public void MergeReferences(SemanticElements otherList)
    {
      for (int i = 0; i < Count; i++)
      {
        SemanticElement thisItem = this[i];
        SemanticElement otherItem = (from item in otherList
                                     where item.RefID == thisItem.RefID
                                     select item).FirstOrDefault();
        if (otherItem != null)
          thisItem.MergeReferences(otherItem);
      }
    }

  }
}
