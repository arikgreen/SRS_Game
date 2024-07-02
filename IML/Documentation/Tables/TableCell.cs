using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Windows.Markup;
using Iml.Foundation;
using IML = Iml.Foundation;
using WinDocs = System.Windows.Documents;
using System.Windows.Media;
using System;
using Object = Iml.Foundation.Object;

namespace Iml.Documentation
{
  /// <summary>
  /// Element prezentacyjny reprezentujący komórkę tablicy
  /// </summary>
  [CanContain(typeof(TableCell), Ordered = true, GroupName = "Cells")]
  [ContentProperty("Content")]
  public partial class TableCell: Block
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public TableCell()
    {
      Content = new ContentList(this);
    }

    /// <summary>
    /// Format komórki
    /// </summary>
    [DefaultValue(null)]
    public TableCellFormat Format 
    { 
      get
      { 
        return fFormat;
      }
      set
      {
        fFormat = value;
        if (value != null)
          value.SetOwner(this);
      }
    }
    /// <summary>
    /// Pole przechowujące format komórki
    /// </summary>
    protected TableCellFormat fFormat;

    /// <summary>
    /// Lista komórek tablicy
    /// </summary>
    [DataMember]
    [Association("Block", "ID", "OwnerID")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ContentList Content 
    {
      get { return content; }
      private set { content = value; }
    }
    private ContentList content;

    /// <summary>
    /// Komórki są serializowane, gdy lista jest niepusta
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeContent ()
    {
      return content != null && !content.IsEmpty();
    }

    /// <summary>
    /// Text stanowiący zawartość komórki
    /// </summary>
    [DefaultValue(null)]
    public Object Text { get; set; }

    ///// <summary> macierzysty wiersz komórki</summary>
    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //public TableRow Row { get; set; }

    ///// <summary> macierzysta tabela komórki</summary>
    //public Table Table { get { return Row.Table; } }

    /// <summary>
    /// Rozciągnięcie komórki na wiele kolumn
    /// </summary>
    [DataMember]
    [DefaultValue(null)]
    public int? ColSpan { get; set;}
    //{
    //  get { return Properties.ColSpan; }
    //  set { Properties.ColSpan = value; } 
    //}

    ///// <summary> szerokość komórki w punktach</summary>
    //[DefaultValue(null)]
    //public double? Width
    //{
    //  get { return Properties.Width; }
    //  set { Properties.Width = value; }
    //}

    /// <summary> Rozciąganie komórki na wiele wierszy</summary>
    [DefaultValue(null)]
    public VerticalMergeType? VMerge {get; set;}
    //{
    //  get { return Properties.VMerge; }
    //  set { Properties.VMerge = value; }
    //}

    /// <summary>
    /// Czy komórka jest pusta?
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return false;
    }

    /// <summary>
    /// Lokalny identyfikator jest numerem komórki w wierszu
    /// </summary>
    public override string Id
    {
      get
      {
        int hash= GetHash();
        if (hash!=0)
          return hash.ToString();
        return base.Id;
      }
      set
      {
        base.Id = value;
      }
    }

    /// <summary>
    /// Kod skrótu do identyfikacji na podstawie numeru komórki w wierszu
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
