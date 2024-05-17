using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("tabStop")]
  [Alias("TabStop")]
  public class TabStop
  {
    [Tag("tabJc")]
    TabStopValues Val{ get; set; }

    [Tag("tabTlc")]
    TabStopLeaderCharValues Leader{ get; set; }

    [Tag("signedTwipsMeasure")]
    SignedTwipsMeasureValue Pos{ get; set; }

  }
}
