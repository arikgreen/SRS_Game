using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Foundation
{
  /// <summary>
  /// Lista elementów z referencjami wychodzącymi. Definiuje operacje rozwiązywania referencji
  /// </summary>
  /// <typeparam name="itemType">typ elementu</typeparam>
  public partial class ReferencingElementList<itemType>: ElementList<itemType> where itemType: Element
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public ReferencingElementList() { }

    /// <summary>
    /// Konstruktor właściwy dla listy elementów.
    /// </summary>
    /// <param name="aOwner"></param>
    public ReferencingElementList(Object aOwner) : base(aOwner) { }

    /// <summary>
    /// Uogólniona metoda rozwiązania referencji we wszystkich elementach składowych
    /// </summary>
    /// <param name="items">lista elementów, do których następują referencje</param>
    public void ResolveReferences (IEnumerable<Element> items)
    {
      foreach (itemType element in this)
        if (element is IReferencingElement)
          (element as IReferencingElement).ResolveReferences (items);
    }
  }
}
