using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("lang")]
  [Alias("Lang")]
  public class Languages
  {
    [Tag("lang")]
    LangValue Val{ get; set; }

  }
}
