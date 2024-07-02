using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("rubyAlign")]
  [Alias("RubyAlign")]
  public class RubyAlign
  {
    [Tag("rubyAlign")]
    RubyAlignValues Val{ get; set; }

  }
}
