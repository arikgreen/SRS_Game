using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Wordprocessing
{
  [Tag("wrapSquare")]
  [Alias("WrapSquare")]
  public class WrapSquare
  {
    [Tag("wrapText")]
    WrapTextValues WrapText{ get; set; }

    [Tag("wrapDistance")]
    WrapDistanceValue DistT{ get; set; }

    [Tag("wrapDistance")]
    WrapDistanceValue DistB{ get; set; }

    [Tag("wrapDistance")]
    WrapDistanceValue DistL{ get; set; }

    [Tag("wrapDistance")]
    WrapDistanceValue DistR{ get; set; }

  }
}
