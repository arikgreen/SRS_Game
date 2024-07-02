using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Sposób zawijania tekstu
  /// </summary>
  public partial class TextWrapping: Item
  {
    /// <summary>
    /// Nazwa kształtu
    /// </summary>
    [DefaultValue(null)]
    public string Shape { get; set; }

    /// <summary>
    /// Lista parametrów kształtu
    /// </summary>
    [DefaultValue(null)]
    public ShapeParameters Parameters
    {
      get
      {
        if (fParameters == null)
          fParameters = new ShapeParameters(this);
        return fParameters;
      }
      //set
      //{
      //  fParameters = value; if (value != null) value.SetOwner(this);
      //}
    }
    /// <summary>
    /// Pole przechowujące listę parametrów kształtu
    /// </summary>
    protected ShapeParameters fParameters;

    /// <summary>
    /// Czy lista parametrów kształtu
    /// </summary>
    public bool ShouldSerializeParameters ()
    {
      return fParameters != null && !fParameters.IsEmpty();
    }

    /// <summary>
    /// Obliczenie skrótu na postawie wartości
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      if (Shape!=null)
        return Shape.GetHashCode();
      return "TextWraPping".GetHashCode();
    }

  }
}
