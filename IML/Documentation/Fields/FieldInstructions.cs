using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Lista instrukcji pola
  /// </summary>
  public partial class FieldInstructions: ItemList<FieldInstruction>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public FieldInstructions () { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public FieldInstructions (object owner) : base(owner) { }
  }
}
