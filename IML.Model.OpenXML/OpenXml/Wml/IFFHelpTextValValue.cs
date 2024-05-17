using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [MaxLength(256)]
  [Alias("FFHelpTextVal")]
  public interface IFFHelpTextValValue
  {
    String AsString{ get; set; }

  }
}
