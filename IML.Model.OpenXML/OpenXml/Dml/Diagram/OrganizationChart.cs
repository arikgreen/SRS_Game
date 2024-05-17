using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("orgChart")]
  [Alias("OrgChart")]
  public class OrganizationChart
  {
    [Tag("boolean")]
    Boolean Val{ get; set; }

  }
}
