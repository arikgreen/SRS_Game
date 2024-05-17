using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("fontReference")]
  [Alias("FontReference")]
  public class FontReference
  {
    [Tag("fontCollectionIndex")]
    FontCollectionIndexValues Idx{ get; set; }

  }
}
