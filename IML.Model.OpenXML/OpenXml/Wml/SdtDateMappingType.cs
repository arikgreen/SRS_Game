using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("sdtDateMappingType")]
  [Alias("SdtDateMappingType")]
  public class SdtDateMappingType
  {
    [Tag("sdtDateMappingType")]
    DateFormatValues Val{ get; set; }

  }
}
