using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("base64Binary")]
  [Alias("Base64Binary")]
  public class TemporarySdt
  {
    [Tag("base64Binary")]
    Byte[] Val{ get; set; }

  }
}
