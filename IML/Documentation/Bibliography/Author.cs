using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Iml.Documentation.Bibliography
{
  /// <summary>
  /// Klasa reprezentująca autora dokumentu - może to być osoba lub firma
  /// </summary>
  [KnownType(typeof(Person))]
  public abstract class Author
  {
    ///// <summary>
    ///// Rola autora
    ///// </summary>
    //public AuthorRole Role { get; set; }
  }
}
