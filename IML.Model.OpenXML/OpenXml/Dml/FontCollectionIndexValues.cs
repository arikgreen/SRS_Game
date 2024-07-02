using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("FontCollectionIndex")]
  public enum FontCollectionIndexValues
  {
    [EnumString("major")]
    Major = 0,
    [EnumString("minor")]
    Minor = 1,
    [EnumString("none")]
    None = 2,
  }
}
