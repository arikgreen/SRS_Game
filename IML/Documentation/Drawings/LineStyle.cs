using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  //==========================================================================================
  /// <summary>
  /// Klasa reprezentujaca styl linii
  /// </summary>
  public enum LineStyle
  {
    /// <summary>niewidoczna</summary>
    Invisible,
    /// <summary>linia pojedyncza</summary>
    Single,
    /// <summary>linia wykropkowana</summary>
    Dotted,
    /// <summary>linia przerywana z małymi odstępami</summary>
    DashSmallGap,
    /// <summary>linia przerywana</summary>
    Dashed,
    /// <summary>kropka-kreska</summary>
    DotDash,
    /// <summary>kropka-kropka-kreska</summary>
    DotDotDash,
    /// <summary>linia podwójna</summary>
    Double,
    /// <summary>linia potrójna</summary>
    Triple,
    /// <summary>linia podwójna: cienka-gruba z małym odstępem</summary>
    ThinThickSmallGap,
    /// <summary>linia podwójna: gruba-cienka z małym odstępem</summary>
    ThickThinSmallGap,
    /// <summary>linia podwójna: cienka-gruba ze średnim odstępem</summary>
    ThinThickMediumGap,
    /// <summary>linia podwójna: gruba-cienka ze średnim odstępem</summary>
    ThickThinMediumGap,
    /// <summary>linia potrójna: cienka-gruba-cienka ze małym odstępem</summary>
    ThinThickThinSmallGap,
    /// <summary>linia potrójna: cienka-gruba-cienka ze średnim odstępem</summary>
    ThinThickThinMediumGap,
    /// <summary>linia potrójna: gruba-cienka-gruba ze średnim odstępem</summary>
    ThickThinThickMediumGap,
    /// <summary>linia podwójna: cienka-gruba z dużym odstępem</summary>
    ThinThickLargeGap,
    /// <summary>linia podwójna: gruba-cienka z dużym odstępem</summary>
    ThickThinLargeGap,
    /// <summary>linia potrójna: cienka-gruba-cienka z dużym odstępem</summary>
    ThinThickThinLargeGap,
    /// <summary>linia potrójna: gruba-cienka-gruba z dużym odstępem</summary>
    ThickThinThickLargeGap,
    /// <summary>linia falująca</summary>
    Wave,
    /// <summary>linia podwójna falująca</summary>
    DoubleWave,
    /// <summary>wypukła</summary>
    Outset,
    /// <summary>wklęsła</summary>
    Inset,
    /// <summary>ukośnie wytłaczana</summary>
    DashDotStroked,
    /// <summary>3D wytłaczana</summary>
    ThreeDEmboss,
    /// <summary>3D wyżłobiona</summary>
    ThreeDEngrave,
  }
}
