using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Iml.Documentation
{
  /// <summary>
  /// Format komórki tabeli
  /// </summary>
  public partial class TableCellFormat: Format
  {
    /// <summary>
    /// Zwraca typ formatu
    /// </summary>
    public override FormatType Type
    {
      get { return FormatType.TableCell; }
    }

    /// <summary> szerokość komórki w punktach</summary>
    [DefaultValue(null)]
    public TableWidth Width { get; set; }

    /// <summary>
    /// Czy zawijanie tekstu w komórce jest wyłączone
    /// </summary>
    [DefaultValue(null)]
    public bool? NoWrap { get; set; }

    /// <summary>
    /// Kierunek wyświetlania tekstu
    /// </summary>
    [DefaultValue(null)]
    public TextDirection TextDir { get; set; }

    /// <summary>
    /// Czy ignorować znak końca komórki przy obliczaniu wysokości wiersza
    /// </summary>
    [DefaultValue(null)]
    public bool? IgnoreEndMark { get; set; }

    /// <summary>
    /// Sposób wyrównania zawartości w komórce
    /// </summary>
    [DefaultValue(null)]
    public VerticalAlignment? VerticalAlignment { get; set; }

    /// <summary>
    /// Cieniowanie komórki
    /// </summary>
    [DefaultValue(null)]
    public Shading Shading { get; set; }

    /// <summary>
    /// Obramowanie komórki
    /// </summary>
    //[DefaultValue(null)]
    [XmlArray]
    [XmlArrayItem(Type = typeof(BorderLine))]
    public virtual Borders Borders
    {
      get
      {
        if (borders == null)
          borders = new Borders(this);
        return borders;
      }
      set { borders = value; if (value != null) value.SetOwner(this); }
    }
    private Borders borders;

    /// <summary>
    /// Czy obramowania mają być serializowane
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeBorders()
    {
      return borders != null && !borders.IsEmpty();
    }

    /// <summary>
    /// Czy ten format jest pusty
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return
        !ShouldSerializeBorders()
        && this.Width == null
        && this.NoWrap == null
        && this.TextDir == null
        && this.Shading == null
        && this.VerticalAlignment == null
        && this.IgnoreEndMark == null
        && base.IsEmpty();
    }
  }
}
