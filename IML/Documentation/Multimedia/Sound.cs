using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Multimedia
{
  /// <summary>
  /// Element dźwiękowy w dokumencie
  /// </summary>
  public partial class Sound
  {
    /// <summary>
    /// Nazwa dźwięku
    /// </summary>
    [DefaultValue(null)]
    public string Name { get; set; }
    /// <summary>
    /// Relacja do pliku dźwiękowego
    /// </summary>
    [DefaultValue(null)]
    public string TargetRel { get; set; }
  }
}
