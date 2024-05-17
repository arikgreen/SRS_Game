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
  /// Styl akapitu. Rozszerza styl tekstowy o format akapitu i format bloku
  /// </summary>
  public partial class ParagraphStyle: TextStyle
  {
    /// <summary>
    /// Typ stylu - czego dotyczy styl
    /// </summary>
    public override StyleType Type
    {
      get { return StyleType.Paragraph; }
    }

    /// <summary>
    /// Obiekt reprezentujący format akapitu
    /// </summary>
    [IgnoreDataMember]
    [XmlIgnore]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ParagraphFormat ParagraphFormat
    {
      get { return GetComponent<ParagraphFormat>(); }
      set { SetComponent<ParagraphFormat>(value); }
    }

    #region format bloku

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

    /// <summary>
    /// Szybki dostęp do atrybutu <c>Borders</c>
    /// </summary>
    [DefaultValue (null)]
    public Borders Borders
    {
      get
      {
        if (BlockFormat == null)
          return null;
        else
          return BlockFormat.Borders;
      }
      set
      {
        if (BlockFormat == null)
          BlockFormat = new BlockFormat ();
        BlockFormat.Borders = value;
      }
    }

    ///// <summary>
    ///// Właściwości akapitu wynikające z ustawień własnych i stylu bazowego
    ///// </summary>
    ////[IgnoreDataMember]
    ////[DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    //public virtual BlockFormat DerivedBlockFormat
    //{
    //  get
    //  {
    //    BlockFormat temp = BlockFormat;
    //    if (NextStyle is ParagraphStyle)
    //      temp |= (NextStyle as ParagraphStyle).DerivedBlockFormat;
    //    return temp;
    //  }
    //}
    #endregion format bloku

    /// <summary>
    /// Referencja do stylu powiązanego
    /// </summary>
    [DefaultValue(null)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ParagraphStyle NextStyle
    {
      get { return _NextStyle; }
      set
      {
        if (_NextStyle != value)
        {
          if (_NextStyle != null)
          {
            _NextStyle.RefCount--;
            if (_NextStyle.RefCount < 0)
              _NextStyle.RefCount = 0;
          }
          _NextStyle = value;
          if (_NextStyle != null)
            _NextStyle.RefCount++;
        }
      }
    }
    private ParagraphStyle _NextStyle;
    /// <summary>
    /// Referencja do stylu następnego
    /// </summary>
    [DefaultValue(null)]
    public string NextStyleID
    {
      get
      {
        return _NextStyle != null ? _NextStyle.Id : _NextStyleID;
      }
      set
      {
        _NextStyleID = value;
      }
    }
    private string _NextStyleID;

    /// <summary>
    /// Zwolnienie referencji
    /// </summary>
    public override void Dispose ()
    {
      base.Dispose();
      NextStyleID = null;
    }
  }
}
