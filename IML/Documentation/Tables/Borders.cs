using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca obramowania
  /// </summary>
  //[TypeConverter (typeof (BordersTypeConverter))]
  public partial class Borders : ObjectList<BorderLine>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Borders () { }

    /// <summary>
    /// Konstruktor właściwy dla listy elementów.
    /// </summary>
    /// <param name="aOwner"></param>
    public Borders (Item aOwner) : base(aOwner) { }

  }
}