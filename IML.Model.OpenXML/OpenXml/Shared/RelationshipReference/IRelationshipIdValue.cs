using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml
{
  [Alias("RelationshipId")]
  public interface IRelationshipIdValue
  {
    String AsString{ get; set; }

  }
}
