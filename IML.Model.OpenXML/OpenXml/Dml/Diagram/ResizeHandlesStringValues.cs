using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("ResizeHandlesStr")]
  public enum ResizeHandlesStringValues
  {
    [EnumString("exact")]
    Exact = 0,
    [EnumString("rel")]
    Rel,
  }
}
