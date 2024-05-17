using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Iml.Foundation;
using System.Windows.Markup;

namespace Iml.Organization
{

  /// <summary>
  /// Informacja o szablonie dokumentu
  /// </summary>
  public partial class TemplateInfo
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public TemplateInfo ()
    {
    }

    /// <summary>
    /// Identyfikator szablonu w rejestrze
    /// </summary>
    [Key]
    [Display(AutoGenerateField = false)]
    [Required]
    public Guid ID { get; set; }

    /// <summary>
    /// Nazwa szablonu
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Nazwa pliku z szablonem
    /// </summary>
    [Required]
    public string FileName { get; set; }

    /// <summary>
    /// Stereotyp dokumentu, dla którego jest przeznaczony ten szablon
    /// </summary>
    public string Stereotype { get; set; }

    /// <summary>
    /// Domyślny tytuł dokumentu
    /// </summary>
    public string Title { get; set; }
  }
}