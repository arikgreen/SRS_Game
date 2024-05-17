using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Iml.Documentation
{
  public partial class Paragraph//: IReferencingElement
  {
    /// <summary>
    /// Konstruktor ułatwiający tworzenie akapitu z prostego tekstu.
    /// </summary>
    /// <param name="aText">tekst wejściowy</param>
    public Paragraph (string aText) : this() { Content.Add(new TextRun(aText)); }

    /// <summary>
    /// Konstruktor ułatwiający tworzenie akapitu z <see cref="Inline"/>
    /// </summary>
    /// <param name="aInline"><see cref="Inline"/> wejściowy</param>
    public Paragraph (Inline aInline) : this() { Content.Add(aInline); }


    /// <summary>
    /// Składowe elementy akapitu
    /// </summary>
    [DataMember]
    [Association ("Content", "ID", "OwnerID")]
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Content)]
    public ContentList Content { get; private set; }

    /// <summary>
    /// Liczba składowych
    /// </summary>
    public int Count 
    {
      get { return Content.Count; }
    }

    /// <summary>
    /// Dodanie składowej do akapitu
    /// </summary>
    /// <param name="item"></param>
    public void Add(object item)
    {
      if (item is DocumentContent)
        Content.Add((DocumentContent)item);
    }
    /// <summary>
    /// Dodanie elementu składowego na podanej pozycji
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="item"></param>
    public void Insert(int pos, object item)
    {
      if (item is DocumentContent)
        Content.Insert(pos, (DocumentContent)item);
    }

    /// <summary>
    /// Usunięcie elementu składowego
    /// </summary>
    /// <param name="item"></param>
    public void Remove(object item)
    {
      if (item is Inline)
        Content.Remove((DocumentContent)item);
    }

    /// <summary>
    /// Usunięcie elementu składowego z podanej pozycji
    /// </summary>
    /// <param name="pos"></param>
    public void RemoveAt (int pos)
    {
      Content.RemoveAt(pos);
    }

    /// <summary>
    /// Podanie pierwszej składowej
    /// </summary>
    /// <returns></returns>
    public DocumentContent First ()
    {
      if (Content.Count != 0)
        return Content.First();
      else
        return null;
    }

    /// <summary>
    /// Podanie ostatniej składowej
    /// </summary>
    /// <returns></returns>
    public DocumentContent Last ()
    {
      if (Content.Count != 0)
        return Content.Last();
      else
        return null;
    }

    /// <summary>
    /// Dostęp do elementów składowych
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public DocumentContent this[int n]
    {
      get
      {
        return Content[n];
      }
      set
      {
        if (value is DocumentContent)
          Content[n] = (DocumentContent)value;
      }
    }

    /// <summary>
    /// Enumerator po elementach składowych
    /// </summary>
    /// <returns></returns>
    public IEnumerator<DocumentContent> GetEnumerator()
    {
      foreach (DocumentContent item in Content)
        yield return item;
    }

    /// <summary>
    /// Czy akapit zawiera tylko prosty tekst?
    /// </summary>
    public bool IsPlain ()
    {
      //if (Style != null)
      //  return false;
      //if (TextFormat != null && !TextFormat.IsEmpty ())
      //  return false;
      //foreach (Inline aInline in Inlines)
      //{
      //  if (!aInline.IsPlain ())
      //    return false;
      //}
      return true;
    }

    /// <summary>
    /// Pobranie prostego tekstu z akapitu
    /// </summary>
    public String GetText ()
    {
      return TextXml;
      /*
      StringBuilder sb = new StringBuilder ();
      foreach (Inline aInline in Inlines)
      {
        string s = aInline.GetText ();
        if (!String.IsNullOrEmpty (s))
          sb.Append (s);
      }
      return sb.ToString ();
       */ 
    }

    /// <summary>
    /// Czy format ma być ignorowany
    /// </summary>
    [IgnoreDataMember]
    [XmlIgnore]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IgnoreFormat { get; set; }

    ///// <summary>
    ///// Styl wynikowy akapitu
    ///// </summary>
    //[IgnoreDataMember]
    //[XmlIgnore]
    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //public ParagraphStyle OutputStyle { get; set; }

    /// <summary>
    /// Pobranie tekstu sformatowanego w postaci łańcucha XML.
    /// </summary>
    /// <returns></returns>
    public String GetTextXml ()
    {
      List<object> elements = new List<object>();
      //foreach (Inline aInline in Inlines)
      //{
      //  elements.Add(aInline.GetTextXml());
      //}
      return new XElement("TextXml", elements.ToArray()).ToString();
    }

    /// <summary>
    /// Ustawienie tekstu sformatowanego z danego łańcucha XML
    /// </summary>
    /// <param name="value">dany łańcuch XML</param>
    public void SetTextXml (string value)
    {
      //Inlines.Clear();
      //XElement aElement = XElement.Parse(value);
      //if (aElement.HasElements)
      //{
      //  foreach (XNode item in aElement.Nodes())
      //  {
      //    Inline aInline = Inline.NewInline(item);
      //    if (aInline!=null)
      //      Inlines.Add(aInline);
      //  }
      //}
      //else
      //{
      //  value = aElement.Value;
      //  if (value != null)
      //    Inlines.Add(new Run(value));
      //}
    }

    #region atrybuty typograficzne

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

    ///// <summary>
    ///// Szybki dostęp do atrybutu <c>FontSize</c>
    ///// </summary>
    //[DefaultValue(null)]
    //public double? FontSize
    //{
    //  get
    //  {
    //    if (TextFormat == null)
    //      return null;
    //    else
    //      return TextFormat.FontSize;
    //  }
    //  set
    //  {
    //    if (TextFormat == null)
    //      TextFormat = new TextFormat();
    //    TextFormat.FontSize = value;
    //  }
    //}

    ///// <summary>
    ///// Szybki dostęp do atrybutu <c>Bold</c>
    ///// </summary>
    //[DefaultValue(null)]
    //public bool? Bold
    //{
    //  get
    //  {
    //    bool? temp = null;
    //    if (TextFormat != null)
    //      temp = TextFormat.Bold;
    //    if (temp == null && Style != null)
    //      temp = Style.Bold;
    //    return temp;
    //  }
    //  set
    //  {
    //    if (TextFormat == null)
    //      TextFormat = new TextFormat();
    //    TextFormat.Bold = value;
    //  }
    //}

    ///// <summary>
    ///// Szybki dostęp do atrybutu <c>Italic</c>
    ///// </summary>
    //[DefaultValue(null)]
    //public bool? Italic
    //{
    //  get
    //  {
    //    if (TextFormat == null)
    //      return null;
    //    else
    //      return TextFormat.Italic;
    //  }
    //  set
    //  {
    //    if (TextFormat == null)
    //      TextFormat = new TextFormat();
    //    TextFormat.Italic = value;
    //  }
    //}

    ///// <summary>
    ///// Szybki dostęp do atrybutu <c>Underline</c>
    ///// </summary>
    //[DefaultValue(null)]
    //public bool? Underline
    //{
    //  get
    //  {
    //    if (TextFormat == null)
    //      return null;
    //    else
    //      return TextFormat.Underline;
    //  }
    //  set
    //  {
    //    if (TextFormat == null)
    //      TextFormat = new TextFormat();
    //    TextFormat.Underline = value;
    //  }
    //}

    ///// <summary>
    ///// Szybki dostęp do atrybutu <c>StrikeThrough</c>
    ///// </summary>
    //[DefaultValue(null)]
    //public bool? StrikeThrough
    //{
    //  get
    //  {
    //    if (TextFormat == null)
    //      return null;
    //    else
    //      return TextFormat.StrikeThrough;
    //  }
    //  set
    //  {
    //    if (TextFormat == null)
    //      TextFormat = new TextFormat();
    //    TextFormat.StrikeThrough = value;
    //  }
    //}

    ///// <summary>
    ///// Szybki dostęp do atrybutu <c>VerticalPosition</c>
    ///// </summary>
    //[DefaultValue(null)]
    //public VerticalPosition? VerticalPosition
    //{
    //  get
    //  {
    //    if (TextFormat == null)
    //      return null;
    //    else
    //      return TextFormat.VPosition;
    //  }
    //  set
    //  {
    //    if (TextFormat == null)
    //      TextFormat = new TextFormat();
    //    TextFormat.VPosition = value;
    //  }
    //}

    ///// <summary>
    ///// Atrybuty tekstowe wynikające z ustawień własnych i stylu
    ///// </summary>
    //public TextFormat DerivedTextFormat
    //{
    //  get
    //  {
    //    TextFormat temp = EndCharTextFormat;
    //    if (Style != null)
    //      temp |= Style.DerivedTextFormat;
    //    return temp;
    //  }
    //}

    #endregion atrybuty typograficzne

    #region atrybuty akapitu
    ///// <summary>
    ///// Styl przypisany do elementu
    ///// </summary>
    //[DefaultValue(null)]
    //[DataMember]
    //[Association("ParagraphStyle", "StyleID", "ID")]
    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //public new ParagraphStyle Style
    //{
    //  get { return base.Style as ParagraphStyle; }
    //  set { base.Style = value; }
    //}

    ///// <summary>
    ///// Identyfikator stylu
    ///// </summary>
    //public Guid StyleID
    //{
    //  get
    //  {
    //    if (StyleRef != null)
    //      return StyleRef.TargetID;
    //    else
    //      return Guid.Empty;
    //  }
    //}

    private Iml.Foundation.Reference _StyleRef;
    /// <summary>
    /// Referencja do stylu akapitu
    /// </summary>
    [DefaultValue(null)]
    [TypeConverter(typeof(Iml.Foundation.ReferenceTypeConverter))]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Iml.Foundation.Reference StyleRef
    {
      get { return _StyleRef; }
      set
      {
        _StyleRef = value;
        if (_StyleRef != null)
          _StyleRef.Owner = this;
      }
    }


    ///// <summary>
    ///// Szybki dostęp do atrybutu <c>Justification</c>
    ///// </summary>
    //[DefaultValue(null)]
    //public HorizontalAlignment? Justification
    //{
    //  get
    //  {
    //    if (ParagraphFormat == null)
    //      return null;
    //    else
    //      return ParagraphFormat.Alignment;
    //  }
    //  set
    //  {
    //    if (ParagraphFormat == null)
    //      ParagraphFormat = new ParagraphFormat();
    //    ParagraphFormat.Alignment = value;
    //  }
    //}

    ///// <summary>
    ///// Szybki dostęp do atrybutu <c>Interline</c>
    ///// </summary>
    //[DefaultValue(null)]
    //public LineSpacing Interline
    //{
    //  get
    //  {
    //    if (ParagraphFormat == null)
    //      return null;
    //    else
    //      return ParagraphFormat.Interline;
    //  }
    //  set
    //  {
    //    if (ParagraphFormat == null)
    //      ParagraphFormat = new ParagraphFormat();
    //    ParagraphFormat.Interline = value;
    //  }
    //}

    ///// <summary>
    ///// Szybki dostęp do atrybutu <c>SpacingAfter</c>
    ///// </summary>
    //[DefaultValue(null)]
    //public VerticalSpacing SpacingAfter
    //{
    //  get
    //  {
    //    if (ParagraphFormat == null)
    //      return null;
    //    else
    //      return ParagraphFormat.SpacingAfter;
    //  }
    //  set
    //  {
    //    if (ParagraphFormat == null)
    //      ParagraphFormat = new ParagraphFormat();
    //    ParagraphFormat.SpacingAfter = value;
    //  }
    //}

    ///// <summary>
    ///// Szybki dostęp do atrybutu <c>SpacingBefore</c>
    ///// </summary>
    //[DefaultValue(null)]
    //public VerticalSpacing SpacingBefore
    //{
    //  get
    //  {
    //    if (ParagraphFormat == null)
    //      return null;
    //    else
    //      return ParagraphFormat.SpacingBefore;
    //  }
    //  set
    //  {
    //    if (ParagraphFormat == null)
    //      ParagraphFormat = new ParagraphFormat();
    //    ParagraphFormat.SpacingBefore = value;
    //  }
    //}

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
    #region implementacja interfejsu IReferencingElement

    /// <summary>
    /// Sprawdzenie, czy akapit ma referencję do stylu
    /// </summary>
    public bool HasReferences { get { return StyleRef != null; } }

    /// <summary>
    /// Sprawdzenie, czy referencja do stylu jest nierozwiązana
    /// </summary>
    public bool HasUnresolvedReferences { get { return StyleRef != null && !StyleRef.IsResolved; } }

    /// <summary>
    /// Ta jest potrzebna dla implementacji IReferencingElement
    /// </summary>
    /// <param name="aRef"></param>
    public void AddOutgoingReference (Iml.Foundation.Reference aRef)
    {
      StyleRef = aRef;
    }

    /// <summary>
    /// Ta jest potrzebna dla implementacji IReferencingElement
    /// </summary>
    /// <param name="aRef"></param>
    public void RemoveOutgoingReference (Iml.Foundation.Reference aRef)
    {
      StyleRef = null;
    }

    /// <summary>
    /// Zwraca jednoelementową listę referencji do stylu
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Iml.Foundation.Reference> GetOutgoingReferences ()
    {
      List<Iml.Foundation.Reference> result = new List<Iml.Foundation.Reference>();
      if (StyleRef != null)
        result.Add(StyleRef);
      return result;
    }

    /// <summary>
    /// Czyści referencję do stylu
    /// </summary>
    public void ClearReferences ()
    {
      StyleRef = null;
    }

    /// <summary>
    /// Rozwiązanie referencji
    /// </summary>
    /// <param name="refList"></param>
    public void ResolveReferences (IEnumerable<Iml.Foundation.Element> refList)
    {
      if (StyleRef != null)
        StyleRef.TryResolveReference(refList);
    }

    #endregion implementacja interfejsu IReferencingElement


    /// <summary>
    /// Czy akapit ma jednolity format?
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
      uniformStyle = null;//Style;
      uniformFormat = null;//DerivedParagraphFormat;
      uniformAttributes = null;// DerivedTextFormat;
      //if (Inlines == null)
      //  return true;
      //if (Inlines.Count == 0)
      //  return true;
      //foreach (Inline aInline in Inlines)
      //{
      //  if (aInline is Run)
      //  {
      //    Run aRun = (Run)aInline;
      //    if (aRun.Style != null)
      //    {
      //      if (!aRun.Style.Equals (uniformStyle))
      //        return false;
      //    }
      //    if (aRun.TextFormat != null)
      //    {
      //      if (!aRun.TextFormat.Equals (uniformAttributes))
      //        return false;
      //    }
      //  }
      //}
      return true;
    }

    ///// <summary>
    ///// Destruktor wymuszający zwolnienie referencji
    ///// </summary>
    //~Paragraph()
    //{
    //  Dispose();
    //}


    //private InlineCollection inlines;
    /*
    /// <summary>
    /// Składowe elementy <see cref="Inline"/> akapitu
    /// </summary>
    [DataMember]
    [Include]
    [Association("Inline", "ID", "OwnerID")]
    [Composition]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public InlineCollection Inlines { get { return inlines; } }
     */
    /// <summary>
    /// Tekst sformatowany przekazywany jako łańcuch XML.
    /// </summary>
    [DataMember]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public String TextXml { get; set; }
    /*
    {
      get { return GetTextXml(); }
      set { SetTextXml(value); }
    }
    */

    /// <summary>
    /// Kod skrótu na podstawie zawartości
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      if (fHashCode == null)
      {
        int hash = "PaRagRaph".GetHashCode();
        if (Content != null)
          hash += Content.GetHash();
        if (RevisionId != null)
        {
          int val;
          if (int.TryParse(RevisionId, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val))
            hash += val;
        } 
        if (Collection != null)
          hash = Collection.MakeHashUnique(hash);
        fHashCode = hash;
      }
      return (int)fHashCode;
    }
    /// <summary>
    /// Pole przechowujące kod skrótu
    /// </summary>
    protected int? fHashCode = null;
  }
}
