using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Pattern(@"([0-9]+)%")]
  [Units(new string[]{"%"})]
  [Alias("ThicknessPercent")]
  public interface IThicknessPercentValue
  {
    Int32 AsInt32{ get; set; }

  }
}
