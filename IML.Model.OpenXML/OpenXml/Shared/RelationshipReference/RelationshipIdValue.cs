using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml
{
  [Alias("RelationshipId")]
  public struct RelationshipIdValue
  {
    private String value;

    private RelationshipIdValue (String value)
    {
      this.value = value;
    }

    public String AsString
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator RelationshipIdValue (String value)
    {
      return new RelationshipIdValue(value);
    }

    public static implicit operator String (RelationshipIdValue value)
    {
      return value.value;
    }

  }
}
