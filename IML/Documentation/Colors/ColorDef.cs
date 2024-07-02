using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Definicja koloru w schemacie kolorów
  /// </summary>
  public partial class ColorDef: Item
  {
    /// <summary>
    /// Identyfikator lokalny tworzony na podstawie nazwy
    /// </summary>
    public override int GetHash()
    {
      if (Name != null)
        return Name.GetHashCode();
      return 0;
    }

    /// <summary>
    /// Nazwa koloru
    /// </summary>
    [DefaultValue(null)]
    public string Name { get; set; }

    /// <summary>
    /// Wartość koloru
    /// </summary>
    [DefaultValue(null)]
    public Color Value { get; set; }
  }
}
