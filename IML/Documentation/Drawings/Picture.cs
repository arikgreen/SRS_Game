using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Obrazek jako element rysunkowy
  /// </summary>
  public partial class Picture: DrawingItem
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Picture () 
    {
      Shape = new DrawingShape();
    }

    /// <summary>
    /// Opcja względnej zmiany rozmiaru
    /// </summary>
    [DefaultValue(null)]
    public bool? PreferRelativeResize { get; set; }
    /// <summary>
    /// Identyfikator kamery
    /// </summary>
    [DefaultValue(null)]
    public string CameraId { get; set; }

    /// <summary>
    /// Wypełnienie obrazka
    /// </summary>
    [DefaultValue(null)]
    public PictureFill Fill { get; set; }

    /// <summary>
    /// Tryb konwersji na czerń i biel
    /// </summary>
    [DefaultValue(null)]
    public string BlackAndWhiteMode { get; set; }

    /// <summary>
    /// Kształt obrazka
    /// </summary>
    public DrawingShape Shape { get; set; }
  }
}
