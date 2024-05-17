using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("MailMergeDataType")]
  public struct MailMergeDataTypeValue
  {
    private String value;

    private MailMergeDataTypeValue (String value)
    {
      this.value = value;
    }

    public String AsString
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator MailMergeDataTypeValue (String value)
    {
      return new MailMergeDataTypeValue(value);
    }

    public static implicit operator String (MailMergeDataTypeValue value)
    {
      return value.value;
    }

  }
}
