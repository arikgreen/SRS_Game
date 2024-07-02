using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml.Wml
{
  [Tag("docType")]
  [Alias("DocType")]
  public class SectType
  {
    [Tag("docType")]
    DocTypeValue Val{ get; set; }

  }
}
