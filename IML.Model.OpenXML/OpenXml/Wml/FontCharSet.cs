using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("charset")]
  [Alias("Charset")]
  public class FontCharSet
  {
    [Tag("string")]
    String CharacterSet{ get; set; }

  }
}
