using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  public partial class DrawingItem
  {
    /// <summary>
    /// Dodanie elementu do rysunku
    /// </summary>
    /// <param name="element"></param>
    public void Add (DrawingItem element)
    {
      Components.Add(element);
    }
  }
}
