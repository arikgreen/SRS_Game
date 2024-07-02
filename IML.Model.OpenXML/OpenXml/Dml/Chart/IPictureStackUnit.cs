using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("PictureStackUnit")]
  public interface IPictureStackUnit
  {
    Double AsDouble{ get; set; }

  }
}
