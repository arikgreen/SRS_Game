using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("DocType")]
  public interface IDocTypeValue
  {
    String AsString{ get; set; }

  }
}
