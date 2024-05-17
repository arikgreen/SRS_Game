using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MyLib.OrdNumbers;
using MyLib.GuidUtils;
using Iml.Documentation;

namespace Iml.Organization
{

  /// <summary>
  /// Informacja o wersji dokumentu
  /// </summary>
  public partial class VersionInfo: Iml.Foundation.Element
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public VersionInfo ()
    {
      PropertyChanged += new PropertyChangedEventHandler (VersionInfo_PropertyChanged);
    }

    void VersionInfo_PropertyChanged (object sender, PropertyChangedEventArgs e)
    {
      if (e.PropertyName == "Owner")
      {
      }
    }
/*
    /// <summary>
    /// Identyfikator unikatowy wersji
    /// </summary>
    [Key]
    [Display(Order = 0)]
    public string ID { get; set; }
*/
    private OrdNum _OrdNum = new OrdNum();
    /// <summary>
    /// Numer porządkowy wersji
    /// </summary>edz
    public string OrdNum 
    {
      get { return _OrdNum; }
      set 
      { 
          _OrdNum = value;
          string v = _OrdNum.ToString();
          string[] parts = v.Split('.');
          if (parts.Length == 4)
          {
              version = String.Format("{0}.{1}.{2}", parts[0], parts[1], parts[2]);
              revision = parts[3];
          }
      }
    }

    private string version;
    /// <summary>
    /// Numer wersji
    /// </summary>
    public string Version 
    {
        get { return version; }
        set { version = value; }    
    }

    /// <summary>
    /// Numer rewizji
    /// </summary>
    public string Revision
    {
        get { return revision; }
        set { revision = value; }
    }
    private string revision;

    /// <summary>
    /// Status dokumentu w tej wersji
    /// </summary>
    public DocumentStatus Status { get; set; }

    /// <summary>
    /// Identyfikator dokumentu, który opisuje ta wersja
    /// </summary>
    [Display(AutoGenerateField=false)]
    [ReadOnly(true)]
    [Editable(false)]
    [UIHint ("HideField")]
    public Guid DocumentID { get; set; }

    /// <summary>
    /// Nazwa dokumentu w danej wersji
    /// </summary>
    [Display(AutoGenerateField = false)]
    [ReadOnly(true)]
    [Editable(false)]
    [UIHint ("HideField")]
    public string DisplayName { get; set; }

    /// <summary>
    /// Stereotyp dokumentu w danej wersji
    /// </summary>
    [Display(AutoGenerateField = false)]
    [ReadOnly(true)]
    [Editable(false)]
    [UIHint ("HideField")]
    public string Stereotype { get; set; }

    /// <summary>
    /// Data/czas utworzenia wersji
    /// </summary>
    [Display(Order = 2)]
    [ReadOnly(true)]
    [Editable(false)]
    [UIHint ("HideField")]
    public DateTime OpenedAt { get; set; }

    /// <summary>
    /// Id autora, który utworzył tę wersję
    /// </summary>
    [Display(Order = 3)]
    [ReadOnly(true)]
    [Editable(false)]
    [UIHint ("HideField")]
    public string OpenedBy { get; set; }

    /// <summary>
    /// Czy wersja jest zamknięta
    /// </summary>
    [Display(Order = 4)]
    [ReadOnly(true)]
    [Editable(false)]
    [UIHint ("HideField")]
    public bool IsClosed { get; set; }

    /// <summary>
    /// Data/czas utworzenia wersji
    /// </summary>
    [Display(Order = 5)]
    [ReadOnly(true)]
    [Editable(false)]
    [UIHint ("HideField")]
    public DateTime ClosedAt { get; set; }

    /// <summary>
    /// Id autora, który zamknął tę wersję
    /// </summary>
    [Display(Order = 6)]
    [ReadOnly(true)]
    [Editable(false)]
    [UIHint ("HideField")]
    public string ClosedBy { get; set; }

    /// <summary>
    /// Dokument otwierany dla tej wersji
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Association("VersionDocument", "DocumentID", "ID")]
    public Document Document { get; set; }

    /// <summary>
    /// Reprezentacją tekstową jest numer porządkowy
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return this.OrdNum;
    }
  }
}