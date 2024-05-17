using System.Runtime.Serialization;
using Iml.Foundation;
using Iml.Modeling;

namespace Iml.Model.Requirements
{
  /// <summary>
  /// Klasa reprezentująca komponent systemu.
  /// </summary>
  [Metaclass(Order = "3.2.2")]
  [IsAbstract]
  [KnownType(typeof(HardwareComponent))]
  [KnownType(typeof(SoftwareComponent))]
  public class SystemComponent : ComponentObject
  {
  }
}
