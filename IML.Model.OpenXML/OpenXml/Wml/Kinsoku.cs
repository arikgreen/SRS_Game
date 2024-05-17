using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("kinsoku")]
  [Alias("Kinsoku")]
  public class Kinsoku
  {
    [Tag("lang")]
    LangValue Lang{ get; set; }

    [Tag("string")]
    String Val{ get; set; }

  }
}
