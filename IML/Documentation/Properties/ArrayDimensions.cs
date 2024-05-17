using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
  /// <summary>
  /// Wymiary tablicy
  /// </summary>
  public class ArrayDimensions: List<ArrayBounds>
  {
    /// <summary>
    /// konstruktor domyślny
    /// </summary>
    public ArrayDimensions () { }

    /// <summary>
    /// Konstruktor z rozmiarem
    /// </summary>
    /// <param name="size"></param>
    public ArrayDimensions (int size) : base(size) { }

  }
}
