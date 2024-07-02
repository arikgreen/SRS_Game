using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Wordprocessing
{
  [Tag("anchor")]
  [Alias("Anchor")]
  public class Anchor
  {
    [Tag("wrapDistance")]
    WrapDistanceValue DistT{ get; set; }

    [Tag("wrapDistance")]
    WrapDistanceValue DistB{ get; set; }

    [Tag("wrapDistance")]
    WrapDistanceValue DistL{ get; set; }

    [Tag("wrapDistance")]
    WrapDistanceValue DistR{ get; set; }

    [Tag("boolean")]
    Boolean SimplePos{ get; set; }

    [Tag("unsignedInt")]
    UInt32 RelativeHeight{ get; set; }

    [Tag("boolean")]
    Boolean BehindDoc{ get; set; }

    [Tag("boolean")]
    Boolean Locked{ get; set; }

    [Tag("boolean")]
    Boolean LayoutInCell{ get; set; }

    [Tag("boolean")]
    Boolean Hidden{ get; set; }

    [Tag("boolean")]
    Boolean AllowOverlap{ get; set; }

  }
}
