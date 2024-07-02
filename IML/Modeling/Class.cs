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
  /// Definicja klasy modelowej
  /// </summary>
  [ContentProperty("Properties")]
  public class Class: Type
  {
    /// <summary>
    /// Czy metaklasa jest abstrakcyjna
    /// </summary>
    [DefaultValue(false)]
    public bool IsAbstract { get; set; }

    /// <summary>
    /// Nazwa metaklasy nadrzędnej
    /// </summary>
    [DefaultValue(null)]
    public string DerivedFrom { get; set; }

    /// <summary>
    /// Kolekcja definicji właściwości
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Properties Properties
    {
      get
      {
        if (fProperties == null)
          fProperties = new Properties(this);
        return fProperties;
      }
    }
    private Properties fProperties;
  }
}
