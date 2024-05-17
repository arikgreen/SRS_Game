using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml.Wml
{
  [Tag("mailMergeSourceType")]
  [Alias("MailMergeSourceType")]
  public class MailMergeSourceType
  {
    [Tag("mailMergeSourceType")]
    MailMergeSourceValues Val{ get; set; }

  }
}
