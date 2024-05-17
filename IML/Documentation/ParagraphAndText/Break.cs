using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Element tekstowy oznaczający złamanie akapitu
  /// </summary>
  public partial class Break: TextItem
  {
    /// <summary>
    /// Typ podziału
    /// </summary>
    [DefaultValue(null)]
    public BreakType? Type { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [DefaultValue(null)]
    public BreakLocation? Location { get; set; }

    /// <summary>
    /// Podaje znak odstępu
    /// </summary>
    /// <returns></returns>
    public override string GetString()
    {
      return null;
    }

    /// <summary>
    /// Element nie jest pusty
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return false;
    }

    /// <summary>
    /// Stały skrót
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      return "BrEak".GetHashCode();
    }
  }
}
