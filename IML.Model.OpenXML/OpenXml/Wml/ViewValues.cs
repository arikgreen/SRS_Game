using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("View")]
  public enum ViewValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("print")]
    Print = 1,
    [EnumString("outline")]
    Outline = 2,
    [EnumString("masterPages")]
    MasterPages = 3,
    [EnumString("normal")]
    Normal = 4,
    [EnumString("web")]
    Web = 5,
  }
}
