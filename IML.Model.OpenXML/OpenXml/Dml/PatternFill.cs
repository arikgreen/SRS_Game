using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("textField")]
  [Alias("TextField")]
  public class PatternFill
  {
    [Tag("guid")]
    Guid Id{ get; set; }

    [Tag("string")]
    String Type{ get; set; }

  }
}
