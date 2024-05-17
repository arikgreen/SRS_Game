using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("DocProtect")]
  public enum DocumentProtectionValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("readOnly")]
    ReadOnly = 1,
    [EnumString("comments")]
    Comments = 2,
    [EnumString("trackedChanges")]
    TrackedChanges = 3,
    [EnumString("forms")]
    Forms = 4,
  }
}
