using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("PresetCameraType")]
  public enum PresetCameraValues
  {
    [EnumString("legacyObliqueTopLeft")]
    LegacyObliqueTopLeft = 0,
    [EnumString("legacyObliqueTop")]
    LegacyObliqueTop = 1,
    [EnumString("legacyObliqueTopRight")]
    LegacyObliqueTopRight = 2,
    [EnumString("legacyObliqueLeft")]
    LegacyObliqueLeft = 3,
    [EnumString("legacyObliqueFront")]
    LegacyObliqueFront = 4,
    [EnumString("legacyObliqueRight")]
    LegacyObliqueRight = 5,
    [EnumString("legacyObliqueBottomLeft")]
    LegacyObliqueBottomLeft = 6,
    [EnumString("legacyObliqueBottom")]
    LegacyObliqueBottom = 7,
    [EnumString("legacyObliqueBottomRight")]
    LegacyObliqueBottomRight = 8,
    [EnumString("legacyPerspectiveTopLeft")]
    LegacyPerspectiveTopLeft = 9,
    [EnumString("legacyPerspectiveTop")]
    LegacyPerspectiveTop = 10,
    [EnumString("legacyPerspectiveTopRight")]
    LegacyPerspectiveTopRight = 11,
    [EnumString("legacyPerspectiveLeft")]
    LegacyPerspectiveLeft = 12,
    [EnumString("legacyPerspectiveFront")]
    LegacyPerspectiveFront = 13,
    [EnumString("legacyPerspectiveRight")]
    LegacyPerspectiveRight = 14,
    [EnumString("legacyPerspectiveBottomLeft")]
    LegacyPerspectiveBottomLeft = 15,
    [EnumString("legacyPerspectiveBottom")]
    LegacyPerspectiveBottom = 16,
    [EnumString("legacyPerspectiveBottomRight")]
    LegacyPerspectiveBottomRight = 17,
    [EnumString("orthographicFront")]
    OrthographicFront = 18,
    [EnumString("isometricTopUp")]
    IsometricTopUp = 19,
    [EnumString("isometricTopDown")]
    IsometricTopDown = 20,
    [EnumString("isometricBottomUp")]
    IsometricBottomUp = 21,
    [EnumString("isometricBottomDown")]
    IsometricBottomDown = 22,
    [EnumString("isometricLeftUp")]
    IsometricLeftUp = 23,
    [EnumString("isometricLeftDown")]
    IsometricLeftDown = 24,
    [EnumString("isometricRightUp")]
    IsometricRightUp = 25,
    [EnumString("isometricRightDown")]
    IsometricRightDown = 26,
    [EnumString("isometricOffAxis1Left")]
    IsometricOffAxis1Left = 27,
    [EnumString("isometricOffAxis1Right")]
    IsometricOffAxis1Right = 28,
    [EnumString("isometricOffAxis1Top")]
    IsometricOffAxis1Top = 29,
    [EnumString("isometricOffAxis2Left")]
    IsometricOffAxis2Left = 30,
    [EnumString("isometricOffAxis2Right")]
    IsometricOffAxis2Right = 31,
    [EnumString("isometricOffAxis2Top")]
    IsometricOffAxis2Top = 32,
    [EnumString("isometricOffAxis3Left")]
    IsometricOffAxis3Left = 33,
    [EnumString("isometricOffAxis3Right")]
    IsometricOffAxis3Right = 34,
    [EnumString("isometricOffAxis3Bottom")]
    IsometricOffAxis3Bottom = 35,
    [EnumString("isometricOffAxis4Left")]
    IsometricOffAxis4Left = 36,
    [EnumString("isometricOffAxis4Right")]
    IsometricOffAxis4Right = 37,
    [EnumString("isometricOffAxis4Bottom")]
    IsometricOffAxis4Bottom = 38,
    [EnumString("obliqueTopLeft")]
    ObliqueTopLeft = 39,
    [EnumString("obliqueTop")]
    ObliqueTop = 40,
    [EnumString("obliqueTopRight")]
    ObliqueTopRight = 41,
    [EnumString("obliqueLeft")]
    ObliqueLeft = 42,
    [EnumString("obliqueRight")]
    ObliqueRight = 43,
    [EnumString("obliqueBottomLeft")]
    ObliqueBottomLeft = 44,
    [EnumString("obliqueBottom")]
    ObliqueBottom = 45,
    [EnumString("obliqueBottomRight")]
    ObliqueBottomRight = 46,
    [EnumString("perspectiveFront")]
    PerspectiveFront = 47,
    [EnumString("perspectiveLeft")]
    PerspectiveLeft = 48,
    [EnumString("perspectiveRight")]
    PerspectiveRight = 49,
    [EnumString("perspectiveAbove")]
    PerspectiveAbove = 50,
    [EnumString("perspectiveBelow")]
    PerspectiveBelow = 51,
    [EnumString("perspectiveAboveLeftFacing")]
    PerspectiveAboveLeftFacing = 52,
    [EnumString("perspectiveAboveRightFacing")]
    PerspectiveAboveRightFacing = 53,
    [EnumString("perspectiveContrastingLeftFacing")]
    PerspectiveContrastingLeftFacing = 54,
    [EnumString("perspectiveContrastingRightFacing")]
    PerspectiveContrastingRightFacing = 55,
    [EnumString("perspectiveHeroicLeftFacing")]
    PerspectiveHeroicLeftFacing = 56,
    [EnumString("perspectiveHeroicRightFacing")]
    PerspectiveHeroicRightFacing = 57,
    [EnumString("perspectiveHeroicExtremeLeftFacing")]
    PerspectiveHeroicExtremeLeftFacing = 58,
    [EnumString("perspectiveHeroicExtremeRightFacing")]
    PerspectiveHeroicExtremeRightFacing = 59,
    [EnumString("perspectiveRelaxed")]
    PerspectiveRelaxed = 60,
    [EnumString("perspectiveRelaxedModerately")]
    PerspectiveRelaxedModerately = 61,
  }
}
