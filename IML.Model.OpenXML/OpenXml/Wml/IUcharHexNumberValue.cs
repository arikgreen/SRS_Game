using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Format("X2")]
  [Alias("UcharHexNumber")]
  public interface IUcharHexNumberValue
  {
    Byte AsByte{ get; set; }

  }
}
