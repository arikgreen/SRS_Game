using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  public partial class ColorTransformation
  {
    /// <summary>
    /// Abstrakcyjna metoda przekształcenia koloru
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public abstract ARGBColor Transform (ARGBColor value);

    /// <summary>
    /// Przekształcenie koloru z RGB na HLS
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static HlsColor RealColor2HlsColor(ARGBColor value)
    {
      double H,L,S;
      Color.Rgb2Hls(value.Red, value.Green, value.Blue, out H, out L, out S);
      return new HlsColor { Alpha = value.Alpha, Hue = H, Luminance = L, Saturation = S };
    }

    /// <summary>
    /// Przekształcenie koloru z HLS na RGB
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ARGBColor HlsColor2RealColor (HlsColor value)
    {
      double R, G, B;
      Color.Hls2Rgb(value.Hue, value.Saturation, value.Saturation , out R, out G, out B);
      return new ARGBColor { Alpha = value.Alpha, Red = R, Green = G, Blue = B };
    }

    /// <summary>
    /// Ograniczenie wartości składowej do skali 0-1
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static double Fix(double value)
    {
      while (value > 1)
        value -= 1;
      while (value < 0)
        value += 1;
      return value;
    }

    /// <summary>
    /// Ograniczenie wartości składowej do skali 0-360
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static double Fix360 (double value)
    {
      while (value > 360)
        value -= 360;
      while (value < 0)
        value += 360;
      return value;
    }

  }
}
