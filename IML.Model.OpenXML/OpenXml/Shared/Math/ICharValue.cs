using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [MaxLength(1)]
  [Alias("Char")]
  public interface ICharValue
  {
    String AsString{ get; set; }

  }
}
