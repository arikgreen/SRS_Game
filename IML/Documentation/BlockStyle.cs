using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Windows.Media;

namespace Iml.Documentation
{
  /// <summary>
  /// Styl tablicy w tekście.
  /// </summary>
  public abstract class BlockStyle: Style
  {
    /// <summary>
    /// Obiekt reprezentujący atrybuty bloku
    /// </summary>
    [IgnoreDataMember]
    [XmlIgnore]
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    public BlockFormat BlockFormat { get; set; }

    /// <summary>
    /// Szybki dostęp do atrybutu <c>Background</c>
    /// </summary>
    [DefaultValue (null)]
    public Brush Background
    {
      get
      {
        if (BlockFormat == null)
          return null;
        else
          return BlockFormat.Background;
      }
      set
      {
        if (BlockFormat == null)
          BlockFormat = new BlockFormat ();
        BlockFormat.Background = value;
      }
    }


    ///// <summary>
    ///// Właściwości akapitu wynikające z ustawień własnych i stylu bazowego
    ///// </summary>
    //public BlockFormat DerivedBlockFormat
    //{
    //  get
    //  {
    //    BlockFormat temp = BlockFormat;
    //    if (BaseStyle is BlockStyle)
    //      temp |= (BaseStyle as BlockStyle).DerivedBlockFormat;
    //    return temp;
    //  }
    //}

  }
}
