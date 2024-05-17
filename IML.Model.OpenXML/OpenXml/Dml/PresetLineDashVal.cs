using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml.Dml
{
  [Tag("presetLineDashProperties")]
  [Alias("PresetLineDashProperties")]
  public class PresetLineDashVal
  {
    [Tag("presetLineDashVal")]
    PresetLineDashValues Val{ get; set; }

  }
}
