using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("fontFamily")]
  [Alias("FontFamily")]
  public class FontFamily
  {
    [Tag("fontFamily")]
    FontFamilyValues Val{ get; set; }

  }
}
