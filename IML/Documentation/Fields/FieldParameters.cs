using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Lista parametrów instrukcji tekstowej
  /// </summary>
  public partial class FieldParameters: ItemList<NameValuePair>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public FieldParameters (): base() { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public FieldParameters (Item owner) : base(owner) { }
  }
}
