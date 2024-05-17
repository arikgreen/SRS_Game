using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("Proof")]
  public enum ProofingStateValues
  {
    [EnumString("clean")]
    Clean = 0,
    [EnumString("dirty")]
    Dirty = 1,
  }
}
