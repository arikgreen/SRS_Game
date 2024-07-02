using Iml.Stereotyping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Bibliography
{
  /// <summary>
  /// Interfejs stereotypu "Art" dla typu <see cref="Source"/>
  /// </summary>
  public interface Art
  {
    /// <summary>
    /// *Wykonawcy 
    ///</summary>
    [Required]
    Authors Artist { get; }
    /// <summary>
    /// *tytuł
    /// </summary>
    [Required]
    string Title { get; set; }

    /// <summary>
    /// Instytucja promująca sztukę
    /// </summary>     
    [Required(false)]
    string Institution { get; set; }

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
    /// Krótki tytuł
    /// </summary>
    string ShortTitle { get; set; }
    /// <summary>
    /// Komentarze
    /// </summary>
    string Comments { get; set; }

  }
}

