using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Iml.Foundation;

namespace Iml.Model.UseCases
{
  /// <summary>
  /// Abstrakcyjny element modelu przypadków użyca
  /// </summary>
  [KnownType(typeof(Actor))]
  [KnownType(typeof(UseCase))]
  public abstract class UseCasesElement: SemanticElement
  {
  }
}
