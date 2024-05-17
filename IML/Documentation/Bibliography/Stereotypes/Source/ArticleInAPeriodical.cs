using Iml.Stereotyping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Bibliography
{
  /// <summary>
  /// Interfejs stereotypu "ArticleInAPeriodical" dla typu <see cref="Source"/>
  /// </summary>
  public interface ArticleInAPeriodical
  {
    /// <summary>
    /// *Autorzy 
    ///</summary>
    [Required]
    Authors Authors { get; }
    /// <summary>
    /// *Tytuł 
    /// </summary>
    [Required]
    string Title { get; set; }
    /// <summary>
    /// *Tytuł czasopisma
    /// </summary>
    [Required]
    string PeriodicalTitle { get; set; }
    /// <summary>
    /// *Rok
    /// </summary>     
    [Required]
    string Year { get; set; }
    /// <summary>
    /// Miesiąc
    /// </summary>     
    string Month { get; set; }
    /// <summary>
    /// Dzień
    /// </summary>     
    string Day { get; set; }
    /// <summary>
    /// Miasto
    /// </summary>
    string City { get; set; }
    /// <summary>
    /// Wydawca
    /// </summary>
    string Publisher { get; set; }
    /// <summary>
    /// Redaktor
    /// </summary>
    Authors Editor { get; set; }
    /// <summary>
    /// Wydanie 
    /// </summary>
    string Edition { get; set; }
    /// <summary>
    /// Tom
    /// </summary>
    string Volume { get; set; }
    /// <summary>
    /// Numer
    /// </summary>
    string Issue { get; set; }
    /// <summary>
    /// *Strony
    /// </summary>
    [Required]
    string Pages { get; set; }
    /// <summary>
    /// Krótki tytuł
    /// </summary>
    string ShortTitle { get; set; }
    /// <summary>
    /// Numer standardowy (ISBN lub ISSN)
    /// </summary>
    string StandardNumber { get; set; }
    /// <summary>
    /// Komentarze
    /// </summary>
    string Comments { get; set; }

  }
}

