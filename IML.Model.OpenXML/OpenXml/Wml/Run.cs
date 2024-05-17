using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("r")]
  [Alias("R")]
  public class Run
  {
    [Tag("longHexNumber")]
    LongHexNumberValue RsidRPr{ get; set; }

    [Tag("longHexNumber")]
    LongHexNumberValue RsidDel{ get; set; }

    [Tag("longHexNumber")]
    LongHexNumberValue RsidR{ get; set; }

  }
}
