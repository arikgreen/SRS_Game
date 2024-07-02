using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml
{
  [Alias("ConformanceClass")]
  public enum WordprocessingDocumentType
  {
    [EnumString("strict")]
    Strict,
    [EnumString("transitional")]
    Transitional,
  }
}
