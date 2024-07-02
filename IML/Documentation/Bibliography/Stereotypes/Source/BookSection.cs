using Iml.Stereotyping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Bibliography
{
  /// <summary>
  /// Interfejs stereotypu "BookSection" dla typu <see cref="Source"/>
  /// </summary>
  public interface BookSection
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
    /// Autor książki 
    ///</summary>
    Authors BookAuthor { get; }
    /// <summary>
    /// *Tytuł książki
    /// </summary>
    [Required]
    string BookTitle { get; set; }
    /// <summary>
    /// *Rok
    /// </summary>     
    [Required]
    string Year { get; set; }
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
    /// Redaktor
    /// </summary>
    Authors Editor { get; set; }
    /// <summary>
    /// Tłumacz
    /// </summary>
    Authors Translator { get; set; }
    /// <summary>
    /// Tom, 
    /// </summary>
    string Volume { get; set; }
    /// <summary>
    /// Liczba tomów, 
    /// </summary>
    string NumberVolumes { get; set; }
    /// <summary>
    /// Liczba tomów, 
    /// </summary>
    string ChapterNumber { get; set; }
    /// <summary>
    /// *Strony
    /// </summary>
    [Required]
    string Pages { get; set; }
    /// <summary>
    /// Wydanie
    /// </summary>
    string Issue { get; set; }
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

