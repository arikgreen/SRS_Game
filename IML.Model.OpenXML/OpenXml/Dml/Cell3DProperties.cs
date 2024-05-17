using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("cell3D")]
  [Alias("Cell3D")]
  public class Cell3DProperties
  {
    [Tag("presetMaterialType")]
    PresetMaterialTypeValues PrstMaterial{ get; set; }

  }
}
