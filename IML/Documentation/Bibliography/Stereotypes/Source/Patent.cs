using Iml.Stereotyping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Bibliography
{
  /// <summary>
  /// Interfejs stereotypu "Patent" dla typu <see cref="Source"/>
  /// </summary>
  public interface Patent
  {
    /// <summary>
    /// Wynalazcy 
    ///</summary>
    [Required(false)]
    Authors Inventor { get; }
    /// <summary>
    /// Redaktor 
    ///</summary>
    Authors Editor { get; }
    /// <summary>
    /// Tłumacz 
    ///</summary>
    Authors Translator { get; }
    /// <summary>
    /// *Tytuł 
    /// </summary>
    [Required]
    string Title { get; set; }

    /// <summary>
    /// Kraj/Region
    /// </summary>
    [Required]
    string CountryRegion { get; set; }

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
    /// Typ patentu
    /// </summary>

    string Type { get; set; }
    /// <summary>
    /// Numer patentu
    /// </summary>
    string PatentNumber { get; set; }
    /// <summary>
    /// Krótki tytuł
    /// </summary>
    string ShortTitle { get; set; }
    /// <summary>
    /// Numer standardowy
    /// </summary>
    string StandardNumber { get; set; }
    /// <summary>
    /// Komentarze
    /// </summary>
    string Comments { get; set; }

  }
}
