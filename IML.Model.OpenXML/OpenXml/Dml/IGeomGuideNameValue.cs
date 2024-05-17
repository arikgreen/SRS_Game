using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Token]
  [Alias("GeomGuideName")]
  public interface IGeomGuideNameValue
  {
    String AsString{ get; set; }

  }
}
