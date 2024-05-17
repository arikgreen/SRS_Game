using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("errValType")]
  [Alias("ErrValType")]
  public class ErrorBarValueType
  {
    [Tag("errValType")]
    ErrorValues Val{ get; set; }

  }
}
