using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("EdGrp")]
  public enum RangePermissionEditingGroupValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("everyone")]
    Everyone = 1,
    [EnumString("administrators")]
    Administrators = 2,
    [EnumString("contributors")]
    Contributors = 3,
    [EnumString("editors")]
    Editors = 4,
    [EnumString("owners")]
    Owners = 5,
    [EnumString("current")]
    Current = 6,
  }
}
