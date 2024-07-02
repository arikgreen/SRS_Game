using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("StyleType")]
  public enum StyleValues
  {
    [EnumString("paragraph")]
    Paragraph = 0,
    [EnumString("character")]
    Character = 1,
    [EnumString("table")]
    Table = 2,
    [EnumString("numbering")]
    Numbering = 3,
  }
}
