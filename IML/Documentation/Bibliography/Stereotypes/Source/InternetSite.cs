using Iml.Stereotyping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Bibliography
{
  /// <summary>
  /// Interfejs stereotypu "InternetSite" dla typu <see cref="Source"/>
  /// </summary>
  public interface InternetSite
  {
    /// <summary>
    /// *Autorzy 
    ///</summary>
    [Required]
    Authors Authors { get; }
    /// <summary>
    /// *tytuł strony sieci Web 
    /// </summary>
    [Required]
    string Title { get; set; }
    /// <summary>
    /// Redaktor strony
    ///</summary>
    [Required]
    Authors Editor { get; }
    /// <summary>
    /// Osoba prowadząca stronę
    ///</summary>
    [Required]
    Authors ProducerName { get; }
    
    /// <summary>
    /// *Firma prowadząca stronę
    /// </summary>     
    [Required]
    string ProductionCompany { get; set; }

    /// <summary>
    /// Nazwa witryny sieci Web
    /// </summary>     
    string InternetSiteTitle { get; set; }

    /// <summary>
    /// *Rok utworzenia strony
    /// </summary>     
    [Required(false)]
    string Year { get; set; }

    /// <summary>
    /// *Miesiąc utworzenia strony
    /// </summary>     
    [Required(false)]
    string Month { get; set; }

    /// <summary>
    /// *Dzień utworzenia strony
    /// </summary>     
    [Required(false)]
    string Day { get; set; }


    /// <summary>
    /// *Rok pobrania strony
    /// </summary>     
    [Required]
    string YearAccessed { get; set; }

    /// <summary>
    /// *Miesiąc pobrania strony
    /// </summary>     
    [Required(false)]
    string MonthAccessed { get; set; }

    /// <summary>
    /// *Dzień pobrania strony
    /// </summary>     
    [Required(false)]
    string DayAccessed { get; set; }

    /// <summary>
    /// *Adres internetowy strony
    /// </summary>     
    [Required]
    string URL { get; set; }

    /// <summary>
    /// wersja
    /// </summary>     
    string Version { get; set; }

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

