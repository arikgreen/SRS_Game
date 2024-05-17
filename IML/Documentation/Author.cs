using System;
using System.Data;
using System.Xml.Serialization;
using Iml.Foundation;
using System.Runtime.Serialization;

namespace Iml.Documentation

{

  /// <summary>Klasa reprezentująca autora</summary>
  /// <remarks>
  /// Jest to definicja autora. Pojęcie autora jest potrzebne dla rejestrowania zmian w projekcie.
  /// Każdy autor jest reprezentowany przez login, który jest przypisywany do elementu projektowego
  /// w momencie jego tworzenia a także do każdej właściwości w momencie jej ustawienia.
  /// Instancja autora reprezentuje takie dane autora, jak imię i nazwisko oraz kontakt.
  /// </remarks>
  [DataContract]
  public partial class Author: Item
  {
    /// <summary>domyślny konstruktor dla autora</summary>
    public Author()
    { }

    private string fID;
    /// <summary>identyfikator autora</summary>
    [DataMember]
    [XmlAttribute]
    public string ID 
    {
      get { return fID; }
      set
      {
        if (fID != value)
        {
          if (fID != null)
            throw new ReadOnlyException(GetType().Name + ".ID");
          fID = value;
          NotifyPropertyChanged("ID");
        }
      }
    }

    private string fName;
    /// <summary>imię i nazwisko autora</summary>
    [DataMember]
    [XmlText]
    public string DisplayName
    {
      get { return fName; }
      set
      {
        if (fName != value)
        {
          if (!CheckUnique("DisplayName", value))
            throw new DuplicateNameException(GetType().Name + ".DisplayName");
          fName = value;
          NotifyPropertyChanged("DisplayName");
        }
      }
    }

    private string fInitials;
    /// <summary>Inicjały autora</summary>
    [DataMember]
    [XmlAttribute]
    public string Initials
    {
      get { return fInitials; }
      set
      {
        if (fInitials != value)
        {
          if (!CheckUnique("Initials", value))
            throw new DuplicateNameException("GetType().Name + .Initials");
          fInitials = value;
          NotifyPropertyChanged("Initials");
        }
      }
    }

    private string fContact;
    /// <summary>kontakt do autora - dane teleadresowe</summary>
    [DataMember]
    [XmlAttribute("Contact")]
    public string Contact
    {
      get { return fContact; }
      set
      {
        if (fContact != value)
        {
          fContact = value;
          NotifyPropertyChanged("Contact");
        }
      }
    }

    ///// <summary>zwraca nazwę widoczną</summary>
    //public override string ToString()
    //{
    //  return DisplayName;
    //}
  }

}