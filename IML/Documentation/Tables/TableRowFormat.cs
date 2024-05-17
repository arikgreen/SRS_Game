using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Format wiersza tabeli
  /// </summary>
  public partial class TableRowFormat: Format
  {
    ///// <summary>
    ///// Konstruktor domyślny
    ///// </summary>
    //public TableRowFormat () { }

    ///// <summary>
    ///// Konstruktor z właścicielem
    ///// </summary>
    ///// <param name="owner"></param>
    //public TableRowFormat (object owner) : base(owner) { }

    /// <summary>
    /// Zwraca typ formatu
    /// </summary>
    public override FormatType Type
    {
      get { return FormatType.TableRow; }
    }

    /// <summary>preferowana szerokość tabeli przed wierszem</summary>
    [DefaultValue(null)]
    public TableWidth WidthBefore { get; set; }

    /// <summary>preferowana szerokość tabeli za wierszem</summary>
    [DefaultValue(null)]
    public TableWidth WidthAfter { get; set; }

    /// <summary>odstępy między komórkami w wierszu</summary>
    [DefaultValue(null)]
    public TableWidth CellSpacing { get; set; }

    /// <summary>preferowana wysokość wiersza</summary>
    [DefaultValue(null)]
    public LineSpacing RowHeight { get; set; }

    /// <summary> czy wiersz może być dzielony między strony</summary>
    [DefaultValue(null)]
    public bool? CantSplit { get; set; }

    /// <summary> czy wiersz jest ukryty</summary>
    [DefaultValue(null)]
    public bool? IsHidden { get; set; }

    /// <summary> czy ten wiersz nagłówkiem tabeli</summary>
    [DefaultValue(null)]
    public bool? IsHeader { get; set; }

    /// <summary>Wyrównanie wiersza (poziome)</summary>
    [DefaultValue(null)]
    public HorizontalAlignment? HorizontalAlignment { get; set; }

    /// <summary>
    /// Identyfikator dla HTML'a
    /// </summary>
    [DefaultValue(null)]
    public string DivId { get; set; }

    /// <summary>
    /// Czy format jest pusty
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty()
    {
      bool result = 
          WidthBefore == null
        && WidthAfter == null
        && CellSpacing == null
        && RowHeight == null
        && CantSplit == null
        && IsHidden == null
        && IsHeader == null
        && HorizontalAlignment == null
        && DivId == null
        && base.IsEmpty();
      return result;
    }
  }
}
