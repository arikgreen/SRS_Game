using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Documents;
using System.Windows.Markup;
using Iml.Foundation;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Iml.Documentation
{

  /// <summary>
  /// Klasa reprezentująca tekst, który może być prosty lub sformatowany.
  /// Tekst sformatowany może składać się z wielu akapitów,
  /// a każdy akapit zawiera elementy <see cref="Inline"/> z pakietu <see cref="System.Windows.Documents"/>
  /// Klasa ta rozszerza klasę <c>Iml.Foundation.RichText</c>
  /// </summary>
  [ContentProperty("Body")]
  public partial class RichText: ImlText
  {
    /// <summary>
    /// Konstruktor domyślny.
    /// </summary>
    public RichText(): base() {}

    /// <summary>
    /// Konstruktor umożliwiający łatwe utworzenie elementu <see cref="RichText"/>
    /// zawierającego prosty tekst.
    /// </summary>
    /// <param name="value"></param>
    public RichText(string value): base (value) { }

    /// <summary>
    /// Konstruktor umożliwiający łatwe utworzenie elementu <see cref="RichText"/>
    /// w określonym języku zawierającego prosty tekst.
    /// </summary>
    /// <param name="language">język, w którym tworzony jest tekst</param>
    /// <param name="value"></param>
    public RichText(string language, string value): base (language, value) { }

    ///// <summary>
    ///// Zwolnienie referencji
    ///// </summary>
    //public void Dispose ()
    //{
    //  if (body != null)
    //    foreach (Block block in body)
    //      block.Dispose ();
    //}

    private BlockList body;
    /// <summary>
    /// Lista bloków tworząca tekst sformatowany.
    /// </summary>
    [DataMember]
    [Association("RichTextBody", "ID", "OwnerID")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public BlockList Body 
    {
      get 
      { 
        if (body == null) 
          body = new BlockList(this); 
        return body; 
      }
    }

    /// <summary>
    /// Lista bloków jest serializowana tylko wówczas, gdy nie jest pusta.
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeBody()
    {
      return (body!=null) && !IsPlain;
    }


    /// <summary>
    /// Ustawienie prostego tekstu - kasuje listę bloków
    /// </summary>
    /// <param name="value"></param>
    public override void SetText(string value)
    {
      plainText = value;
      if (value != null)
      {
        Body.Clear();
        Body.Add(new Paragraph(value));
      }
      else
        body = null;
    }

    /// <summary>
    /// Pobranie prostego tekstu - również z listy bloków.
    /// Trzeba sprawdzić, czy tekst jest prosty.
    /// </summary>
    /// <returns></returns>
    public override string GetText()
    {
      if (!String.IsNullOrEmpty(plainText))
        return plainText;
      if (body != null)
      {
        StringBuilder sb = new StringBuilder();
        bool first = true;
        foreach (Block item in body)
        {
          if (item is Paragraph)
          {
            if (!first)
              sb.Append("\r\n");
            first = false;
            sb.Append((item as Paragraph).GetText());
          }
        }
        return sb.ToString();
      }
      else
        return plainText;
    }

    /// <summary>
    /// Ustalenie formatu zgodnie z zawartością
    /// </summary>
    /// <returns>Czy ustalenie się udało?</returns>
    public bool FixFormat ()
    {
      ParagraphStyle uniformStyle;
      ParagraphFormat uniformFormat;
      TextFormat uniformAttributes;
      bool ok = HasUniformFormat (out uniformStyle, out uniformFormat, out uniformAttributes);
      if (ok)
      {
        Style = uniformStyle;
        ParagraphFormat = uniformFormat;
        TextFormat = uniformAttributes;
      }
      return ok;
    }

    /// <summary>
    /// Czy element zawiera tylko prosty tekst?
    /// </summary>
    protected override bool IsPlainText()
    {
      ParagraphStyle uniformStyle; 
      ParagraphFormat uniformFormat;
      TextFormat uniformAttributes;
      bool ok = HasUniformFormat (out uniformStyle, out uniformFormat, out uniformAttributes);
      return false;
    }

    /// <summary>
    /// Czy tekst ma jednolity format?
    /// </summary>
    /// <param name="uniformStyle">jednolity styl</param>
    /// <param name="uniformFormat">jednolity format akapitu</param>
    /// <param name="uniformAttributes">jednolite atrybuty tekstu</param>
    /// <returns></returns>
    public bool HasUniformFormat
      (out ParagraphStyle uniformStyle, 
       out ParagraphFormat uniformFormat,
       out TextFormat uniformAttributes)
    {
      uniformStyle = null;
      uniformFormat = null;
      uniformAttributes = null;
      if (Body == null)
        return true;
      if (Body.Count == 0)
        return true;
      foreach (Block aBlock in Body)
      {
        if (aBlock is Paragraph)
        {
          Paragraph aParagraph = (Paragraph)aBlock;
          ParagraphStyle style;
          ParagraphFormat format;
          TextFormat attributes;
          if (!aParagraph.HasUniformFormat (out style, out format, out attributes))
            return false;
          if (style != null)
          {
            if (style!=uniformStyle)
            {
              if (uniformStyle == null)
                uniformStyle = style;
              else
                return false;
            }
          }
          if (format != null)
          {
            if (!format.Equals (uniformFormat))
            {
              if (uniformFormat == null)
                uniformFormat = format;
              else
                return false;
            }
          }
          if (attributes != null)
          {
            if (!attributes.Equals (uniformAttributes))
            {
              if (uniformAttributes == null)
                uniformAttributes = attributes;
              else
                return false;
            }
          }
        }
        else
          return false;
      }
      return true;
    }

    /// <summary>
    /// Konwersja jawna na łańcuch (z tekstu prostego)
    /// </summary>
    public override string ToString()
    {
      return GetText();
    }

    /// <summary>
    /// Konwersja niejawna na łańcuch (z tekstu prostego)
    /// </summary>
    public static implicit operator String(RichText value)
    {
      return value.GetText();
    }

    /// <summary>
    /// Konwersja niejawna prostego tekstu na <see cref="RichText"/>
    /// </summary>
    public static implicit operator RichText(string value)
    {
      return new RichText(value);
    }
 
    /// <summary>
    /// Dodanie bloku do tekstu sformatowanego
    /// </summary>
    /// <param name="item">dodawany blok</param>
    public void Add(Block item)
    {
      if (Body == null)
      {
        //body = new BlockList(this);
        //if (!String.IsNullOrEmpty(plainText))
        //  Body.Add(new Paragraph(new Run(plainText)));
        plainText = null;
      }
      Body.Add(item);
    }
/*
    /// <summary>
    /// Przepisanie ID z innego elementu
    /// </summary>
    public override void MergeID(Element otherElement)
    {
      base.MergeID(otherElement);
      if (otherElement is RichText)
      {
        RichText other = (RichText)otherElement;
        this.Body.MergeIDs(other.Body);
      }
    }
*/

    //#region implementacja interfejsu IRefencingElement

    ///// <summary>
    ///// Podaje listę elementów do rozwiązywania rerefncji
    ///// </summary>
    ///// <returns></returns>
    //protected virtual IEnumerable<IReferencingElement> GetReferencingItems ()
    //{
    //  if (body != null)
    //    return body;
    //  return new IReferencingElement[0];
    //}

    //void IReferencingElement.AddOutgoingReference (Iml.Foundation.Reference aReference)
    //{
    //}

    //void IReferencingElement.RemoveOutgoingReference (Iml.Foundation.Reference aReference)
    //{
    //}

    //void IReferencingElement.ClearReferences ()
    //{
    //  foreach (IReferencingElement item in GetReferencingItems ())
    //    item.ClearReferences ();
    //}

    //bool IReferencingElement.HasUnresolvedReferences
    //{
    //  get
    //  {
    //    foreach (IReferencingElement item in GetReferencingItems ())
    //      if (item.HasUnresolvedReferences)
    //        return true;
    //    return false;
    //  }
    //}

    //void IReferencingElement.ResolveReferences (IEnumerable<Element> referencedItems)
    //{
    //  foreach (IReferencingElement item in GetReferencingItems ())
    //    item.ResolveReferences (referencedItems);
    //}

    //bool IReferencingElement.HasReferences 
    //{ 
    //  get 
    //  {
    //    foreach (IReferencingElement item in GetReferencingItems ())
    //      if (item.HasReferences)
    //        return true;
    //    return false;
    //  } 
    //}

    //IEnumerable<Iml.Foundation.Reference> IReferencingElement.GetOutgoingReferences ()
    //{
    //  return new Iml.Foundation.Reference[0];
    //}
    //#endregion

    #region atrybuty typograficzne

    /// <summary>
    /// Obiekt reprezentujący atrybuty typograficzne tekstu
    /// </summary>
    [IgnoreDataMember]
    [XmlIgnore]
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    public TextFormat TextFormat { get; set; }

    ///// <summary>
    ///// Szybki dostęp do atrybutu <c>FontFamily</c>
    ///// </summary>
    //[DefaultValue (null)]
    //public string FontFamily
    //{
    //  get
    //  {
    //    if (TextFormat == null)
    //      return null;
    //    else
    //      return TextFormat.FontFamily;
    //  }
    //  set
    //  {
    //    if (TextFormat == null)
    //      TextFormat = new TextFormat ();
    //    TextFormat.FontFamily = value;
    //  }
    //}

    /// <summary>
    /// Szybki dostęp do atrybutu <c>FontSize</c>
    /// </summary>
    [DefaultValue (null)]
    public double? FontSize
    {
      get
      {
        if (TextFormat == null)
          return null;
        else
          return TextFormat.FontSize;
      }
      set
      {
        if (TextFormat == null)
          TextFormat = new TextFormat ();
        TextFormat.FontSize = value;
      }
    }

    /// <summary>
    /// Szybki dostęp do atrybutu <c>Bold</c>
    /// </summary>
    [DefaultValue (null)]
    public bool? Bold
    {
      get
      {
        bool? temp = null;
        if (TextFormat != null)
          temp = TextFormat.Boldface;
        if (temp == null && Style != null)
          temp = Style.TextFormat.Boldface;
        return temp;
      }
      set
      {
        if (TextFormat == null)
          TextFormat = new TextFormat ();
        TextFormat.Boldface = value;
      }
    }

    /// <summary>
    /// Szybki dostęp do atrybutu <c>Italic</c>
    /// </summary>
    [DefaultValue (null)]
    public bool? Italic
    {
      get
      {
        if (TextFormat == null)
          return null;
        else
          return TextFormat.Italic;
      }
      set
      {
        if (TextFormat == null)
          TextFormat = new TextFormat ();
        TextFormat.Italic = value;
      }
    }

    /// <summary>
    /// Szybki dostęp do atrybutu <c>Underline</c>
    /// </summary>
    [DefaultValue (null)]
    public bool? Underline
    {
      get
      {
        if (TextFormat == null)
          return null;
        else
          return TextFormat.Underlined;
      }
      set
      {
        if (TextFormat == null)
          TextFormat = new TextFormat ();
        TextFormat.Underlined = value;
      }
    }

    /// <summary>
    /// Szybki dostęp do atrybutu <c>StrikeThrough</c>
    /// </summary>
    [DefaultValue (null)]
    public bool? StrikeThrough
    {
      get
      {
        if (TextFormat == null)
          return null;
        else
          return TextFormat.Strikethrough;
      }
      set
      {
        if (TextFormat == null)
          TextFormat = new TextFormat ();
        TextFormat.Strikethrough = value;
      }
    }

    ///// <summary>
    ///// Szybki dostęp do atrybutu <c>VerticalPosition</c>
    ///// </summary>
    //[DefaultValue (null)]
    //public VerticalPosition? VerticalPosition
    //{
    //  get
    //  {
    //    if (TextFormat == null)
    //      return null;
    //    else
    //      return (VerticalPosition)TextFormat.VerticalShift;
    //  }
    //  set
    //  {
    //    if (TextFormat == null)
    //      TextFormat = new TextFormat ();
    //    TextFormat.VPosition = value;
    //  }
    //}

    /// <summary>
    /// Atrybuty tekstowe wynikające z ustawień własnych i stylu
    /// </summary>
    public TextFormat DerivedTextFormat
    {
      get
      {
        TextFormat temp = TextFormat;
        if (Style != null)
          temp |= Style.DerivedTextFormat;
        return temp;
      }
    }

    #endregion atrybuty typograficzne

    #region atrybuty akapitu
    /// <summary>
    /// Styl przypisany do elementu
    /// </summary>
    [DefaultValue (null)]
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    public ParagraphStyle Style
    {
      get { return (StyleRef != null) ? StyleRef.Target as ParagraphStyle : null; }
      set
      {
        //if (StyleRef!=null)
        //  StyleRef.Dispose();
        if (value != null)
        {
          StyleRef = new StyleRef { Owner = this, Target = value };
        }
        else
          StyleRef = null;
      }
    }

    private StyleRef _StyleRef;
    /// <summary>
    /// Referencja do stylu akapitu
    /// </summary>
    [DefaultValue (null)]
    [TypeConverter (typeof (Iml.Foundation.ReferenceTypeConverter))]
    public StyleRef StyleRef
    {
      get { return _StyleRef; }
      set
      {
        _StyleRef = value;
        if (_StyleRef != null)
          _StyleRef.Owner = this;
      }
    }


    /// <summary>
    /// Obiekt reprezentujący atrybuty akapitu
    /// </summary>
    [IgnoreDataMember]
    [XmlIgnore]
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    public ParagraphFormat ParagraphFormat { get; set; }

    /// <summary>
    /// Szybki dostęp do atrybutu <c>Justification</c>
    /// </summary>
    [DefaultValue (null)]
    public HorizontalAlignment? Justification
    {
      get
      {
        if (ParagraphFormat == null)
          return null;
        else
          return ParagraphFormat.Alignment;
      }
      set
      {
        if (ParagraphFormat == null)
          ParagraphFormat = new ParagraphFormat ();
        ParagraphFormat.Alignment = value;
      }
    }

    /// <summary>
    /// Szybki dostęp do atrybutu <c>Interline</c>
    /// </summary>
    [DefaultValue (null)]
    public LineSpacing Interline
    {
      get
      {
        if (ParagraphFormat == null)
          return null;
        else
          return ParagraphFormat.Interline;
      }
      set
      {
        if (ParagraphFormat == null)
          ParagraphFormat = new ParagraphFormat ();
        ParagraphFormat.Interline = value;
      }
    }

    /// <summary>
    /// Szybki dostęp do atrybutu <c>SpacingAfter</c>
    /// </summary>
    [DefaultValue (null)]
    public VerticalSpacing SpacingAfter
    {
      get
      {
        if (ParagraphFormat == null)
          return null;
        else
          return ParagraphFormat.SpacingAfter;
      }
      set
      {
        if (ParagraphFormat == null)
          ParagraphFormat = new ParagraphFormat ();
        ParagraphFormat.SpacingAfter = value;
      }
    }

    /// <summary>
    /// Szybki dostęp do atrybutu <c>SpacingBefore</c>
    /// </summary>
    [DefaultValue (null)]
    public VerticalSpacing SpacingBefore
    {
      get
      {
        if (ParagraphFormat == null)
          return null;
        else
          return ParagraphFormat.SpacingBefore;
      }
      set
      {
        if (ParagraphFormat == null)
          ParagraphFormat = new ParagraphFormat ();
        ParagraphFormat.SpacingBefore = value;
      }
    }

    /// <summary>
    /// Właściwości akapitu wynikające z ustawień własnych i ustawień stylu
    /// </summary>
    public ParagraphFormat DerivedParagraphFormat
    {
      get
      {
        ParagraphFormat temp = ParagraphFormat;
        //if (Style != null)
        //  temp |= Style.DerivedParagraphFormat;
        return temp;
      }
    }

    #endregion atrybuty akapitu
  }

}
