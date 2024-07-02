using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("numFmt")]
  [Alias("NumFmt")]
  public class NumberingFormat
  {
    [Tag("xstring")]
    XstringValue FormatCode{ get; set; }

    [Tag("boolean")]
    Boolean SourceLinked{ get; set; }

  }
}
