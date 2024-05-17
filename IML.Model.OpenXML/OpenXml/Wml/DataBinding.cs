using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("dataBinding")]
  [Alias("DataBinding")]
  public class DataBinding
  {
    [Tag("string")]
    String PrefixMappings{ get; set; }

    [Tag("string")]
    String Xpath{ get; set; }

    [Tag("string")]
    String StoreItemID{ get; set; }

  }
}
