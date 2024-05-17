using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml.Wml
{
  [Tag("styleSort")]
  [Alias("StyleSort")]
  public class StyleSort
  {
    [Tag("styleSort")]
    StylePaneSortMethodsValues Val{ get; set; }

  }
}
