using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("sym")]
  [Alias("Sym")]
  public class SymbolChar
  {
    [Tag("string")]
    String Font{ get; set; }

    [Tag("shortHexNumber")]
    ShortHexNumberValue Char{ get; set; }

  }
}
