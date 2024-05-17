using Iml.Stereotyping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Bibliography
{
  /// <summary>
  /// Interfejs stereotypu "Performance" dla typu <see cref="Source"/>
  /// </summary>
  public interface Performance
  {
    /// <summary>
    /// *Reżyser 
    ///</summary>
    [Required]
    Authors Director { get; }
    /// <summary>
    /// *Scenarzysta 
    ///</summary>
    [Required]
    Authors Writer { get; }
    /// <summary>
    /// Wykonawca 
    ///</summary>
    [Required(false)]
    Authors Performer { get; }
    /// <summary>
    /// *Producent 
    ///</summary>
    [Required(false)]
    Authors ProducerName { get; }

    /// <summary>
    /// *tytuł
    /// </summary>
    [Required]
    string Title { get; set; }

    /// <summary>
    /// Teatr
    /// </summary>
    [Required(false)]
    string Theater { get; set; }

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
    /// Firma produkcyjna
    /// </summary>
    [Required(false)]
    string ProductionCompany { get; set; }

    /// <summary>
    /// *Rok publikacji
    /// </summary>     
    [Required]
    string Year { get; set; }

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

