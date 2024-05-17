using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("ObjectUpdateMode")]
  public enum ObjectUpdateMode
  {
    [EnumString("always")]
    Always,
    [EnumString("onCall")]
    OnCall,
  }
}
