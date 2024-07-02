using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [MinValue(1)]
  [MaxValue(255)]
  [Alias("Integer255")]
  public interface IInteger255Value
  {
    Int32 AsInt32{ get; set; }

  }
}
