using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [Tag("string")]
  [Alias("String")]
  public class StrikeHorizontal
  {
    [Tag("string")]
    String Val{ get; set; }

  }
}
