using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("numRestart")]
  [Alias("NumRestart")]
  public class NumberingRestart
  {
    [Tag("restartNumber")]
    RestartNumberValues Val{ get; set; }

  }
}
