using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Pattern(@"0*(([2-9][0-9])|([1-9][0-9][0-9])|(1[0-9][0-9][0-9])|2000)%")]
  [Units(new string[]{"%"})]
  [Alias("DepthPercentWithSymbol")]
  public interface IDepthPercentWithSymbolValue
  {
    Int32 AsInt32{ get; set; }

  }
}
