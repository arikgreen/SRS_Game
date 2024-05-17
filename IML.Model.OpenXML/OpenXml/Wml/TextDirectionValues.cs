using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("TextDirection")]
  public enum TextDirectionValues
  {
    [EnumString("tb")]
    Tb,
    [EnumString("rl")]
    Rl,
    [EnumString("lr")]
    Lr,
    [EnumString("tbV")]
    TbV,
    [EnumString("rlV")]
    RlV,
    [EnumString("lrV")]
    LrV,
  }
}
