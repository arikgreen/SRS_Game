using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Windows.Markup;
using Iml.Foundation;
using IML = Iml.Foundation;
using WinDocs = System.Windows.Documents;
using System.Windows.Media;
using System.Diagnostics;

namespace Iml.Documentation
{
  /// <summary>
  /// Wiersz tabeli
  /// </summary>
  [CanContain(typeof(TableCell), Ordered = true, GroupName = "Cells")]
  [ContentProperty("Content")]
  public partial class TableRow : Block
  {

    /// <summary>
    /// Lista komórek tablicy
    /// </summary>
    [DataMember]
    [Association("TableCell", "ID", "OwnerID")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ContentList Content 
    { 
      get
      {
        if (fContent == null)
          fContent = new ContentList(this);
        return fContent;
      }
      private set
      {
        fContent = value; if (value != null) value.SetOwner(this);
      }
    }
    /// <summary>
    /// Pole przechowujace zawartość (komórki i znaczniki)
    /// </summary>
    protected ContentList fContent;

    /// <summary>
    /// Komórki są serializowane, gdy lista jest niepusta
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeContent()
    {
      return fContent != null && !fContent.IsEmpty();
    }

    /// <summary>
    /// Wyjątki od formatu tabeli
    /// </summary>
    [DefaultValue(null)]
    public TableFormat TableFormatExceptions { get; set; }

    /// <summary> macierzysta tabela wiersza</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Table Table { get; set; }

    /// <summary>
    /// Format wiersza tabeli
    /// </summary>
    //[DefaultValue(null)]
    public TableRowFormat Format 
    { 
      get
      {
        if (fFormat == null)
          fFormat = new TableRowFormat();
        return fFormat;
      }
      set { fFormat = value; }
    }
    /// <summary>
    /// Pole przechowujące format wiersza
    /// </summary>
    protected TableRowFormat fFormat;

    /// <summary>
    /// Czy format wiersza ma być serializowany
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeFormat()
    {
      return fFormat != null && !fFormat.IsEmpty();
    }

    /// <summary> ile kolumn jest pomijanych (pustych) przed pierwszą komórką wiersza</summary>
    [DefaultValue(null)]
    public int? GridBefore { get; set; }

    /// <summary> ile kolumn jest pomijanych (pustych) za ostatnią komórką wiersza</summary>
    [DefaultValue(null)]
    public int? GridAfter { get; set; }

    /// <summary>
    /// Czy wiersz jest pusty
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return false;      
    }

    /// <summary>
    /// Lokalny identyfikator jest numerem wiersza w tabeli
    /// </summary>
    public override string Id
    {
      get
      {
        int hash = GetHash();
        if (hash != 0)
          return hash.ToString();
        return base.Id;
      }
      set
      {
        base.Id = value;
      }
    }

    /// <summary>
    /// Identyfikator paragrafu
    /// </summary>
    public string ParaId { get; set; }

    /// <summary>
    /// Identyfikator tekstu
    /// </summary>
    public string TextId { get; set; }

    /// <summary>
    /// Kod skrótu do identyfikacji na podstawie numeru wiersza w tabeli
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      if (Collection != null)
        return Collection.IndexOf(this) + 1;
      return base.GetHash();
    }
  }
}
