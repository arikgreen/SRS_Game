using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("customXmlRun")]
  [Alias("CustomXmlRun")]
  public class CustomXmlRun
  {
    [Tag("string")]
    String Uri{ get; set; }

    [Tag("xmlName")]
    XmlNameValue Element{ get; set; }

  }
}
