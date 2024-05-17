using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("InfoTextType")]
  public enum InfoTextValues
  {
    [EnumString("text")]
    Text = 0,
    [EnumString("autoText")]
    AutoText = 1,
  }
}
