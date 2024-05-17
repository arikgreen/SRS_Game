using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("guid")]
  [Alias("Guid")]
  public class DocPartId
  {
    [Tag("guid")]
    Guid Val{ get; set; }

  }
}
