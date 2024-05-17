using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("PageBorderDisplay")]
  public enum PageBorderDisplayValues
  {
    [EnumString("allPages")]
    AllPages = 0,
    [EnumString("firstPage")]
    FirstPage = 1,
    [EnumString("notFirstPage")]
    NotFirstPage = 2,
  }
}
