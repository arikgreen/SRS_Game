using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Iml.Foundation
{
  /// <summary>
  /// Interfejs, który musi implementować element, który ma nazwę
  /// </summary>
  public interface INamedElement
  {
    /// <summary>
    /// Element powinien mieć nazwę, która może być różna w różnych językach 
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Nazwa "przyjazna" może być tożsama z nazwą "zwykłą" a może być lepiej sformatowana
    /// </summary>
    string DisplayName { get; }

    /// <summary>
    /// Element powinien mieć identyfikator języka, w którym aktualnie jest prezentowana nazwa elementu
    /// </summary>
    string Language { get; }
  }
}
