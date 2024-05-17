using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml.Wml
{
  [Tag("sectType")]
  [Alias("SectType")]
  public class SectionMark
  {
    [Tag("sectionMark")]
    SectionMarkValues Val{ get; set; }

  }
}
