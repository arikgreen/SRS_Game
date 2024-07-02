using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Klasa reprezentująca wypełnienie gradientowe
  /// </summary>
  public partial class GradientFill: Fill
  {
    /// <summary>
    /// Odbijanie kafelek w poziomie i w pionie
    /// </summary>
    [DefaultValue(null)]
    public TileFlipping? TileFlip { get; set; }

    /// <summary>
    /// Obracanie wypełnienia wraz z kształtem
    /// </summary>
    [DefaultValue(null)]
    public bool? RotateWithShape { get; set; }

    /// <summary>
    /// Punkty kontrolne wypelnienia gradientowego
    /// </summary>
    public GradientStopList StopList 
    {
      get 
      {
        if (stopList == null)
          stopList = new GradientStopList(this);
        return stopList;
      }
      set
      {
        stopList = value; if (value != null) value.SetOwner(this);
      }
    }
    private GradientStopList stopList;

    /// <summary>
    /// Lista punktów kontrolnych serializowana tylko wtedy, gdy niepusta
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeStopList()
    {
      return stopList != null && !stopList.IsEmpty();
    }

    /// <summary>
    /// Czy może być serializowane do łańcucha
    /// </summary>
    /// <returns></returns>
    public override bool CanSerializeToString ()
    {
      return false;
    }  
  }
}
