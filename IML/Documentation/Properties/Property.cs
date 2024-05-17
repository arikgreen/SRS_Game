using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Windows.Markup;
using System.Xml.Serialization;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Właściwość dokumentu. 
  /// Kojarzy nazwę i wartość właściwości dotyczącej dokumentu
  /// </summary>
  [ContentProperty("Content")]
  public partial class Property: Item
  {
    /// <summary>
    /// Skrót tworzony na podstawie nazwy lub pozycji w kolekcji
    /// </summary>
    public override int GetHash()
    {
      if (Name != null)
        return Name.GetHashCode();
      if (Collection != null)
        return Collection.IndexOf(this);
      return 0;
    }


    /// <summary>
    /// Nazwa właściwości
    /// </summary>
    [XmlAttribute("Name")]
    [DefaultValue(null)]
    [DataMember]
    public string Name { get; set; }

    /// <summary>
    /// Typ właściwości
    /// </summary>
    [XmlAttribute("Type")]
    [DefaultValue(null)]
    [DataMember]
    public ValueType Type 
    {
      get
      {
        if (fType != null)
          return fType;
        if (Val != null)
          return Val.Type;
        else
          return fType;
      }
      set { fType = value; }
    }
    /// <summary>
    /// Pole przechowujące typ właściwości
    /// </summary>
    protected ValueType fType;

    /// <summary>
    /// Wartość właściwości (tekstowa)
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Value Val { get; set; }

    /// <summary>
    /// Wartość właściwości (tekstowa)
    /// </summary>
    [XmlAttribute("Value")]
    [DefaultValue(null)]
    [DataMember]
    public string Value 
    { 
      get
      {
        if (Val != null)
          return Val.ToString();
        return fValue;
      }
      set 
      {
        fValue = value;
        if (fType != null)
        {
          if (fType == ValueTypes.Variant)
            Debug.Assert(true);
          Val = Iml.Documentation.Value.Parse(fValue, fType);
        }
      }

    }
    /// <summary>
    /// Pole przechowujące wartość tekstową
    /// </summary>
    protected string fValue;

    /// <summary>
    /// Wartości składowe (w przypadku właściwości złożonych)
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Properties Content
    {
      get
      {
        if (fContent == null)
          fContent = new Properties(this);
        return fContent;
      }
      set { fContent = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące wartości składowe
    /// </summary>
    protected Properties fContent;

    /// <summary>
    /// Czy zawartość powinna być serializowana
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeContent()
    {
      return fContent != null && !fContent.IsEmpty();
    }
  }

}
