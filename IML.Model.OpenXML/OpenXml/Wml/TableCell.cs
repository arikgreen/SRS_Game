using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("tc")]
  [Alias("Tc")]
  public class TableCell
  {
    [Tag("string")]
    String Id{ get; set; }

  }
}
