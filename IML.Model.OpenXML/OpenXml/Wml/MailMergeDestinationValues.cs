using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("MailMergeDest")]
  public enum MailMergeDestinationValues
  {
    [EnumString("newDocument")]
    NewDocument = 0,
    [EnumString("printer")]
    Printer = 1,
    [EnumString("email")]
    Email = 2,
    [EnumString("fax")]
    Fax = 3,
  }
}
