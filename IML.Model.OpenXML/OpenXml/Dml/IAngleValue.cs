using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("Angle")]
  public interface IAngleValue
  {
    Int32 AsInt32{ get; set; }

  }
}
