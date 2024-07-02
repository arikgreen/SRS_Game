using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Markup;

namespace Iml.Organization
{
  /// <summary>
  /// Informacja o projekcie
  /// </summary>
  [ContentProperty("Documents")]
  public partial class ProjectInfo: Iml.Foundation.Element
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public ProjectInfo ()
    {
      Documents = new Iml.Foundation.ElementList<DocumentInfo> (this);
    }

    /// <summary>
    /// Identyfikator bazy danych
    /// </summary>
    [Display(AutoGenerateField = false)]
    [Required]
    public Guid SolutionID { get; set; }
/*
    /// <summary>
    /// Identyfikator unikatowy projektu
    /// </summary>
    [Key]
    [Display(Order = 1)]
    [Required]
    public Guid ID { get; set; }
*/
    /// <summary>
    /// Stereotyp projektu (na przyszłość)
    /// </summary>
    [Display(Order = 2)]
    [Required]
    public String Stereotype { get; set; }

    /// <summary>
    /// Identyfikator referencyjny (symbol) projektu
    /// </summary>
    [Display(Order = 3)]
    [Required]
    public String Symbol { get; set; }

    /// <summary>
    /// Nazwa widoczna projektu
    /// </summary>
    [Display(Order = 4)]
    [Required]
    public String Name { get; set; }

    /// <summary>
    /// Data/czas utworzenia
    /// </summary>
    [Display(Order = 5)]
    [Editable(false)]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// ID użytkownika, który utworzył projekt
    /// </summary>
    [Display(Order = 6)]
    [Editable(false)]
    public String CreatedBy { get; set; }

    /// <summary>
    /// Flaga - czy projekt może zostać usunięty
    /// </summary>
    [Display(Order = 7)]
    [Editable(false)]
    public bool Removable { get; set; }

    /// <summary>
    /// Flaga - czy projekt został zamknięty do edycji
    /// </summary>
    public bool Closed { get; set; }
/*
    /// <summary>
    /// Klucz dostępu do bazy danych - przekazywany od klienta
    /// </summary>
    [Display(AutoGenerateField = false)]
    public string DbKey { get; set; }
*/
    /// <summary>
    /// Dokumenty zawarte w tym projekcie
    /// </summary>
    [Association("ProjectDocument", "ID", "ProjectID")]
    public Iml.Foundation.ElementList<DocumentInfo> Documents { get; private set; }
  
  }
}