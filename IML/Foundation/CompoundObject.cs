using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace Iml.Foundation
{
  /// <summary>
  /// Klasa obiektu złożonego
  /// </summary>
  [ContentProperty("Components")]
  public partial class CompoundObject: Object
  {
    /// <summary>
    /// pole zawierające komponenty tego obiektu
    /// </summary>
    private ObjectList<Object> components;

    /// <summary>
    /// Właściwość dostępowa do zapamiętywania komponentów
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ObjectList<Object> Components
    {
      get
      {
        if (components == null)
          components = new ObjectList<Object>();
        return components;
      }
    }

    /// <summary>
    /// Czy obiekt ma komponenty?
    /// </summary>
    /// <returns></returns>
    public bool HasComponents ()
    {
      return components != null && !components.IsEmpty();
    }

    /// <summary>
    /// Czy lista komponentów ma być zapamiętywana?
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeComponents()
    {
      return components != null && !components.IsEmpty();
    }

    /// <summary>
    /// Wyczyszczenie listy komponentów
    /// </summary>
    public void Clear()
    {
      if (components != null)
        components.Clear();
    }

    /// <summary>
    /// Czy lista komponentów jest pusta
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty()
    {
      if (components != null)
        return components.IsEmpty();
      return true;
    }

    /// <summary>
    /// Podaje komponent określonego typu (albo null)
    /// </summary>
    /// <typeparam name="itemType"></typeparam>
    /// <returns></returns>
    public itemType GetComponent<itemType> () where itemType : Object
    {
      if (HasComponents())
        return (itemType)Components.FirstOrDefault(item => item is itemType);
      return null;
    }

    /// <summary>
    /// Ustawia komponent określonego typu (zastępuje już istniejący)
    /// </summary>
    /// <typeparam name="itemType"></typeparam>
    /// <returns></returns>
    public void SetComponent<itemType> (itemType value) where itemType : Object
    {
      if (HasComponents())
      {
        itemType foundItem = (itemType)Components.FirstOrDefault(item => item is itemType);
        if (foundItem != null)
          Components.Remove(foundItem);
      }
      if (value!=null)
        Components.Add(value);
    }
  }
}
