using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TextTypeface")]
  public interface ITextTypefaceValue
  {
    String AsString{ get; set; }

  }
}
