using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using Iml.Foundation;
using StringColor = System.String;

namespace Iml.Documentation.VML
{
  /// <summary>
  /// Abstrakcyjny element rysunku VML
  /// </summary>
  [ContentProperty("Content")]
  public abstract partial class VmlElement : VmlItem
  {

    /// <summary>
    /// Czy element jest dozwolony w komórce tabeli
    /// </summary>
    [DefaultValue(null)]
    public bool? AllowInCell { get; set; }

    /// <summary>
    /// Czy dozwolone jest nakładanie się kształtów
    /// </summary>
    [DefaultValue(null)]
    public bool? AllowOverlap { get; set; }

    /// <summary>
    /// Tekst alternatywny
    /// </summary>
    [DefaultValue(null)]
    public string AlternateText { get; set; }

    /// <summary>
    /// Kolor dolnego obramowania
    /// </summary>
    [DefaultValue(null)]
    public StringColor BorderBottomColor { get; set; }

    /// <summary>
    /// Kolor lewego obramowania
    /// </summary>
    [DefaultValue(null)]
    public StringColor BorderLeftColor { get; set; }

    /// <summary>
    /// Kolor prawego obramowania
    /// </summary>
    [DefaultValue(null)]
    public StringColor BorderRightColor { get; set; }

    /// <summary>
    /// Kolor dolnego obramowania
    /// </summary>
    [DefaultValue(null)]
    public StringColor BorderTopColor { get; set; }

    /// <summary>
    /// Czy element jest graficznym punktorem
    /// </summary>
    [DefaultValue(null)]
    public bool? Bullet { get; set; }

    /// <summary>
    /// Czy element ma się zachowywać jak przycisk
    /// </summary>
    [DefaultValue(null)]
    public bool? Button { get; set; }


    /// <summary>
    /// Klasa CSS
    /// </summary>
    [DefaultValue(null)]
    public string CssClass { get; set; }

    /// <summary>
    /// Styl CSS
    /// </summary>
    [DefaultValue(null)]
    public string CssStyle { get; set; }

    /// <summary>
    /// Początek układu współrzędnych
    /// </summary>
    [DefaultValue(null)]
    public string CoordinateOrigin { get; set; }

    /// <summary>
    /// Rozmiar układu współrzędnych
    /// </summary>
    [DefaultValue(null)]
    public string CoordinateSize { get; set; }

    /// <summary>
    /// Typ układu diagramu
    /// </summary>
    [DefaultValue(null)]
    public string DiagramLayout { get; set; }

    /// <summary>
    /// Typ układu diagramu ostatnio zastosowany do elementów składowych
    /// </summary>
    [DefaultValue(null)]
    public string DiagramLayoutMRU { get; set; }

    /// <summary>
    /// Opcjonalny parametr nadawany do elementu przez aplikację diagramu
    /// </summary>
    [DefaultValue(null)]
    public string DiagramNodeKind { get; set; }

    /// <summary>
    /// Czy element powiadamia o dwukliku
    /// </summary>
    [DefaultValue(null)]
    public bool? DoubleClickNotify { get; set; }

    /// <summary>
    /// Kolor wypełnienia
    /// </summary>
    [DefaultValue(null)]
    public StringColor FillColor { get; set; }

    /// <summary>
    /// Czy kształt jest wypełniony
    /// </summary>
    [DefaultValue(null)]
    public bool? Filled { get; set; }

    /// <summary>
    /// Dane graficzne (w postaci znaków Base64
    /// </summary>
    [DefaultValue(null)]
    public string GraphicData { get; set; }

    /// <summary>
    /// Czy element element jest linijką poziomą
    /// </summary>
    [DefaultValue(null)]
    public bool? HorizontalRule { get; set; }

    /// <summary>
    /// Czy pozioma linijka ma cień 3D
    /// </summary>
    [DefaultValue(null)]
    public bool? HorizontalRule3DShade { get; set; }

    /// <summary>
    /// Długość poziomej linijki w stosunku do szerokości strony
    /// </summary>
    [DefaultValue(null)]
    public Percent HorizontalRulePercentage { get; set; }

    /// <summary>
    /// Czy zastosować standardowe wyświetlanie poziomej linijki
    /// </summary>
    [DefaultValue(null)]
    public bool? HorizontalRuleStandardDisplay { get; set; }


    /// <summary>
    /// Poziome wyrównanie elementu
    /// </summary>
    [DefaultValue(null)]
    public HorizontalAlignment? HorizontalAlignment { get; set; }

    /// <summary>
    /// Miejsce docelowe hiperłącza
    /// </summary>
    [DefaultValue(null)]
    public string HyperlinkTarget { get; set; }

    /// <summary>
    /// Tryb obliczania wewnętrznego marginesu
    /// </summary>
    [DefaultValue(null)]
    public string InsetMode { get; set; }

    /// <summary>
    /// Czy kształt jest drukowany
    /// </summary>
    [DefaultValue(null)]
    public bool? Printable { get; set; }

    /// <summary>
    /// Łańcuch opcjonalny
    /// </summary>
    [DefaultValue(null)]
    public string OptionalString { get; set; }

    /// <summary>
    /// Identyfikator przegrupowania
    /// </summary>
    [DefaultValue(null)]
    public string RegroupId { get; set; }

    /// <summary>
    /// Czy dodatkowe uchwyty kształtu są ukryte
    /// </summary>
    [DefaultValue(null)]
    public bool? ShapeHandle { get; set; }

    /// <summary>
    /// Miejsce wyświetlania hiperłącza
    /// </summary>
    [DefaultValue(null)]
    public string HyperlinkTargetWindow { get; set; }

    /// <summary>
    /// Tooltip
    /// </summary>
    [DefaultValue(null)]
    public string Title { get; set; }

    /// <summary>
    /// Czy użytkownik dodał kształt do głównego slajdu
    /// </summary>
    [DefaultValue(null)]
    public bool? UserDrawn { get; set; }

    /// <summary>
    /// Czy umiejscownienie skryptu jest ukryte
    /// </summary>
    [DefaultValue(null)]
    public bool? UserHidden { get; set; }

    /// <summary>
    /// Współrzędne wielokąta opisanego na kształcie
    /// </summary>
    [DefaultValue(null)]
    public string WrapCoordinates { get; set; }

    /// <summary>
    /// Blokada edycji elementu
    /// </summary>
    [DefaultValue(null)]
    public Locks? Lock { get; set; }

    /// <summary>
    /// Zawartość elementu
    /// </summary>
   [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public VmlItemList Content
    {
      get
      {
        if (fContent == null)
          fContent = new VmlItemList(this);
        return fContent;
      }
      //set { fContent = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące zawartość elementu
    /// </summary>
    protected VmlItemList fContent;

    /// <summary>
    /// Czy zawartość ma być serializowana
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeContent ()
    {
      return fContent != null && !fContent.IsEmpty();
    }

    /// <summary>
    /// Na razie nie jest pusty.
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return false;
    }

    /// <summary>
    /// Obliczenie skrótu na podstawie numeru dodatkowego
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      int hash = "VmlElemEnt".GetHashCode();
      if (OptionalString != null)
        hash += OptionalString.GetHashCode();
      if (Collection != null)
        hash = Collection.MakeHashUnique(hash);
      return hash;
    }
  }
}
