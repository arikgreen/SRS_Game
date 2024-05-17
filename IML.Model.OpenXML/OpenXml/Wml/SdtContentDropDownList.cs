using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("sdtDropDownList")]
  [Alias("SdtDropDownList")]
  public class SdtContentDropDownList
  {
    [Tag("string")]
    String LastValue{ get; set; }

  }
}
