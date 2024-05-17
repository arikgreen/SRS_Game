using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("sdtDate")]
  [Alias("SdtDate")]
  public class SdtContentDate
  {
    [Tag("dateTime")]
    DateTime FullDate{ get; set; }

  }
}
