using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("StyleSort")]
  public enum StylePaneSortMethodsValues
  {
    [EnumString("name")]
    Name = 1,
    [EnumString("priority")]
    Priority = 3,
    [EnumString("default")]
    Default = 11,
    [EnumString("font")]
    Font = 5,
    [EnumString("basedOn")]
    BasedOn = 7,
    [EnumString("type")]
    Type = 9,
  }
}
