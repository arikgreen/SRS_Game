using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("attr")]
  [Alias("Attr")]
  public class CustomXmlAttribute
  {
    [Tag("string")]
    String Uri{ get; set; }

    [Tag("string")]
    String Name{ get; set; }

    [Tag("string")]
    String Val{ get; set; }

  }
}
