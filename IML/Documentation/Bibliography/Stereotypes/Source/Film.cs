using Iml.Stereotyping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Bibliography
{
  /// <summary>
  /// Interfejs stereotypu "Film" dla typu <see cref="Source"/>
  /// </summary>
  public interface Film
  {
    /// <summary>
    /// Reżyser 
    ///</summary>
    [Required(false)]
    Authors Director { get; }
    /// <summary>
    /// Scenarzysta 
    ///</summary>
    [Required(false)]
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
    /// Firma produkcyjna
    /// </summary>
    [Required(false)]
    string ProductionCompany { get; set; }

    /// <summary>
    /// Nośnik
    /// </summary>
    [Required(false)]
    string Medium { get; set; }

    /// <summary>
    /// dystrybutor
    /// </summary>
    [Required(false)]
    string Distributor { get; set; }

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
