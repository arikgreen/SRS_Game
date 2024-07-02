using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  public partial class Color
  {
    ///// <summary>
    ///// Tworzy kolor z wartości HLS
    ///// </summary>
    ///// <param name="H">barwa</param>
    ///// <param name="L">jasność</param>
    ///// <param name="S">nasycenie</param>
    ///// <returns></returns>
    //public static Color FromHls (double H, double L, double S)
    //{
    //  double v;
    //  double r, g, b;

    //  r = L;
    //  g = L;
    //  b = L;
    //  v = (L <= 0.5) ? (L * (1.0 + S)) : (L + S - L * S);

    //  if (v > 0)
    //  {
    //    double m;
    //    double sv;
    //    int sextant;
    //    double fract, vsf, mid1, mid2;

    //    m = L + L - v;
    //    sv = (v - m) / v;
    //    H *= 6.0;
    //    sextant = (int)H;
    //    fract = H - sextant;
    //    vsf = v * sv * fract;
    //    mid1 = m + vsf;
    //    mid2 = v - vsf;
    //    switch (sextant)
    //    {
    //      case 0:
    //        r = v;
    //        g = mid1;
    //        b = m;
    //        break;
    //      case 1:
    //        r = mid2;
    //        g = v;
    //        b = m;
    //        break;
    //      case 2:
    //        r = m;
    //        g = v;
    //        b = mid1;
    //        break;
    //      case 3:
    //        r = m;
    //        g = mid2;
    //        b = v;
    //        break;
    //      case 4:
    //        r = mid1;
    //        g = m;
    //        b = v;
    //        break;
    //      case 5:
    //        r = v;
    //        g = m;
    //        b = mid2;
    //        break;
    //    }
    //  }

    //  byte R = Convert.ToByte(r * 255.0f);
    //  byte G = Convert.ToByte(g * 255.0f);
    //  byte B = Convert.ToByte(b * 255.0f);

    //  return FromArgb(R, G, B);
    //}

    /// <summary>
    /// Konwersja wartości RGB na HLS. Wszystkie wartości w skali 0-1
    /// </summary>
    /// <param name="R">składowa czerwona</param>
    /// <param name="G">składowa zielona</param>
    /// <param name="B">składowa niebieska</param>
    /// <param name="H">barwa</param>
    /// <param name="L">jasność</param>
    /// <param name="S">nasycenie</param>
    public static void Rgb2Hls (double R, double G, double B, out double H, out double L, out double S)
    {
      R = Math.Max(0.0, Math.Min(1.0, R));
      G = Math.Max(0.0, Math.Min(1.0, G));
      B = Math.Max(0.0, Math.Min(1.0, B));
      double Xmin = Math.Min(Math.Min(R, G), B);
      double Xmax = Math.Max(Math.Max(R, G), B);
      L = (Xmax + Xmin) / 2.0;
      if (Xmax == Xmin)
      {
        S = 0;
        H = 0;
      }
      else
      {
        if (L < 0.5)
          S = (Xmax - Xmin) / (Xmax + Xmin);
        else
          S = (Xmax - Xmin) / (2.0 - Xmax - Xmin);
        if (R == Xmax)
          H = (G - B) / (Xmax - Xmin);
        else if (G == Xmax)
          H = 2 + (B - R) / (Xmax - Xmin);
        else
          H = 4 + (R - G) / (Xmax - Xmin);
        if (H < 0)
          H = H + 6;
        // H jest w zakresie od 0 to 6.0
        H = H * 60;
      }
    }

    /// <summary>
    /// Konwersja wartości HLS na RGB. Wszystkie wartości w skali 0-1
    /// </summary>
    /// <param name="R">składowa czerwona</param>
    /// <param name="G">składowa zielona</param>
    /// <param name="B">składowa niebieska</param>
    /// <param name="H">barwa w stopniach</param>
    /// <param name="L">jasność</param>
    /// <param name="S">nasycenie</param>
    public static void Hls2Rgb (double H, double L, double S, out double R, out double G, out double B)
    {
      H = H / 360;
      H = Math.Max(0.0, Math.Min(1.0, H));
      L = Math.Max(0.0, Math.Min(1.0, L));
      S = Math.Max(0.0, Math.Min(1.0, S));

      if (S == 0)
      {
        R = L;
        G = L;
        B = L;
      }
      else
      {
        double temp2;
        if (L < 0.5)
          temp2 = L * (1 + S);
        else
          temp2 = L + S - L * S;
        double temp1 = 2 * L - temp2;
        double temp3;
        temp3 = H + 1.0 / 3; if (temp3 > 1) temp3 = temp3 - 1;
        R = Temp3Color (temp1, temp2, temp3);
        temp3 = H;
        G = Temp3Color(temp1, temp2, temp3);
        temp3 = H - 1.0 / 3; if (temp3 < 0) temp3 = temp3 + 1;
        B = Temp3Color(temp1, temp2, temp3);
      }
    }

    /// <summary>
    /// Pomocnicza procedura dla metody <see cref="Color.Hls2Rgb"/>
    /// </summary>
    /// <param name="temp1">wartość tymczasowa 1</param>
    /// <param name="temp2">wartość tymczasowa 2</param>
    /// <param name="temp3">wartość tymczasowa 3</param>
    /// <returns></returns>
    private static double Temp3Color(double temp1, double temp2, double temp3)
    {
      if (temp3 < 1.0 / 6)
        return temp1 + (temp2 - temp1) * 6 * temp3;
      if (temp3 < 0.5)
        return temp2;
      if (temp3 < 2.0 / 3)
        return temp1 + (temp2 - temp1) * (2.0 / 3 - temp3) * 6;
      return temp1;
    }
  }
}
