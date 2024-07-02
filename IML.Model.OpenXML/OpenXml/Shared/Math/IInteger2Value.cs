using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [MinValue(-2)]
  [MaxValue(2)]
  [Alias("Integer2")]
  public interface IInteger2Value
  {
    Int32 AsInt32{ get; set; }

  }
}
