using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("SystemColorVal")]
  public enum SystemColorValues
  {
    [EnumString("scrollBar")]
    ScrollBar = 0,
    [EnumString("background")]
    Background = 1,
    [EnumString("activeCaption")]
    ActiveCaption = 2,
    [EnumString("inactiveCaption")]
    InactiveCaption = 3,
    [EnumString("menu")]
    Menu = 4,
    [EnumString("window")]
    Window = 5,
    [EnumString("windowFrame")]
    WindowFrame = 6,
    [EnumString("menuText")]
    MenuText = 7,
    [EnumString("windowText")]
    WindowText = 8,
    [EnumString("captionText")]
    CaptionText = 9,
    [EnumString("activeBorder")]
    ActiveBorder = 10,
    [EnumString("inactiveBorder")]
    InactiveBorder = 11,
    [EnumString("appWorkspace")]
    AppWorkspace,
    [EnumString("highlight")]
    Highlight = 13,
    [EnumString("highlightText")]
    HighlightText = 14,
    [EnumString("btnFace")]
    BtnFace,
    [EnumString("btnShadow")]
    BtnShadow,
    [EnumString("grayText")]
    GrayText = 17,
    [EnumString("btnText")]
    BtnText,
    [EnumString("inactiveCaptionText")]
    InactiveCaptionText = 19,
    [EnumString("btnHighlight")]
    BtnHighlight,
    [EnumString("3dDkShadow")]
    _3dDkShadow,
    [EnumString("3dLight")]
    _3dLight,
    [EnumString("infoText")]
    InfoText = 23,
    [EnumString("infoBk")]
    InfoBk,
    [EnumString("hotLight")]
    HotLight = 25,
    [EnumString("gradientActiveCaption")]
    GradientActiveCaption = 26,
    [EnumString("gradientInactiveCaption")]
    GradientInactiveCaption = 27,
    [EnumString("menuHighlight")]
    MenuHighlight = 28,
    [EnumString("menuBar")]
    MenuBar = 29,
  }
}
