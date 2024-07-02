using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Pattern(@"0*([1-9]|([1-8][0-9])|90)%")]
  [Units(new string[]{"%"})]
  [Alias("HoleSizePercent")]
  public interface IHoleSizePercentValue
  {
    Int32 AsInt32{ get; set; }

  }
}
