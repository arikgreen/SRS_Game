using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("textboxTightWrap")]
  [Alias("TextboxTightWrap")]
  public class TextBoxTightWrap
  {
    [Tag("textboxTightWrap")]
    TextBoxTightWrapValues Val{ get; set; }

  }
}
