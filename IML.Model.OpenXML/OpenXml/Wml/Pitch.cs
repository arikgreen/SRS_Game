using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("pitch")]
  [Alias("Pitch")]
  public class Pitch
  {
    [Tag("pitch")]
    FontPitchValues Val{ get; set; }

  }
}
