using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("textEffect")]
  [Alias("TextEffect")]
  public class TextEffect
  {
    [Tag("textEffect")]
    TextEffectValues Val{ get; set; }

  }
}
