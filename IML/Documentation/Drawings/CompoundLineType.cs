using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{

  /// <summary>
  /// Typ linii złożonej
  /// </summary>
  public enum CompoundLineType
  {
    /// <summary>
    /// Linia pojedyncza
    /// </summary>
    Single,
    /// <summary>
    /// Linia podwójna
    /// </summary>
    Double,
    /// <summary>
    /// Podwójna gruba-cienka
    /// </summary>
    ThickThin,
    /// <summary>
    /// Podwójna cienka-gruba
    /// </summary>
    ThinThick,
    /// <summary>
    /// Potrójna
    /// </summary>
    Triple,
  }
}
