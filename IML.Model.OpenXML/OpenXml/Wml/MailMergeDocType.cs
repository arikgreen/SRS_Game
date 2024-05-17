using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml.Wml
{
  [Tag("mailMergeDataType")]
  [Alias("MailMergeDataType")]
  public class MailMergeDocType
  {
    [Tag("mailMergeDataType")]
    MailMergeDataTypeValue Val{ get; set; }

  }
}
