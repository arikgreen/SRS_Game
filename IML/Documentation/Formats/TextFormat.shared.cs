using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  public partial class TextFormat
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public TextFormat ()
    {
    }

    /// <summary>
    /// Inicjalizacja przez wartość atrybutów.
    /// </summary>
    /// <param name="value">wartość początkowa</param>
    public TextFormat (int value) { Attributes = value; FontSize = 0; VerticalShift = 0; }

    /// <summary>
    /// Kopiowanie struktury.
    /// </summary>
    /// <param name="other">obiekt, z którego atrybuty są kopiowane</param>
    public TextFormat (TextFormat other)
    {
      Attributes = other.Attributes;
      FontSize = other.FontSize;
      VerticalShift = other.VerticalShift;
    }

    #region metody szybkiego dostępu do atrybutów typu bool?
    /// <summary>
    /// Właściwość dostępowa do atrybutu Italic
    /// </summary>
    [DefaultValue(null)]
    public bool? Italic
    {
      get { return Attributes.Italic; }
      set { Attributes.Italic = value; }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu Boldface
    /// </summary>
    [DefaultValue(null)]
    public bool? Boldface
    {
      get { return Attributes.Boldface; }
      set { Attributes.Boldface = value; }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu Underlined
    /// </summary>
    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [DefaultValue(null)]
    public bool? Underlined
    {
      get { return Attributes.Underlined; }
      set { Attributes.Underlined = value; }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu StrikeThrough
    /// </summary>
    [DefaultValue(null)]
    public bool? Strikethrough
    {
      get { return Attributes.Strikethrough; }
      set { Attributes.Strikethrough = value; }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu Subscript
    /// </summary>
    [DefaultValue(null)]
    public bool? Superscript
    {
      get { return Attributes.Superscript; }
      set { Attributes.Superscript = value; }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu Subscript
    /// </summary>
    [DefaultValue(null)]
    public bool? Subscript
    {
      get { return Attributes.Subscript; }
      set { Attributes.Subscript = value; }
    }
    #endregion

    #region metody szybkiego dostępu do atrybutów typu bool
    /// <summary>
    /// Właściwość dostępowa do atrybutu Italic
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

    public bool IsItalic
    {
      get { return Attributes.IsItalic; }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu Boldface
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsBoldface
    {
      get { return Attributes.IsBoldface; }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu Underlined
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsUnderlined
    {
      get { return Attributes.IsUnderlined; }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu StrikeThrough
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsStrikethrough
    {
      get { return Attributes.IsStrikethrough; }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu Subscript
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsSuperscript
    {
      get { return Attributes.IsSuperscript; }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu Superscript
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsSubscript
    {
      get { return Attributes.IsSubscript; }
    }
    #endregion

    /// <summary>
    /// Czyszczenie atrybutów
    /// </summary>
    public new void Clear ()
    {
      Attributes = 0;
      Typeface = null;
      FontSize = null;
      VerticalShift = null;
      Language = null;
      Proofing = null;
      UnderlineStyle = null;
      FontColor = null;
      base.Clear();
    }

    /// <summary>
    /// Czy format jest pusty?
    /// </summary>
    /// <returns></returns>
    public new bool IsEmpty()
    {
      return (int)Attributes == 0
        && Typeface == null
        && Language == null
        && FontSize == null
        && VerticalShift == null
        && Language == null
        && Proofing == null
        && UnderlineStyle == null
        && FontColor == null
        && !ShouldSerializeSubstitutes()
        && base.IsEmpty();
    }
    ///// <summary>
    ///// Sprawdzenie, czy atrybutu formatu są identyczne.
    ///// </summary>
    ///// <param name="other"></param>
    ///// <returns></returns>
    //public bool EqualsTo (TextFormat other)
    //{
    //  bool ok = (Attributes == other.Attributes) && VerticalShift == other.VerticalShift && FontSize == other.FontSize;
    //  return ok;
    //}

    /// <summary>
    /// Porównanie z innym formatem
    /// </summary>
    public bool Equals (TextFormat other)
    {
      return this.Attributes == other.Attributes && this.FontSize == other.FontSize && this.VerticalShift == other.VerticalShift;
    }

    /// <summary>
    /// Połączenie dwóch zbiorów atrybutów. Atrybuty pierwszego zbioru mają pierwszeństwo.
    /// </summary>
    public static TextFormat operator | (TextFormat A, TextFormat B)
    {
      if (B == null)
        return A;
      if (A == null)
        return B;
      return A.Merge(B);
    }

    /// <summary>
    /// Połączenie formatu z innym formatem
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public TextFormat Merge (TextFormat other)
    {
      TextFormat newFormat = new TextFormat();
      if (other != null)
      {
        newFormat.Attributes = this.Attributes.Merge(other.Attributes);
        newFormat.Typeface = other.Typeface ?? this.Typeface;
        if (other.FontSize != null)
          newFormat.FontSize = other.FontSize;
        else
          newFormat.FontSize = this.FontSize;
      }
      return newFormat;
    }

  }
}
