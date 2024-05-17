using System;
using System.Reflection;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Windows;
using System.Runtime.Serialization;

namespace Iml.Serialization
{
  public class ImlItemInfo : IComparable
  {
    public bool AsAttribute { get; set; }
    public bool AsValue { get; set; }

    private string fImlName;
    public string ImlName
    {
      get
      {
        if (fImlName != null)
          return fImlName;
        else
          return Property.Name;
      }
      set { fImlName = value; }
    }

    public TypeInfo TypeInfo { get; set; }
    public PropertyInfo Property { get; set; }
    public DependencyProperty DependencyProperty { get; set; }
    public int AddOrder { get; set; }
    public int Order { get; set; }
    public bool IsRequired { get; set; }
    public bool EmitDefaultValue { get; set; }
    public bool SpanDefaultValue { get; set; }
    public string ConverterTypeName { get; set; }
    public Object DefaultValue { get; set; }
    public bool IsImplicit { get; set; }

    public ImlItemInfo() { }

    public ImlItemInfo(PropertyInfo aProperty)
    {
      Property = aProperty;
    }

    public ImlItemInfo(DependencyProperty aProperty)
    {
      DependencyProperty = aProperty;
    }

    public void SetAttribute(Attribute aAttribute)
    {
      Type aType = aAttribute.GetType();
      if (aType == typeof(XmlAttributeAttribute))
        SetXmlAttributeAttribute((XmlAttributeAttribute)aAttribute);
      else if (aType == typeof(ImlAttributeAttribute))
        SetImlAttributeAttribute((ImlAttributeAttribute)aAttribute);
      else if (aType == typeof(XmlElementAttribute))
        SetXmlElementAttribute((XmlElementAttribute)aAttribute);
      else if (aType == typeof(XmlArrayAttribute))
        SetXmlArrayAttribute((XmlArrayAttribute)aAttribute);
      else if (aType == typeof(DataMemberAttribute))
        SetDataMemberAttribute((DataMemberAttribute)aAttribute);
      else if (aType == typeof(TypeConverterAttribute))
        SetTypeConverterAttribute((TypeConverterAttribute)aAttribute);
      else if (aType == typeof(ImlDictionaryAttribute))
        SetImlDictionaryAttribute((ImlDictionaryAttribute)aAttribute);
      else if (aType == typeof(ImlDictionaryItemAttribute))
        SetImlDictionaryItemAttribute((ImlDictionaryItemAttribute)aAttribute);
      else if (aType == typeof(ImlDictionaryKeyAttribute))
        SetImlDictionaryKeyAttribute((ImlDictionaryKeyAttribute)aAttribute);
      else if (aType == typeof(ImlDictionaryValueAttribute))
        SetImlDictionaryValueAttribute((ImlDictionaryValueAttribute)aAttribute);
      else if (aType == typeof(XmlTextAttribute))
        this.AsValue = true;
    }

    public void SetXmlAttributeAttribute(XmlAttributeAttribute aAttribute)
    {
      AsAttribute = true;
      if (!String.IsNullOrEmpty(aAttribute.AttributeName))
        ImlName = aAttribute.AttributeName;
      if (aAttribute is ImlAttributeAttribute)
        Order = (aAttribute as ImlAttributeAttribute).Order;
    }

    public void SetImlAttributeAttribute(ImlAttributeAttribute aAttribute)
    {
      AsAttribute = true;
      if (!String.IsNullOrEmpty(aAttribute.AttributeName))
        ImlName = aAttribute.AttributeName;
      Order = (aAttribute as ImlAttributeAttribute).Order;
    }

    public void SetXmlElementAttribute(XmlElementAttribute aAttribute)
    {
      if (!String.IsNullOrEmpty(aAttribute.ElementName))
        ImlName = aAttribute.ElementName;
    }

    public void SetXmlArrayAttribute(XmlArrayAttribute aAttribute)
    {
      if (!String.IsNullOrEmpty(aAttribute.ElementName))
        ImlName = aAttribute.ElementName;
      Order = aAttribute.Order;
      EmitDefaultValue = aAttribute.IsNullable;
    }

    public void SetDataMemberAttribute(DataMemberAttribute aAttribute)
    {
      if (!String.IsNullOrEmpty(aAttribute.Name))
        ImlName = aAttribute.Name;
      Order = aAttribute.Order;
      IsRequired = aAttribute.IsRequired;
      if (IsRequired)
        EmitDefaultValue = aAttribute.EmitDefaultValue;
    }

    public void SetTypeConverterAttribute(TypeConverterAttribute aAttribute)
    {
      if (!String.IsNullOrEmpty(aAttribute.ConverterTypeName))
      {
        ConverterTypeName = aAttribute.ConverterTypeName;
      }
    }

    public void SetDefaultValueAttribute(DefaultValueAttribute aAttribute)
    {
      DefaultValue = aAttribute.Value;
    }

    public void SetImlDictionaryAttribute(ImlDictionaryAttribute aAttribute)
    {
      if (!String.IsNullOrEmpty(aAttribute.ElementName))
        ImlName = aAttribute.ElementName;
      Order = aAttribute.Order;
      EmitDefaultValue = aAttribute.IsNullable;
    }

    public void SetImlDictionaryItemAttribute(ImlDictionaryItemAttribute aAttribute)
    {
      if (!String.IsNullOrEmpty(aAttribute.ElementName))
        ImlName = aAttribute.ElementName;
    }

    public void SetImlDictionaryKeyAttribute(ImlDictionaryKeyAttribute aAttribute)
    {
      if (!String.IsNullOrEmpty(aAttribute.AttributeName))
        ImlName = aAttribute.AttributeName;
    }

    public void SetImlDictionaryValueAttribute(ImlDictionaryValueAttribute aAttribute)
    {
      if (!String.IsNullOrEmpty(aAttribute.AttributeName))
        ImlName = aAttribute.AttributeName;
    }

    public int CompareTo(object aObject)
    {
      if (aObject is ImlItemInfo)
      {
        if (Order == 0)
        {
          if ((aObject as ImlItemInfo).Order > 0)
            return 1;
          else
            if ((aObject as ImlItemInfo).Order < 0)
              return -1;
            else
              return AddOrder.CompareTo((aObject as ImlItemInfo).AddOrder);
        }
        else if ((aObject as ImlItemInfo).Order == 0)
        {
          if (Order > 0)
            return -1;
          else
            if (Order < 0)
              return 1;
            else
              return AddOrder.CompareTo((aObject as ImlItemInfo).AddOrder);
        }
        else
        {
          if ((uint)Order > (uint)(aObject as ImlItemInfo).Order)
            return 1;
          else
            if ((uint)Order < (uint)(aObject as ImlItemInfo).Order)
              return -1;
            else
              return AddOrder.CompareTo((aObject as ImlItemInfo).AddOrder);
        }
      }
      else
        return 0;
    }

    public override string ToString()
    {
      return "<"+ImlName+">";
    }
  }
}
