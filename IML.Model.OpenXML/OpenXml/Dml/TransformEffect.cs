using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("transformEffect")]
  [Alias("TransformEffect")]
  public class TransformEffect
  {
    [Tag("percentage")]
    PercentageValue Sx{ get; set; }

    [Tag("percentage")]
    PercentageValue Sy{ get; set; }

    [Tag("fixedAngle")]
    FixedAngleValue Kx{ get; set; }

    [Tag("fixedAngle")]
    FixedAngleValue Ky{ get; set; }

    [Tag("coordinate")]
    CoordinateValue Tx{ get; set; }

    [Tag("coordinate")]
    CoordinateValue Ty{ get; set; }

  }
}
