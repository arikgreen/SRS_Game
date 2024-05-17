using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Pattern(@"0*(600|([0-5]?[0-9]?[0-9]))%")]
  [Units(new string[]{"%"})]
  [Alias("TextScalePercent")]
  public interface ITextScalePercentValue
  {
    Int32 AsInt32{ get; set; }

  }
}
