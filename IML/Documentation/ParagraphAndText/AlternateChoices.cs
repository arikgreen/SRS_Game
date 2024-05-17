using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Lista wyboru elementu <see cref="AlternateContent"/>
  /// </summary>
  public partial class AlternateChoices: ItemList<AlternateChoice>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public AlternateChoices(): base() {}

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public AlternateChoices (Item owner) : base(owner) { }
  }
}
