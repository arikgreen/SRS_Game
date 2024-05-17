using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml.Wml
{
  [Tag("characterSpacing")]
  [Alias("CharacterSpacing")]
  public class CharacterSpacing
  {
    [Tag("characterSpacing")]
    CharacterSpacingValues Val{ get; set; }

  }
}
