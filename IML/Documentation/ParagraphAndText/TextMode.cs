using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IML = Iml.Documentation;

namespace Iml.Documentation
{

  /// <summary>
  /// Typ reprezentujący tryb kodowania fragmentu tekstowego
  /// </summary>
  [Flags]
  public enum TextMode
  {
    /// <summary>
    /// czy tekst może być zakodowany w trybie tekstowym
    /// </summary>
    TextEnabled = 0x0001,

    /// <summary>
    /// czy tekst może być zakodowany w trybie matematycznym
    /// </summary>
    MathEnabled = 0x0002,   

    /// <summary>
    /// czy wybrano tryb matematyczny
    /// </summary>
    IsMath = 0x0004,
  }

    ///// <summary>
    ///// Inicjalizacja struktury przez wartość.
    ///// </summary>
    ///// <param name="value">wartość początkowa</param>
    //public TextMode(byte value) { Modes = value; }

    ///// <summary>
    ///// Kopiowanie struktury.
    ///// </summary>
    ///// <param name="obj">obiekt, z którego bity trybu są kopiowane</param>
    //public TextMode(TextMode obj) 
    //{ 
    //  Modes = obj.Modes; 
    //}
  
    ///// <summary>
    ///// Czyszczenie atrybutów
    ///// </summary>
    //public void Clear()
    //{
    //  Modes = 0;
    //}

  /// <summary>
  /// Operacje dostępowe do typu TextMode
  /// </summary>
  public static class TextModeUtilities
  {
    /// <summary>
    /// Metoda dostępowa do trybu IsTextEnabled
    /// </summary>
    public static bool IsTextEnabled(this IML.TextRun aRange)
    {
      return aRange.Mode.HasFlag(TextMode.TextEnabled);
    }

    /// <summary>
    /// Metoda zapisu do trybu IsTextEnabled
    /// </summary>
    public static void SetTextEnabled (this IML.TextRun aRange, bool value)
    {
      if (value)
        aRange.Mode |= TextMode.TextEnabled;
      else
        aRange.Mode = (TextMode)((byte)aRange.Mode & unchecked((byte)(~TextMode.TextEnabled)));
    }

    /// <summary>
    /// Metoda dostępowa do trybu IsMathEnabled
    /// </summary>
    public static bool IsMathEnabled(this IML.TextRun aRange)
    {
      return aRange.Mode.HasFlag(TextMode.MathEnabled);
    }

    /// <summary>
    /// Metoda zapisu do trybu IsMathEnabled
    /// </summary>
    public static void SetMathEnabled(this IML.TextRun aRange, bool value)
    {
      if (value)
        aRange.Mode |= TextMode.MathEnabled;
      else
        aRange.Mode = (TextMode)((byte)aRange.Mode & unchecked((byte)(~TextMode.MathEnabled)));
    }

    /// <summary>
    /// Metoda dostępowa do trybu IsMath
    /// </summary>
    public static bool IsMath (this IML.TextRun aRange)
    {
      return aRange.Mode.HasFlag(TextMode.IsMath);
    }

    /// <summary>
    /// Metoda zapisu do trybu IsMath
    /// </summary>
    public static void SetMath(this IML.TextRun aRange, bool value)
    {
      if (value)
        aRange.Mode |= TextMode.IsMath;
      else
        aRange.Mode = (TextMode)((byte)aRange.Mode & unchecked((byte)(~TextMode.IsMath)));

    }

  }
}
