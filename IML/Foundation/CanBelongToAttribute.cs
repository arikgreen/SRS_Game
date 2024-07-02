using System;

namespace Iml.Foundation
{
  /// <summary>
  /// Klasa atrybutu umożliwiająca określenie, jakie inne elementy semantyczne
  /// mogą zawierać dany element semantyczny. Określenie to obejmuje: 
  /// klasę zawieranego elementu, stereotyp zawieranego elementu, semantykę zawartości (rolę),
  /// grupę elementów (przedział tabelki definicji) oraz atrybuty wymagalności 
  /// (dziedziczone z klasy <see cref="ImlSemanticAttribute"/>).
  /// Relacja semantyczna określana przez tę klasę atrybutu jest relacją przeciwną
  /// do relacji określanej przez <see cref="CanContainAttribute"/>
  /// </summary>
  public partial class CanBelongToAttribute: ImlSemanticAttribute 
  {
    /// <summary>
    /// Konstruktor określający tylko klasę zawierającego elementu
    /// </summary>
    /// <param name="type">klasa elementu semantycznego</param>
    public CanBelongToAttribute(Type type)
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
