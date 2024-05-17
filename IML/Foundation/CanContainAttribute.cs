using System;

namespace Iml.Foundation
{
  /// <summary>
  /// Klasa atrybutu umożliwiająca określenie, jakie inne elementy semantyczne
  /// może zawierać dany element semantyczny. Określenie to obejmuje: 
  /// klasę zawieranego elementu, stereotyp zawieranego elementu, semantykę zawartości (rolę),
  /// grupę elementów (przedział tabelki definicji) oraz atrybuty wymagalności
  /// (dziedziczone z klasy <see cref="ImlSemanticAttribute"/>).
  /// Pozostałe atrybuty są przeniesione z definicji UML.
  /// Relacja semantyczna określana przez tę klasę atrybutu jest relacją przeciwną
  /// do relacji określanej przez <see cref="CanBelongToAttribute"/>
  /// </summary>
  public partial class CanContainAttribute: ImlSemanticAttribute 
  {
    /// <summary>
    /// Konstruktor określający tylko klasę zawieranego elementu
    /// </summary>
    /// <param name="type">klasa elementu semantycznego</param>
    public CanContainAttribute(Type type)
    {
      Type = type;
    }

    /// <summary>
    /// Nazwa grupy
    /// </summary>
    public string GroupName { get; set; }

    /// <summary>
    /// Akceptowalna klasa elementu semantycznego
    /// </summary>
    public Type Type { get; set; }

    /// <summary>
    /// Akceptowalny stereotyp elementu semantycznego
    /// </summary>
    public string Stereotype { get; set; }

    /// <summary>
    /// Semantyka zawartości (rola składnika)
    /// </summary>
    public string Semantics { get; set; }

    /// <summary>
    /// Semantyka referencji wstecznej
    /// </summary>
    public String BackwardSemantics { get; set; }

  }
}
