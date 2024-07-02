using System;

namespace Iml.Foundation
{
  /// <summary>
  /// Klasa atrybutu umożliwiająca określenie, do jakich innych elementów semantycznych
  /// może odwoływać się dany element semantyczny przez referencję. Określenie to obejmuje: 
  /// klasę wskazywanego elementu, stereotyp wskazywanego elementu, semantykę referencji (rolę wskazywanego elementu),
  /// grupę referencji (przedział tabelki definicji) oraz atrybuty wymagalności.
  /// Pozostałe atrybuty są przeniesione z definicji UML.
  /// </summary>
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple=true,Inherited = true)]
  public partial class CanReferToAttribute: ImlSemanticAttribute 
  {
    /// <summary>
    /// Konstruktor określający klasę wskazanego elementu. Pozostałe właściwości atrybutu definiowane przez nazwy.
    /// </summary>
    /// <param name="type">klasa wskazanego elementu semantycznego</param>
    public CanReferToAttribute(Type type)
    {
      Type = type;
    }

    private string groupName;
    /// <summary>
    /// Nazwa grupy, do której należy dana referencja
    /// </summary>
    public string GroupName 
    {
      get
      {
        if (groupName != null)
          return groupName;
        if (Semantics != null)
          return Semantics;
        if (Stereotype != null)
          return Semantics;
        return "";
      }

      set { groupName = value; }
    }

    /// <summary>
    /// Akceptowalna klasa elementu wskazywanego
    /// </summary>
    public Type Type { get; set; }

    /// <summary>
    /// Akceptowalny stereotyp elementu wskazywanego
    /// </summary>
    public string Stereotype { get; set; }

    /// <summary>
    /// Semantyka referencji
    /// </summary>
    public string Semantics { get; set; }
    /// <summary>
    /// Semantyka referencji wstecznej
    /// </summary>
    public String BackwardSemantics { get; set; }

  }
}
