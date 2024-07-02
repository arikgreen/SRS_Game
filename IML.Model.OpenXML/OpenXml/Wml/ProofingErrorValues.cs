using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("ProofErr")]
  public enum ProofingErrorValues
  {
    [EnumString("spellStart")]
    SpellStart = 0,
    [EnumString("spellEnd")]
    SpellEnd = 1,
    [EnumString("gramStart")]
    GramStart,
    [EnumString("gramEnd")]
    GramEnd,
  }
}
