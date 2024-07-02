using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Iml.Modeling
{
  /// <summary>
  /// Typ wyliczeniowy
  /// </summary>
  [ContentProperty("Values")]
  public class EnumType : Type
  {
    /// <summary>
    /// Kolekcja definicji właściwości
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public EnumValues Values
    {
      get
      {
        if (fValues == null)
          fValues = new EnumValues(this);
        return fValues;
      }
    }
    private EnumValues fValues;
  }
}
