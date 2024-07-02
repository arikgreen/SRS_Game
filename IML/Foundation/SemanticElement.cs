using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Iml.Modeling;
using Type = System.Type;

namespace Iml.Foundation
{
  /// <summary>
  /// Abstrakcyjna klasa reprezentująca element semantyczny.
  /// Może zawierać inne elementy semantyczne.
  /// Może nawiązywać relacje z innymi elementami semantycznymi.
  /// Element ma identyfikator referencyjny, który jest czytelny
  /// dla człowieka, ale ma pewną formalną składnię.
  /// </summary>
  [KnownType("GetKnownTypes")]
  [CanReferTo(typeof(SemanticElement), Semantics="trace",Required=true,DisplayOrder=8)]
  [CanReferTo(typeof(SemanticElement), GroupName="references", DisplayOrder=9)]
  public abstract class SemanticElement : ProjectElement, IReferencingElement, IReferencedElement, IDisposable
  {
    /// <summary>
    /// Ponieważ <see cref="SemanticElement"/> jest klasą abstrakcyjną,
    /// więc musi udostępniać listę znanych typów konkretnych
    /// dla deserializacji. Typy te będą deklarowane w innych
    /// modułach, stąd lista typów jest budowana dynamicznie.
    /// </summary>
    public static List<Type> KnownTypes = new List<Type>();

    static Type[] GetKnownTypes()
    {
      return KnownTypes.ToArray();
    }

    /// <summary>
    /// Konstruktor domyślny.
    /// </summary>
    public SemanticElement()
    {
    }

    /// <summary>
    /// Fizyczne zniszczenie elementu powoduje usunięcie relacji
    /// łączących go z innymi elementami
    /// </summary>
    public override void Dispose()
    {
      ClearReferences();
    }

    /// <summary>
    /// Identyfikator referencyjny elementu. W odróżnieniu od ID
    /// jest unikatowy tylko w ramach listy elementów należących
    /// do pewnego elementu właścicielskiego. Za to jest czytelny
    /// dla człowieka.
    /// </summary>
    [MetaclassProperty(Order = "0.1")]
    [XmlAttribute("RefID")]
    [DefaultValue(null)]
    public string RefID { get; set; }

    private SemanticElements items;
    /// <summary>
    /// Elementy składowe.
    /// </summary>
    [DataMember]
    [Association("ElementItems", "ID", "OwnerID")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public SemanticElements Items 
    { 
      get 
      {
        if (items == null)
          items = new SemanticElements(this);
        return items; 
      } 
    }

    /// <summary>
    /// Czy ma elementy składowe. Nie można po prostu zbadać liczności
    /// kolekcji <see cref="Items"/>, bo jest automatycznie tworzona.
    /// </summary>
    public bool HasItems
    {
      get { return items != null && !items.IsEmpty(); }
        
    }

    /// <summary>
    /// Zwraca/kasuje własny znacznik modyfikacji
    /// i przeprowadza kwerendę po elementach składowych (o ile je posiada).
    /// </summary>
    public override bool IsModified
    {
      get
      {
        if (base.IsModified)
          return true;
        else if (HasItems)
          return Items.IsModified;
        else
          return false;
      }
      set
      {
        base.IsModified = value;
        if (HasItems)
          Items.IsModified = value;
      }
    }

    #region metody potrzebne do importu / eksportu
    /// <summary>
    /// Wyszukanie elementów danej klasy wśród elementów składowych.
    /// </summary>
    /// <param name="aClass">poszukiwana klasa elementu składowego</param>
    /// <returns>lista nazw znalezionych elementów składowych</returns>
    public string[] GetTextItems(Type aClass)
    {
      if (items == null)
        return null;
      List<string> result = new List<string>();
      foreach (SemanticElement aItem in items)
      {
        if (aItem.GetType().Name == aClass.Name)
          result.Add(aItem.DisplayName);
      }
      return result.ToArray();
    }

    /// <summary>
    /// Wyszukanie elementów danej klasy i danego stereotypu wśród elementów składowych.
    /// </summary>
    /// <param name="aClass">poszukiwana klasa elementu składowego</param>
    /// <param name="stereotype">poszukiwany stereotyp elementu składowego</param>
    /// <returns>lista nazw znalezionych elementów składowych</returns>
    public string[] GetTextItems(Type aClass, string stereotype)
    {
      if (items == null)
        return null;
      List<string> result = new List<string>();
      foreach (SemanticElement aItem in items)
      {
        if (aItem.GetType().Name == aClass.Name && aItem.Stereotype == stereotype)
          result.Add(aItem.DisplayName);
      }
      return result.ToArray();
    }

    /// <summary>
    /// Dodawanie elementów danej klasy i o podanych nazwach 
    /// do listy elementów składowych
    /// </summary>
    /// <param name="aClass">dana klasa</param>
    /// <param name="value">lista nazw elementów</param>
    public void AddTextItems(Type aClass, string[] value)
    {
      if (items == null)
        items = new SemanticElements(this);
      for (int i = items.Count - 1; i >= 0; i--)
      {
        SemanticElement aItem = items[i];
        if (aItem.GetType().Name == aClass.Name && !value.Contains(aItem.DisplayName))
          aItem.Deleted = true;
      }
      foreach (string s in value)
      {
        var foundItems = from item in (items as IEnumerable<SemanticElement>) where item.DisplayName == s select item;
        SemanticElement aItem = foundItems.FirstOrDefault();
        if (aItem != null)
        {
          aItem.Deleted = false;
        }
        else
        {
          ConstructorInfo aConstructor = aClass.GetConstructor(new Type[] { });
          aItem = aConstructor.Invoke(new object[] { }) as SemanticElement;
          items.Add(aItem);
          aItem.DisplayName = s;
        }
      }
    }

    /// <summary>
    /// Dodawanie elementów danej klasy, danego stereotypu i o podanych nazwach 
    /// do listy elementów składowych
    /// </summary>
    /// <param name="aClass">dana klasa</param>
    /// <param name="stereotype">dany stereotyp</param>
    /// <param name="value">lista nazw elementów</param>
    public void AddTextItems(Type aClass, string stereotype, string[] value)
    {
      if (items == null)
        items = new SemanticElements(this);
      for (int i = items.Count - 1; i >= 0; i--)
      {
        SemanticElement aItem = items[i];
        if (aItem.GetType().Name == aClass.Name && aItem.Stereotype == stereotype && !value.Contains(aItem.DisplayName))
          aItem.Deleted = true;
      }
      foreach (string s in value)
      {
        var foundItems = from item in (items as IEnumerable<SemanticElement>) where item.DisplayName == s select item;
        SemanticElement aItem = foundItems.FirstOrDefault();
        if (aItem != null)
        {
          aItem.Stereotype = stereotype;
          aItem.Deleted = false;
        }
        else
        {
          ConstructorInfo aConstructor = aClass.GetConstructor(new Type[]{});
          aItem = aConstructor.Invoke(new object[] { }) as SemanticElement;
          items.Add(aItem);
          aItem.Stereotype = stereotype;
          aItem.DisplayName = s;
        }
      }
    }
    #endregion

    #region metody obsługi referencji

    private ReferenceList references;
    /// <summary>
    /// Lista referencji wychodzących z danego elementu
    /// </summary>
    [MetaclassProperty(Order = "99")]
    [DataMember]
    [Association("ElementReferences", "ID", "OwnerID")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ReferenceList References
    {
      get
      {
        if (references == null)
        {
          references = new ReferenceList();
          references.SetOwner(this);
        }
        return references;
      }
        set
        {
            references = value;
        }
    }

    /// <summary>
    /// Referencje są serializowane tylko wtedy, gdy lista referencji nie jest pusta.
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeReferences() { return references != null && !references.IsEmpty(); }

    /// <summary>
    /// Enumerator po elementach składowych. 
    /// Potrzebny dla rozwiązywania referencji.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Element> GetItems()
    {
      foreach (SemanticElement item in items)
        yield return item;
    }

    /// <summary>
    /// Próbuje wyszukać listę elementów składowych o podanej klasie
    /// </summary>
    /// <param name="itemType">poszukiwana klasa elementów</param>
    /// <param name="result">lista wyszukanych elementów</param>
    /// <returns>czy znaleziono element?</returns>
    public bool TryGetItems(Type itemType, out List<SemanticElement> result)
    {
      result = null;
      if (items == null)
        return false;
      var Items = from Item in items 
                  where Item.GetType() == itemType || Item.GetType().IsSubclassOf(itemType) select Item;
      result = new List<SemanticElement>(Items);
      return result != null && result.Count > 0;
    }

    /// <summary>
    /// Próbuje wyszukać listę elementów składowych o podanej klasie i stereotypie
    /// </summary>
    /// <param name="itemType">poszukiwana klasa elementów</param>
    /// <param name="stereotype">poszukiwany stereotyp</param>
    /// <param name="result">lista wyszukanych elementów</param>
    /// <returns>czy znaleziono element?</returns>
    public bool TryGetItems(Type itemType, string stereotype, out List<SemanticElement> result)
    {
      result = null;
      if (items == null)
        return false;
      var Items = from Item in items
                  where (Item.GetType() == itemType || Item.GetType().IsSubclassOf(itemType)) && Item.Stereotype == stereotype
                  select Item;
      result = new List<SemanticElement>(Items);
      return result != null && result.Count > 0;
    }

    /// <summary>
    /// Czy dany element ma referencje do innych elementów.
    /// </summary>
    public bool HasReferences { get { return references != null && references.Count > 0; } }

    /// <summary>
    /// Implementacja metody <see cref="GetOutgoingReferences"/> interfejsu <see cref="IReferencingElement"/>
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Reference> GetOutgoingReferences()
    {
      return References;
    }

    /// <summary>
    /// Dodawanie referencji do listy referencji. 
    /// Implementacja metody <see cref="AddOutgoingReference"/> interfejsu <see cref="IReferencingElement"/>
    /// Pilnuje, aby nie było podwójnych referencji.
    /// </summary>
    /// <param name="aReference">dodawana referencja</param>
    public void AddOutgoingReference(Reference aReference)
    {
      References.Add(aReference);
    }

    /// <summary>
    /// Usuwanie referencji z listy referencji.
    /// Implementacja metody <see cref="RemoveOutgoingReference"/> interfejsu <see cref="IReferencingElement"/>
    /// </summary>
    /// <param name="aReference">usuwana referencja</param>
    public void RemoveOutgoingReference(Reference aReference)
    {
      if (references != null)
        references.Remove(aReference);
    }

    /// <summary>
    /// Usuwanie wszystkich referencji o podanej semantyce z listy referencji.
    /// </summary>
    /// <param name="semantics">poszukiwana semantyka</param>
    public void RemoveReferences(string semantics)
    {
      if (references != null)
      {
        for (int i = references.Count - 1; i >= 0; i--)
          if ((references[i] is Reference) && (references[i] as Reference).Semantics == semantics)
            references.RemoveAt(i);
      }
    }

    /// <summary>
    /// Czyszczenie listy referencji wychodzących i wchodzących.
    /// Implementacja metody <see cref="ClearReferences"/> interfejsu <see cref="IReferencingElement"/>
    /// i interfejsu <see cref="IReferencedElement"/>
    /// </summary>
    public virtual void ClearReferences()
    {
      if (references != null)
      {
        for (int i = references.Count - 1; i >= 0; i--)
        {
          Reference aReference = references[i];
          aReference.Target = null;
        }
        references = null;
      }
      if (incomingReferences != null)
      {
        for (int i = incomingReferences.Count - 1; i >= 0; i--)
        {
          Reference aReference = incomingReferences[i];
          aReference.Target = null;
        }
        incomingReferences = null;
      }
    }

    /// <summary>
    /// Próbuje wyszukać referencję o podanej semantyce. 
    /// Jeśli element ma wiele referencji, to zwracana jest pierwsza.
    /// </summary>
    /// <param name="semantics">poszukiwana semantyka</param>
    /// <param name="result">wyszukana referencja</param>
    /// <returns>czy znaleziono referencję?</returns>
    public bool TryGetReference(string semantics, out Reference result)
    {
      result = null;
      if (references == null)
        return false;
      var Refs = from Ref in references 
                 where (Ref is Reference) && (Ref as Reference).Semantics == semantics 
                 select Ref as Reference;
      result = Refs.FirstOrDefault();
      return result != null;
    }

    /// <summary>
    /// Próbuje wyszukać listę wszystkich referencji o podanej semantyce
    /// </summary>
    /// <param name="semantics">poszukiwana semantyka</param>
    /// <param name="result">lista wyszukanych referencji</param>
    /// <returns>czy znaleziono referencje?</returns>
    public bool TryGetReferences(string semantics, out List<Reference> result)
    {
      result = null;
      if (references == null)
        return false;
      var Refs = from Ref in references
                 where (Ref is Reference) && (Ref as Reference).Semantics == semantics
                 select Ref as Reference;
      result = new List<Reference>(Refs);
      return result != null && result.Count > 0;
    }


    /// <summary>
    /// Próbuje wyszukać listę wszystkich referencji o podanej semantyce
    /// </summary>
    /// <param name="semantics">poszukiwana semantyka</param>
    /// <param name="result">lista nazw referencji (semantyka + cel)</param>
    /// <returns>czy znaleziono referencje?</returns>
    public bool TryGetReferenceNames(string semantics, out List<string> result)
    {
      result = null;
      if (references == null)
        return false;
      var Refs = from Ref in references
                 where (Ref is Reference) && (Ref as Reference).Semantics == semantics
                 select (Ref as Reference).DisplayName;
      result = new List<string>(Refs);
      return result != null && result.Count > 0;
    }

    /// <summary>
    /// Próbuje dodać listę referencji o podanej semantyce i podanych nazwach
    /// </summary>
    /// <param name="semantics">podana semantyka</param>
    /// <param name="value">lista nazw referencji (semantyka + cel)</param>
    /// <returns>czy operacja się udała?</returns>
    public bool TryAddReferenceNames(string semantics, List<string> value)
    {
      bool result = false;
      if (references == null)
        references = new ReferenceList(this);
      for (int i = references.Count - 1; i >= 0; i--)
      {
        if (references[i] is Reference)
        {
          Reference aReference = references[i] as Reference;
          {
            if (!aReference.IsDeferred)
            {
              if (!value.Contains(aReference.DisplayName))
              {
                if (aReference.Semantics == semantics)
                {
                  if (!aReference.Deleted)
                  {
                    aReference.Deleted = true;
                    result = true;
                  }
                }
              }
              else
              {
                if (aReference.Semantics != semantics)
                {
                  aReference.Semantics = semantics;
                  result = true;
                }
              }
            }
          }
        }
      }
      foreach (string s in value)
      {
        var foundItems = from item in references 
                         where item is Reference && (item as Reference).DisplayName == s select item;
        if (foundItems.FirstOrDefault() == null)
        {
          references.Add(new Reference(semantics, s));
          result = true;
        }
      }
      return result;
    }

    /// <summary>
    /// Czy ma nierozwiązane referencje?
    /// Implementacja metody <see cref="HasUnresolvedReferences"/> interfejsu <see cref="IReferencingElement"/>
    /// </summary>
    public bool HasUnresolvedReferences
    {
      get
      {
        if (references == null)
          return false;
        foreach (Reference aReference in references)
          if (!aReference.IsResolved)
            return true;
        return false;
      }
    }

    /// <summary>
    /// Rozwiązuje nierozwiązane referencje.
    /// Implementacja metody <see cref="ResolveReferences"/> interfejsu <see cref="IReferencingElement"/>
    /// </summary>
    /// <param name="referencedItems">lista przeszukiwanych elementów</param>
    public void ResolveReferences(IEnumerable<Element> referencedItems)
    {
      if (references != null)
      {
        foreach (Reference aReference in references)
        {
          if (aReference.Target == null)// && aReference.DisplayName != null)
          {
            aReference.TryResolveReference(referencedItems);//, aReference.DisplayName);
          }
        }
      }
    }

    private List<Reference> incomingReferences;
    /// <summary>
    /// Lista referencji przychodzących do elementu.
    /// Nie są zapamiętywane, lecz nawiązywane 
    /// przez referencje przychodzące od innych elementów.
    /// </summary>
    public List<Reference> IncomingReferences { get { return incomingReferences; } }

    /// <summary>
    /// Czy istnieją referencje do tego elementu?
    /// </summary>
    public bool IsReferenced { get { return incomingReferences != null && incomingReferences.Count > 0; } }

    /// <summary>
    /// Dodawanie referencji przychodzącej.
    /// Implementacja metody <see cref="AddIncomingReference"/> interfejsu <see cref="IReferencedElement"/>
    /// </summary>
    /// <param name="aReference">dodawana referencja</param>
    public void AddIncomingReference(Reference aReference)
    {
      if (incomingReferences == null)
        incomingReferences = new List<Reference>();
      incomingReferences.Add(aReference);
    }

    /// <summary>
    /// Usuwanie referencji przychodzącej.
    /// Implementacja metody <see cref="RemoveIncomingReference"/> interfejsu <see cref="IReferencedElement"/>
    /// </summary>
    /// <param name="aReference">usuwana referencja</param>
    public void RemoveIncomingReference(Reference aReference)
    {
      if (incomingReferences != null)
      {
        if (aReference.Source is IReferencingElement)
          (aReference.Source as IReferencingElement).RemoveOutgoingReference(aReference);
        incomingReferences.Remove(aReference);
      }
    }

    #endregion

    /// <summary>
    /// Przepisanie ID z innego elementu
    /// </summary>
    public override void MergeID(Element otherElement)
    {
      base.MergeID(otherElement);
      if (otherElement is SemanticElement)
      {
        SemanticElement other = (SemanticElement)otherElement;
        //this.Names.MergeIDs(other.Names);
        //this.Descriptions.MergeIDs(other.Descriptions);
        this.Items.MergeIDs(other.Items);
      }
    }

    /// <summary>
    /// Mieszanie ID z extra również dla nazw i elementów składowych
    /// </summary>
    /// <param name="extra"></param>
    public override void MixID (string extra)
    {
      base.MixID (extra);
      //if (Names!=null)
      //  Names.MixIDs (extra);
      if (Items!=null)
        Items.MixIDs (extra);
      if (References != null)
        References.MixIDs (extra);
    }

    /// <summary>
    /// Przepisanie identyfikatorów referencji z innej listy.
    /// Skojarzenie następuje wg <c>TargetID</c>.
    /// </summary>
    public void MergeReferences(SemanticElement otherElement)
    {
      this.References.MergeIDs(otherElement.References);
      this.Items.MergeReferences(otherElement.Items);
    }
  }
}
