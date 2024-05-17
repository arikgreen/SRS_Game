using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.VML
{
  /// <summary>
  /// Blokady nakładane na element graficzny (kształt)
  /// </summary>
  [Flags]
  public enum Locks
  {
    //adjusthandles (Handles Lock)
    /// <summary>
    /// Blokada uchwytów kształtu
    /// </summary>
    AdjustHandles = 1,
    //aspectratio (Aspect Ratio Lock)
    /// <summary>
    /// Blokada współczynnika proporcji
    /// </summary>
    AspectRatio = 2,
    //cropping (Cropping Lock)
    /// <summary>
    /// Blokada przycinania
    /// </summary>
    Cropping = 4,
    //ext (VML Extension Handling Behavior)
    /// <summary>
    /// blokada rozszerzonego zachowania uchwytów
    /// </summary>
    Ext = 8,
    //grouping (Grouping Lock)
    /// <summary>
    /// Blokada grupowania
    /// </summary>
    Grouping = 16,
    //position (Position Lock)
    /// <summary>
    /// Blokada pozycji
    /// </summary>
    Position = 32,
    //rotation (Rotation Lock)
    /// <summary>
    /// Blokada rotacji
    /// </summary>
    Rotation = 64,
    //selection (Selection Lock)
    /// <summary>
    /// Blokada wybierania
    /// </summary>
    Selection = 128,
    //shapetype (AutoShape Type Lock)
    /// <summary>
    /// Blokada zmiany kształtu
    /// </summary>
    ShapeType = 0x100,
    //text (Text Lock)
    /// <summary>
    /// Blokada tekstu
    /// </summary>
    Text = 0x200,
    //ungrouping (Ungrouping Lock)
    /// <summary>
    /// Blokada rozgrupowania
    /// </summary>
    Ungrouping = 0x400,
    //verticies (Vertices Lock)
    /// <summary>
    /// Blokada wierzchołków
    /// </summary>
    Verticies = 0x800,
  }
}
