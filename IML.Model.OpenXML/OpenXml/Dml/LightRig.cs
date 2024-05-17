using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("lightRig")]
  [Alias("LightRig")]
  public class LightRig
  {
    [Tag("lightRigType")]
    LightRigValues Rig{ get; set; }

    [Tag("lightRigDirection")]
    LightRigDirectionValues Dir{ get; set; }

  }
}
