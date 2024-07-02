using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("pictureFormat")]
  [Alias("PictureFormat")]
  public class PictureFormat
  {
    [Tag("pictureFormat")]
    PictureFormatValues Val{ get; set; }

  }
}
