using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [Tag("char")]
  [Alias("Char")]
  public class CharType
  {
    [Tag("char")]
    CharValue Val{ get; set; }

  }
}
