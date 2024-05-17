using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Iml.Modeling
{
  /// <summary>
  /// Krotność elementu
  /// </summary>
  public abstract partial class MultiplicityElement: ModelElement
  {
    /// <summary>
    /// Czy elementy są uporządkowane
    /// </summary>
    [DefaultValue(false)]
    public Boolean IsOrdered { get; set; }

    /// <summary>
    /// Czy elementy są unikatowe
    /// </summary>
    [DefaultValue(true)]
    public Boolean IsUnique { get; set; }

    /// <summary>
    /// Dolna granica krotności
    /// </summary>
    [DefaultValue(1)]
    public Integer Lower { get; set; }

    /// <summary>
    /// Górna granica krotności
    /// </summary>
    [DefaultValue(1)]
    public UnlimitedNatural Upper { get; set; }
  }
}
