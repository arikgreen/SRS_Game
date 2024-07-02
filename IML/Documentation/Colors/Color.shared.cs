using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  public partial class Color
  {
    /// <summary>
    /// Lista indeksowa znanych kolorów
    /// </summary>
    public static Dictionary<string, Color> KnownColors = 
      new Dictionary<string, Color>(StringComparer.InvariantCultureIgnoreCase)
    {
      { "auto", new Color(0x00FFFFFE)},
      { "transparent", new Color(0x00FFFFFF)},
      { "AliceBlue", new Color (0xFFF0F8FF)},
      { "AntiqueWhite", new Color (0xFFFAEBD7)},
      { "Aqua", new Color (0xFF00FFFF)},
      { "Aquamarine", new Color (0xFF7FFFD4)},
      { "Azure", new Color (0xFFF0FFFF)},
      { "Beige", new Color (0xFFF5F5DC)},
      { "Bisque", new Color (0xFFFFE4C4)},
      { "Black", new Color (0xFF000000)},
      { "BlanchedAlmond", new Color (0xFFFFFFCD)},
      { "Blue", new Color (0xFF0000FF)},
      { "BlueViolet", new Color (0xFF8A2BE2)},
      { "Brown", new Color (0xFFA52A2A)},
      { "BurlyWood", new Color (0xFFDEB887)},
      { "CadetBlue", new Color (0xFF5F9EA0)},
      { "Chartreuse", new Color (0xFF7FFF00)},
      { "Chocolate", new Color (0xFFD2691E)},
      { "Coral", new Color (0xFFFF7F50)},
      { "CornflowerBlue", new Color (0xFF6495ED)},
      { "Cornsilk", new Color (0xFFFFF8DC)},
      { "Crimson", new Color (0xFFDC143C)},
      { "Cyan", new Color (0xFF00FFFF)},
      { "DarkBlue", new Color (0xFF00008B)},
      { "DarkCyan", new Color (0xFF008B8B)},
      { "DarkGoldenrod", new Color (0xFFB8860B)},
      { "DarkGray", new Color (0xFFA9A9A9)},
      { "DarkGreen", new Color (0xFF006400)},
      { "DarkKhaki", new Color (0xFFBDB76B)},
      { "DarkMagena", new Color (0xFF8B008B)},
      { "DarkOliveGreen", new Color (0xFF556B2F)},
      { "DarkOrange", new Color (0xFFFF8C00)},
      { "DarkOrchid", new Color (0xFF9932CC)},
      { "DarkRed", new Color (0xFF8B0000)},
      { "DarkSalmon", new Color (0xFFE9967A)},
      { "DarkSeaGreen", new Color (0xFF8FBC8F)},
      { "DarkSlateBlue", new Color (0xFF483D8B)},
      { "DarkSlateGray", new Color (0xFF284F4F)},
      { "DarkTurquoise", new Color (0xFF00CED1)},
      { "DarkViolet", new Color (0xFF9400D3)},
      { "DeepPink", new Color (0xFFFF1493)},
      { "DeepSkyBlue", new Color (0xFF00BFFF)},
      { "DimGray", new Color (0xFF696969)},
      { "DodgerBlue", new Color (0xFF1E90FF)},
      { "Firebrick", new Color (0xFFB22222)},
      { "FloralWhite", new Color (0xFFFFFAF0)},
      { "ForestGreen", new Color (0xFF228B22)},
      { "Fuschia", new Color (0xFFFF00FF)},
      { "Gainsboro", new Color (0xFFDCDCDC)},
      { "GhostWhite", new Color (0xFFF8F8FF)},
      { "Gold", new Color (0xFFFFD700)},
      { "Goldenrod", new Color (0xFFDAA520)},
      { "Gray", new Color (0xFF808080)},
      { "Green", new Color (0xFF008000)},
      { "GreenYellow", new Color (0xFFADFF2F)},
      { "Honeydew", new Color (0xFFF0FFF0)},
      { "HotPink", new Color (0xFFFF69B4)},
      { "IndianRed", new Color (0xFFCD5C5C)},
      { "Indigo", new Color (0xFF4B0082)},
      { "Ivory", new Color (0xFFFFF0F0)},
      { "Khaki", new Color (0xFFF0E68C)},
      { "Lavender", new Color (0xFFE6E6FA)},
      { "LavenderBlush", new Color (0xFFFFF0F5)},
      { "LawnGreen", new Color (0xFF7CFC00)},
      { "LemonChiffon", new Color (0xFFFFFACD)},
      { "LightBlue", new Color (0xFFADD8E6)},
      { "LightCoral", new Color (0xFFF08080)},
      { "LightCyan", new Color (0xFFE0FFFF)},
      { "LightGoldenrodYellow", new Color (0xFFFAFAD2)},
      { "LightGreen", new Color (0xFF90EE90)},
      { "LightGray", new Color (0xFFD3D3D3)},
      { "LightPink", new Color (0xFFFFB6C1)},
      { "LightSalmon", new Color (0xFFFFA07A)},
      { "LightSeaGreen", new Color (0xFF20B2AA)},
      { "LightSkyBlue", new Color (0xFF87CEFA)},
      { "LightSlateGray", new Color (0xFF778899)},
      { "LightSteelBlue", new Color (0xFFB0C4DE)},
      { "LightYellow", new Color (0xFFFFFFE0)},
      { "Lime", new Color (0xFF00FF00)},
      { "LimeGreen", new Color (0xFF32CD32)},
      { "Linen", new Color (0xFFFAF0E6)},
      { "Magenta", new Color (0xFFFF00FF)},
      { "Maroon", new Color (0xFF800000)},
      { "MediumAquamarine", new Color (0xFF66CDAA)},
      { "MediumBlue", new Color (0xFF0000CD)},
      { "MediumOrchid", new Color (0xFFBA55D3)},
      { "MediumPurple", new Color (0xFF9370DB)},
      { "MediumSeaGreen", new Color (0xFF3CB371)},
      { "MediumSlateBlue", new Color (0xFF7B68EE)},
      { "MediumSpringGreen", new Color (0xFF00FA9A)},
      { "MediumTurquoise", new Color (0xFF48D1CC)},
      { "MediumVioletRed", new Color (0xFFC71570)},
      { "MidnightBlue", new Color (0xFF191970)},
      { "MCream", new Color (0xFFF5FFFA)},
      { "MistyRose", new Color (0xFFFFE4E1)},
      { "Moccasin", new Color (0xFFFFE4B5)},
      { "NavajoWhite", new Color (0xFFFFDEAD)},
      { "Navy", new Color (0xFF000080)},
      { "OldLace", new Color (0xFFFDF5E6)},
      { "Olive", new Color (0xFF808000)},
      { "OliveDrab", new Color (0xFF6B8E2D)},
      { "Orange", new Color (0xFFFFA500)},
      { "OrangeRed", new Color (0xFFFF4500)},
      { "Orchid", new Color (0xFFDA70D6)},
      { "PaleGoldenrod", new Color (0xFFEEE8AA)},
      { "PaleGreen", new Color (0xFF98FB98)},
      { "PaleTurquoise", new Color (0xFFAFEEEE)},
      { "PaleVioletRed", new Color (0xFFDB7093)},
      { "PapayaWhip", new Color (0xFFFFEFD5)},
      { "PeachPuff", new Color (0xFFFFDA9B)},
      { "Peru", new Color (0xFFCD853F)},
      { "Pink", new Color (0xFFFFC0CB)},
      { "Plum", new Color (0xFFDDA0DD)},
      { "PowderBlue", new Color (0xFFB0E0E6)},
      { "Purple", new Color (0xFF800080)},
      { "Red", new Color (0xFFFF0000)},
      { "RosyBrown", new Color (0xFFBC8F8F)},
      { "RoyalBlue", new Color (0xFF4169E1)},
      { "SaddleBrown", new Color (0xFF8B4513)},
      { "Salmon", new Color (0xFFFA8072)},
      { "SandyBrown", new Color (0xFFF4A460)},
      { "SeaGreen", new Color (0xFF2E8B57)},
      { "Seashell", new Color (0xFFFFF5EE)},
      { "Sienna", new Color (0xFFA0522D)},
      { "Silver", new Color (0xFFC0C0C0)},
      { "SkyBlue", new Color (0xFF87CEEB)},
      { "SlateBlue", new Color (0xFF6A5ACD)},
      { "SlateGray", new Color (0xFF708090)},
      { "Snow", new Color (0xFFFFFAFA)},
      { "SpringGreen", new Color (0xFF00FF7F)},
      { "SteelBlue", new Color (0xFF4682B4)},
      { "Tan", new Color (0xFFD2B48C)},
      { "Teal", new Color (0xFF008080)},
      { "Thistle", new Color (0xFFD8BFD8)},
      { "Tomato", new Color (0xFFFD6347)},
      { "Turquoise", new Color (0xFF40E0D0)},
      { "Violet", new Color (0xFFEE82EE)},
      { "Wheat", new Color (0xFFF5DEB3)},
      { "White", new Color (0xFFFFFFFF)},
      { "WhiteSmoke", new Color (0xFFF5F5F5)},
      { "Yellow", new Color (0xFFFFFF00)},
      { "YellowGreen", new Color (0xFF9ACD32)},
    };

    /// <summary>
    /// Statyczna metoda dostępu do koloru automatycznego
    /// </summary>
    public static Color Auto
    {
      get { return KnownColors["Auto"]; }
    }
    /// <summary>
    /// Statyczna metoda dostępu do koloru przezroczystego
    /// </summary>
    public static Color Transparent
    {
      get { return KnownColors["Transparent"]; }
    }
    /// <summary>
    /// Statyczna metoda dostępu do koloru czarnego
    /// </summary>
    public static Color Black
    {
      get { return KnownColors["Black"]; }
    }
    /// <summary>
    /// Statyczna metoda dostępu do koloru białego
    /// </summary>
    public static Color White
    {
      get { return KnownColors["White"]; }
    }

    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Color()
    {

    }
    /// <summary>
    /// Konstruktor inicjujący
    /// </summary>
    /// <param name="value"></param>
    private Color(uint value)
    {
      Value = (int)value;
    }

    /// <summary>
    /// Czy kolor jest pusty
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty()
    {
        return this.Value==0;
    }

    /// <summary>
    /// Czy jest to znany kolor
    /// </summary>
    public bool IsKnownColor()
    { 
      return KnownColors.FirstOrDefault(item => item.Value.Equals(this)).Key!=null; 
    }

    /// <summary>
    /// Tworzy nowy kolor z wartości całkowitej 32-bitowej
    /// </summary>
    /// <param name="argb"></param>
    /// <returns></returns>
    public static Color FromArgb (int argb)
    {
      Color result = KnownColors.FirstOrDefault(item => item.Value.Equals(argb)).Value;
      if (result != null)
        return result;
      result = new Color { Value = argb };
      return result;
    }

    /// <summary>
    /// Tworzy nowy kolor z czterech wartości składowych
    /// </summary>
    /// <param name="alpha"></param>
    /// <param name="red"></param>
    /// <param name="green"></param>
    /// <param name="blue"></param>
    /// <returns></returns>
    public static Color FromArgb (int alpha, int red, int green, int blue)
    {
      int value = (int)(alpha << 24) | (int)(red << 16) | (int)(green << 8) | (int)(blue);
      return FromArgb(value);
    }

    /// <summary>
    /// Tworzy nowy kolor z trzech wartości składowych
    /// </summary>
    /// <param name="red"></param>
    /// <param name="green"></param>
    /// <param name="blue"></param>
    /// <returns></returns>
    public static Color FromArgb (int red, int green, int blue)
    {
      return FromArgb(0xFF, red, green, blue);
    }
    
    /// <summary>
    /// Tworzy nowy kolor z innego zmieniając tylko jego kanał <c>Alpha</c>
    /// </summary>
    /// <param name="alpha">wartość kanału <c>Alpha</c></param>
    /// <param name="baseColor">kolor bazowy, na podstawie którego jest tworzony nowy kolor</param>
    /// <returns></returns>
    public static Color FromArgb (int alpha, Color baseColor)
    {
      Color result = new Color { Value = baseColor.Value };
      result.A = (byte)alpha;
      return result;
    }

    /// <summary>
    /// Podaje wartość całkowitą 32-bitową
    /// </summary>
    /// <returns></returns>
    public int ToArgb ()
    {
      return (int)A << 24 | (int)R << 16 | (int)G << 8 | (int)B;
    }

    /// <summary>
    /// Składowa <c>Alpha</c>
    /// </summary>
    public byte A 
    {
      get { return (byte)(Value >> 24); }
      set { Value |= ((int)value << 24); }
    }
    /// <summary>
    /// Składowa <c>Blue</c>
    /// </summary>
    public byte R 
    {
      get { return (byte)(Value >> 16); }
      set { Value |= ((int)value << 16); }
    }
    /// <summary>
    /// Składowa <c>Green</c>
    /// </summary>
    public byte G 
    {
      get { return (byte)(Value >> 8); }
      set { Value |= ((int)value << 8); }
    }
    /// <summary>
    /// Składowa <c>Red</c>
    /// </summary>
    public byte B 
    {
      get { return (byte)(Value); }
      set { Value |= ((int)value); }
    }

    /// <summary>
    /// Porównanie obiektów
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals (object obj)
    {
      if (obj == null)
        return false;
      if (obj is int)
        return Value == (int)obj;
      Color right = obj as Color;
      return this.A == right.A && this.B == right.B && this.G == right.G && this.R == right.R;
    }
    /// <summary>
    /// Konieczne dla porównania
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode ()
    {
      return ToArgb();
    }

    /// <summary>
    /// Dodawanie dwóch kolorów. Daje kolor pośredni
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static Color Add (Color left, Color right)
    {
      return new Color
      {
        A = (byte)(((int)left.A + (int)right.A) / 2),
        R = (byte)(((int)left.R + (int)right.R) / 2),
        G = (byte)(((int)left.G + (int)right.G) / 2),
        B = (byte)(((int)left.B + (int)right.B) / 2),
      };
    }

    /// <summary>
    /// Wiarygodna konwersja wartości rzeczywistej na bajtową (z ograniczeniem 0-255)
    /// </summary>
    /// <param name="value">wartość rzeczywista</param>
    /// <returns></returns>
    public static byte Byte (double value)
    {
      if (value < 0)
        return 0;
      if (value > 255)
        return 255;
      return (byte)value;
    }  
  }
}
