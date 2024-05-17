using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Element reprezentujący początek zakładki
  /// </summary>
  public partial class BookmarkBegin: DocumentContent
  {
    
    /// <summary>
    /// Nazwa (widoczna) zakładki
    /// </summary>
    [DefaultValue(null)]
    public string Name { get; set; }

    /// <summary>
    /// Pierwsza kolumna pokryta przez zakładkę
    /// </summary>
    [DefaultValue(null)]
    public int? ColumnFirst { get; set; }

    /// <summary>
    /// Ostatnia kolumna pokryta przez zakładkę
    /// </summary>
    [DefaultValue(null)]
    public int? ColumnLast { get; set; }

    /// <summary>
    /// Przesunięcie zakładki przez element "CustomXml" (z Worda)
    /// </summary>
    [DefaultValue(null)]
    public Displacing? DisplacedByCustomXml { get; set; }

    //public string OutName;                  // etykieta wynikowa - zastępuje nazwę
    //public string RefPrefix;                // prefiks etykiety
    //public IML.Paragraph Destination;       // akapit wskazywany
    //public Bookmark Joint;                  // zakładka podstawowa - wiele zakładek może oznaczać pojedynczą pozycję

    /// <summary>
    /// Na razie żadna zakładka nie jest pusta
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return false;
    }
  }
}
