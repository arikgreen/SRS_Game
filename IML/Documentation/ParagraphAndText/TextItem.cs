using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Abstrakcyjna klasa podstawowa dla wszystkich elementów tekstowych we fragmencie akapitu
  /// </summary>
  [KnownType(typeof(Text))]
  [KnownType(typeof(TabChar))]
  public abstract class TextItem: DocumentContent
  {
    /// <summary>
    /// Abstrakcyjna procedura podająca łańcuch właściwy dla elementu
    /// </summary>
    /// <returns></returns>
    public abstract string GetString ();

    ///// <summary>
    ///// Czy ten element tekstowy jest pusty?
    ///// </summary>
    ///// <returns></returns>
    //public abstract bool IsEmpty ();
  }
}
