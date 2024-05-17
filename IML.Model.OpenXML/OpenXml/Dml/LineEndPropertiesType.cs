using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("lineEndProperties")]
  [Alias("LineEndProperties")]
  public class LineEndPropertiesType
  {
    [Tag("lineEndType")]
    LineEndValues Type{ get; set; }

    [Tag("lineEndWidth")]
    LineEndWidthValues W{ get; set; }

    [Tag("lineEndLength")]
    LineEndLengthValues Len{ get; set; }

  }
}
