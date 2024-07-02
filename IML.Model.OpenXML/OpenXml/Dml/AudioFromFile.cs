using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("audioFile")]
  [Alias("AudioFile")]
  public class AudioFromFile
  {
    [Tag("string")]
    String ContentType{ get; set; }

  }
}
