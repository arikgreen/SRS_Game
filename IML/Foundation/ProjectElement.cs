using System.ComponentModel;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.Diagnostics;
using System.Windows.Markup;
using System.IO;
using System.Xml;
using System.Text;
using System.Runtime.Serialization;
using Iml.Modeling;
using Type = System.Type;

namespace Iml.Foundation
{
  /// <summary>
  /// Abstrakcyjna klasa łącząca elementy semantyczne i elementy prezentacyjne.
  /// Wspólną cechą są stereotyp.
  /// </summary>
  [DataContract]
  public abstract partial class ProjectElement : NamedElement, IReferencingElement
  {
    private string stereotype;
    /// <summary>
    /// Stereotyp uściśla i rozbudowuje definicję metaklasy.
    /// </summary>
    [MetaclassProperty(Order = "0.2")]
    [XmlAttribute("Stereotype")]
    [DefaultValue(null)]
    public string Stereotype 
    {
      get { return stereotype; }
      set
      {
        if (value != stereotype)
        {
          stereotype = value;
          IsModified = true;
        }
      }
    }

    #region implementacja interfejsu IReferencingElement

    private static Dictionary<Type, List<PropertyInfo>> referencingProperties = new Dictionary<Type, List<PropertyInfo>> ();

    /// <summary>
    /// Rozpoznane właściwości referencyjne
    /// </summary>
    protected IList<PropertyInfo> ReferencingProperties 
    {
      get
      {
        List<PropertyInfo> result = null;
        referencingProperties.TryGetValue (GetType (), out result);
        if (result==null)
        {
          result = new List<PropertyInfo> ();
          referencingProperties.Add (GetType (), result);
          PropertyInfo[] props = GetType ().GetProperties ();
          foreach (PropertyInfo prop in props)
          {
            if (prop.PropertyType == typeof (Reference) || prop.PropertyType.IsSubclassOf (typeof (Reference)))
            {
              result.Add (prop);
            }
          }
        }
        return result;
      }
    }


    void IReferencingElement.AddOutgoingReference (Reference aReference)
    {
      //throw new System.NotImplementedException ();
    }

    void IReferencingElement.RemoveOutgoingReference (Reference aReference)
    {
      //throw new System.NotImplementedException ();
    }

    void IReferencingElement.ClearReferences ()
    {
      if (ReferencingProperties != null)
      {
        foreach (PropertyInfo aInfo in ReferencingProperties)
        {
          MethodInfo getMethod = aInfo.GetGetMethod ();
          Reference aReference = getMethod.Invoke (this, new object[0]) as Reference;
          if (aReference != null)
            aReference.Dispose ();
          MethodInfo setMethod = aInfo.GetSetMethod ();
          setMethod.Invoke (this, new object[] { null });
        }
      }
    }

    bool IReferencingElement.HasReferences
    {
      get { return ReferencingProperties != null && ReferencingProperties.Count>0; }
    }

    System.Collections.Generic.IEnumerable<Reference> IReferencingElement.GetOutgoingReferences ()
    {
      List<Reference> result = new List<Reference> ();
      if (ReferencingProperties != null)
      {
        foreach (PropertyInfo aInfo in ReferencingProperties)
        {
          MethodInfo getMethod = aInfo.GetGetMethod ();
          Reference aReference = getMethod.Invoke (this, new object[0]) as Reference;
          if (aReference != null)
            result.Add (aReference);
        }
      }
      return result;
    }

    bool IReferencingElement.HasUnresolvedReferences
    {
      get 
      {
        foreach (Reference aReference in (this as IReferencingElement).GetOutgoingReferences ())
          if (!aReference.IsResolved)
            return true;
        return false;
      }
    }

    void IReferencingElement.ResolveReferences (System.Collections.Generic.IEnumerable<Element> referencedItems)
    {

      foreach (Reference aReference in (this as IReferencingElement).GetOutgoingReferences ())
        if (!aReference.IsResolved)
          aReference.TryResolveReference (referencedItems);
      foreach (IReferencingElement item in GetReferencingItems())
        item.ResolveReferences (referencedItems);
    }

    /// <summary>
    /// Podaje listę elementów do rozwiązywania referencji
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerable<IReferencingElement> GetReferencingItems ()
    {
      return new IReferencingElement[0];
    }

    /// <summary>
    /// Zwolnienie referencji
    /// </summary>
    public virtual void Dispose ()
    {
      (this as IReferencingElement).ClearReferences ();
    }

    #endregion implementacja interfejsu IReferencingElement
  }
}
