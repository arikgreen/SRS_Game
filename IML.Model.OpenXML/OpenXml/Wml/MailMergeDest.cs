using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml.Wml
{
  [Tag("mailMergeDest")]
  [Alias("MailMergeDest")]
  public class MailMergeDest
  {
    [Tag("mailMergeDest")]
    MailMergeDestinationValues Val{ get; set; }

  }
}
