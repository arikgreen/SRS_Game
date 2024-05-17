using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("sdtComboBox")]
  [Alias("SdtComboBox")]
  public class SdtContentComboBox
  {
    [Tag("string")]
    String LastValue{ get; set; }

  }
}
