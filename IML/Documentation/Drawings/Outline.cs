using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Element reprezentujący obwiednię kształtu
  /// </summary>
  public partial class Outline: Item
  {
    /// <summary>
    /// Identyfikator nie jest serializowany
    /// </summary>
    [DefaultValue(null)]
    public override string Id
    {
      get
      {
        return null;
      }
      set
      {
        base.Id = value;
      }
    }
    /// <summary>
    /// Wyrównanie linii względem kształtu
    /// </summary>
    [DefaultValue(null)]
    public LineAlignmentType LineAlignment { get; set; }

    /// <summary>
    /// Sposoby zakończenia linii
    /// </summary>
    [DefaultValue(null)]
    public LineCapType LineCap { get; set; }

    /// <summary>
    /// Rodzaje linii złożonej (podwójnej, potrójnej)
    /// </summary>
    [DefaultValue(null)]
    public CompoundLineType CompoundLine { get; set; }

    /// <summary>
    /// Grubość linii
    /// </summary>
    [DefaultValue(null)]
    public PointValue Width { get; set; }

    /// <summary>
    /// Wypełnienie obwiedni
    /// </summary>
    [DefaultValue(null)]
    public Fill Fill { get; set; }

    /// <summary>
    /// Styl rysowania linii
    /// </summary>
    [DefaultValue(null)]
    public string LineStyle { get; set; }

    /// <summary>
    /// Zakończenie rozpoczynające linię
    /// </summary>
    [DefaultValue(null)]
    public LineEnding SourceEnding { get; set; }

    /// <summary>
    /// Zakończenie kończące linię
    /// </summary>
    [DefaultValue(null)]
    public LineEnding TargetEnding { get; set; }
  }
}
