using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Iml.Foundation;
using Object = Iml.Foundation.Object;

namespace Iml.Organization
{

  /// <summary>
  /// Informacja o rozwiązaniu (bazie danych projektowych)
  /// </summary>
  public partial class SolutionInfo: Object
  {

    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public SolutionInfo ()
    {
      Projects = new ElementList<ProjectInfo> (this);
    }

    /// <summary>
    /// Identyfikator unikatowy rozwiązania
    /// </summary>
    [Key]
    [Display(Order = 0)]
    [UIHint("HideField")]
    public Guid ID { get; set; }

    /// <summary>
    /// Rodzaj bazy danych projektowych
    /// </summary>
    public DatabaseKind Kind { get; set; }

    /// <summary>
    /// Nazwa bazy danych projektowych (alias dla serwera SQL)
   /// </summary>
    public String DbName { get; set; }

    /// <summary>
    /// Nazwa pliku bazy danych (pliku lub katalogu - bez ścieżki i rozszerzenia)
    /// </summary>
    public String FileName { get; set; }

    /// <summary>
    /// Identyfikator użytkownika, który utworzył rozwiązanie
    /// </summary>
    [UIHint("HideField")]
    public String CreatedBy { get; set; }

    /// <summary>
    /// Data/czas utworzenia rozwiązania
    /// </summary>
    [ReadOnly(true)]
    [Editable(false)]
    [UIHint ("HideField")]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Data/czas ostatniej modyfikacji
    /// </summary>
    [ReadOnly(true)]
    [Editable(false)]
    [UIHint ("HideField")]
    public DateTime ModifiedAt { get; set; }

    /// <summary>
    /// Identyfikator użytkownika odpowiedzialnego za rozwiązanie (ma wobec niego uprawnienia administratora)
    /// </summary>
    public String Responsible { get; set; }

    /// <summary>
    /// Użytkownicy zarejestrowani jako autorzy
    /// </summary>
    [ReadOnly (true)]
    [Editable (false)]
    [UIHint ("HideField")]
    public String Authors { get; set; }

    /// <summary>
    /// Źródło danych identyfikujące serwer SQL, przez który dostępna jest baza danych. 
    /// Przekazywane między serwerem a klientem, ale nie udostępniane użytkownikowi
    /// </summary>
    [Display(AutoGenerateField = false)]
    [Editable(false)]
    public string DataSource { get; set; }
/*
    /// <summary>
    /// Klucz dostępu do otwartej bazy danych.
    /// To pole jest wypełniane w momencie otwarcia rozwiązania.
    /// Przekazywane między serwerem a klientem, ale nie udostępniane użytkownikowi
    /// </summary>
    [Display(AutoGenerateField = false)]
    [Editable(false)]
    public string DbKey { get; set; }
*/
    /// <summary>
    /// Lista projektów
    /// </summary>
    [DataMember]
    [Association ("SolutionProjects", "ID", "SolutionID")]
    [Display(AutoGenerateField=false)]
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Content)]
    [UIHint ("HideField")]
    public ElementList<ProjectInfo> Projects { get; private set; }
 
  }
}