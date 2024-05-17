using Iml.Stereotyping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Bibliography
{
  /// <summary>
  /// Interfejs stereotypu "Report" dla typu <see cref="Source"/>
  /// </summary>
  public interface Report
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
    /// Wydział
    /// </summary>    
    string Department { get; set; }
    /// <summary>
    /// Instytucja
    /// </summary>
    string Institution { get; set; }
    /// <summary>
    /// *Wydawca
    /// </summary>
    [Required]
    string Publisher { get; set; }
    /// <summary>
    /// Typ raportu
    /// </summary>
    string ThesisType { get; set; }
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
