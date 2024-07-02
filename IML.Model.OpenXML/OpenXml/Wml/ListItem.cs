using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("sdtListItem")]
  [Alias("SdtListItem")]
  public class ListItem
  {
    [Tag("string")]
    String DisplayText{ get; set; }

    [Tag("string")]
    String Value{ get; set; }

  }
}
