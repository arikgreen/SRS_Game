using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("styleMatrixReference")]
  [Alias("StyleMatrixReference")]
  public class StyleMatrixReferenceType
  {
    [Tag("styleMatrixColumnIndex")]
    StyleMatrixColumnIndexValue Idx{ get; set; }

  }
}
