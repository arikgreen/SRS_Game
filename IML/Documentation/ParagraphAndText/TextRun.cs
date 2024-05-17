using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using IML = Iml.Documentation;
using System.Windows.Markup;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Diagnostics;

namespace Iml.Documentation
{

  /// <summary>
  /// Fragment akapitu zawierający tekst (złożony)
  /// </summary>
  [ContentProperty("Content")]
  public partial class TextRun: Run
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public TextRun () { }

    /// <summary>
    /// tekst wczytany z dokumentu
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    //[DefaultValue(null)]
    public TextItems Content 
    { 
      get
      {
        if (fContent == null)
          fContent = new TextItems(this);
        return fContent;
      }
      internal set
      {
        fContent = value; if (value != null) value.SetOwner(this);
      }
    }
    /// <summary>
    /// Pole przechowujące tekst
    /// </summary>
    protected TextItems fContent;

    /// <summary>
    /// Czy zawartość ma być serializowana
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeContent()
    {
      return fContent!=null && !fContent.IsEmpty();
    }

    /// <summary>
    /// Teks wewnętrzny elementu
    /// </summary>
    [XmlIgnore]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Text
    {
      get
      {
        return GetText();
      }
      set
      {
        SetText(value);
      }
    }

    /// <summary>
    /// Pobranie tekstu
    /// </summary>
    public string GetText ()
    {
      StringBuilder sb = new StringBuilder();
      foreach (TextItem item in Content)
        sb.Append(item.GetString());
      string result = sb.ToString();
      return result != "" ? result : null;
    }

    /// <summary>
    /// Wstawienie tekstu
    /// </summary>
    /// <param name="str"></param>
    public void SetText(string str)
    {
      Content.Add(new Text(str));
    }
    ///// <summary>
    ///// Właściwość reprezentująca liczbę odstępów w tekście, gdy tekst składa się z samych odstępów. 
    ///// Potrzebna dla serializacji
    ///// </summary>
    //[DefaultValue(0)]
    //public int Whitespaces
    //{
    //  get
    //  {
    //    if (fText != null && String.IsNullOrWhiteSpace(fText))
    //      return fText.Length;
    //    return 0;
    //  }
    //  set 
    //  {
    //    if (value != 0)
    //      fText = new string(' ', value);
    //  }
    //}


  }
}
