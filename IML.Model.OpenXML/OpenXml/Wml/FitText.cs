using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("sdtText")]
  [Alias("SdtText")]
  public class FitText
  {
    [Tag("onOff")]
    OnOffValue MultiLine{ get; set; }

  }
}
