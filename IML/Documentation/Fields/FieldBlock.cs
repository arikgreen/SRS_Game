using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca blok tekstu, którego zawartość jest obliczana
  /// </summary>
  public partial class FieldBlock: Block
  {
    /// <summary>
    /// Instrukcja określająca zawartość bloku
    /// </summary>
    public FieldInstruction Instruction { get; set; }
    /// <summary>
    /// Zawartość bloku
    /// </summary>
    public BlockList Content { get { return fContent; } }
    private BlockList fContent = new BlockList();

    /// <summary>
    /// Czy pole jest puste?
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return false;
    }
  }
}
