using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca format tabeli
  /// </summary>
  public partial class TableFormat: Format
  {
    /// <summary>
    /// Zwraca typ formatu
    /// </summary>
    public override FormatType Type
    {
      get { return FormatType.Table; }
    }

    /// <summary>
    /// Wygląd tabeli
    /// </summary>
    [DefaultValue(null)]
    public TableLayout Layout 
    { 
      get; 
      set;
    }

    /// <summary>
    /// Wcięcie tabeli w punktach
    /// </summary>
    [DefaultValue(null)]
    public TableWidth Indent { get; set; }

    /// <summary>
    /// Szerokość tabeli w punktach
    /// </summary>
    [DefaultValue(null)]
    public TableWidth Width { get; set; }

    /// <summary>
    /// Odstępy między komórkami
    /// </summary>
    [DefaultValue(null)]
    public TableWidth CellSpacing { get; set; }

    /// <summary>
    /// Domyślne marginesy komórek
    /// </summary>
    [DefaultValue(null)]
    public TableCellMargin DefaultCellMargin { get; set; }

    /// <summary>
    /// Czy tabela dopasowywana do zawartości
    /// </summary>
    [DefaultValue(null)]
    public bool? Autofit { get; set; }

    /// <summary>
    /// Obramowanie komórki
    /// </summary>
    //[DefaultValue(null)]
    public virtual Borders Borders
    {
      get
      {
        if (borders == null)
          borders = new Borders(this);
        return borders;
      }
      set { borders = value; if (value != null) value.SetOwner(this); }
    }
    private Borders borders;

    /// <summary>
    /// Czy obramowanie ma być serializowane
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeBorders ()
    {
      return borders != null && !borders.IsEmpty();
    }

    /// <summary>
    /// Wyrównanie tabeli w poziomie
    /// </summary>
    [DefaultValue(null)]
    public HorizontalAlignment? TableAlignment { get; set; }

    /// <summary>
    /// Szerokość wstęgi wierszy (liczba wierszy)
    /// </summary>
    [DefaultValue(null)]
    public int? RowBandSize { get; set; }

    /// <summary>
    /// Szerokość wstęgi kolumn (liczba kolumn)
    /// </summary>
    [DefaultValue(null)]
    public int? ColBandSize { get; set; }

    //private TablePartFormatList tablePartFormats;
    ///// <summary>
    ///// Formaty dla części tabeli
    ///// </summary>
    //[DataMember]
    //[Include]
    //[Association("TablePartFormats", "ID", "OwnerID")]
    //[Composition]
    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    //public TablePartFormatList TablePartFormats
    //{
    //  get
    //  {
    //    if (tablePartFormats == null)
    //      tablePartFormats = new TablePartFormatList(this);
    //    return tablePartFormats;
    //  }
    //  set { tablePartFormats = value; if (value != null) value.SetOwner(this); }
    //}

    /// <summary>
    /// Formaty dla części tabeli
    /// </summary>
    public IEnumerable<TablePartFormat> TablePartFormats
    {
      get
      {
        return (from item in Components where item is TablePartFormat select item).Cast<TablePartFormat>();
      }
    }
  }
}
