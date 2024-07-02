using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("supplementalFont")]
  [Alias("SupplementalFont")]
  public class SupplementalFont
  {
    [Tag("string")]
    String Script{ get; set; }

    [Tag("textTypeface")]
    TextTypefaceValue Typeface{ get; set; }

  }
}
