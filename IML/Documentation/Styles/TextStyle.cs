using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Windows.Media;

namespace Iml.Documentation
{
  /// <summary>
  /// Styl tekstowy
  /// </summary>
  public partial class TextStyle : Style
  {
    /// <summary>
    /// Typ stylu - czego dotyczy styl
    /// </summary>
    public override StyleType Type
    {
      get { return StyleType.Character; }
    }

    #region atrybuty typograficzne
    /// <summary>
    /// Obiekt reprezentujący format tekstowy
    /// </summary>
    [IgnoreDataMember]
    [XmlIgnore]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TextFormat TextFormat 
    { 
      get  { return GetComponent<TextFormat>(); }
      set { SetComponent<TextFormat>(value); }
    }

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
    //    if (TextFormat == null)
    //      return null;
    //    else
    //      return TextFormat.Boldface;
    //  }
    //  set
    //  {
    //    if (TextFormat == null)
    //      TextFormat = new TextFormat();
    //    TextFormat.Boldface = value;
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
    ///// Szybki dostęp do atrybutu <c>Underlined</c>
    ///// </summary>
    //[DefaultValue(null)]
    //public bool? Underlined
    //{
    //  get
    //  {
    //    if (TextFormat == null)
    //      return null;
    //    else
    //      return TextFormat.Underlined;
    //  }
    //  set
    //  {
    //    if (TextFormat == null)
    //      TextFormat = new TextFormat();
    //    TextFormat.Underlined = value;
    //  }
    //}

    ///// <summary>
    ///// Szybki dostęp do atrybutu <c>UnderlineStyle</c>
    ///// </summary>
    //[DefaultValue(null)]
    //public string UnderlineStyle
    //{
    //  get
    //  {
    //    if (TextFormat == null)
    //      return null;
    //    else
    //      return TextFormat.UnderlineStyle;
    //  }
    //  set
    //  {
    //    if (TextFormat == null)
    //      TextFormat = new TextFormat();
    //    TextFormat.UnderlineStyle = value;
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
    //      return TextFormat.Strikethrough;
    //  }
    //  set
    //  {
    //    if (TextFormat == null)
    //      TextFormat = new TextFormat();
    //    TextFormat.Strikethrough = value;
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
/*
    /// <summary>
    /// Szybki dostęp do atrybutu <c>FontColor</c>
    /// </summary>
    [IgnoreDataMember]
    [ReadOnly(true)]
    public Color FontColor
    {
      get
      {
        if (TextFormat == null)
          return Color.FromArgb(0,0,0,0);
        else
          return TextFormat.FontColor;
      }
      set
      {
        if (TextFormat == null)
          TextFormat = new TextFormat ();
        TextFormat.FontColor = value;
      }
    }
/*
    /// <summary>
    /// Szybki dostęp do atrybutu <c>BackColor</c>
    /// </summary>
    [DefaultValue (null)]
    public Color BackColor
    {
      get
      {
        if (TextFormat == null)
          return Color.FromArgb(0,0,0,0);
        else
          return TextFormat.BackColor;
      }
      set
      {
        if (TextFormat == null)
          TextFormat = new TextFormat ();
        TextFormat.BackColor = value;
      }
    }
*/
    /// <summary>
    /// Atrybuty tekstowe wynikające z ustawień własnych i stylu bazowego
    /// </summary>
    public TextFormat DerivedTextFormat
    {
      get
      {
        TextFormat temp = TextFormat;
        if (BaseStyle is TextStyle)
          temp |= (BaseStyle as TextStyle).DerivedTextFormat;
        return temp;
      }
    }

    #endregion atrybuty typograficzne

  }
}
