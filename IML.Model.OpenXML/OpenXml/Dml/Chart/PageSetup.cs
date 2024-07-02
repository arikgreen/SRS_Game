using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("pageSetup")]
  [Alias("PageSetup")]
  public class PageSetup
  {
    [Tag("unsignedInt")]
    UInt32 PaperSize{ get; set; }

    [Tag("positiveUniversalMeasure")]
    PositiveUniversalMeasureValue PaperHeight{ get; set; }

    [Tag("positiveUniversalMeasure")]
    PositiveUniversalMeasureValue PaperWidth{ get; set; }

    [Tag("unsignedInt")]
    UInt32 FirstPageNumber{ get; set; }

    [Tag("pageSetupOrientation")]
    PageSetupOrientationValues Orientation{ get; set; }

    [Tag("boolean")]
    Boolean BlackAndWhite{ get; set; }

    [Tag("boolean")]
    Boolean Draft{ get; set; }

    [Tag("boolean")]
    Boolean UseFirstPageNumber{ get; set; }

    [Tag("int")]
    Int32 HorizontalDpi{ get; set; }

    [Tag("int")]
    Int32 VerticalDpi{ get; set; }

    [Tag("unsignedInt")]
    UInt32 Copies{ get; set; }

  }
}
