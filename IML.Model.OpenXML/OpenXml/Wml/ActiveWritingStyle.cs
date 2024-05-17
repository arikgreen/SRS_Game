using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("writingStyle")]
  [Alias("WritingStyle")]
  public class ActiveWritingStyle
  {
    [Tag("lang")]
    LangValue Lang{ get; set; }

    [Tag("string")]
    String VendorID{ get; set; }

    [Tag("string")]
    String DllVersion{ get; set; }

    [Tag("onOff")]
    OnOffValue NlCheck{ get; set; }

    [Tag("onOff")]
    OnOffValue CheckStyle{ get; set; }

    [Tag("string")]
    String AppName{ get; set; }

  }
}
