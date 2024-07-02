using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml
{
  [Tag("textLanguageID")]
  [Alias("TextLanguageID")]
  public class LangValue
  {
    [Tag("lang")]
    LangValue Val{ get; set; }

  }
}
