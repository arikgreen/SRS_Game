using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("docVar")]
  [Alias("DocVar")]
  public class DocumentVariable
  {
    [Tag("string")]
    String Name{ get; set; }

    [Tag("string")]
    String Val{ get; set; }

  }
}
