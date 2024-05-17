using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Bibliography
{
  /// <summary>
  /// Klasa reprezentująca firmę - autora
  /// </summary>
  public class Corporation: Author
  {
    /// <summary>
    /// Nazwa firmy
    /// </summary>
    public String Name { get; set;}

    /// <summary>
    /// Zamiana na łańcuch - zwraca nazwę
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      return Name;
    }
  }
}
