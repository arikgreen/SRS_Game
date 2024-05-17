using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("MailMergeDocType")]
  public enum MailMergeDocumentValues
  {
    [EnumString("catalog")]
    Catalog = 0,
    [EnumString("envelopes")]
    Envelopes,
    [EnumString("mailingLabels")]
    MailingLabels,
    [EnumString("formLetters")]
    FormLetters,
    [EnumString("email")]
    Email = 4,
    [EnumString("fax")]
    Fax = 5,
  }
}
