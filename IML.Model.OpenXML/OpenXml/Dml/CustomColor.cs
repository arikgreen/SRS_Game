using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("customColor")]
  [Alias("CustomColor")]
  public class CustomColor
  {
    [Tag("string")]
    String Name{ get; set; }

  }
}
