using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("FFTextType")]
  public enum TextBoxFormFieldValues
  {
    [EnumString("regular")]
    Regular = 0,
    [EnumString("number")]
    Number = 1,
    [EnumString("date")]
    Date = 2,
    [EnumString("currentTime")]
    CurrentTime = 3,
    [EnumString("currentDate")]
    CurrentDate = 4,
    [EnumString("calculated")]
    Calculated = 5,
  }
}
