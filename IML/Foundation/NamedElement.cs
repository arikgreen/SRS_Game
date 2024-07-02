using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Iml.Modeling;

namespace Iml.Foundation
{
  /// <summary>
  /// Pierwsza nieabstrakcyjna klasa reprezentująca dowolny element, który ma nazwę. 
  /// </summary>
  [DataContract]
  [IsAbstract]
  public partial class NamedElement: Element, INamedElement
  {
    /// <summary>
    /// konstruktor inicjujący
    /// </summary>
    public NamedElement()
    {
    }

    /// <summary>
    /// Identyfikator języka, w którym aktualnie jest prezentowana nazwa elementu
    /// Pobierany z elementu nadrzędnego
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual string Language
    {
      get
      {
        if (Owner is INamedElement)
          return (Owner as INamedElement).Language;
        else
          return null;
      }
      set { }
    }

    private NameList names;
    /// <summary>
    /// Lista nazw elementu (w różnych językach)
    /// </summary>
    [IgnoreDataMember]
//    [Include]
//    [Association("ElementNames", "ID", "OwnerID")]
//    [Composition]
//    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public NameList Names
    {
      get 
      {
        if (names==null)
          names = new NameList (this);
        return names; 
      }
    }

    /// <summary>
    ///  Nazwy są serializowane tylko wtedy, gdy jest ich więcej niż jedna.
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeNames()
    {
      return names != null && (names.Count > 1);// || names.Count==1 && names[0].Language!=null);
    }
    
    /// <summary>
    /// Nazwa elementu. Pobierana z listy nazw w różnych językach wg właściwości <c>"Language"</c>.
    /// Jeśli nie ma nazwy w danym języku, to poszukiwana jest nazwa z <c>Language==null</c>.
    /// </summary>
    [MetaclassProperty(Order = "0.3")]
    [DefaultValue(null)]
    public string Name //{ get;set;}
    {
      get 
      {
        if (names == null)
          return fName;
        return Names.GetValue(Language); 
      }
      set 
      {
        fName = value;
        Names.SetValue(Language, value); 
      }
    }
    private string fName;

    private ImlTextList descriptions;
    /// <summary>
    /// Lista opisów elementu (w różnych językach)
    /// </summary>
    [IgnoreDataMember]
    //[Include]
    //[Association ("ElementDescriptions", "ID", "OwnerID")]
    //[Composition]
    //[DesignerSerializationVisibility (DesignerSerializationVisibility.Content)]
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    public ImlTextList Descriptions
    {
      get 
      {
        if (descriptions == null)
          descriptions = new ImlTextList (this);
        return descriptions; 
      }
    }

    /// <summary>
    /// Opis elementu. Również wybierany z listy opisów
    /// w różnych językach.
    /// </summary>
    [MetaclassProperty(Order = "1")]
    [DataMember]
    //[DesignerSerializationVisibility (DesignerSerializationVisibility.Visible)]
    [DefaultValue(null)]
    public string Description
    {
      get 
      {
        if (descriptions == null)
          return fDescription;
        return Descriptions.GetValue (Language); 
      }
      set 
      { 
        fDescription = value;
        Descriptions.SetValue (Language, new ImlText(value)); 
      }
    }
    private string fDescription;

    /// <summary>
    ///  opisy są serializowane tylko wtedy, gdy jest ich więcej niż jednen
    ///  lub ten jeden jest w określonym języku
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeDescriptions ()
    {
      return descriptions != null && (descriptions.Count > 1);
        //|| descriptions.Count==1 && descriptions[0].Language!=null);
    }

  }
}
