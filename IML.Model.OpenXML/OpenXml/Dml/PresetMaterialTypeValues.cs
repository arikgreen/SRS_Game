using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("PresetMaterialType")]
  public enum PresetMaterialTypeValues
  {
    [EnumString("legacyMatte")]
    LegacyMatte = 0,
    [EnumString("legacyPlastic")]
    LegacyPlastic = 1,
    [EnumString("legacyMetal")]
    LegacyMetal = 2,
    [EnumString("legacyWireframe")]
    LegacyWireframe = 3,
    [EnumString("matte")]
    Matte = 4,
    [EnumString("plastic")]
    Plastic = 5,
    [EnumString("metal")]
    Metal = 6,
    [EnumString("warmMatte")]
    WarmMatte = 7,
    [EnumString("translucentPowder")]
    TranslucentPowder = 8,
    [EnumString("powder")]
    Powder = 9,
    [EnumString("dkEdge")]
    DkEdge,
    [EnumString("softEdge")]
    SoftEdge = 11,
    [EnumString("clear")]
    Clear = 12,
    [EnumString("flat")]
    Flat = 13,
    [EnumString("softmetal")]
    Softmetal,
  }
}
