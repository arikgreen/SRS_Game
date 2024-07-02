using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("textDirection")]
  [Alias("TextDirection")]
  public class TextDirection
  {
    [Tag("textDirection")]
    TextDirectionValues Val{ get; set; }

  }
}
