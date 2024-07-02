using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Windows.Markup;
using Iml.Foundation;
using WinDocs = System.Windows.Documents;
using System;
using System.Windows.Media;
using IML = Iml.Documentation;
using System.Xml.Serialization;
using System.Globalization;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca tablicę w dokumencie IML
  /// </summary>
  [CanContain(typeof(TableRow),Ordered=true,GroupName="Rows")]
  [ContentProperty("Rows")]
  public partial class Table: Block
  {
    /// <summary>
    /// Konstruktor inicjujący
    /// </summary>
    public Table()
    {
      //Columns = new TableColumns (this);
      Rows = new ItemList<TableRow>(this);
      Grid = new TableGrid();
    }

    /// <summary>
    /// Wiersze tablicy
    /// </summary>
    [DataMember]
    [Association("TableRow", "ID", "OwnerID")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ItemList<TableRow> Rows { get; private set; }

    /// <summary>
    /// Wiersze są serializowane, gdy lista jest niepusta
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeRows()
    {
      return Rows != null && !Rows.IsEmpty();
    }

    ///// <summary>
    ///// Szerokość tabeli
    ///// </summary>
    //public double Width { get; set;}

    ///// <summary>
    ///// Aktualna szerokość tabeli  - obliczana na podstawie szerokości kolumn
    ///// </summary>
    //public double CurrentWidth
    //{
    //  get { return EvaluateWidth (); }
    //}

    ///// <summary>
    ///// Obliczenie szerokości tabeli na podstawie szerokości kolumn
    ///// </summary>
    //public double EvaluateWidth()
    //{
    //  double result = 0;
    //  if (Columns!=null)
    //    foreach (TableColumn aColumn in Columns)
    //    {
    //      if (aColumn.Width != null)
    //        result += (double)aColumn.Width;
    //    }
    //  return result;
    //}

    /// <summary>
    /// Format tabeli
    /// </summary>
    [DefaultValue(null)]
    public TableFormat TableFormat { get; set;}

    ///// <summary>
    ///// Format bloku (tło, obramowanie)
    ///// </summary>
    //[DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    //public override BlockFormat BlockFormat 
    //{
    //  get { return base.BlockFormat ?? DerivedBlockFormat; }
    //  set { base.BlockFormat = value; }
    //}

    ///// <summary>
    ///// Format bloku pozyskiwany ze stylu
    ///// </summary>
    //[DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    //public BlockFormat DerivedBlockFormat
    //{
    //  get
    //  {
    //    if (Style != null)
    //      return Style.BlockFormat;
    //    else
    //      return null;
    //  }
    //}

    ///// <summary>
    ///// Tło własne lub wyznaczane na podstawie stylu 
    ///// </summary>
    //[DefaultValue (null)]
    //public override Brush Background
    //{
    //  get
    //  {
    //    Brush result = null;
    //    if (BlockFormat != null)
    //      result = BlockFormat.Background;
    //    if (result == null && Style != null)
    //      result = Style.Background;
    //    return result;
    //  }
    //  set
    //  {
    //    if (value != Background)
    //    {
    //      if (BlockFormat == null)
    //        BlockFormat = new BlockFormat ();
    //      BlockFormat.Background = value;
    //      if (BlockFormat.IsEmpty ())
    //        BlockFormat = null;
    //      NotifyPropertyChanged ("Background");
    //      foreach (TableRow aRow in Rows)
    //        aRow.NotifyObjectChanged (this, "Background");
    //    }
    //  }
    //}

    ///// <summary>
    ///// Obramowanie własne lub wyznaczane na podstawie stylu
    ///// </summary>
    //[DefaultValue (null)]
    //public override Borders Borders
    //{
    //  get
    //  {
    //    Borders result = null;
    //    if (BlockFormat != null)
    //      result = BlockFormat.Borders;
    //    if (result == null && Style != null)
    //      result = Style.Borders;
    //    return result;
    //  }
    //  set
    //  {
    //    if (value != Borders)
    //    {
    //      if (BlockFormat == null)
    //        BlockFormat = new BlockFormat ();
    //      BlockFormat.Borders = value;
    //      if (BlockFormat.IsEmpty ())
    //        BlockFormat = null;
    //      NotifyPropertyChanged ("Borders");
    //      foreach (TableRow aRow in Rows)
    //        aRow.NotifyObjectChanged (this, "Borders");
    //    }
    //  }
    //}

    ///// <summary>
    ///// Zwraca wiersze do rozwiązywania referencji
    ///// </summary>
    ///// <returns></returns>
    //protected override IEnumerable<IReferencingElement> GetReferencingItems ()
    //{
    //  return Rows;
    //}

    ///// <summary>
    ///// Styl przypisany do elementu
    ///// </summary>
    //[DefaultValue (null)]
    //[DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    //public new TableStyle Style
    //{
    //  get { return base.Style as TableStyle; }
    //  set { base.Style = value; }
    //}

    //private Iml.Foundation.Reference _StyleRef;
    ///// <summary>
    ///// Referencja do stylu akapitu
    ///// </summary>
    //[DefaultValue (null)]
    //[TypeConverter (typeof (Iml.Foundation.ReferenceTypeConverter))]
    //public Iml.Foundation.Reference StyleRef
    //{
    //  get { return _StyleRef; }
    //  set
    //  {
    //    _StyleRef = value;
    //    if (_StyleRef != null)
    //      _StyleRef.Owner = this;
    //  }
    //}

    /// <summary>
    /// Siatka tabeli
    /// </summary>
    [DefaultValue(null)]
    [XmlArray]
    [XmlArrayItem(Type = typeof(TableGridCol))]
    public TableGrid Grid { get; set; }

    /// <summary>
    /// Podpis tabeli
    /// </summary>
    [DefaultValue(null)]
    public string Caption { get; set; }

    /// <summary>
    /// Czy tabela jest pusta?
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return false;
    }

    /// <summary>
    /// Kond skrótu pobierany z "rsid" pierwszego wiersza
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      int hash = "TabLe".GetHashCode();
      if (Rows != null && Rows.Count > 0)
      {
        TableRow firstRow = Rows[0];
        if (firstRow.RevisionId != null)
        {
          int val;
          if (int.TryParse(firstRow.RevisionId, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val))
            hash += val;
        }
      }
      if (Collection != null)
        hash = Collection.MakeHashUnique(hash);
      return hash;
    }
  }
}
