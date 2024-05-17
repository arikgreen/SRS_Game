using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Pattern(@"0*((2[5-9])|([3-9][0-9])|([1-3][0-9][0-9])|400)%")]
  [Units(new string[]{"%"})]
  [Alias("TextBulletSizePercent")]
  public interface ITextBulletSizePercentValue
  {
    Int32 AsInt32{ get; set; }

  }
}
