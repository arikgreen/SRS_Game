using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("SdtDateMappingType")]
  public enum DateFormatValues
  {
    [EnumString("text")]
    Text = 0,
    [EnumString("date")]
    Date = 1,
    [EnumString("dateTime")]
    DateTime = 2,
  }
}
