using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("presetColor")]
  [Alias("PresetColor")]
  public class PresetColor
  {
    [Tag("presetColorVal")]
    PresetColorValues Val{ get; set; }

  }
}
