using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("signedTwipsMeasure")]
  [Alias("SignedTwipsMeasure")]
  public class SignedTwipsMeasureType
  {
    [Tag("signedTwipsMeasure")]
    SignedTwipsMeasureValue Val{ get; set; }

  }
}
