using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TextVerticalType")]
  public enum TextVerticalValues
  {
    [EnumString("horz")]
    Horz,
    [EnumString("vert")]
    Vert,
    [EnumString("vert270")]
    Vert270,
    [EnumString("wordArtVert")]
    WordArtVert,
    [EnumString("eaVert")]
    EaVert,
    [EnumString("mongolianVert")]
    MongolianVert,
    [EnumString("wordArtVertRtl")]
    WordArtVertRtl,
  }
}
