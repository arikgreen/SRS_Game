using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("cxn")]
  [Alias("Cxn")]
  public class Connection
  {
    [Tag("modelId")]
    ModelIdValue ModelId{ get; set; }

    [Tag("cxnType")]
    ConnectionValues Type{ get; set; }

    [Tag("modelId")]
    ModelIdValue SrcId{ get; set; }

    [Tag("modelId")]
    ModelIdValue DestId{ get; set; }

    [Tag("unsignedInt")]
    UInt32 SrcOrd{ get; set; }

    [Tag("unsignedInt")]
    UInt32 DestOrd{ get; set; }

    [Tag("modelId")]
    ModelIdValue ParTransId{ get; set; }

    [Tag("modelId")]
    ModelIdValue SibTransId{ get; set; }

    [Tag("string")]
    String PresId{ get; set; }

  }
}
