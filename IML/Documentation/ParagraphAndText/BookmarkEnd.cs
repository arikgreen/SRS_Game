using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Element reprezentujący koniec zakładki
  /// </summary>
  public partial class BookmarkEnd: DocumentContent
  {
    /// <summary>
    /// Przesunięcie zakładki przez element "CustomXml" (z Worda)
    /// </summary>
    [DefaultValue(null)]
    public Displacing? DisplacedByCustomXml { get; set; }

    /// <summary>
    /// Element nie jest pusty
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return false;
    }
  }
}
