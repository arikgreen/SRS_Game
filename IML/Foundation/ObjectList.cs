using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Foundation
{
  /// <summary>
  /// Uogólniona lista obiektów
  /// </summary>
  /// <typeparam name="item"></typeparam>
  public partial class ObjectList<item>: List<item>
  {
    /// <summary>
    /// Nadpisane, aby ta właściwość nie była serializowana
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new int Capacity
    {
      get { return base.Capacity; }
      set { base.Capacity = value; }
    }

    /// <summary>
    /// Czy kolekcja jest pusta
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty ()
    {
      return Count == 0;
    }

    /// <summary>
    /// Na razie nie zaimplementowane, ale potrzebne aby móc zastąpić 
    /// obiekt klasy <c>ObjectList</c>przez obiekt klasy <c>ItemList</c> w klasach potomnych
    /// </summary>
    /// <param name="owner"></param>
    public void SetOwner(object owner)
    {

    }

    /// <summary>
    /// Konstruktor domyślny. Dla wprowadzenia konstruktora z właścicielem
    /// </summary>
    public ObjectList () { }

    /// <summary>
    /// Konstruktor z właścicielem.
    /// </summary>
    public ObjectList (object owner) 
    {
      SetOwner(owner);
    }

  }
}
