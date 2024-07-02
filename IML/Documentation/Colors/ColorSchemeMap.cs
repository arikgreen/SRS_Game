using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Odwzorowanie schematu kolorów
  /// </summary>
  public partial class ColorSchemeMap : ObjectIndex<NameMapping>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public ColorSchemeMap () { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public ColorSchemeMap (object owner) : base(owner) { }

    ///// <summary>
    ///// Czy lista jest pusta
    ///// </summary>
    ///// <returns></returns>
    //public bool IsEmpty()
    //{
    //  return Count == 0;
    //}
  }
}
