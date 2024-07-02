using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("smartTagType")]
  [Alias("SmartTagType")]
  public class DataType
  {
    [Tag("string")]
    String Namespaceuri{ get; set; }

    [Tag("string")]
    String Name{ get; set; }

    [Tag("string")]
    String Url{ get; set; }

  }
}
