using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("row")]
  [Alias("Row")]
  public class TopBorder
  {
    [Tag("longHexNumber")]
    LongHexNumberValue RsidRPr{ get; set; }

    [Tag("longHexNumber")]
    LongHexNumberValue RsidR{ get; set; }

    [Tag("longHexNumber")]
    LongHexNumberValue RsidDel{ get; set; }

    [Tag("longHexNumber")]
    LongHexNumberValue RsidTr{ get; set; }

  }
}
