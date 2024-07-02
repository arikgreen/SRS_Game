using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Modeling
{
  using Iml.Foundation;

  /// <summary>
  /// Interfejs dla elementu typowanego. 
  /// </summary>
  /// <remarks>
  /// Tu możliwości nie są zdefiniowane. Przestrzeń nazw jest też zdefiniowana jako klasa, 
  /// ale interfejs jest zdefiniowany osobno, bo w C# nie ma dziedziczenia wielokrotnego.
  /// </remarks>
  [CanReferTo(typeof(Type), Semantics = "type", Required = true, Multiplicity = "0..1")]
  public interface ITypedElement
  {
  }

  /// <summary>
  /// Abstrakcyjna klasa nazwanych elementów. Powiązana z przestrzenią nazw.
  /// </summary>
  public abstract class TypedElement : NamedElement, ITypedElement
  {
  }

  ///// <summary>
  ///// Abstrakcyjna klasa typu
  ///// </summary>
  //public abstract class Type : NamedElement
  //{
  //}

}
