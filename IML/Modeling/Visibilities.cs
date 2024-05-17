using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Modeling
{
  /// <summary>
  /// Zakres widoczności elementu
  /// </summary>
  public enum VisibilityKind
  {
    /// <summary>
    /// Widoczność nieokreślona
    /// </summary>
    Default,

    /// <summary>
    /// Widoczność publiczna
    /// </summary>
    Public,

    /// <summary>
    /// Widoczność prywatna
    /// </summary>
    Private,

    /// <summary>
    /// Widoczność chroniona
    /// </summary>
    Protected,

    /// <summary>
    /// Widoczność w ramach pakietu
    /// </summary>
    Package,
  }

  /// <summary>
  /// Abstrakcyjny element nazwany
  /// </summary>
  public abstract partial class NamedElement
  {
    /// <summary>
    /// Zasięg widoczności nazwy
    /// </summary>
    public VisibilityKind Visibility { get; set; }
  }
}
