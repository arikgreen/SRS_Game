using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Runtime;
using System.Xml.Serialization;

namespace Iml.Foundation
{
  /// <summary>
  /// Uogólniona lista elementów. Sama należy do jakiegoś elementu właścicielskiego
  /// i przypisuje do niego własne elementy składowe. 
  /// </summary>
  /// <remarks>
  /// Własna implementacja
  /// interfejsu <c>IList</c> była konieczna, bo klasa <c>List</c> nie daje
  /// wirtualnej metody <c>Insert</c>
  /// </remarks>
  /// <typeparam name="itemType">element składowy musi być typu <see cref="Item"/></typeparam>
  [Serializable]
  public partial class ItemList<itemType> :
    IList<itemType>, IList, ICollection<itemType>, ICollection, IEnumerable<itemType>, IEnumerable,
    IUniqueItemsCollection,
    INotifyCollectionChanged, INotifyObjectChanged
    where itemType : Item
  {
    
    
    /// <summary>
    /// Konstruktor domyślny.
    /// </summary>
    /// 
    public ItemList() { }

    /// <summary>
    /// Konstruktor ustalający właściciela listy.
    /// </summary>
    /// <param name="aOwner"></param>
    /// 
    public ItemList(object aOwner) { SetOwner(aOwner); }

    private object owner;
    /// <summary>
    /// Właściciel listy.
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [XmlIgnore]
    public object Owner { get { return owner; } set { SetOwner (value); } }

    /// <summary>
    /// Metoda ustawienia właściciela. Potrzebna, gdy przypisywana jest cała lista.
    /// </summary>
    /// <param name="aOwner"></param>
    public virtual void SetOwner(object aOwner)
    {
      owner = aOwner;
      foreach (itemType aItem in this)
        aItem.Owner = aOwner;
    }

    /// <summary>
    /// Ustawienie właściciela elementu na właściciela kolekcji.
    /// </summary>
    /// <param name="item"></param>
    protected virtual void SetItemOwner(itemType item)
    {
      // to musi być w tej kolejności
      item.Owner = this.Owner;
      item.Collection = this;
    }
    
    /// <summary>
    /// Elementy składowe - udostępniane przez metody interfejsu <see cref="IList"/>
    /// </summary>
    private List<itemType> items = new List<itemType>();

    /// <summary>
    /// Dodanie elementu.
    /// </summary>
    /// <param name="item">element dodawany</param>
    public void Add(itemType item) 
    {
      Insert(items.Count, item);
    }

    /// <summary>
    /// Wirtualna metoda wstawiania elementów. Umożliwia rozszerzenie implementacji
    /// przez klasy potomne.
    /// </summary>
    /// <param name="index">pozycja elementu</param>
    /// <param name="item">wstawiany element</param>
    public virtual void Insert(int index, itemType item)
    {
      items.Insert(index, item);
      item.Collection = this;
      item.CollectionIndex = this.Count;
      SetItemOwner(item);
    }

    /// <summary>
    /// Czy lista jest pusta?
    /// </summary>
    public virtual bool IsEmpty() { return items.Count == 0; }

    /// <summary>
    /// Enumerator listy.
    /// </summary>
    public IEnumerator<itemType> GetEnumerator() { return items.GetEnumerator(); }

    /// <summary>
    /// Dostęp do pojedynczego elementu
    /// </summary>
    /// <param name="index">indeks elementu</param>
    public itemType this[int index] 
    { 
      get 
      {
        if (index >= 0 && index < Count)
          return items[index];
        else
        {
          ConstructorInfo aConstructor = typeof(itemType).GetConstructor(new Type[0]);
          if (aConstructor != null)
            return (itemType)aConstructor.Invoke (new object[0]);
          else
            return null;
        }
      } 
      set 
      {
        if (index >= 0 && index < Count)
          items[index] = value; 
      } 
    }

    /// <summary>
    /// Czy lista jest tylko do czytania?
    /// </summary>
    public bool IsReadOnly { get { return false; } }

    /// <summary>
    /// Liczba elementów listy.
    /// </summary>
    public int Count { get { return items.Count; } }

    /// <summary>
    /// Kopiowanie listy do tablicy.
    /// </summary>
    /// <param name="array">tablica docelowa</param>
    /// <param name="index">pozycja, od której kopiować</param>
    public void CopyTo(itemType[] array, int index) { items.CopyTo(array, index); }

    /// <summary>
    /// Czy zawiera element?
    /// </summary>
    /// <param name="item">poszukiwany element</param>
    public bool Contains(itemType item) { return items.Contains(item); }

    /// <summary>
    /// Usunięcie elementu
    /// </summary>
    /// <param name="item">usuwany element</param>
    /// <returns>czy operacja się udała?</returns>
    public bool Remove(itemType item) 
    {
      item.Collection = null;
      return items.Remove(item); 
    }

    /// <summary>
    /// Usunięcie wszystkich elementów z listy.
    /// </summary>
    public void Clear() { items.Clear(); }

    /// <summary>
    /// Usunięcie elementu na podanej pozycji
    /// </summary>
    /// <param name="index">pozycja usuwanego elementu</param>
    /// 
    public void RemoveAt(int index) 
    {
      itemType item = this[index];
      item.Collection = null;
      items.RemoveAt(index); 
    }

    /// <summary>
    /// Wyszukanie elementu
    /// </summary>
    /// <param name="item">poszukiwany element</param>
    /// <returns>pozycja wyszukanego elementu, -1 gdy nie znaleziono</returns>
    /// 
    public int IndexOf(itemType item) { return items.IndexOf(item); }

    #region implementacja interfejsu IList

    int IList.Add (object item)
    {
      if (ItemList<itemType>.IsCompatibleObject(item))
      {
        this.Add((itemType)item);
        return this.Count - 1;
      }
      return -1;
    }

    void IList.Clear ()
    {
      this.Clear ();
    }

    bool IList.Contains (object item)
    {
      if (!ItemList<itemType>.IsCompatibleObject(item))
      {
        return false;
      }
      return this.Contains((itemType)item);
    }

    int IList.IndexOf (object item)
    {
      if (!ItemList<itemType>.IsCompatibleObject(item))
      {
        return -1;
      }
      return this.IndexOf((itemType)item);
    }

    void IList.Insert (int index, object item)
    {
      if (ItemList<itemType>.IsCompatibleObject(item))
      {
        this.Insert(index, (itemType)item);
      }
    }

    bool IList.IsFixedSize
    {
      get { return false; }
    }

    bool IList.IsReadOnly
    {
      get { return false; }
    }

    void IList.Remove(object item)
    {
      if (ItemList<itemType>.IsCompatibleObject(item))
      {
        this.Remove((itemType)item);
      }
    }  

    void IList.RemoveAt (int index)
    {
      this.RemoveAt (index);
    }

    object IList.this[int index]
    {
      get
      {
        return this[index];
      }
      set
      {
        this[index] = value as itemType;
      }
    }

    /// <summary>
    /// Metoda wykorzystywana w interfejsie <c>IList</c>
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    /// 
    private static bool IsCompatibleObject(object value)
    {
      if (value is itemType)
      {
        return true;
      }
      if (value != null)
      {
        return false;
      }
      itemType t = default(itemType);
      return t == null;
    }

    #endregion implementacja interfejsu IList

    #region implementacja interfejsu ICollection

    void ICollection.CopyTo (Array array, int index)
    {
      this.CopyTo (array as itemType[], index);
    }

    int ICollection.Count
    {
      get { return this.Count; }
    }

    bool ICollection.IsSynchronized
    {
      get { return false; }
    }

    object ICollection.SyncRoot
    {
      get { return null; }
    }
  
    #endregion implementacja interfejsu ICollection

    #region implementacja interfejsu IEnumerable

    /// <summary>
    /// Pobranie enumeratora
    /// </summary>
    /// <returns></returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
      return items.GetEnumerator();
    }

    #endregion implementacja interfejs IEnumerable

    #region implementacja interfejsu INotifyCollectionChanged

    /// <summary>
    /// Uchwyt zdarzenia zmiany kolekcji
    /// </summary>
    /// 
    public event NotifyCollectionChangedEventHandler CollectionChanged;

    /// <summary>
    /// Implementacja zdarzenia zmiany listy.
    /// Powinna być wywoływana przy zmianie.
    /// </summary>
    /// <param name="action">akcja określająca, to się stało</param>
    /// <param name="changedItem">zmieniany element</param>
    /// 
    public void NotifyCollectionChanged(NotifyCollectionChangedAction action, object changedItem)
    {
      IsModified = true;
      NotifyCollectionChangedEventHandler handler = CollectionChanged;
      if (handler != null)
      {
        handler(this, new NotifyCollectionChangedEventArgs(action,changedItem));
      }
    }
  
    #endregion implementacja interfejsu INotifyCollectionChanged
 
    /// <summary>
    /// Kwerenda po znacznikach modyfikacji elementów.
    /// Umożliwia również kasowanie znaczników.
    /// </summary>
    /// 
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    [XmlIgnore]
    public bool IsModified
    {
      get
      {
        bool result = (from item in items where item.IsModified select true).FirstOrDefault ();
        return result;
      }
      set
      {
        if (value == false)
          foreach (Item item in items)
            item.IsModified = false;
      }
    }

    /// <summary>
    /// Sprawdzenie, czy wartość właściwości elementu jest unikatowa w kolekcji
    /// </summary>
    /// <param name="propName">nazwa właściwości</param>
    /// <param name="value">sprawdzana wartość</param>
    /// <param name="excludeItem">odrzucany element (czyli ten, który chce wprowadzić wartość)</param>
    /// <returns><c>true</c>, gdy w indeksie nie ma takiej wartości lub gdy wartość w indeksie wskazuje odrzucany element</returns>
    /// 
    public bool CheckUnique(string propName, object value, itemType excludeItem)
    {
      foreach (itemType existingItem in this)
      {
        if (existingItem != excludeItem)
        {
          PropertyInfo property = existingItem.GetType().GetProperty(propName);
          if (property != null)
          {
            object itemValue = property.GetGetMethod().Invoke(existingItem, new object[0]);
            if (itemValue is IComparable
              && (itemValue as IComparable).CompareTo(value) == 0)
              return false;
            if (itemValue == value)
              return false;
          }
        }
      }
      return true;
    }

    /// <summary>
    /// Obliczenie funkcji skrótu na podstawie zawartości
    /// </summary>
    /// <returns></returns>
    public int GetHash ()
    {
      int hash = 0;
      foreach (itemType item in this)
        hash += item.GetHash();
      return hash;
    }

    /// <summary>
    /// Lista skrótów elementów
    /// </summary>
    protected List<int> hashCodes = new List<int>();

    /// <summary>
    /// Funkcja zapewniająca unikatowość skrótów elementów
    /// </summary>
    /// <param name="hashCode"></param>
    /// <returns></returns>
    public int MakeHashUnique(int hashCode)
    {
      if (hashCode == 0)
        hashCode++;
      while (hashCodes.Contains(hashCode))
        hashCode++;
      hashCodes.Add(hashCode);
      return hashCode;
    }

    #region implementacja interfejsu IObjectChanged

    /// <summary>
    /// Zdarzenie zmiany obiektu
    /// </summary>
    public event NotifyObjectChangedEventHandler ObjectChanged;

    /// <summary>
    /// Zgłoszenie zmiany obiektu
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="propName"></param>
    public void NotifyObjectChanged(object sender, string propName)
    {
      IsModified = true;
      NotifyObjectChangedEventHandler handler = ObjectChanged;
      if (handler != null)
      {
        handler(this, new NotifyObjectChangedEventArgs(sender, propName));
      }
    }

    #endregion

  }

}
