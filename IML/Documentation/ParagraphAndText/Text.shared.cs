using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
  public partial class Text
  {
    /// <summary>
    /// Obliczenie skrótu na postawie zawartości
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      if (fHashCode == null)
      {
        if (fText != null)
          fHashCode = fText.GetHashCode();
        else
          fHashCode = 0;
      }
      return (int)fHashCode;
    }
    /// <summary>
    /// Pole przechowujące raz obliczoną funkcję skrótu
    /// </summary>
    protected int? fHashCode = null;
  }
}
