using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("sampleData")]
  [Alias("SampleData")]
  public class SampleDataType
  {
    [Tag("boolean")]
    Boolean UseDef{ get; set; }

  }
}
