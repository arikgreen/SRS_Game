using Iml.Stereotyping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Bibliography
{
  /// <summary>
  /// Interfejs stereotypu "Case" dla typu <see cref="Source"/>
  /// </summary>
  public interface Case
  {
    /// <summary>
    /// Autorzy 
    ///</summary>
    [Required(false)]
    Authors Authors { get; }
    /// <summary>
    /// Doradca 
    ///</summary>
    [Required(false)]
    Authors Councel { get; }
    /// <summary>
    /// *Tytuł 
    /// </summary>
    [Required]
    string Title { get; set; }

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
    /// sprawozdawca
    /// </summary>
    string Reporter { get; set; }

    /// <summary>
    /// Urząd
    /// </summary>
    string Court { get; set; }

    /// <summary>
    /// Numer sprawy
    /// </summary>
    string CaseNumber { get; set; }

    /// <summary>
    /// Miejsce publikacji
    /// </summary>
    string City { get; set; }

    /// <summary>
    /// skrócony numer sprawy
    /// </summary>
    string AbbreviatedCaseNumber { get; set; }

    /// <summary>
    /// Krótki tytuł
    /// </summary>
    string ShortTitle { get; set; }
    /// <summary>
    /// Komentarze
    /// </summary>
    string Comments { get; set; }

  }
}
