using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml.Wml
{
  [Tag("jcTable")]
  [Alias("JcTable")]
  public class JcTable
  {
    [Tag("jcTable")]
    TabStopValues Val{ get; set; }

  }
}
