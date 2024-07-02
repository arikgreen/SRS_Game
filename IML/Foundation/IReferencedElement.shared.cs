using System;
using System.Collections.Generic;

namespace Iml.Foundation
{
  /// <summary>
  /// Interfejs, który musi implementować element, do którego 
  /// inne elementy będą się mogły odwoływać.
  /// </summary>
  public interface IReferencedElement: IDisposable
  {
    /// <summary>
    /// Umożliwia odwołanie się do obiektu, który implementuje interfejs
    /// </summary>
    Object Instance { get; }

    /// <summary>
    /// Element powinien mieć unikatowy identyfikator,
    /// który służy do rozwiązywania referencji.
    /// </summary>
    Guid ID { get; }

    /// <summary>
    /// Element powinien mieć identyfikator referencyjny,
    /// który służy do rozwiązywania referencji wówczas,
    /// gdy zawodzi identyfikator unikatowy.
    /// </summary>
    string RefID { get; }

    /// <summary>
    /// Element powinien mieć nazwę, 
    /// która służy do rozwiązywania referencji wówczas, 
    /// gdy zawodzi identyfikator referencyjny.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Element powinien rejestrować referencje przychodzące. 
    /// </summary>
    /// <param name="aReference">Referencja przychodząca do obiektu</param>
    void AddIncomingReference(Reference aReference);

    /// <summary>
    /// Element powinien umożliwiać usunięcie referencji przychodzącej. 
    /// </summary>
    /// <param name="aReference">Referencja przychodząca do obiektu</param>
    void RemoveIncomingReference(Reference aReference);

    /// <summary>
    /// Element powinien umożliwiać usunięcie wszystkich referencji. 
    /// </summary>
    void ClearReferences();

    /// <summary>
    /// Czy do danego elementu są referencje?
    /// </summary>
    bool IsReferenced { get; }

    /// <summary>
    /// Element powinien określać, czy ma elementy składowe. 
    /// </summary>
    bool HasItems { get; }

    /// <summary>
    /// Jeśli element ma elementy składowe, to powinien podawać ich listę.
    /// </summary>
    IEnumerable<Element> GetItems();
  }
}
