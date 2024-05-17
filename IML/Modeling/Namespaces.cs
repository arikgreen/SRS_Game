using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Modeling
{
  using Iml.Foundation;

  /// <summary>
  /// Interfejs przestrzeni nazw. 
  /// </summary>
  /// <remarks>
  /// Tu możliwości nie są zdefiniowane. Przestrzeń nazw jest też zdefiniowana jako klasa, 
  /// ale interfejs jest zdefiniowany osobno, bo w C# nie ma dziedziczenia wielokrotnego.
  /// </remarks>
  public partial interface INamespace
  {
  }

  /// <summary>
  /// Abstrakcyjna klasa nazwanych elementów. Powiązana z przestrzenią nazw.
  /// </summary>
  [CanBelongTo(typeof(INamespace), Semantics="namespace", BackwardSemantics="ownedMember",
    Subsets="owner",
    Required=true, Readonly=true, Union=true)]
  public abstract partial class NamedElement : ModelElement
  {
    /// <summary>
    /// Przestrzeń nazw, do której należy dany element.
    /// </summary>
    public Namespace Namespace
    {
      get { return Owner as Namespace; }
    }

    /// <summary>
    /// Nazwa kwalifikowana przez przestrzeń nazw
    /// </summary>
    public string QualifiedName 
    {
      get
      {
        if (Namespace != null)
          return Namespace.QualifiedName + "." + Name;
        else
          return Name;
      }
    }
  }

  /// <summary>
  /// Abstrakcyjna klasa przestrzeni nazw. Zapewnia unikatowość nazw elementów nazwanych.
  /// </summary>
  [CanContain(typeof(NamedElement), Semantics = "ownedMember", BackwardSemantics = "namespace", 
    Readonly=true, Union=true, 
    Subsets="ownerElement, member")]
  [CanReferTo(typeof(NamedElement), Semantics = "member",
    Readonly = true, Union = true)]
  public abstract class Namespace : NamedElement, INamespace
  {
  }

}
