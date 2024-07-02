using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
using Iml.Foundation;

namespace Iml.Documentation
{
  public partial class Document
  {
    ///// <summary>
    ///// Dodatkowa właściwość "Kategoria" - występująca w dokumentach Worda
    ///// </summary>
    //[IgnoreDataMember]
    //[XmlIgnore]
    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //public string Category
    //{
    //  get { return GetProperty("Category"); }
    //  set { SetProperty("category", value);}
    //}

    ///// <summary>
    ///// Dodatkowa właściwość "Status" - występująca w dokumentach Worda
    ///// </summary>
    //[IgnoreDataMember]
    //[XmlIgnore]
    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //public string ContentStatus
    //{
    //  get { return GetProperty("Status"); }
    //  set { SetProperty("Status", value); }
    //}

    /// <summary>
    /// Dodatkowa właściwość "ContentType" - występująca w dokumentach Worda
    /// </summary>
    [IgnoreDataMember]
    [XmlIgnore]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string ContentType
    {
      get { return GetProperty("ContentType"); }
      set { SetProperty("ContentType", value); }
    }

    /// <summary>
    /// Dodatkowa właściwość "Keywords" - występująca w dokumentach Worda
    /// </summary>
    [IgnoreDataMember]
    [XmlIgnore]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Keywords
    {
      get { return GetProperty("Keywords"); }
      set { SetProperty("Keywords", value); }
    }

    /// <summary>
    /// Dodatkowa właściwość "Subject" - występująca w dokumentach Worda
    /// </summary>
    [IgnoreDataMember]
    [XmlIgnore]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Subject
    {
      get { return GetProperty("Subject"); }
      set { SetProperty("Subject", value); }
    }

    /// <summary>
    /// Dodatkowa właściwość "LastPrinted" - występująca w dokumentach Worda
    /// </summary>
    [IgnoreDataMember]
    [XmlIgnore]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Date LastPrinted
    {
      get 
      {
        string str = GetProperty("LastPrinted"); 
        if (str!=null)
        {
          Date value;
          if (Date.TryParse(str, out value))
            return value;
        }
        return null;
      }
      set 
      { 
        if (value!=null)
          SetProperty("LastPrinted", value.ToString()); 
        else
          SetProperty("LastPrinted", null);
      }
    }

    /// <summary>
    /// Wspólna metoda pobierania właściwości dodatkowej z dokumentu
    /// </summary>
    /// <param name="propName">nazwa właściwości</param>
    /// <returns>wartość tekstowa właściwości</returns>
    public string GetProperty(string propName)
    {
      Property property = this.Properties[propName];
      if (property != null)
        return property.Value;
      else
        return null;
    }

    /// <summary>
    /// Wspólna metoda ustawienia właściwości dodatkowej z dokumentu
    /// </summary>
    /// <param name="propName">nazwa właściwości</param>
    /// <param name="value">wartość (tekstowa) do ustawienia</param>
    public void SetProperty (string propName, string value)
    {
      Property property = this.Properties[propName];
      if (property != null)
      {
        if (value != null)
          property.Value = value;
        else
          this.Properties.Remove(property);
      }
      else
      {
        if (value != null)
          this.Properties.Add(new Property { Name = propName, Value = value });
      }
    }

    /// <summary>
    /// Wspólna metoda ustawienia właściwości dodatkowej z dokumentu
    /// </summary>
    /// <param name="propName">nazwa właściwości</param>
    /// <param name="value">wartość (tekstowa) do ustawienia</param>
    public void SetPropertyValue (string propName, Value value)
    {
      if (propName == "ProjectSymbol")
        Debug.Assert(true);
      Property property = this.Properties[propName];
      if (property != null)
      {
        if (value != null)
          property.Val = value;
        else
          this.Properties.Remove(property);
      }
      else
      {
        if (value != null)
          this.Properties.Add(new Property { Name = propName, Val = value });
      }
    }

    /// <summary>
    /// Wspólna metoda ustawienia właściwości statystycznej z dokumentu
    /// </summary>
    /// <param name="propName">nazwa właściwości</param>
    /// <param name="value">wartość (tekstowa) do ustawienia</param>
    public void SetStatisticsProperty (string propName, string value)
    {
      Property property = this.Statistics[propName];
      if (property != null)
      {
        if (value != null)
          property.Value = value;
        else
          this.Statistics.Remove(property);
      }
      else
      {
        if (value != null)
          this.Statistics.Add(new Property { Name = propName, Value = value });
      }
    }

  }
}
