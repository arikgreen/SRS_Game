using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("saveThroughXslt")]
  [Alias("SaveThroughXslt")]
  public class SaveThroughXslt
  {
    [Tag("string")]
    String SolutionID{ get; set; }

  }
}
