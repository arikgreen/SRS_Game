using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("pictureLocking")]
  [Alias("PictureLocking")]
  public class PictureLocks
  {
    [Tag("boolean")]
    Boolean NoCrop{ get; set; }

  }
}
