using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("errBarType")]
  [Alias("ErrBarType")]
  public class ErrorBarType
  {
    [Tag("errBarType")]
    ErrorBarValues Val{ get; set; }

  }
}
