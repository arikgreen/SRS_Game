using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("numPicBullet")]
  [Alias("NumPicBullet")]
  public class NumberingPictureBullet
  {
    [Tag("decimalNumber")]
    DecimalNumberValue NumPicBulletId{ get; set; }

  }
}
