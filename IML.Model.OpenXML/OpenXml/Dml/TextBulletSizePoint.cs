using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml.Dml
{
  [Tag("textBulletSizePercent")]
  [Alias("TextBulletSizePercent")]
  public class TextBulletSizePoint
  {
    [Tag("textBulletSizePercent")]
    TextBulletSizePercentValue Val{ get; set; }

  }
}
