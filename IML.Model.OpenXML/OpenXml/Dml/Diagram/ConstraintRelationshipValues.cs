using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("ConstraintRelationship")]
  public enum ConstraintRelationshipValues
  {
    [EnumString("self")]
    Self = 0,
    [EnumString("ch")]
    Ch,
    [EnumString("des")]
    Des,
  }
}
