using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
  /// <summary>
  /// Format strony w drukarce
  /// </summary>
  public partial class PageFormat: Format
  {
    /// <summary>
    /// Id nie jest serializowany
    /// </summary>
    [DefaultValue(null)]
    public override string Id
    {
      get
      {
        return null;
      }
      set
      {
        base.Id = value;
      }
    }

    /// <summary>
    /// Podaje typ formatu
    /// </summary>
    public override FormatType Type
    {
      get { return FormatType.Page; }
    }

    /// <summary>
    /// Kod formatu strony dla drukarki
    /// </summary>
    [DefaultValue(null)]
    public int? PrinterPageCode { get; set; }
    /// <summary>
    /// Wysokość
    /// </summary>
    public PointValue Height { get; set; }
    /// <summary>
    /// Szerokość
    /// </summary>
    public PointValue Width { get; set; }
    /// <summary>
    /// Orientacja strony
    /// </summary>
    public PageOrientation Orientation { get; set; }

    /// <summary>
    /// Lewy margines
    /// </summary>
    public PointValue LeftMargin { get; set; }
    /// <summary>
    /// Prawy margines
    /// </summary>
    public PointValue RightMargin { get; set; }
    /// <summary>
    /// Górny margines
    /// </summary>
    public PointValue TopMargin { get; set; }
    /// <summary>
    /// Dolny margines
    /// </summary>
    public PointValue BottomMargin { get; set; }
    /// <summary>
    /// Margines nagłówka
    /// </summary>
    public PointValue HeaderMargin { get; set; }
    /// <summary>
    /// Margines stopki
    /// </summary>
    public PointValue FooterMargin { get; set; }
    /// <summary>
    /// Margines na zszycie
    /// </summary>
    public PointValue GutterMargin { get; set; }

    /// <summary>
    /// Liczba kolumn tekstowych
    /// </summary>
    public int? ColumnCount { get; set; }
    /// <summary>
    /// Czy kolumny tekstowe są równej długości
    /// </summary>
    public bool? EqualColumnWidth { get; set; }
    /// <summary>
    /// Czy między kolumnami ma być umieszczona pionowa linia
    /// </summary>
    public bool? ColumnsSeparated { get; set; }
    /// <summary>
    /// Odległość między kolumnami
    /// </summary>
    public PointValue IntercolumnSpace { get; set; }


  }
}
