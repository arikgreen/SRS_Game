using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iml.Modeling;

namespace Iml.Model.Requirements
{
  /// <summary>
  /// Rodzaje źródeł wymagań
  /// </summary>
  [Metatype(Order = "0.2")]
  public enum StakeholderKind
  {

    /// <value>
    /// nieznany typ źródła
    /// </value>
    Undefined = 0,

    /// <value>
    /// źródło osobowe
    /// </value>
    Personal = 1,

    /// <value>
    /// źródło organizacyjne
    /// </value>
    Organizational = 2,

    /// <value>
    /// źródło prawne
    /// </value>
    Group = 3
  }
}
