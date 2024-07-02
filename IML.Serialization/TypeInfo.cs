using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using System.Linq;


namespace Iml.Serialization
{
  public class TypeInfo
  {

    public Type Type { get; set; }
    public TypeInfo BaseType { get; set; }
    public string ElementPrefix { get; set; }
    public string ElementName { get; set; }
    public string ElementNs { get; set; }
    public bool IsConstructable { get; set; }
    public bool IsList { get; set; }
    public bool IsDictionary { get; set; }
    public bool HasAliases { get; set; }
    public TypeInfo KeyType { get; set; }
    public TypeInfo ItemType { get; set; }
    public ImlItemInfo ValueInfo { get; set; }
    public ImlItemInfo KeyAttribute { get; set; }
    public ImlItemInfo ValueAttribute { get; set; }
    public List<ImlItemInfo> Attributes { get; set; }
    public List<ImlItemInfo> Elements { get; set; }
    public PropertyInfo XmlLangProperty { get; set; }
    public PropertyInfo ContentProperty { get; set; }
    public String ConverterTypeName { get; set; }
    public Object DefaultValue { get; set; }
    public List<Type> ContentWrappers { get; set; }

    public string FullElementName
    {
      get
      {
        if (!String.IsNullOrEmpty(ElementPrefix))
          return ElementPrefix+":"+ElementName;
        else
          return ElementName;
      }
    }

    //-----------------------------------------------------------------------------------------------------------
    public void AddImlItemInfo(ImlItemInfo aImlItemInfo)
    {
      if (aImlItemInfo.Property == ContentProperty)
        return;
      if (aImlItemInfo.AsValue)
      {
        if (Attributes != null)
          Attributes.RemoveAll(item => item.ImlName == aImlItemInfo.ImlName);
        if (Elements != null)
          Elements.RemoveAll(item => item.ImlName == aImlItemInfo.ImlName);
        ValueInfo = aImlItemInfo;
      }
      else if (aImlItemInfo.AsAttribute)
      {
        if (Attributes == null)
          Attributes = new List<ImlItemInfo>();
        aImlItemInfo.AddOrder = Attributes.Count;
        Attributes.RemoveAll(item => item.ImlName == aImlItemInfo.ImlName);
        if (Elements != null)
          Elements.RemoveAll(item => item.ImlName == aImlItemInfo.ImlName);
        Attributes.Add(aImlItemInfo);
      }
      else
      {
        if (Elements == null)
          Elements = new List<ImlItemInfo>();
        aImlItemInfo.AddOrder = Elements.Count;
        if (Attributes != null)
          Attributes.RemoveAll(item => item.ImlName == aImlItemInfo.ImlName);
        Elements.RemoveAll(item => item.ImlName == aImlItemInfo.ImlName);
        Elements.Add(aImlItemInfo);
      }
    }

    public override string ToString()
    {
      return "<" + ElementName + ">";
    }
  }

}
