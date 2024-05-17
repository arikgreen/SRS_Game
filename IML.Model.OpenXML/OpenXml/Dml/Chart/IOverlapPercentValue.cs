using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Pattern(@"(-?0*(([0-9])|([1-9][0-9])|100))%")]
  [Units(new string[]{"%"})]
  [Alias("OverlapPercent")]
  public interface IOverlapPercentValue
  {
    Int32 AsInt32{ get; set; }

  }
}
