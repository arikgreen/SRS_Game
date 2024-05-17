using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("fFStatusText")]
  [Alias("FFStatusText")]
  public class FFStatusTextValValue
  {
    [Tag("infoTextType")]
    InfoTextValues Type{ get; set; }

    [Tag("fFStatusTextVal")]
    FFStatusTextValValue Val{ get; set; }

  }
}
