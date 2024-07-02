using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace Iml.Documentation
{
  /// <summary>
  /// Hiperłącze w tekście
  /// </summary>
  [ContentProperty("Content")]
  public partial class Hyperlink: DocumentContent
  {
    /// <summary>
    /// Ustalony kod skrótu 
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      int hash = "HyPerLinK".GetHashCode();
      if (TargetRef != null)
        hash += TargetRef.GetHashCode();
      if (Collection != null)
        hash = Collection.MakeHashUnique(hash);
      return hash; 
    }

    /// <summary>
    /// Id relacji elementu docelowego
    /// </summary>
    [DefaultValue(null)]
    public string TargetRef { get; set; }

    /// <summary>
    /// Czy jest to hyperlink do dokumentu zewnętrznego
    /// </summary>
    [DefaultValue(null)]
    public bool? IsExternal { get; set; }
    
    /// <summary>
    /// Uri elementu docelowego
    /// </summary>
    [DefaultValue(null)]
    public string TargetUri { get; set; }

    /// <summary>
    /// Docelowa zakładka (w dokumencie docelowym)
    /// </summary>
    [DefaultValue(null)]
    public string TargetBookmark { get; set; }

    /// <summary>
    /// Docelowe miejsce w dokumencie (gdy nie ma zadeklarowanej zakładki docelowej)
    /// </summary>
    [DefaultValue(null)]
    public string TargetLocation { get; set; }

    /// <summary>
    /// Czy hiperłącze ma być dodawane do historii przeglądanych hiperłączy
    /// </summary>
    [DefaultValue(null)]
    public bool? AddToHistory { get; set; }

    /// <summary>
    /// Miejsce prezentacji elementu docelowego
    /// </summary>
    [DefaultValue(null)]
    public string DisplayWindow { get; set; }

    /// <summary>
    /// Miejsce prezentacji elementu docelowego
    /// </summary>
    [DefaultValue(null)]
    public string Tooltip { get; set; }

    /// <summary>
    /// Zawartość hiperłącza
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
    /// Pole przechowujące zawartość
    /// </summary>
    protected ContentList fContent;

    /// <summary>
    /// Czy zawartość ma być serializowana
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeContent ()
    {
      return fContent != null && !fContent.IsEmpty();
    }

    /// <summary>
    /// Na razie nie jest pusty
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return false;
    }
  }
}
