using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using System.Xml.Serialization;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Klasa reprezentująca rysunek w dokumencie
  /// </summary>
  [ContentProperty("Content")]
  public partial class Drawing : DocumentContent
  {
    /// <summary>
    /// Na razie element nie jest pusty
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return false;
    }

    /// <summary>
    /// tekst wczytany z dokumentu
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    //[DefaultValue(null)]
    public DrawingItemList Content
    {
      get
      {
        if (fContent == null)
          fContent = new DrawingItemList(this);
        return fContent;
      }
      //set
      //{
      //  fContent = value; if (value != null) value.SetOwner(this);
      //}
    }
    /// <summary>
    /// Pole przechowujące tekst
    /// </summary>
    protected DrawingItemList fContent;

    /// <summary>
    /// Czy zawartość ma być serializowana
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeContent ()
    {
      return fContent != null && !fContent.IsEmpty();
    }

    /// <summary>
    /// identyfikator rysunku w dokumencie
    /// </summary>
    [DefaultValue(null)]
    public override string Id { get; set; }
    /// <summary>
    /// Nazwa rysunku w dokumencie
    /// </summary>
    [DefaultValue(null)]
    public string Name { get; set; }
    /// <summary>
    /// Tytuł rysunku
    /// </summary>
    [DefaultValue(null)]
    public string Title { get; set; }
    /// <summary>
    /// Opis rysunku - tekst alternatywny
    /// </summary>
    [DefaultValue(null)]
    public string Description { get; set; }
    /// <summary>
    /// Czy rysunek jest ukryty
    /// </summary>
    [DefaultValue(null)]
    public bool? Hidden { get; set; }

    /// <summary>
    /// Szerokość rysunku w punktach
    /// </summary>
    public PointValue Width { get; set;}

    /// <summary>
    /// Wysokość rysunku w punktach
    /// </summary>
    public PointValue Height { get; set; }

    /// <summary>
    /// Margines dookoła rysunku
    /// </summary>
    [DefaultValue(null)]
    public Rectangle Margin { get; set; }

    /// <summary>
    /// Margines wewnętrzny rysunku. Efekty mogą spowodować rysowanie po marginesie.
    /// </summary>
    [DefaultValue(null)]
    public Rectangle Padding { get; set; }



    /// <summary>
    /// Identyfikator zakotwiczenia rysunku
    /// </summary>
    [DefaultValue(null)]
    public string AnchorId { get; set; }

    /// <summary>
    /// Identyfikator edycji rysunku
    /// </summary>
    [DefaultValue(null)]
    public string EditId { get; set; }

    /// <summary>
    /// Zdarzenie kliknięcia myszą
    /// </summary>
    [DefaultValue(null)]
    public EventHyperlink OnClick { get; set; }

    /// <summary>
    /// Zdarzenie najechania myszą
    /// </summary>
    [DefaultValue(null)]
    public EventHyperlink OnHover { get; set; }

    /// <summary>
    /// Lista rozszerzeń
    /// </summary>
    public ExtensionList Extensions
    {
      get { if (fExtensions == null) fExtensions = new ExtensionList(this); return fExtensions; }
      set { fExtensions = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>Pole przechowujące listę rozszerzeń</summary>
    protected ExtensionList fExtensions;

    /// <summary>
    /// Czy lista rozszerzeń powinna być serializowana
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeExtensions ()
    {
      return fExtensions != null && !fExtensions.IsEmpty();
    }

    /// <summary>
    /// Blokady nakładane na rysunek
    /// </summary>
    [DefaultValue(default(DrawingLocks))]
    public DrawingLocks Locks { get; set; }

    /// <summary>
    /// URI do odczytu danych graficznych
    /// </summary>
    [DefaultValue(null)]
    public string URI { get; set; }

    /// <summary>
    /// Zakotwicznie rysunku
    /// </summary>
    [DefaultValue(null)]
    public Anchor Anchor { get; set; }
    
  }
}
