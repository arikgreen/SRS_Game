using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("FldCharType")]
  public enum FieldCharValues
  {
    [EnumString("begin")]
    Begin = 0,
    [EnumString("separate")]
    Separate = 1,
    [EnumString("end")]
    End = 2,
  }
}
