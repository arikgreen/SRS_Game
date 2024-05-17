using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("dispBlanksAs")]
  [Alias("DispBlanksAs")]
  public class DisplayBlanksAs
  {
    [Tag("dispBlanksAs")]
    DisplayBlanksAsValues Val{ get; set; }

  }
}
