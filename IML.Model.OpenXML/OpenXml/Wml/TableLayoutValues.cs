using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("TblLayoutType")]
  public enum TableLayoutValues
  {
    [EnumString("fixed")]
    Fixed = 0,
    [EnumString("autofit")]
    Autofit = 1,
  }
}
