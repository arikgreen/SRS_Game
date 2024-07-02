using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml.Wml
{
  [Tag("calendarType")]
  [Alias("CalendarType")]
  public class FldCharType
  {
    [Tag("calendarType")]
    PresentationDocumentType Val{ get; set; }

  }
}
