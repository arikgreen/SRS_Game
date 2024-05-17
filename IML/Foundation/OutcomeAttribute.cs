using System;

namespace Iml.Foundation
{
  /// <summary>
  /// Klasa atrybutu umożliwiająca oznaczenie jakiej klasy elementy mogą być rozwiązaniem dla danej klasy elementów bazowych
  /// </summary>
  [AttributeUsage(AttributeTargets.Class, AllowMultiple=true,Inherited = true)]
  public partial class OutcomeAttribute: Attribute 
  {

    /// <summary>
    /// Konstruktor domyślny - musi być podany typ rozwiązania,
    /// rozwiązanie domyślnie jest wymagane
    /// </summary>
    public OutcomeAttribute(Type outcomeType)
    {
      OutcomeType = outcomeType;
      Required = true;
    }

    /// <summary>
    /// Typ rozwiązania
    /// </summary>
    public Type OutcomeType { get; set; }

    /// <summary>
    /// Faza projektowa, od której rozwiązanie jest wymagane
    /// (0 - nie jest wymagane)
    /// </summary>
    public int RequiredFrom { get; set; }

    /// <summary>
    /// Czy zawartość jest wymagana
    /// </summary>
    public bool Required
    {
      get { return RequiredFrom > 0; }
      set { RequiredFrom = (value) ? 1 : 0; }
    }
  }
}
