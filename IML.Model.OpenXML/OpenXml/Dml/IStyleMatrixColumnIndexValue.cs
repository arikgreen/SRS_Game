using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("StyleMatrixColumnIndex")]
  public interface IStyleMatrixColumnIndexValue
  {
    UInt32 AsUInt32{ get; set; }

  }
}
