using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using StringColor = System.String;

namespace Iml.Documentation.VML
{
  /// <summary>
  /// Abstrakcyjna klasa kształtów VML
  /// </summary>
  public partial class VmlShape: VmlElement
  {
    //adj (Adjustment Parameters)
    /// <summary>
    /// Parametry dopasowujące kształt
    /// </summary>
    [DefaultValue(null)]
    public string Adjustment { get; set; }
    //bwmode (Black-and-White Mode)
    /// <summary>
    /// Sposób konwersji na tryb czarno-biały
    /// </summary>
    [DefaultValue(null)]
    public string BlackWhiteMode { get; set; }
    //bwnormal (Normal Black-and-White Mode)
    /// <summary>
    /// Sposób normalnej konwersji na tryb czarno-biały
    /// </summary>
    [DefaultValue(null)]
    public string NormalBlackWhiteMode { get; set; }
    //bwpure (Pure Black-and-White Mode)
    /// <summary>
    /// Sposób czystej konwersji na tryb czarno-biały
    /// </summary>
    [DefaultValue(null)]
    public string PureBlackWhiteMode { get; set; }
    //chromakey (Image Transparency Color)
    /// <summary>
    /// Kolor uznawany za przezroczysty
    /// </summary>
    [DefaultValue(null)]
    public StringColor TransparentColor { get; set; }
    //clip (Clipping Toggle)
    /// <summary>
    /// Czy kształt jest przycinany
    /// </summary>
    [DefaultValue(null)]
    public bool? Clipping { get; set; }
    //cliptowrap (Clip to Wrapping Polygon)
    /// <summary>
    /// Przycinanie do wielokąta opisującego
    /// </summary>
    [DefaultValue(null)]
    public bool? ClipToWrappingPolygon { get; set; }
    //connectortype (Shape Connector Type)
    /// <summary>
    /// Typ konektora
    /// </summary>
    [DefaultValue(null)]
    public string ConnectorType { get; set; }
    //forcedash (Force Dashed Outline)
    /// <summary>
    /// Wymuszanie obwiedni przerywanej
    /// </summary>
    [DefaultValue(null)]
    public bool? ForceDash { get; set; }
    //insetpen (Inset Border From Path)
    /// <summary>
    /// Czy obrys jest wewnątrz kształtu
    /// </summary>
    [DefaultValue(null)]
    public bool? InsetPen { get; set; }
    //ole (Embedded Object Toggle)
    /// <summary>
    /// Czy zawiera obiekt OLE
    /// </summary>
    [DefaultValue(null)]
    public bool? EmbedObject { get; set; }
    //oleicon (Embedded Object Icon Toggle)
    /// <summary>
    /// Czy zawiera ikonę obiektu OLE
    /// </summary>
    [DefaultValue(null)]
    public bool? EmbedObjectIcon { get; set; }
    //opacity (Fill Color Opacity)
    /// <summary>
    /// Stopień nieprzezroczystości
    /// </summary>
    [DefaultValue(null)]
    public double? Opacity { get; set; }
    //path (Edge Path)
    /// <summary>
    /// Ścieżka kształtu (łancuch)
    /// </summary>
    [DefaultValue(null)]
    public string PathString { get; set; }
    //preferrelative (Relative Resize Toggle)
    /// <summary>
    /// Czy rozmiar po przeskalowany jest zachowywany?
    /// </summary>
    [DefaultValue(null)]
    public bool? PreferRelative { get; set; }
    //spt (Optional Number)
    /// <summary>
    /// Opcjonalna liczba
    /// </summary>
    [DefaultValue(null)]
    public int? OptionalNumber { get; set; }
    //strokecolor (Shape Stroke Color)
    /// <summary>
    /// Kolor linii
    /// </summary>
    [DefaultValue(null)]
    public StringColor StrokeColor { get; set; }
    //stroked (Shape Stroke Toggle)
    /// <summary>
    /// Czy linia jest rysowana
    /// </summary>
    [DefaultValue(null)]
    public bool? Stroked { get; set; }
    //strokeweight (Shape Stroke Weight)
    /// <summary>
    /// Grubość linii (w punktach)
    /// </summary>
    [DefaultValue(null)]
    public string /*PointValue*/ StrokeWeight { get; set; }

    /// <summary>
    /// Właściwości wypełnienia
    /// </summary>
    [DefaultValue(null)]
    public Fill Fill { get; set; }

    /// <summary>
    /// Właściwości rysowania
    /// </summary>
    [DefaultValue(null)]
    public Stroke Stroke { get; set; }

    /// <summary>
    /// Lista formuł rysowania
    /// </summary>
    //[DefaultValue(null)]
    public Formulas Formulas
    {
      get
      {
        if (fFormulas == null)
          fFormulas = new Formulas(this);
        return fFormulas;
      }
      set
      {
        fFormulas = value;
        if (value != null) value.SetOwner(this);
      }
    }
    /// <summary>
    /// Pole przechowujące listę formuł
    /// </summary>
    protected Formulas fFormulas;

    /// <summary>
    /// Czy lista formuł ma być serializowana
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeFormulas ()
    {
      return fFormulas != null && !fFormulas.IsEmpty();
    }

    /// <summary>
    /// Ścieżka rysowania
    /// </summary>
    [DefaultValue(null)]
    public Path Path 
    { 
      get { return fPath; }
      set { fPath = value;  if (value != null) value.Owner = this; }
    }
    /// <summary>
    /// Pole przechowujące ścieżkę
    /// </summary>
    protected Path fPath;

    /// <summary>
    /// Pole tekstowe
    /// </summary>
    [DefaultValue(null)]
    public TextBox TextBox 
    {
      get { return fTextBox; }
      set { fTextBox = value; if (value != null) value.Owner = this; }
    }
    /// <summary>
    /// Pole przechowujące pole tekstowe
    /// </summary>
    protected TextBox fTextBox;

    /// <summary>
    /// Zawartość elementu
    /// </summary>
    public ShapeHandles ShapeHandles
    {
      get
      {
        if (fShapeHandles == null)
          fShapeHandles = new ShapeHandles(this);
        return fShapeHandles;
      }
      set { fShapeHandles = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące zawartość elementu
    /// </summary>
    protected ShapeHandles fShapeHandles;

    /// <summary>
    /// Czy zawartość ma być serializowana
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeShapeHandles ()
    {
      return fShapeHandles != null && !fShapeHandles.IsEmpty();
    }

    /// <summary>
    /// Cień elementu
    /// </summary>
    [DefaultValue(null)]
    public Shadow Shadow
    {
      get { return fShadow; }
      set { fShadow = value; if (value != null) value.Owner = this; }
    }

    /// <summary>
    /// Pole przechowujące ścieżkę
    /// </summary>
    protected Shadow fShadow;

    /// <summary>
    /// Obliczenie skrótu na podstawie numeru dodatkowego
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      int hash = "VmlShApe".GetHashCode();
      if (OptionalString != null)
        hash += OptionalString.GetHashCode();
      if (OptionalNumber != null)
        hash += OptionalNumber.GetHashCode();
      if (Collection != null)
        hash = Collection.MakeHashUnique(hash);
      return hash;
    }
  }
}
