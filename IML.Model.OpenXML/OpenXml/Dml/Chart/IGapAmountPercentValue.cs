using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Pattern(@"0*(([0-9])|([1-9][0-9])|([1-4][0-9][0-9])|500)%")]
  [Units(new string[]{"%"})]
  [Alias("GapAmountPercent")]
  public interface IGapAmountPercentValue
  {
    Int32 AsInt32{ get; set; }

  }
}
