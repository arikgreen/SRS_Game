using System;

namespace Iml.Foundation
{
  /// <summary>
  /// Klasa atrybutu umożliwiająca oznaczenie jakiej klasy elementy mogą być elementami bazowymi dla danej klasy elementów.
  /// </summary>
  [AttributeUsage(AttributeTargets.Class, AllowMultiple=true,Inherited = true)]
  public partial class FoundationAttribute: Attribute 
  {

    /// <summary>
    /// Konstruktor domyślny - musi być podany typ bazowy (założenie).
    /// Założenie domyślnie jest wymagane.
    /// </summary>
    public FoundationAttribute(Type foundationType)
    {
      FoundationType = foundationType;
      Required = true;
    }

    /// <summary>
    /// Typ bazowy
    /// </summary>
    public Type FoundationType { get; set; }

    /// <summary>
    /// Faza projektowa, od której założenie jest wymagane
    /// (0 - nie jest wymagane)
    /// </summary>
    public int RequiredFrom { get; set; }

    /// <summary>
    /// Czy założenie jest wymagane
    /// </summary>
    public bool Required
    {
      get { return RequiredFrom > 0; }
      set { RequiredFrom = (value) ? 1 : 0; }
    }

  }
}
