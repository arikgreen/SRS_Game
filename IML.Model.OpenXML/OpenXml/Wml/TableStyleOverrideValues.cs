using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("TblStyleOverrideType")]
  public enum TableStyleOverrideValues
  {
    [EnumString("wholeTable")]
    WholeTable = 0,
    [EnumString("firstRow")]
    FirstRow = 1,
    [EnumString("lastRow")]
    LastRow = 2,
    [EnumString("firstCol")]
    FirstCol,
    [EnumString("lastCol")]
    LastCol,
    [EnumString("band1Vert")]
    Band1Vert,
    [EnumString("band2Vert")]
    Band2Vert,
    [EnumString("band1Horz")]
    Band1Horz,
    [EnumString("band2Horz")]
    Band2Horz,
    [EnumString("neCell")]
    NeCell,
    [EnumString("nwCell")]
    NwCell,
    [EnumString("seCell")]
    SeCell,
    [EnumString("swCell")]
    SwCell,
  }
}
