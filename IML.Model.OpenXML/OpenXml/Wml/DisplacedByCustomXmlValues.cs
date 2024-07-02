using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("DisplacedByCustomXml")]
  public enum DisplacedByCustomXmlValues
  {
    [EnumString("next")]
    Next = 0,
    [EnumString("prev")]
    Prev,
  }
}
