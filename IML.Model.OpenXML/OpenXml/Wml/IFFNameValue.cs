using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [MaxLength(65)]
  [Alias("FFName")]
  public interface IFFNameValue
  {
    String AsString{ get; set; }

  }
}
