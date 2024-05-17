using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
  /// <summary>
  /// Deklaracja typu wartości
  /// </summary>
  public partial class ValueType
  {
    /// <summary>
    /// Typ wartości
    /// </summary>
    public ValueTypes Type {get; set;}
    
    /// <summary>
    /// Deklaracja typu elementu składowego
    /// </summary>
    [DefaultValue(null)]
    public ValueType BaseType { get; set; }
  
    /// <summary>
    /// Rozmiar wektora
    /// </summary>
    [DefaultValue(null)]
    public int? Size { get; set; }

    /// <summary>
    /// Wymiary tablicy
    /// </summary>
    [DefaultValue(null)]
    public ArrayDimensions Dimensions { get; set; }
  }
}
