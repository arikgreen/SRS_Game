using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("dashStop")]
  [Alias("DashStop")]
  public class DashStop
  {
    [Tag("positivePercentage")]
    PositivePercentageValue D{ get; set; }

    [Tag("positivePercentage")]
    PositivePercentageValue Sp{ get; set; }

  }
}
