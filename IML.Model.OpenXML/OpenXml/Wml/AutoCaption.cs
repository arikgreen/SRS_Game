using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("autoCaption")]
  [Alias("AutoCaption")]
  public class AutoCaption
  {
    [Tag("string")]
    String Name{ get; set; }

    [Tag("string")]
    String Caption{ get; set; }

  }
}
