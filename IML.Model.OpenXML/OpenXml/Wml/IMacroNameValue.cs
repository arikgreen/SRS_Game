using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [MaxLength(33)]
  [Alias("MacroName")]
  public interface IMacroNameValue
  {
    String AsString{ get; set; }

  }
}
