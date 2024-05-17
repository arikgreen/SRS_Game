using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml
{
  [Alias("CalendarType")]
  public enum PresentationDocumentType
  {
    [EnumString("gregorian")]
    Gregorian,
    [EnumString("gregorianUs")]
    GregorianUs,
    [EnumString("gregorianMeFrench")]
    GregorianMeFrench,
    [EnumString("gregorianArabic")]
    GregorianArabic,
    [EnumString("hijri")]
    Hijri,
    [EnumString("hebrew")]
    Hebrew,
    [EnumString("taiwan")]
    Taiwan,
    [EnumString("japan")]
    Japan,
    [EnumString("thai")]
    Thai,
    [EnumString("korea")]
    Korea,
    [EnumString("saka")]
    Saka,
    [EnumString("gregorianXlitEnglish")]
    GregorianXlitEnglish,
    [EnumString("gregorianXlitFrench")]
    GregorianXlitFrench,
    [EnumString("none")]
    None,
  }
}
