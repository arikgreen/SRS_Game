using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace Iml.Documentation.VML
{
  /// <summary>
  /// Pole tekstowe
  /// </summary>
  [ContentProperty("Content")]
  public partial class TextBox: VmlItem
  {
    /// <summary>
    /// ??? TextBoxInset
    /// </summary>
    //[SchemaAttr(0, "inset")]
    [DefaultValue(null)]
    public string Inset { get; set; }
    //o:insetmode (Text Inset Mode)
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    public string InsetMode { get; set; }
    /// <summary>
    /// ??? Text Box Single-Click Selection Toggle.
    /// </summary>
    //[SchemaAttr(27, "singleclick")]
    [DefaultValue(null)]
    public bool? SingleClick { get; set; }
    /// <summary>
    /// Styl 
    /// </summary>
    //[SchemaAttr(0, "style")]
    [DefaultValue(null)]
    public string CssStyle { get; set; }

    /// <summary>
    /// Zawartość pola tekstowego
    /// </summary>
   [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    //[DefaultValue(null)]
    public ContentList Content
    {
      get 
      {
        if (fContent == null)
          fContent = new ContentList(this);
        return fContent;
      }
      //set
      //{
      //  fContent = value; if (value != null) value.SetOwner(this);
      //}
    }
    /// <summary>
    /// Pole przechowujące zawartość pola tekstowego
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
    /// Obliczenie skrótu na podstawie kształtu i parametrów
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      int hashCode = 0;
      if (Content != null)
        hashCode += Content.GetHash();
      return hashCode;
    }
  }
}
