using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("bulletEnabled")]
  [Alias("BulletEnabled")]
  public class BulletEnabled
  {
    [Tag("boolean")]
    Boolean Val{ get; set; }

  }
}
