
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca instrukcję pola tekstowego lub pola blokowego
  /// </summary>
  public partial class TextInstruction : TextRun
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public TextInstruction () { }

    /// <summary>
    /// Konstruktor kopiujący
    /// </summary>
    /// <param name="source"></param>
    public TextInstruction (Run source) : base(source) { }
  }
}

