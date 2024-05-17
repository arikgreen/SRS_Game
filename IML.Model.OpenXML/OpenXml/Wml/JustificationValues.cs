using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("Jc")]
  public enum JustificationValues
  {
    [EnumString("start")]
    Start = 1,
    [EnumString("center")]
    Center = 2,
    [EnumString("end")]
    End = 4,
    [EnumString("both")]
    Both = 5,
    [EnumString("mediumKashida")]
    MediumKashida = 6,
    [EnumString("distribute")]
    Distribute = 7,
    [EnumString("numTab")]
    NumTab = 8,
    [EnumString("highKashida")]
    HighKashida = 9,
    [EnumString("lowKashida")]
    LowKashida = 10,
    [EnumString("thaiDistribute")]
    ThaiDistribute = 11,
  }
}
