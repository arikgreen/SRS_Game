using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("view")]
  [Alias("View")]
  public class View
  {
    [Tag("view")]
    ViewValues Val{ get; set; }

  }
}
