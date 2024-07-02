using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa zakładki
  /// </summary>
  public partial class Bookmark
  {
    /// <summary>
    /// Identyfikator zakładki
    /// </summary>
    public string Id { get; set; }
    /// <summary>
    /// Nazwa zakładki
    /// </summary>
    public string Name { get; set; }         // nazwa zakładki
    /// <summary>
    /// Czy zakładka jest identyfikatorem jakiegoś elementu
    /// </summary>
    public bool IsID { get; set; }
    /// <summary>
    /// obiekt wskazywany przez zakładkę
    /// </summary>
    public object Target { get; set; }           

    //public string OutName;                  // etykieta wynikowa - zastępuje nazwę
    //public string RefPrefix;                // prefiks etykiety
    /// <summary>
    /// zakładka podstawowa - wiele zakładek może oznaczać pojedynczą pozycję
    /// </summary>
    public Bookmark Joint;                 

    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Bookmark () { }

  }
}
