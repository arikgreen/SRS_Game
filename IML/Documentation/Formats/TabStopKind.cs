using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Typ tabulatora
  /// </summary>
  public enum TabStopKind
  {
    /// <summary>brak tabulatora</summary>
    Clear,    
    /// <summary>lewy</summary>
    Left,
    /// <summary>początkowy (z uwzględnieniem dwukierunkowości)</summary>
    Start,
    /// <summary>środkowy</summary>
    Center,
    /// <summary>prawy</summary>
    Right,
    /// <summary>koncowy (z uwzględnieniem dwukierunkowości)</summary>
    End,
    /// <summary>dziesiętny</summary>
    Decimal,
    /// <summary>pionowy</summary>
    Bar,
    /// <summary>numeryczny</summary>
    Number,
  }
}
