using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace Iml.Documentation.VML
{
  /// <summary>
  /// Formuła obliczeniowa dla grafiki VML
  /// </summary>
  [ContentProperty("Equation")]
  public partial class Formula: Iml.Foundation.Item
  {
    /// <summary>
    /// Równanie w postaci tekstowej
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [DefaultValue(null)]
    public string Equation { get; set; }
  }
}
