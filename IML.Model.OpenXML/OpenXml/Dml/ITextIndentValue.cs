using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [MinValue(-51206400)]
  [MaxValue(51206400)]
  [Alias("TextIndent")]
  public interface ITextIndentValue
  {
    Int32 AsInt32{ get; set; }

  }
}
