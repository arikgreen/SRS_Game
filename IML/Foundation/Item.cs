using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Iml.Foundation
{
  /// <summary>
  /// Abstrakcyjna klasa bazowa dla wszystkich elementów modelu danych IML
  /// </summary>
  
  [DataContractAttribute]
  [Serializable]
  public abstract class Item: Object, INotifyPropertyChanged, INotifyObjectChanged
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Item () { }

    /// <summary>
    /// Konstruktor kopiujący
    /// </summary>
    /// <param name="source"></param>
    public Item (Item source) : base(source) 
    {
      this.IsModified = source.IsModified;
      this.Tag = source.Tag;
    }

    private object owner;
    /// <summary>
    /// Element właścicielski względem danego elementu.
    /// </summary>
    [IgnoreDataMember]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Display(AutoGenerateField = false)]
    [XmlIgnore]
    public object Owner
    {
      get { return owner; }
      set 
      {
        if (value != owner)
        {
          owner = value;
          NotifyPropertyChanged("Owner");
        }
      }
    }

    /// <summary>
    /// Kolekcja zawierająca dany element
    /// </summary>
    [IgnoreDataMember]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Display(AutoGenerateField = false)]
    [XmlIgnore]
    public IUniqueItemsCollection Collection { get; set; }

    /// <summary>
    /// Indeks w kolekcji (przy wstawianiu)
    /// </summary>
    [IgnoreDataMember]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Display(AutoGenerateField = false)]
    [XmlIgnore]
    public int CollectionIndex { get; set; }

    /// <summary>
    /// Czy element jest pierwszy w kolekcji
    /// </summary>
    public bool IsFirst()
    {
      if (Collection != null)
      {
        return Collection.IndexOf(this) == 0;
      }
      throw new InvalidOperationException("Element does not belong to any collection");
    }

    /// <summary>
    /// Czy element jest ostatni w kolekcji
    /// </summary>
    public bool IsLast()
    {
      if (Collection != null)
      {
        return Collection.IndexOf(this) == Collection.Count - 1;
      }
      throw new InvalidOperationException("Element does not belong to any collection");
    }


    /// <summary>
    /// Sprawdzenie, czy wartość właściwości jest unikatowa w kolekcji zawierającej dany element
    /// </summary>
    /// <param name="propName">nazwa właściwości</param>
    /// <param name="value">sprawdzana wartość</param>
    /// <returns><c>true</c>, gdy w indeksie nie ma takiej wartości lub gdy wartość w indeksie wskazuje dany element</returns>
    public bool CheckUnique(string propName, object value)
    {
      if (Collection == null)
        return true;
      MethodInfo aMethod = Collection.GetType().GetMethod("CheckUnique");
      if (aMethod!=null)
        return (bool)aMethod.Invoke(Collection, new[] { propName, value, this });
      return true;
    }
    
    private bool modified;
    /// <summary>
    /// Znacznik modyfikacji elementu.
    /// Ustawiany przy modyfikacji właściwości lub elementów składowych.
    /// Kasowany z zewnątrz.
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Display(AutoGenerateField = false)]
    [XmlIgnore]
    public virtual bool IsModified 
    { 
      get { return modified; } 
      set { modified = value; } 
    }

    /// <summary>
    /// Dowolny obiekt przypisany do elementu.
    /// </summary>
    [IgnoreDataMember]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Display(AutoGenerateField = false)]
    [XmlIgnore]
    public object Tag { get; set; }

    #region implementacja interfejsu INotifyPropertyChanged
    /// <summary>
    /// Uchwyt zdarzenia zmiany właściwości
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Implementacja zdarzenia zmiany właściwości. 
    /// Powinna być wywoływana przy zmianie każdej właściwości.
    /// </summary>
    /// <param name="propName"></param>
    protected void NotifyPropertyChanged(string propName)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(propName));
      if (Collection != null)
      {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
          handler(this, new PropertyChangedEventArgs(propName));
        if (Collection is INotifyObjectChanged)
          (Collection as INotifyObjectChanged).NotifyObjectChanged(this, propName);
        IsModified = true;
      }
      if (owner is Item)
      {
        (owner as Item).NotifyObjectChanged(this, propName);
      }
    }

    /// <summary>
    /// Identyfikator lokalny
    /// </summary>
    public virtual string Id
    {
      get
      {
        if (fId == null)
          fId = GetHash().ToString("X8");
        return fId;
      }
      set
      {
        fId = value;
      }
    }
    /// <summary>
    /// Pole przechowujące identyfikator
    /// </summary>
    protected string fId;

    /// <summary>
    /// Obliczenie funkcji skrótu dla potrzeb identyfikacji
    /// </summary>
    /// <returns></returns>
    public virtual int GetHash()
    {
      return CollectionIndex;
    }

    #endregion implementacja interfejsu INotifyPropertyChanged

    #region implementacja interfejsu IObjectChanged

    /// <summary>
    /// Zarzenie zmiany obiektu
    /// </summary>
    public event NotifyObjectChangedEventHandler ObjectChanged;


    /// <summary>
    /// Sygnalizacja, że inny, podany obiekt zmienił właściwość
    /// </summary>
    /// <param name="sender">obiekt sygnalizujący</param>
    /// <param name="propName">nazwa właściwości</param>
    public virtual void NotifyObjectChanged(object sender, string propName=null)
    {
      NotifyObjectChangedEventHandler handler = ObjectChanged;
      if (handler != null)
      {
        handler(this, new NotifyObjectChangedEventArgs(sender, propName));
      }
    }
    #endregion

  }
}
