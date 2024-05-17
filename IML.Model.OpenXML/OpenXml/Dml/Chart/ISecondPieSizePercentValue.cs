using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Pattern(@"0*(([5-9])|([1-9][0-9])|(1[0-9][0-9])|200)%")]
  [Units(new string[]{"%"})]
  [Alias("SecondPieSizePercent")]
  public interface ISecondPieSizePercentValue
  {
    Int32 AsInt32{ get; set; }

  }
}
