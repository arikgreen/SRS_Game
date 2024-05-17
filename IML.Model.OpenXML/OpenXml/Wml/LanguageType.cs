using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("language")]
  [Alias("Language")]
  public class LanguageType
  {
    [Tag("lang")]
    LangValue Val{ get; set; }

    [Tag("lang")]
    LangValue EastAsia{ get; set; }

    [Tag("lang")]
    LangValue Bidi{ get; set; }

  }
}
