using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("VariableType")]
  public enum VariableValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("orgChart")]
    OrgChart,
    [EnumString("chMax")]
    ChMax,
    [EnumString("chPref")]
    ChPref,
    [EnumString("bulEnabled")]
    BulEnabled,
    [EnumString("dir")]
    Dir,
    [EnumString("hierBranch")]
    HierBranch,
    [EnumString("animOne")]
    AnimOne,
    [EnumString("animLvl")]
    AnimLvl,
    [EnumString("resizeHandles")]
    ResizeHandles = 9,
  }
}
