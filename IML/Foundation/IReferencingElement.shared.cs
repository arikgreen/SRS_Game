using System.Collections.Generic;
using System;

namespace Iml.Foundation
{
  /// <summary>
  /// Interfejs, który musi implementować element, 
  /// który ma się odwoływać do innych elementów.
  /// </summary>
  public interface IReferencingElement: IDisposable
  {
    /// <summary>
    /// Umożliwia odwołanie się do obiektu, który implementuje interfejs
    /// </summary>
    Object Instance { get; }

    /// <summary>
    /// Element powinien rejestrować referencje wychodzące do innych elementów. 
    /// </summary>
    /// <param name="aReference">Referencja wychodząca do innego obiektu</param>
    void AddOutgoingReference(Reference aReference);

    /// <summary>
    /// Element powinien umożliwiać usunięcie referencji wychodzącej do innego elementu. 
    /// </summary>
    /// <param name="aReference">Referencja wychodząca do innego obiektu</param>
    void RemoveOutgoingReference(Reference aReference);

    /// <summary>
    /// Element powinien umożliwiać usunięcie wszystkich referencji. 
    /// </summary>
    void ClearReferences();

    /// <summary>
    /// Element powinien sprawdzać, czy w ogóle ma referencje
    /// </summary>
    bool HasReferences { get; }

    /// <summary>
    /// Jeśli element ma referencje, to powinien podawać ich listę.
    /// </summary>
    /// <returns></returns>
    IEnumerable<Reference> GetOutgoingReferences();

    /// <summary>
    /// Element powinien sprawdzać, czy ma nierozwiązane referencje
    /// </summary>
    bool HasUnresolvedReferences { get; }

    /// <summary>
    /// Jeśli element ma nierozwiązane referencje, to powinien umożliwiać ich rozwiązanie
    /// </summary>
    /// <param name="referencedItems">Lista elementów, które będą przeglądane dla rozwiązania referencji</param>
    void ResolveReferences(IEnumerable<Element> referencedItems);

  }
}
