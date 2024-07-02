using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("proofErr")]
  [Alias("ProofErr")]
  public class ProofError
  {
    [Tag("proofErr")]
    ProofingErrorValues Type{ get; set; }

  }
}
