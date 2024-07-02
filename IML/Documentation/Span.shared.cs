using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using System.Runtime;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Iml.Documentation
{
  /// <summary>
  /// Element tekstowy grupujący elementy <see cref="Inline"/>
  /// </summary>
  [ContentProperty("Inlines")]
  public partial class Span : Inline
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Span() { Inlines = new InlineCollection(this); }

    /// <summary>
    /// Konstruktor tworzący element i dodający podany element składowy.
    /// </summary>
    public Span(Inline childInline): this() { Inlines.Add(childInline); }

    /// <summary>
    /// Składowe elementy <see cref="Inline"/>
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public InlineCollection Inlines { get; private set; }

    /// <summary>
    /// Czy kolekcja elementów składowych ma być serializowana?
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInlines()
    {
      return Inlines.Count > 0;
    }

    /// <summary>
    /// Czy element jest pusty
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return !ShouldSerializeInlines();
    }
  }
}
