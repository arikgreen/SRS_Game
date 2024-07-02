using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Pattern(@"0*(([0-9])|([1-9][0-9])|([1-9][0-9][0-9])|1000)%")]
  [Units(new string[]{"%"})]
  [Alias("LblOffsetPercent")]
  public interface ILblOffsetPercentValue
  {
    Int32 AsInt32{ get; set; }

  }
}
