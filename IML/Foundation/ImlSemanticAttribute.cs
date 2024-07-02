using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Foundation
{
  /// <summary>
  /// Abstrakcyjna klasa atrybutów dla elementów IML opisująca ich cechy semantyczne.
  /// Definiuje pola określające kiedy dana cecha elementu jest dozwolona, a kiedy jest wymagana.
  /// Definiuje też metaatrybuty przeniesione z definicji UML
  /// </summary>
  [AttributeUsage (AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
  public abstract class ImlSemanticAttribute : Attribute
  {
    /// <summary>
    /// Faza projektowa, od której cecha jest dozwolona
    /// (0 - zawsze)
    /// </summary>
    public int AllowedFrom { get; set; }


    /// <summary>
    /// Czy cecha jest dozwolona (umożliwia wyłączenie cechy dozwolonej w klasie nadrzędnej w hierarchii dziedziczenia)
    /// </summary>
    public bool Allowed
    {
      get { return AllowedFrom == 0; }
      set { AllowedFrom = (value) ? 0 : Int32.MaxValue; }
    }

    /// <summary>
    /// Faza projektowa, od której cecha jest wymagana
    /// (0 - nie jest wymagana)
    /// </summary>
    public int RequiredFrom { get; set; }

    /// <summary>
    /// Czy cecha jest wymagana
    /// </summary>
    public bool Required
    {
      get { return RequiredFrom > 0; }
      set { RequiredFrom = (value) ? 1 : 0; }
    }

    /// <summary>
    /// Definiuje kolejność wyświetlania cechy w interfejsie użytkownika
    /// </summary>
    public int DisplayOrder { get; set; }

    #region atrybuty przeniesione z UML

    /// <summary>
    /// Dany zbiór właściwości może stanowić podzbiór innych właściwości
    /// </summary>
    public string Subsets { get; set; }

    /// <summary>
    /// Zbiór właściwości tworzy unię z innych zbiorów
    /// </summary>
    public bool Union { get; set; }

    /// <summary>
    /// Właściwość jest tylko do czytania
    /// </summary>
    public bool Readonly { get; set; }

    /// <summary>
    /// Zbiór instancji właściwości jest uporządkowany
    /// </summary>
    public bool Ordered { get; set; }

    /// <summary>
    /// Liczba dozwolonych instancji właściwości
    /// </summary>
    public String Multiplicity { get; set; }

    #endregion
  }
}
