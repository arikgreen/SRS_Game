using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [Tag("script")]
  [Alias("Script")]
  public class Script
  {
    [Tag("script")]
    ScriptValues Val{ get; set; }

  }
}
