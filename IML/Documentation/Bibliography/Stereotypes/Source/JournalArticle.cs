using Iml.Stereotyping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Bibliography
{
  /// <summary>
  /// Interfejs stereotypu "JournalArticle" dla typu <see cref="Source"/>
  /// </summary>
  public interface JournalArticle
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
    /// *Nazwa magazynu
    /// </summary>
    [Required]
    string JournalName { get; set; }
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
    /// *Miasto
    /// </summary>
    [Required(false)]
    string City { get; set; }
    /// <summary>
    /// *Wydawca
    /// </summary>
    [Required]
    string Publisher { get; set; }
    /// <summary>
    /// Redaktor
    /// </summary>
    Authors Editor { get; set; }
    /// <summary>
    /// Tom, 
    /// </summary>
    [Required(false)]
    string Volume { get; set; }
    /// <summary>
    /// Wydanie
    /// </summary>
    [Required(false)]
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

