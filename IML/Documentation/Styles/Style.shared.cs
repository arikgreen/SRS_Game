using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  partial class Style
  {
    /// <summary>
    /// Utworzenie poprawnego identyfikatora dla stylu
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public string CreateID (string name)
    {
      StringBuilder sb = new StringBuilder();
      foreach (char ch in name)
      {
        if (Char.IsLetterOrDigit(ch) || ch == '_')
          sb.Append(ch);
      }
      return sb.ToString();
    }

    /// <summary>
    /// Zwiększenie licznika odwołań
    /// </summary>
    /// <param name="aStyle"></param>
    public static void IncRefCount(Style aStyle)
    {
      if (aStyle != null)
        aStyle.RefCount++;
    }

    /// <summary>
    /// Zmniejszenie licznika odwołań
    /// </summary>
    /// <param name="aStyle"></param>
    public static void DecRefCount (Style aStyle)
    {
      if (aStyle != null)
        if (aStyle.RefCount>0)
          aStyle.RefCount--;
    }

    /// <summary>
    /// Licznik referencji przychodzących
    /// </summary>
    public int RefCount;

    /// <summary>
    /// Czy do danego stylu są referencje?
    /// </summary>
    public bool IsReferenced { get { return RefCount == 0; } }
    /*
        {
          get { return (BaseStyleRef != null) ? BaseStyleRef.Target as Style : null; }
          set
          {
            if (value != null)
            {
              BaseStyleRef = new Reference { Owner = this, Target = value };
            }
            else
              BaseStyleRef = null;
          }
        }

        private Reference _BaseStyleRef;
        /// <summary>
        /// Referencja do stylu bazowego
        /// </summary>
        [DefaultValue (null)]
        [TypeConverter (typeof (ReferenceTypeConverter))]
        public Reference BaseStyleRef
        {
          get { return _BaseStyleRef; }
          set
          {
            _BaseStyleRef = value;
            if (_BaseStyleRef != null)
              _BaseStyleRef.Owner = this;
          }
        }
        */
    #region implementacja interfejsu IReferencedElement
    /*
    bool IReferencedElement.HasItems { get { return false; } }

    IEnumerable<Element> IReferencedElement.GetItems() { return null; }

    string IReferencedElement.RefID { get { return StyleID; } }

    string IReferencedElement.Name { get { return Name; } }

    private ReferenceList incomingReferences;

    /// <summary>
    /// Dodanie referencji do stylu
    /// </summary>
    /// <param name="aRef">referencja przychodząca</param>
    public void AddIncomingReference(Reference aRef)
    {
      if (incomingReferences == null)
        incomingReferences = new ReferenceList();
      incomingReferences.Add(aRef);
    }

    /// <summary>
    /// Usunięcie referencji do stylu
    /// </summary>
    /// <param name="aRef">istniejąca referencja przychodząca</param>
    public void RemoveIncomingReference(Reference aRef)
    {
      if (incomingReferences != null)
        incomingReferences.Remove(aRef);
    }

    /// <summary>
    /// Wyczyszczenie referencji do stylu
    /// </summary>
    public void ClearReferences()
    {
      if (incomingReferences != null)
        incomingReferences.Clear();
      if (BaseStyleRef != null)
      {
        BaseStyleRef.Dispose ();
        BaseStyleRef = null;
      }
    }

    /// <summary>
    /// Czy istnieją referencje do stylu
    /// </summary>
    public bool IsReferenced { get { return incomingReferences != null && incomingReferences.Count > 0; } }

    /// <summary>
    /// Usunięcie referencji przy zniszczeniu stylu
    /// </summary>
    public void Dispose()
    {
      ClearReferences();
    }
    #endregion implementacja interfejsu IReferencedElement

    #region IReferencingElement

    //private ReferenceList outgoingReferences;

    void IReferencingElement.AddOutgoingReference (Reference aReference)
    {
      BaseStyleRef = aReference;
    }

    void IReferencingElement.RemoveOutgoingReference (Reference aReference)
    {
      BaseStyleRef = null;
    }

    bool IReferencingElement.HasReferences
    {
      get 
      {
        return BaseStyleRef!=null;
      }
    }

    IEnumerable<Reference> IReferencingElement.GetOutgoingReferences ()
    {
      List<Reference> result = new List<Reference> ();
      if (BaseStyleRef != null)
        result.Add (BaseStyleRef);
      return result;
    }

    /// <summary>
    /// Czy ma nierozwiązaną referencję do stylu bazowego
    /// </summary>
    public bool HasUnresolvedReferences
    {
      get
      {
        return BaseStyleRef != null && !BaseStyleRef.IsResolved; 
      }
    }

    /// <summary>
    /// Rozwiązanie referencji do stylu bazowego
    /// </summary>
    public void ResolveReferences (IEnumerable<Element> referencedItems)
    {
      if (BaseStyleRef != null)
        BaseStyleRef.TryResolveReference (referencedItems);
      
    }
*/


    #endregion IReferencingElement
  }
}
