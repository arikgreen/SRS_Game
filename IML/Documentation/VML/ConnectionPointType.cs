using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.VML
{
  /// <summary>
  /// Typ punktu połączenia segmentów linii
  /// </summary>
  public enum ConnectionPointType
  {
    // Summary:
    //     No.
    //     When the item is serialized out as xml, its value is "none".
    /// <summary>
    /// Brak specjalnego punktu połączenia
    /// </summary>
    //EnumString("none")]
    None = 0,
    //
    // Summary:
    //     Four Connections.
    //     When the item is serialized out as xml, its value is "rect".
    /// <summary>
    /// Połączenie w formie prostokąta
    /// </summary>
    //EnumString("rect")]
    Rectangle = 1,
    //
    // Summary:
    //     Edit Point Connections.
    //     When the item is serialized out as xml, its value is "segments".
    /// <summary>
    /// ??? 
    /// </summary>
    //EnumString("segments")]
    Segments = 2,
    //
    // Summary:
    //     Custom Connections.
    //     When the item is serialized out as xml, its value is "custom".
    /// <summary>
    /// ???
    /// </summary>
    //EnumString("custom")]
    Custom = 3,
  }
}
