using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Modeling
{
  using Iml.Foundation;

  /// <summary>
  /// Abstrakcyjna klasa klasyfikatora dla elementów semantycznych.
  /// Charakteryzowana przez zbiór abstrakcyjnych cech.
  /// </summary>
  [CanReferTo(typeof(Feature),Semantics="feature", BackwardSemantics="featuringClassifier",
    Subsets="member", Union=true)]
  public abstract partial class Classifier : Namespace
  {
  }

  /// <summary>
  /// Abstrakcyjna klasa reprezentująca cechę klasyfikatora
  /// </summary>
  [CanReferTo(typeof(Classifier),Semantics="featuringClassifier", BackwardSemantics="feature",
    Union=true)]
  public abstract class Feature: NamedElement
  {
  }
}
