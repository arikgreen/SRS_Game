using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("p")]
  [Alias("P")]
  public class Paragraph
  {
    [Tag("longHexNumber")]
    LongHexNumberValue RsidRPr{ get; set; }

    [Tag("longHexNumber")]
    LongHexNumberValue RsidR{ get; set; }

    [Tag("longHexNumber")]
    LongHexNumberValue RsidDel{ get; set; }

    [Tag("longHexNumber")]
    LongHexNumberValue RsidP{ get; set; }

    [Tag("longHexNumber")]
    LongHexNumberValue RsidRDefault{ get; set; }

  }
}
