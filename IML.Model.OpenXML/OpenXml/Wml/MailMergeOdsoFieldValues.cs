using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("MailMergeOdsoFMDFieldType")]
  public enum MailMergeOdsoFieldValues
  {
    [EnumString("null")]
    Null = 0,
    [EnumString("dbColumn")]
    DbColumn = 1,
  }
}
