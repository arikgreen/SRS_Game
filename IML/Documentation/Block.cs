using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WinDocs = System.Windows.Documents;
using IML=Iml.Foundation;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Windows.Markup;
using System.Windows.Media;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Abstrakcyjna klasa reprezentująca blok tekstu lub grafiki w dokumencie.
  /// Zastępuje klasę <see cref="Block"/> z pakietu <see cref="System.Windows.Documents"/>.
  /// Wprowadzona ze względu na klasę <see cref="BlockList"/>, która zawiera elementy
  /// składowe tekstu sformatowanego (<see cref="RichText"/>).
  /// </summary>
  [KnownType("GetKnownTypes")]
  public abstract class Block : DocumentContent
  {
    /// <summary>
    /// Ponieważ <see cref="Block"/> jest klasą abstrakcyjną,
    /// więc musi udostępniać listę znanych typów konkretnych
    /// dla deserializacji. Typy te będą deklarowane w innych
    /// modułach, stąd lista typów jest budowana dynamicznie.
    /// W tym module są znane tylko typy <see cref="Paragraph"/>
    /// i <see cref="PresentationBlock"/>.
    /// </summary>
    static Block ()
    {
      KnownTypes.Add(typeof(Paragraph));
      KnownTypes.Add(typeof(PresentationBlock));
      KnownTypes.Add(typeof(Table));
    }

    static Type[] GetKnownTypes ()
    {
      return KnownTypes.ToArray();
    }

    /// <summary>
    /// Konwersja na <c>Block</c> z pakietu <c>System.Windows.Documents</c>
    /// </summary>
    public virtual WinDocs.Block ToWinDocsBlock () { return null; }

    /// <summary>
    /// Format bloku (tło, obramowanie)
    /// </summary>
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    public virtual BlockFormat BlockFormat { get; set; }

    ///// <summary>
    ///// Tło elementu pamiętane w elemencie <see cref="BlockFormat"/>
    ///// </summary>
    //[DefaultValue(null)]
    //public override Brush Background
    //{
    //  get
    //  {
    //    return BlockFormat != null ? BlockFormat.Background : null;
    //  }
    //  set
    //  {
    //    if (value != Background)
    //    {
    //      if (BlockFormat == null)
    //        BlockFormat = new BlockFormat ();
    //      BlockFormat.Background = value;
    //      NotifyPropertyChanged ("Background");
    //    }
    //  }
    //}

    ///// <summary>
    ///// Szybki dostęp do obramowania
    ///// </summary>
    //[DefaultValue (null)]
    //public virtual Borders Borders
    //{
    //  get
    //  {
    //    if (borders == null)
    //      borders = new Borders(this);
    //    return borders;
    //  }
    //  set { borders = value;  if (value!=null) value.SetOwner(this) }
    //}
    //private Borders borders;

    ///// <summary>
    ///// Identyfikator stylu
    ///// </summary>
    //[DefaultValue(null)]
    //public string StyleId
    //{
    //  get
    //  {
    //    return fStyleId ?? ((Style != null) ? Style.StyleId : null);
    //  }
    //  set
    //  {
    //    fStyleId = value;
    //  }
    //}
    //private string fStyleId;

    ///// <summary>
    ///// styl fragmentu (z tabeli stylów)
    ///// </summary>
    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //public Style Style
    //{
    //  get { return _Style; }
    //  set
    //  {
    //    if (value != _Style)
    //    {
    //      _Style = value;
    //      fStyleId = null;
    //    }
    //  }
    //}
    //private Style _Style;
  }
}
