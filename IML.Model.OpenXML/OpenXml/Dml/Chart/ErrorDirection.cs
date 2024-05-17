using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("errDir")]
  [Alias("ErrDir")]
  public class ErrorDirection
  {
    [Tag("errDir")]
    ErrorBarDirectionValues Val{ get; set; }

  }
}
