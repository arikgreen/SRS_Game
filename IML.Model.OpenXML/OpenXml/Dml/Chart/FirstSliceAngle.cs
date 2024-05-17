using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("firstSliceAng")]
  [Alias("FirstSliceAng")]
  public class FirstSliceAngle
  {
    [Tag("firstSliceAng")]
    FirstSliceAngValue Val{ get; set; }

  }
}
