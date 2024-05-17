using Iml.Documentation.Drawings;
using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  /// <summary>
  /// Abstrakcyjne przekształcenie składowej koloru
  /// </summary>
  public abstract class ColorMemberTransformation: ColorTransformation
  {
    /// <summary>
    /// Która składowa jest przekształcana
    /// </summary>
    [DefaultValue(null)]
    public ColorMembers Member { get; set; }
    /// <summary>
    /// Wartość przekształcenia w procentach
    /// </summary>
    [DefaultValue(null)]
    public Percent Value { get; set; }
    /// <summary>
    /// Wartość przekształcenia w stopniach
    /// </summary>
    [DefaultValue(null)]
    public Angle Angle { get; set; }

  }
}
