using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("textSpacingPercent")]
  [Alias("TextSpacingPercent")]
  public class TextSpacingPercentOrPercentStringValue
  {
    [Tag("textSpacingPercentOrPercentString")]
    TextSpacingPercentOrPercentStringValue Val{ get; set; }

  }
}
