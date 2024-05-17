using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("Lock")]
  public enum LockingValues
  {
    [EnumString("sdtLocked")]
    SdtLocked = 0,
    [EnumString("contentLocked")]
    ContentLocked = 1,
    [EnumString("unlocked")]
    Unlocked = 2,
    [EnumString("sdtContentLocked")]
    SdtContentLocked = 3,
  }
}
