using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa oznaczająca pole w Wordzie. Składa się z pola instrukcji i pola tekstowego.
  /// </summary>
  public partial class InlineObject: Run
  {
    /// <summary>
    /// Szerokość obiektu
    /// </summary>
    public PointValue Width;
    /// <summary>
    /// Wysokość obiektu
    /// </summary>
    public PointValue Height;
    /// <summary>
    /// Nazwa pliku z obrazem
    /// </summary>
    public string ImageFilename;
    /// <summary>
    /// Obiekt rysunkowy
    /// </summary>
    public Drawings.Drawing Drawing;

    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public InlineObject() { }

    ///// <summary>
    ///// Utworzenie obiektu z fragmentu tekstowego
    ///// </summary>
    ///// <param name="fromRange"></param>
    //public InlineObject(TextRange fromRange): base (fromRange)
    //{
    //  if (fromRange is InlineObject)
    //  {
    //    this.Width = ((InlineObject)fromRange).Width;
    //    this.Height = ((InlineObject)fromRange).Height;
    //    this.ImageFilename = ((InlineObject)fromRange).ImageFilename;
    //    this.Drawing = ((InlineObject)fromRange).Drawing;
    //  }
    //}

    /// <summary>
    /// Czy fragment  jest pusty
    /// </summary>
    public new bool IsEmpty()
    {
      return String.IsNullOrEmpty(ImageFilename) && Drawing == null;
    }

  }
}
