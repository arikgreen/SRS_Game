using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("customXmlRow")]
  [Alias("CustomXmlRow")]
  public class CustomXmlRow
  {
    [Tag("string")]
    String Uri{ get; set; }

    [Tag("xmlName")]
    XmlNameValue Element{ get; set; }

  }
}
