using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("CxnType")]
  public enum ConnectionValues
  {
    [EnumString("parOf")]
    ParOf,
    [EnumString("presOf")]
    PresOf,
    [EnumString("presParOf")]
    PresParOf,
    [EnumString("unknownRelationship")]
    UnknownRelationship = 3,
  }
}
