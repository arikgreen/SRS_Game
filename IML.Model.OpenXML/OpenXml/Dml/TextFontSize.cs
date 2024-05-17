using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml.Dml
{
  [Tag("textBulletSizePoint")]
  [Alias("TextBulletSizePoint")]
  public class TextFontSize
  {
    [Tag("textFontSize")]
    TextFontSizeValue Val{ get; set; }

  }
}
