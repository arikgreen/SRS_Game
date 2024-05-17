using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("sizeRepresents")]
  [Alias("SizeRepresents")]
  public class SizeRepresents
  {
    [Tag("sizeRepresents")]
    SizeRepresentsValues Val{ get; set; }

  }
}
