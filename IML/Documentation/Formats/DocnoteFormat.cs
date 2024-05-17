using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
  /// <summary>
  /// Format przypisu
  /// </summary>
  public partial class DocnoteFormat: Format
  {
    /// <summary>
    /// Typ formatu
    /// </summary>
    public override FormatType Type
    {
      get { return FormatType.Docnote; }
    }

    /// <summary>
    /// Położenie przypisu
    /// </summary>
    [DefaultValue(null)]
    public DocnotePosition? Position { get; set; }

    /// <summary>
    /// Format numerowania
    /// </summary>
    [DefaultValue(null)]
    public string NumberingFormat { get; set; }

    /// <summary>
    /// Sposób numerowania
    /// </summary>
    [DefaultValue(null)]
    public DocnoteNumbering? Numbering { get; set; }

    /// <summary>
    /// Początek numerowania
    /// </summary>
    [DefaultValue(null)]
    public int NumberingStart { get; set; }
  }
}
