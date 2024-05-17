using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Iml.Foundation;
using System.Windows.Markup;
using Iml.Documentation;

namespace Iml.Organization
{

  /// <summary>
  /// Informacja o elemencie projektowym
  /// </summary>
  public partial class ElementInfo: Iml.Foundation.Element
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public ElementInfo ()
    {
    }

    /// <summary>
    /// Identyfikator referencyjny elementu
    /// </summary>
    [Display(Order = 1)]
    [Required]
    public string RefID { get; set; }
    
    /// <summary>
    /// Stereotyp elementu
    /// </summary>
    [Required]
    public string Stereotype { get; set; }

    /// <summary>
    /// Klasa elementu
    /// </summary>
    [Required]
    public string Class { get; set; }

    /// <summary>
    /// Nazwa elementu
    /// </summary>
    [Required]
    public string Name { get; set; }
  }
}