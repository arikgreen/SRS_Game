using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("fFHelpText")]
  [Alias("FFHelpText")]
  public class FFHelpTextValValue
  {
    [Tag("infoTextType")]
    InfoTextValues Type{ get; set; }

    [Tag("fFHelpTextVal")]
    FFHelpTextValValue Val{ get; set; }

  }
}
