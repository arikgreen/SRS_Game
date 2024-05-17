using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Struktura reprezentująca atrybuty typograficzne tekstu.
  /// </summary>
  public partial class TableLayout
  {
    /// <summary>
    /// Właściwość dostępowa do atrybutu FirstRow
    /// </summary>
    [DefaultValue(null)]
    public bool? FirstRow
    {
      get { return GetAttribute(TableLook.FirstRow); }
      set { SetAttribute(TableLook.FirstRow, value); }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu LastRow
    /// </summary>
    [DefaultValue(null)]
    public bool? LastRow
    {
      get { return GetAttribute(TableLook.LastRow); }
      set { SetAttribute(TableLook.LastRow, value); }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu FirstColumn
    /// </summary>
    [DefaultValue(null)]
    public bool? FirstColumn
    {
      get { return GetAttribute(TableLook.FirstCol); }
      set { SetAttribute(TableLook.FirstCol, value); }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu LastColumn
    /// </summary>
    [DefaultValue(null)]
    public bool? LastColumn
    {
      get { return GetAttribute(TableLook.LastCol); }
      set { SetAttribute(TableLook.LastCol, value); }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu HBand
    /// </summary>
    [DefaultValue(null)]
    public bool? HorizontalBand
    {
      get { return GetAttribute(TableLook.NoRowBand,true); }
      set { SetAttribute(TableLook.NoRowBand, value, true); }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu VBand
    /// </summary>
    [DefaultValue(null)]
    public bool? VerticalBand
    {
      get { return GetAttribute(TableLook.NoColBand,true); }
      set { SetAttribute(TableLook.NoColBand, value, true); }
    }
  }

}
