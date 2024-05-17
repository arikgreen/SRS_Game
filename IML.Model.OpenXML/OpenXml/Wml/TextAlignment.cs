using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("textAlignment")]
  [Alias("TextAlignment")]
  public class TextAlignment
  {
    [Tag("textAlignment")]
    VerticalTextAlignmentValues Val{ get; set; }

  }
}
