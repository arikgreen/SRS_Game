using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca kontrolkę treści
  /// </summary>
  [ContentProperty("Content")]
  public partial class ContentControl: Block
  {
    /// <summary>
    /// Skrót jest obliczany z identyfikatora
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      if (fId!=null)
      {
        int val;
        if (int.TryParse(fId, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val))
          return val;
      }
      return base.GetHash();
    }

    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public ContentControl() { }

    /// <summary>
    /// Typ kontrolki treści (dowolna wartość tekstowa)
    /// </summary>
    [DefaultValue(null)]
    public string Type { get; set; }

    ///// <summary>
    ///// Wewnętrzny identyfikator bloku
    ///// </summary>
    //[DefaultValue(null)]
    //public int? SdtId { get; set; }

    /// <summary>
    /// Znacznik bloku
    /// </summary>
    [DefaultValue(null)]
    public new string Tag { get; set; }

    /// <summary>
    /// Nazwa zastępcza bloku
    /// </summary>
    [DefaultValue(null)]
    public string Alias { get; set; }

    /// <summary>
    /// Czy blok jest zablokowany
    /// </summary>
    [DefaultValue(null)]
    public bool? Locked { get; set; }
    /// <summary>
    /// Czy zawartość jest zablokowana
    /// </summary>
    [DefaultValue(null)]
    public bool? ContentLocked { get; set; }

    /// <summary>
    /// Czy kontrolka treści jest tymczasowa
    /// </summary>
    [DefaultValue(null)]
    public bool? Temporary { get; set; }

    /// <summary>
    /// Czy tekst zastępczy ma być pokazywany
    /// </summary>
    [DefaultValue(null)]
    public bool? ShowingPlaceholder { get; set; }

    /// <summary>
    /// Tekst zastępczy
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DocPart Placeholder { get; set; }

    /// <summary>
    /// Referencja do tekstu zastępczego
    /// </summary>
    [DefaultValue(null)]
    public string PlaceholderId
    {
      get
      {
        if (Placeholder != null)
          return Placeholder.Id.ToString();
        else
          return placeholderID;
      }
      set
      {
        placeholderID = value;
      }
    }
    private string placeholderID;

    /// <summary>
    /// Nazwa elementu tekstu zastępczego
    /// </summary>
    [DefaultValue(null)]
    public string PlaceholderName { get; set; }
    /// <summary>
    /// Lista elementów do wyboru
    /// </summary>
    public ListItems ListItems
    {
      get
      {
        if (fListItems == null)
          fListItems = new ListItems(this);
        return fListItems;
      }
      set { fListItems = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące listę elementów do wyboru
    /// </summary>
    protected ListItems fListItems;

    /// <summary>
    /// Czy lista elementów do wyboru ma być serializowana
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeListItems ()
    {
      return fListItems != null && !fListItems.IsEmpty();    
    }

    /// <summary>
    /// Domyślna wartość wyboru
    /// </summary>
    [DefaultValue(null)]
    public string DefaultValue { get; set; }

    /// <summary>
    /// Lista parametrów
    /// </summary>
    public Parameters Parameters
    {
      get
      {
        if (fParameters == null)
          fParameters = new Parameters (this);
        return fParameters;
      }
      set { fParameters = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące listę parametrów
    /// </summary>
    protected Parameters fParameters;

    /// <summary>
    /// Czy lista parametrów
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeParameters ()
    {
      return fParameters != null && !fParameters.IsEmpty();
    }

    /// <summary>
    /// Zawartość kontrolki
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ContentList Content 
    { 
      get
      {
        if (fContent == null)
          fContent = new ContentList(this);
        return fContent;
      }
      //set { fContent = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące zawartość kontrolki
    /// </summary>
    protected ContentList fContent;

    /// <summary>
    /// Czy zawartość ma być serializowana
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeContent()
    {
      return fContent != null && !fContent.IsEmpty();
    }

    /// <summary>
    /// Zawartość kontrolki
    /// </summary>
    [DefaultValue(null)]
    public DocPart DefaultContent { get; set; }

    /// <summary>
    /// Format tekstowy stosowany w kontrolce
    /// </summary>
    [DefaultValue(null)]
    public TextFormat TextFormat { get; set; }

    /// <summary>
    /// Format tekstowy stosowany na końcu kontrolki
    /// </summary>
    [DefaultValue(null)]
    public TextFormat EndCharTextFormat { get; set; }

    /// <summary>
    /// Informacja o wiązaniu danych
    /// </summary>
    [DefaultValue(null)]
    public DataBinding DataBinding { get; set; }


    /// <summary>
    /// Czy kontrolka jest wieloliniowa
    /// </summary>
    [DefaultValue(null)]
    public bool? Multiline { get; set; }

    /// <summary>
    /// Czy kontrolka jest pusta?
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return false;
    }
  }

}
