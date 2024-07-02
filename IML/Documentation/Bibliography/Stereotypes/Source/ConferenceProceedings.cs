using Iml.Stereotyping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Bibliography
{
  /// <summary>
  /// Interfejs stereotypu "ConferenceProceedings" dla typu <see cref="Source"/>
  /// </summary>
  public interface ConferenceProceedings
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
    /// *Nazwa konferencji
    /// </summary>
    [Required]
    string ConferenceName { get; set; }
    /// <summary>
    /// *Rok
    /// </summary>     
    [Required]
    string Year { get; set; }
    /// <summary>
    /// Miasto
    /// </summary>
    [Required]
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
    /// Tom
    /// </summary>
    string Volume { get; set; }
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


