using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [MinValue(0)]
  [MaxValue(51206400)]
  [Alias("TextMargin")]
  public interface ITextMarginValue
  {
    Int32 AsInt32{ get; set; }

  }
}
