using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("nonVisualContentPartProperties")]
  [Alias("NonVisualContentPartProperties")]
  public class NonVisualContentPartPropertiesType
  {
    [Tag("boolean")]
    Boolean IsComment{ get; set; }

  }
}
