using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("officeStyleSheet")]
  [Alias("OfficeStyleSheet")]
  public class EffectStyleList
  {
    [Tag("string")]
    String Name{ get; set; }

  }
}
