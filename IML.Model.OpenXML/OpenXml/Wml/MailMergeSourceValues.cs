using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("MailMergeSourceType")]
  public enum MailMergeSourceValues
  {
    [EnumString("database")]
    Database = 0,
    [EnumString("addressBook")]
    AddressBook = 1,
    [EnumString("document1")]
    Document1 = 2,
    [EnumString("document2")]
    Document2 = 3,
    [EnumString("text")]
    Text = 4,
    [EnumString("email")]
    Email = 5,
    [EnumString("native")]
    Native = 6,
    [EnumString("legacy")]
    Legacy = 7,
    [EnumString("master")]
    Master = 8,
  }
}
