using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Wypełnienie obrazka
  /// </summary>
  public partial class PictureFill: Fill
  {
    /// <summary>
    /// Odwołanie do obrazka
    /// </summary>
    [DefaultValue(null)]
    public string PictureRef { get; set; }
    /// <summary>
    /// Rozdzielczość obrazka
    /// </summary>
    [DefaultValue(null)]
    public int? DPI { get; set; }
    /// <summary>
    /// Użyj lokalnej rozdzielczości obrazka
    /// </summary>
    [DefaultValue(null)]
    public bool? UseLocalDPI { get; set; }
    /// <summary>
    /// Opcja obrotu obrazka wraz z kształtem
    /// </summary>
    [DefaultValue(null)]
    public bool? RotateWithShape { get; set; }
    /// <summary>
    /// Stopień kompresji
    /// </summary>
    [DefaultValue(null)]
    public PictureCompressionFactor? Compression { get; set; }
    /// <summary>
    /// Prostokąt źródłowy
    /// </summary>
    [DefaultValue(null)]
    public Rectangle SourceRect { get; set; }
    /// <summary>
    /// Prostokąt docelowy przy rozciąganiu
    /// </summary>
    [DefaultValue(null)]
    public Rectangle StretchRect { get; set; }
    /// <summary>
    /// Kafelkowanie
    /// </summary>
    [DefaultValue(null)]
    public Tiling Tiling { get; set; }

  }
}
