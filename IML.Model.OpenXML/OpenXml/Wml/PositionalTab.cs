using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("pTab")]
  [Alias("PTab")]
  public class PositionalTab
  {
    [Tag("pTabAlignment")]
    TableRowAlignmentValues Alignment{ get; set; }

    [Tag("pTabRelativeTo")]
    AbsolutePositionTabPositioningBaseValues RelativeTo{ get; set; }

    [Tag("pTabLeader")]
    AbsolutePositionTabLeaderCharValues Leader{ get; set; }

  }
}
