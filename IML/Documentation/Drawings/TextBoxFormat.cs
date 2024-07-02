using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Format pola tekstowego
  /// </summary>
  public partial class TextBoxFormat: Format
  {
    /// <summary>
    /// Zwraca typ formatu
    /// </summary>
    public override FormatType Type
    {
      get { return FormatType.TextBox; }
    }

    /// <summary>
    /// Wymuszenie antyaliasingu
    /// </summary>
    [DefaultValue(null)]
    public bool? AntiAlias { get; set; }

    /// <summary>
    /// Czy i jak tekst ma być dopasowywany do zawartości
    /// </summary>
    [DefaultValue(null)]
    public AutoFitting? AutoFit { get; set; }
    
    /// <summary>
    /// Liczba kolumn
    /// </summary>
    [DefaultValue(null)]
    public int? ColumnCount { get; set; }

    /// <summary>
    /// Odstęp między kolumnami
    /// </summary>
    [DefaultValue(null)]
    public PointValue ColumnSpacing { get; set; }

    /// <summary>
    /// Czy kolumny od prawej do lewej?
    /// </summary>
    [DefaultValue(null)]
    public bool? ColumnRTL { get; set; }

    /// <summary>
    /// Czy uproszczone odstępy międzyliniowe
    /// </summary>
    [DefaultValue(null)]
    public bool? CompatibleLineSpacing { get; set; }

    /// <summary>
    /// Czy parametry przepisywane z aplkacji WordArt?
    /// </summary>
    [DefaultValue(null)]
    public bool? FromWordArt { get; set; }

    /// <summary>
    ///  Umiejscowienie pola tekstowego wewnątrz kształtu (w poziomie)
    /// </summary>
    [DefaultValue(null)]
    public HorizontalAlignment? HorizontalAlignment { get; set; }

    /// <summary>
    /// Traktowanie przepełnienia tekstem w poziomie
    /// </summary>
    [DefaultValue(null)]
    public TextOverflowHandling? HorizontalOverflow { get; set; }

    /// <summary>
    /// Odstępy tekstu od brzegów pola tekstowego
    /// </summary>
    [DefaultValue(null)]
    public Rectangle Padding { get; set; }
    /// <summary>
    /// Obrót pola tekstowego (w stopniach)
    /// </summary>
    [DefaultValue(null)]
    public Angle Rotation { get; set; }

    /// <summary>
    /// Zawijanie tekstu
    /// </summary>
    [DefaultValue(null)]
    public string TextWrapShape { get; set; }

    /// <summary>
    /// Sposób zawijania tekstu
    /// </summary>
    [DefaultValue(null)]
    public TextWrapping TextWrapping { get; set; }

    /// <summary>
    /// Czy stosować odstępy akapitowe przed pierwszym i ostatnim akapitem
    /// </summary>
    [DefaultValue(null)]
    public bool? UseParagraphSpacing { get; set; }

    /// <summary>
    /// Umiejscowienie pola tekstowego wewnątrz kształtu (w pionie)
    /// </summary>
    [DefaultValue(null)]
    public VerticalAlignment? VerticalAlignment { get; set; }

    /// <summary>
    /// Traktowanie przepełnienia tekstem w pionie
    /// </summary>
    [DefaultValue(null)]
    public TextOverflowHandling? VerticalOverflow { get; set; }

    /// <summary>
    /// Traktowanie tekstu pionowego
    /// </summary>
    [DefaultValue(null)]
    public string VerticalText { get; set; }

  }
}
