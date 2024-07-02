using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("category")]
  [Alias("Category")]
  public class Category
  {
    [Tag("anyURI")]
    Uri Type{ get; set; }

    [Tag("unsignedInt")]
    UInt32 Pri{ get; set; }

  }
}
