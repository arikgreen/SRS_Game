using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Wordprocessing
{
  [Tag("wrapTight")]
  [Alias("WrapTight")]
  public class WrapTight
  {
    [Tag("wrapText")]
    WrapTextValues WrapText{ get; set; }

    [Tag("wrapDistance")]
    WrapDistanceValue DistL{ get; set; }

    [Tag("wrapDistance")]
    WrapDistanceValue DistR{ get; set; }

  }
}
