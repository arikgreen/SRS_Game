using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Iml.Documentation
{
  /// <summary>
  /// Styl dokumentu
  /// </summary>
  [KnownType(typeof(TextStyle))]
  [KnownType(typeof(ParagraphStyle))]
  [KnownType(typeof(TableStyle))]
  [KnownType(typeof(ListStyle))]
  public abstract partial class Style : CompoundItem
  {

    /// <summary>
    /// Typ stylu - czego dotyczy styl
    /// </summary>
    [OpenXMLAttributeName("type", "ST_StyleType", 1)]
    public abstract StyleType Type { get; }

    /// <summary>
    /// identyfikator stylu
    /// </summary>
    [DefaultValue(null)]
    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [OpenXMLAttributeName("styleId", "ST_String", 2)]
    public override string Id { get; set;}

    /// <summary>
    /// Nazwa widoczna stylu
    /// </summary>
    [DefaultValue(null)]
    public string Name { get; set; }
    /// <summary>
    /// Czy styl jest domyślny dla elementów odpowiedniego typu?
    /// </summary>
    [OpenXMLAttributeName ("default", "ST_OnOff", 3)]
    [DefaultValue(null)]
    public bool? IsDefault { get; set; }

    /// <summary>
    /// Czy styl jest zdefiniowany przez użytkownika?
    /// </summary>
    [DefaultValue(null)]
    public bool? IsCustom { get; set; }

    /// <summary>
    /// Czy styl jest zdefiniowany przez użytkownika?
    /// </summary>
    [DefaultValue(null)]
    public bool? IsPrimary { get; set; }

    /// <summary>
    /// Czy styl jest automatycznie redefiniowany przy zmianie właściwości obiektu, którego dotyczy?
    /// </summary>
    [DefaultValue(null)]
    public bool? IsAutoRedef { get; set; }

    /// <summary>
    /// Czy styl jest zablokowany
    /// </summary>
    [DefaultValue(null)]
    public bool? IsLocked { get; set; }

    /// <summary>
    /// Czy styl może być ukrywany
    /// </summary>
    [DefaultValue(null)]
    public Hideable? IsHideable { get; set; }

    /// <summary>
    /// Priorytet wyświetlania na liście w interfejsie użytkownika
    /// </summary>
    [DefaultValue(null)]
    public int? DisplayPriority { get; set; }

    /// <summary>
    /// Styl bazowy dla danego stylu
    /// </summary>
    [DefaultValue (null)]
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    [Association("Style_BaseStyle", "BaseStyleId", "Id")]
    public Style BaseStyle 
    {
      get { return _BaseStyle; }
      set
      {
        if (_BaseStyle != value)
        {
          DecRefCount(_BaseStyle);
          _BaseStyle = value;
          IncRefCount(_BaseStyle);
        }
      }
    }
    private Style _BaseStyle;

    /// <summary>
    /// Referencja do stylu bazowego
    /// </summary>
    [DefaultValue(null)]
    public string BaseStyleId
    {
      get
      {
        return  _BaseStyle != null ? _BaseStyle.Id : _BaseStyleId;
      }
      set
      {
        _BaseStyleId = value;
      }
    }
    private string _BaseStyleId;
    
    /// <summary>
    /// Referencja do stylu powiązanego
    /// </summary>
    [DefaultValue(null)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Association("Style_LinkedStyle", "LinkedStyleId", "Id")]
    public Style LinkedStyle
    {
      get { return _LinkedStyle; }
      set
      {
        if (_LinkedStyle != value)
        {
          DecRefCount(_LinkedStyle);
          _LinkedStyle = value;
          IncRefCount(_LinkedStyle);
        }
      }
    }
    private Style _LinkedStyle;

    /// <summary>
    /// Referencja do stylu powiązanego
    /// </summary>
    [DefaultValue(null)]
    public string LinkedStyleId
    {
      get
      {
        return  _LinkedStyle != null ? _LinkedStyle.Id : _LinkedStyleId;
      }
      set
      {
        _LinkedStyleId = value;
      }
    }
    private string _LinkedStyleId;

    /// <summary>
    /// Identyfikator rewizji utworzenia stylu (z Worda)
    /// </summary>
    [DefaultValue(null)]
    public string RevisionId { get; set; }

    /// <summary>
    /// Zwolnienie referencji
    /// </summary>
    public virtual void Dispose ()
    {
      BaseStyle = null;
      LinkedStyle = null;
    }

  }
}
