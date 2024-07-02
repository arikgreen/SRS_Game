using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("DecimalNumber")]
  public interface IDecimalNumberValue
  {
    Int32 AsInt32{ get; set; }

  }
}
