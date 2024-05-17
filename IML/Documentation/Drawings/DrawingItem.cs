using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using Object = Iml.Foundation.Object;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Klasa reprezentująca element rysunku
  /// </summary>
  public  abstract partial class DrawingItem: CompoundItem
  {

    /// <summary>
    /// Gdy nie ma identyfikatora
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      int hash = "DraWingItEm".GetHashCode();
      if (Collection != null)
        hash = Collection.MakeHashUnique(hash);
      return hash;
    }

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
    /// Położenie lewego brzegu elementu
    /// </summary>
    [DefaultValue(null)]
    public PointValue Left { get; set; }

    /// <summary>
    /// Położenie górnego brzegu elementu
    /// </summary>
    [DefaultValue(null)]
    public PointValue Top { get; set; }

    /// <summary>
    /// Przesunięcie dzieci od lewej strony
    /// </summary>
    [DefaultValue(null)]
    public PointValue ChildLeft { get; set; }

    /// <summary>
    /// Przesunięcie dzieci od góry
    /// </summary>
    [DefaultValue(null)]
    public PointValue ChildTop { get; set; }

    /// <summary>
    /// Szerokość elementu
    /// </summary>
    [DefaultValue(null)]
    public PointValue Width { get; set; }

    /// <summary>
    /// Wysokość elementu
    /// </summary>
    [DefaultValue(null)]
    public PointValue Height { get; set; }

    /// <summary>
    /// Szerokość elementu
    /// </summary>
    [DefaultValue(null)]
    public PointValue ChildWidth { get; set; }

    /// <summary>
    /// Wysokość elementu
    /// </summary>
    [DefaultValue(null)]
    public PointValue ChildHeight { get; set; }
    /// <summary>
    /// Odbicie lustrzane w poziomie
    /// </summary>
    [DefaultValue(false)]
    public bool FlipHorizontal { get; set; }

    /// <summary>
    /// Odbicie lustrzane w pionie
    /// </summary>
    [DefaultValue(false)]
    public bool FlipVertical { get; set; }

    /// <summary>
    /// Obrót
    /// </summary>
    [DefaultValue(null)]
    public Angle Rotation { get; set; }

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
    /// Blokady nakładane na element rysunkowy
    /// </summary>
    [DefaultValue(default(DrawingLocks))]
    public DrawingLocks Locks { get; set; }

    /// <summary>
    /// Identyfikator kształtu elementu
    /// </summary>
    [DefaultValue(null)]
    public string ShapeId { get; set; }

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
  }
}
