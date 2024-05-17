using Iml.Stereotyping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Bibliography
{
  /// <summary>
  /// Interfejs stereotypu "ElectronicSource" dla typu <see cref="Source"/>
  /// </summary>
  public interface ElectronicSource
  {
    /// <summary>
    /// *Autorzy 
    ///</summary>
    [Required]
    Authors Authors { get; }
    /// <summary>
    /// *tytuł
    /// </summary>
    [Required]
    string Title { get; set; }
    /// <summary>
    /// Redaktor
    ///</summary>
    [Required(false)]
    Authors Editor { get; }
    /// <summary>
    /// Tłumacz
    ///</summary>
    [Required(false)]
    Authors Translator { get; }
    /// <summary>
    /// Osoba prowadząca
    ///</summary>
    [Required(false)]
    Authors ProducerName { get; }

    /// <summary>
    /// Firma prowadząca stronę
    /// </summary>     
    [Required(false)]
    string ProductionCompany { get; set; }

    /// <summary>
    /// Tytuł publikacji
    /// </summary>  
    [Required(false)]
    string PublicationTitle { get; set; }

    /// <summary>
    /// *Miasto
    /// </summary>
    [Required(false)]
    string City { get; set; }
    /// <summary>
    /// Województwo
    /// </summary>    
    string StateProvince { get; set; }
    /// <summary>
    /// Kraj/Region
    /// </summary>
    string CountryRegion { get; set; }
    /// <summary>
    /// *Wydawca
    /// </summary>
    [Required]
    string Publisher { get; set; }
    
    /// <summary>
    /// *Rok publikacji
    /// </summary>     
    [Required]
    string Year { get; set; }

    /// <summary>
    /// *Miesiąc publikacji
    /// </summary>     
    [Required(false)]
    string Month { get; set; }

    /// <summary>
    /// *Dzień publikacji
    /// </summary>     
    [Required(false)]
    string Day { get; set; }

    /// <summary>
    /// nośnik
    /// </summary>     
    string Medium { get; set; }

    /// <summary>
    /// Tom
    /// </summary>
    string Volume { get; set; }   

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

