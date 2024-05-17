using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml.Wml
{
  [Tag("fFTextType")]
  [Alias("FFTextType")]
  public class FFTextType
  {
    [Tag("fFTextType")]
    TextBoxFormFieldValues Val{ get; set; }

  }
}
