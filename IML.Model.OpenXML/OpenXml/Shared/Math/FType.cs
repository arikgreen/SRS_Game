using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml
{
  [Tag("fType")]
  [Alias("FType")]
  public class FType
  {
    [Tag("fType")]
    FractionTypeValues Val{ get; set; }

  }
}
