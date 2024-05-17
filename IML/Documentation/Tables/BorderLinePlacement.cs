using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Umiejscowienie linii obramowania
  /// </summary>
  [Flags]
  public enum BorderLinePlacement
  {
    /// <summary>
    /// Na lewej krawędzi tabeli/komórki/akapitu
    /// </summary>
    Left = 1,
    /// <summary>
    /// Na górnej krawędzi tabeli/komórki, przed podobnymi akapitami
    /// </summary>
    Top = 2,
    /// <summary>
    /// Na prawej krawędzi tabeli/komórki/akapitu
    /// </summary>
    Right = 4,
    /// <summary>
    /// Na dolnej krawędzi tabeli/komórki, po podobnych akapitach
    /// </summary>
    Bottom = 8,
    /// <summary>
    /// Dookoła
    /// </summary>
    Frame = 0xF,
    /// <summary>
    /// Wewnątrz pionowo (między kolumnami tabeli)
    /// </summary>
    InsideVertical = 16,
    /// <summary>
    /// Wewnątrz poziomo (między wierszami tabeli)
    /// </summary>
    InsideHorizontal = 32,
    /// <summary>
    /// Linie wewnętrzne
    /// </summary>
    InsideLines = 0x30,
    /// <summary>
    /// Na wszystkich krawędziach siatki
    /// </summary>
    Grid = 0x3F,
    /// <summary>
    /// Na krawędzi rozpoczynającej tabelę/komórkę (u nas na lewej krawędzi)
    /// </summary>
    Start = 64,
    /// <summary>
    /// Na krawędzi kończącej tabelę/komórkę (u nas na prawej krawędzi)
    /// </summary>
    End = 128,
    /// <summary>
    /// Po przekątnej "\" komórki
    /// </summary>
    Diagonal = 256,
    /// <summary>
    /// Po przekątnej "/" komórki
    /// </summary>
    BackDiagonal = 512,
    /// <summary>
    /// Pomiędzy podobnymi akapitami
    /// </summary>
    BetweenSameParagraphs = 1024,
    /// <summary>
    /// Pomiędzy sąsiadującymi stronami
    /// </summary>
    BetweenFacingPages = 2048,
  }
}
