using Iml.Stereotyping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Bibliography
{
  /// <summary>
  /// Interfejs stereotypu "Interview" dla typu <see cref="Source"/>
  /// </summary>
  public interface Interview
  {
    /// <summary>
    /// *Osoba udzielająca wywiadu
    ///</summary>
    [Required]
    Authors Interviewee { get; }
    /// <summary>
    /// Osoba przeprowadzająca wywiad 
    ///</summary>
    [Required(false)]
    Authors Interviewer { get; }
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
    /// Kompilator 
    ///</summary>
    [Required(false)]
    Authors Compiler { get; }
    /// <summary>
    /// *tytuł
    /// </summary>
    [Required]
    string Title { get; set; }

    /// <summary>
    /// Miasto
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
    /// tytuł audycji
    /// </summary>
    [Required(false)]
    string BroadcastTitle { get; set; }

    /// <summary>
    /// Nadawca
    /// </summary>
    [Required(false)]
    string Broadcaster { get; set; }

    /// <summary>
    /// stacja
    /// </summary>
    [Required(false)]
    string Station { get; set; }

    /// <summary>
    /// Strony
    /// </summary>
    [Required(false)]
    string Pages { get; set; }

    /// <summary>
    /// Wydawca
    /// </summary>
    [Required(false)]
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
    /// Numer standardowy
    /// </summary>
    string StandardNumber { get; set; }
    /// <summary>
    /// Komentarze
    /// </summary>
    string Comments { get; set; }

  }
}

