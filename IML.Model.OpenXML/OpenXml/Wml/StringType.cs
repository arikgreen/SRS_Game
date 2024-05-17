using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("string")]
  [Alias("String")]
  public class StringType
  {
    [Tag("string")]
    String Val{ get; set; }

  }
}
