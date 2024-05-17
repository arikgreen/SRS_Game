using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TextNonNegativePoint")]
  public interface ITextNonNegativePointValue
  {
    Int32 AsInt32{ get; set; }

  }
}
