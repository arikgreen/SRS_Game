using System.Xml.Serialization;
using Iml.Foundation;
using System.Runtime.Serialization;
using System.ComponentModel;
using System;
using Iml.Modeling;

namespace Iml.Model.Requirements
{
  /// <summary>
  /// Klasa reprezentująca udziałowca (źródło wymagań)
  /// </summary>
  [Metaclass(Order="1")]
  [IsAbstract]
  [CanReferTo(typeof(SemanticElement), Semantics = "trace", Allowed = false, Required = false)]
  public class Source : RequirementsElement
  {
  }
}
