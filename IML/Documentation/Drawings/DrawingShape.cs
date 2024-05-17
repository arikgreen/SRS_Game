using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;
using Iml.Foundation;
using System.Windows.Markup;
using System.Xml.Serialization;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Klasa reprezentująca kształt na rysunku
  /// </summary>
  //[ContentProperty("ShapeParameters")]
  public partial class DrawingShape: DrawingItem
  {

    /// <summary>
    /// Typ kształtu (geometria)
    /// </summary>
    [DefaultValue(null)]
    public string ShapeType {get; set;}

    /// <summary>
    /// Parametry geometrii - dotyczy zarówno predefiniowanej, jak i swobodnie definiowanej
    /// </summary>
    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [XmlArray]
    [XmlArrayItem(typeof(ShapeParameter))]
    public ShapeParameters Parameters 
    { 
      get
      {
        if (fParameters == null)
          fParameters = new ShapeParameters();
        return fParameters;
      }
      set { fParameters = value; }
    }
    /// <summary>
    /// Pole przechowujące parametry
    /// </summary>
    protected ShapeParameters fParameters;

    /// <summary>
    /// Czy parametry mają być serializowane
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeParameters()
    {
      return fParameters != null && !fParameters.IsEmpty();
    }

    /// <summary>
    /// Swobodnie definiowana geometria kształtu
    /// </summary>
    [DefaultValue(null)]
    public ShapeGeometry CustomGeometry { get; set; }

    /// <summary>
    /// Kolor linii
    /// </summary>
    [DefaultValue(null)]
    public ColorRef LineColor { get; set; }

    /// <summary>
    /// Kolor wypełnienia
    /// </summary>
    [DefaultValue(null)]
    public ColorRef FillColor { get; set; }

    /// <summary>
    /// Kolor efektu
    /// </summary>
    [DefaultValue(null)]
    public ColorRef EffectColor { get; set; }

    /// <summary>
    /// Referencja do czcionki
    /// </summary>
    [DefaultValue(null)]
    public FontRef TextFont { get; set; }

    /// <summary>
    /// Wypełnienie kształtu
    /// </summary>
    [DefaultValue(null)]
    public Fill Fill { get; set; }

    /// <summary>
    /// Obwiednia kształu
    /// </summary>
    [DefaultValue(null)]
    public Outline Outline { get; set; }

    /// <summary>
    /// Efekty nakładane na kształt
    /// </summary>
    [DefaultValue(null)]
    public EffectList EffectList {get; set;}

    /// <summary>
    /// Czy ma pole tekstowe
    /// </summary>
    [DefaultValue(null)]
    public bool? HasTextBox { get; set; }

    /// <summary>
    /// Czy ma pole tekstowe
    /// </summary>
    [DefaultValue(null)]
    public TextBoxFormat TextBoxFormat { get; set; }


    /// <summary>
    /// Pudełko tekstowe umieszczane w kształcie
    /// </summary>
    [DefaultValue(null)]
    public TextBox TextBox { get; set; }

    /// <summary>
    /// Czy kształt jest konektorem?
    /// </summary>
    [DefaultValue(null)]
    public bool? IsConnector { get; set; }

    /// <summary>
    /// Połączenie wejściowe konektora
    /// </summary>
    [DefaultValue(null)]
    public ShapeConnection Source { get; set; }

    /// <summary>
    /// Połączenie wyjściowe konektora
    /// </summary>
    [DefaultValue(null)]
    public ShapeConnection Target { get; set; }

  }
}
