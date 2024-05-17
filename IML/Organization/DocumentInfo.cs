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
  /// Informacja o dokumencie (wraz z wersjami)
  /// </summary>
  [ContentProperty("Versions")]
  public partial class DocumentInfo: Iml.Foundation.Element
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public DocumentInfo ()
    {
      Versions = new ElementList<VersionInfo> (this);
      Authors = new List<Author>();
    }

    ///// <summary>
    ///// Identyfikator unikatowy dokumentu
    ///// </summary>
    //[Key]
    //[Display(AutoGenerateField = false)]
    //[Required]
    //public Guid ID { get; set; }

    /// <summary>
    /// Identyfikator rozwiązania, do którego należy dokument
    /// </summary>
    [Display(AutoGenerateField=false)]
    [ReadOnly(true)]
    [Editable(false)]
    [UIHint("HideField")]
    public Guid SolutionID { get; set; }

    /// <summary>
    /// Identyfikator projektu, do którego należy dokument
    /// </summary>
    [Display(AutoGenerateField = false)]
    [ReadOnly(true)]
    [Editable(false)]
    [UIHint ("HideField")]
    public Guid ProjectID { get; set; }

    /// <summary>
    /// Symbol projektu, do którego należy dokument
    /// </summary>
    [Display(AutoGenerateField = false)]
    [ReadOnly(true)]
    [Editable(false)]
    [UIHint ("HideField")]
    public string ProjectSymbol { get; set; }

    /// <summary>
    /// Nazwa dokumentu
    /// </summary>
    [Display(Order = 1)]
    [Required]
    public string RefID { get; set; }
    
    /// <summary>
    /// Stereotyp dokumentu
    /// </summary>
    [Required]
    public string Stereotype { get; set; }

    /// <summary>
    /// Status dokumentu
    /// </summary>
    [Required]
    public DocumentStatus Status { get; set; }

    /// <summary>
    /// Nazwa dokumentu
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Nazwa szablonu z którego utworzono dokument
    /// </summary>
    public string TemplateName { get; set; }

    /// <summary>
    /// Tytuł dokumentu
    /// </summary>
    [Required]
    public string Title { get; set; }

    /// <summary>
    /// Data/czas utworzenia dokumentu
    /// </summary>
    [ReadOnly(true)]
    [Editable(false)]
    [UIHint ("HideField")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Id autora, który utworzył ten dokument
    /// </summary>
    [Display(Order = 6)]
    [ReadOnly(true)]
    [Editable(false)]
    [UIHint ("HideField")]
    public string CreatedBy { get; set; }

    /// <summary>
    /// Data/czas ostatniej modyfikacji dokumentu
    /// </summary>
    [Display(Order = 7)]
    [ReadOnly(true)]
    [Editable(false)]
    [UIHint("HideField")]
    public DateTime? ModifiedAt { get; set; }

    /// <summary>
    /// Id autora, który ostatnio zmodyfikował ten dokument
    /// </summary>
    [Display(Order = 8)]
    [ReadOnly(true)]
    [Editable(false)]
    [UIHint("HideField")]
    public string ModifiedBy { get; set; }

    /// <summary>
    /// Wersja dokumentu
    /// </summary>
    [Display(Order = 9)]
    public string Version { get; set; }

    /// <summary>
    /// Wydanie dokumentu
    /// </summary>
    [Display(Order = 10)]
    public string Revision { get; set; }

    /// <summary>
    /// Informacje o wersjach dokumentu
    /// </summary>
    [Association ("Document_Versions", "ID", "OwnerID")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ElementList<VersionInfo> Versions { get; set; }

    /// <summary>
    /// Lista autorów
    /// </summary>
    [Association("Document_Authors", "ID", "OwnerID")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public List<Author> Authors { get; private set; }

  }
}