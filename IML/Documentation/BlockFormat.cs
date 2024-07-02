using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Documentation;
using System.ComponentModel;
using System.Windows.Media;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca format bloku
  /// </summary>
  public partial class BlockFormat
  {
    /// <summary>
    /// Tło bloku
    /// </summary>
    [DefaultValue(null)]
    public Brush Background { get; set; }

    /// <summary>
    /// Obramowanie bloku
    /// </summary>
    public Borders Borders { get; set; }

    /// <summary>
    /// Czy właściwości są puste?
    /// </summary>
    public bool IsEmpty ()
    {
      return Background == null
        && Borders == null;
    }

    ///// <summary>
    ///// Suma dwóch zbiorów właściwości. Właściwości pierwszego zbioru mają pierwszeństwo.
    ///// </summary>
    //public static BlockFormat operator | (BlockFormat A, BlockFormat B)
    //{
    //  if (B == null)
    //    return A;
    //  if (A == null)
    //    return B;
    //  BlockFormat result = new BlockFormat ();
    //  result.Background = A.Background ?? B.Background;
    //  result.Borders = A.Borders | B.Borders;
    //  return result;
    //}

  }

}
