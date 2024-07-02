using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Definicja czcionki w dokumencie
  /// </summary>
  public partial class Font: Item
  {
    /// <summary>
    /// Skrót obliczany na podstawie zawartości
    /// </summary>
    public override int GetHash()
    {
      int hash = (Typeface + Script + Panose).GetHashCode();
      if (CharacterSet!=null)
        hash += (int)CharacterSet;
      if (PitchFamily != null)
        hash += (int)PitchFamily;
      return hash;
    }

    /// <summary>
    /// Zbiór znaków
    /// </summary>
    [DefaultValue(null)]
    public int? CharacterSet { get; set; }
    /// <summary>
    /// Krój czcionki
    /// </summary>
    [DefaultValue(null)]
    public string Typeface { get; set; }
    /// <summary>
    /// Identyfikator Panose
    /// </summary>
    [DefaultValue(null)]
    public string Panose { get; set; }
    /// <summary>
    /// Rodzina rastrowa
    /// </summary>
    [DefaultValue(null)]
    public int? PitchFamily { get; set; }
    /// <summary>
    /// Skrypt
    /// </summary>
    [DefaultValue(null)]
    public string Script { get; set; }
  }
}
