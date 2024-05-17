using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml
{
  [Tag("calendarType")]
  [Alias("CalendarType")]
  public class CalendarType
  {
    [Tag("calendarType")]
    PresentationDocumentType Val{ get; set; }

  }
}
