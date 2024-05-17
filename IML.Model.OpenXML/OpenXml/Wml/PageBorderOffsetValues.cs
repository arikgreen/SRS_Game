using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("PageBorderOffset")]
  public enum PageBorderOffsetValues
  {
    [EnumString("page")]
    Page = 0,
    [EnumString("text")]
    Text = 1,
  }
}
