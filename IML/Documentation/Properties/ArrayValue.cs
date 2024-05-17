using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
  /// <summary>
  /// Wartość tablicowa
  /// </summary>
  public class ArrayValue: Value
  {
    /// <summary>
    /// Wymiary tablicy (wraz z granicami)
    /// </summary>
    [DefaultValue(null)]
    public ArrayDimensions Dimensions { get; set; }

    /// <summary>
    /// Typ elementu (dla tablicy) albo typ bazowy (dla wektora)
    /// </summary>
    [DefaultValue(null)]
    public ValueTypes? BaseType { get; set; }

    /// <summary>
    /// Wartości składowe (w przypadku właściwości złożonych)
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Values Content
    {
      get
      {
        if (fContent == null)
          fContent = new Values(this);
        return fContent;
      }
      set { fContent = value; if (value != null) value.SetOwner(this); }
    }

    /// <summary>
    /// Pole przechowujące wartości składowe
    /// </summary>
    protected Values fContent;

    /// <summary>
    /// Czy zawartość powinna być serializowana
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeContent ()
    {
      return fContent != null && !fContent.IsEmpty();
    }

  }
}
