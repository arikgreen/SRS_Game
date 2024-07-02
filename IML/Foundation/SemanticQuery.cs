using System;
using System.Collections.Generic;

namespace Iml.Foundation
{
  /// <summary>
  /// Kwerenda elementów semantycznych.
  /// </summary>
  public partial class SemanticQuery<itemType>: ElementQuery<itemType, SemanticElement> where itemType: SemanticElement
  {
    /// <summary>
    /// Konstruktor właściwy dla kwerendy
    /// </summary>
    /// <param name="source">źródłowa kolekcja elementów</param>
    /// <param name="match">warunek filtrowania</param>
    public SemanticQuery(IList<SemanticElement> source, Predicate<SemanticElement> match) : base(source, match) { }


  }
}
