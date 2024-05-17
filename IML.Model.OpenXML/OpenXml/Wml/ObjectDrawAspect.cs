using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("ObjectDrawAspect")]
  public enum ObjectDrawAspect
  {
    [EnumString("content")]
    Content,
    [EnumString("icon")]
    Icon,
  }
}
