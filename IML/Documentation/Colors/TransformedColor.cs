using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{

  /// <summary>
  /// Kolor przekształcany (z innego koloru)
  /// </summary>
  public partial class TransformedColor: Color
  {
    /// <summary>
    /// Kolor podstawowy
    /// </summary>
    [DefaultValue(null)]
    public Color BaseColor { get; set; }

    /// <summary>
    /// Transformacje koloru
    /// </summary>
    [DefaultValue(null)]
    public ColorTransformations Transformations 
    {
      get
      {
        if (transformations == null)
          transformations = new ColorTransformations(this);
        return transformations;
      }
      set { transformations = value; if (value != null) value.SetOwner(this); }
    }
    private ColorTransformations transformations;

    /// <summary>
    /// Czy transformacje nie są puste?
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeTransformations()
    {
      return transformations != null && !transformations.IsEmpty();
    }
  }
}
