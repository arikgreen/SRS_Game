using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("audioCDTime")]
  [Alias("AudioCDTime")]
  public class AudioCDTimeType
  {
    [Tag("unsignedByte")]
    Byte Track{ get; set; }

    [Tag("unsignedInt")]
    UInt32 Time{ get; set; }

  }
}
