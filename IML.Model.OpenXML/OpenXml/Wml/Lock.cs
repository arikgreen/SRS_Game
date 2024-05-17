using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("lock")]
  [Alias("Lock")]
  public class Lock
  {
    [Tag("lock")]
    LockingValues Val{ get; set; }

  }
}
