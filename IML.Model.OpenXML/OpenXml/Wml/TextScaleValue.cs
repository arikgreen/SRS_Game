using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("textScale")]
  [Alias("TextScale")]
  public class TextScaleValue
  {
    [Tag("textScale")]
    TextScaleValue Val{ get; set; }

  }
}
