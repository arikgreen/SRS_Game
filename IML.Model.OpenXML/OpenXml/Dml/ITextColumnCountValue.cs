using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TextColumnCount")]
  public interface ITextColumnCountValue
  {
    Int32 AsInt32{ get; set; }

  }
}
