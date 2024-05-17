using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [MaxLength(140)]
  [Alias("FFStatusTextVal")]
  public interface IFFStatusTextValValue
  {
    String AsString{ get; set; }

  }
}
