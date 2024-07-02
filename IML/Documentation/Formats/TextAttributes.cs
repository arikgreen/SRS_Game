using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;
using System.Windows.Media;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Iml.Documentation
{
  /// <summary>
  /// Struktura reprezentująca atrybuty typograficzne tekstu.
  /// </summary>
  public partial struct TextAttributes
  {
    /// <summary>
    /// Właściwość dostępowa do atrybutu Italic
    /// </summary>
    [DefaultValue(null)]
    public bool? Italic
    {
      get { return getAttribute(ItalicMask); }
      set { setAttribute(ItalicMask, value); }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu Boldface
    /// </summary>
    [DefaultValue(null)]
    public bool? Boldface
    {
      get { return getAttribute(BoldfaceMask); }
      set { setAttribute(BoldfaceMask, value); }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu Underlined
    /// </summary>
    [DefaultValue(null)]
    public bool? Underlined
    {
      get { return getAttribute(UnderlinedMask); }
      set { setAttribute(UnderlinedMask, value); }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu StrikeThrough
    /// </summary>
    [DefaultValue(null)]
    public bool? Strikethrough
    {
      get { return getAttribute(StrikethroughMask); }
      set { setAttribute(StrikethroughMask, value); }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu Subscript
    /// </summary>
    [DefaultValue(null)]
    public bool? Superscript
    {
      get { return getAttribute(SuperscriptMask); }
      set { setAttribute(SuperscriptMask, value); }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu Superscript
    /// </summary>
    [DefaultValue(null)]
    public bool? Subscript
    {
      get { return getAttribute(SubscriptMask); }
      set { setAttribute(SubscriptMask, value); }
    }

  }
}
