using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Typ stylu
  /// </summary>
  public enum StyleType
  {
    /// <summary>
    /// Nieznany typ stylu
    /// </summary>
    unknown = 0,
    /// <summary>
    /// Styl akapitu
    /// </summary>
    //[OpenXMLAttributeValue ("paragraph")]
    Paragraph = 1,
    /// <summary>
    /// Styl tekstu
    /// </summary>
    //[OpenXMLAttributeValue("character")]
    Character = 2,
    /// <summary>
    /// Styl tabeli
    /// </summary>
    //[OpenXMLAttributeValue("table")]
    Table = 3,
    /// <summary>
    /// Styl listy numerowanej
    /// </summary>
    //[OpenXMLAttributeValue("numbering")]
    List = 4,
    /// <summary>
    /// Styl tylko akapitu (do użytku wewnętrznego WORDA)
    /// </summary>
    ParagraphOnly = 5,
    /// <summary>
    /// Styl połączony akapitu i tekstu (do użytku wewnętrznego WORDA)
    /// </summary>
    Linked = 6,
    /// <summary>
    /// Styl odnosi się do grafiki
    /// </summary>
    Graphics = 7
  }
}
