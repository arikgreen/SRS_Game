using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("objectEmbed")]
  [Alias("ObjectEmbed")]
  public class ObjectEmbed
  {
    [Tag("objectDrawAspect")]
    ObjectDrawAspect DrawAspect{ get; set; }

    [Tag("string")]
    String ProgId{ get; set; }

    [Tag("string")]
    String ShapeId{ get; set; }

    [Tag("string")]
    String FieldCodes{ get; set; }

  }
}
