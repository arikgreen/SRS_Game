using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("docProtect")]
  [Alias("DocProtect")]
  public class SdtContentDocPartList
  {
    [Tag("docProtect")]
    DocumentProtectionValues Edit{ get; set; }

    [Tag("onOff")]
    OnOffValue Formatting{ get; set; }

    [Tag("onOff")]
    OnOffValue Enforcement{ get; set; }

  }
}
