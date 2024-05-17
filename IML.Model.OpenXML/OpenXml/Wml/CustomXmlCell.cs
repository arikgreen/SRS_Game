using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("customXmlCell")]
  [Alias("CustomXmlCell")]
  public class CustomXmlCell
  {
    [Tag("string")]
    String Uri{ get; set; }

    [Tag("xmlName")]
    XmlNameValue Element{ get; set; }

  }
}
