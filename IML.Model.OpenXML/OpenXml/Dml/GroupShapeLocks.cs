using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("groupLocking")]
  [Alias("GroupLocking")]
  public class GroupShapeLocks
  {
    [Tag("boolean")]
    Boolean NoGrp{ get; set; }

    [Tag("boolean")]
    Boolean NoUngrp{ get; set; }

    [Tag("boolean")]
    Boolean NoSelect{ get; set; }

    [Tag("boolean")]
    Boolean NoRot{ get; set; }

    [Tag("boolean")]
    Boolean NoChangeAspect{ get; set; }

    [Tag("boolean")]
    Boolean NoMove{ get; set; }

    [Tag("boolean")]
    Boolean NoResize{ get; set; }

  }
}
