using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("em")]
  [Alias("Em")]
  public class Emphasis
  {
    [Tag("em")]
    EmphasisMarkValues Val{ get; set; }

  }
}
