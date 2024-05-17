using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Object = Iml.Foundation.Object;

namespace Iml.Documentation
{
  /// <summary>
  /// Lista wierszy tabeli
  /// </summary>
  public partial class TableRows: ItemList<TableRow>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public TableRows () { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public TableRows (Object owner) : base(owner) { }
  }
}
