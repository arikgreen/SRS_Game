using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("onOff")]
  [Alias("OnOff")]
  public class OnOffType
  {
    [Tag("onOff")]
    OnOffValue Val{ get; set; }

  }
}
