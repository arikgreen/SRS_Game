using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Blokady nakładane na element graficzny (ramkę)
  /// </summary>
  [Flags]
  public enum DrawingLocks
  {
    /// <summary>
    /// Zabroniona zmiana współczynnika aspektu
    /// </summary>
    NoAspectChange = 1,
    /// <summary>
    /// Zabroniony wybór elementów składowych
    /// </summary>
    NoItemsSelection = 2,
    /// <summary>
    /// Zabronione grupowanie
    /// </summary>
    NoGrouping = 4,
    /// <summary>
    /// Zabronione przesuwanie
    /// </summary>
    NoMove = 8,
    /// <summary>
    /// Zabroniona zmiana rozmiaru
    /// </summary>
    NoResize = 16,
    /// <summary>
    /// Zabroniony wybór elementu
    /// </summary>
    NoSelection = 32,
    /// <summary>
    /// Zabronione dopasowywanie uchwytów
    /// </summary>
    NoHandleAdjustment = 64,
    /// <summary>
    /// Zabroniona zmiana strzałek (zakończeń linii)
    /// </summary>
    NoLineEndChange = 128,
    /// <summary>
    /// Zabroniona zmiana typu kształtu
    /// </summary>
    NoShapeChange = 0x100,
    /// <summary>
    /// Zabronione przycinanie elementu
    /// </summary>
    NoCrop = 0x200,
    /// <summary>
    /// Zabroniona edycja punktów
    /// </summary>
    NoPointsEdit = 0x400,
    /// <summary>
    /// Zabroniona rotacja elementu
    /// </summary>
    NoRotation = 0x800,
    /// <summary>
    /// Zabroniona edycja tekstu
    /// </summary>
    NoTextEdit = 0x1000,
  }
}
