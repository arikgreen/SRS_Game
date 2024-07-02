using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iml.Foundation;
using Iml.Modeling;

namespace Iml.Model.Requirements
{
  /// <summary>
  /// Dodatkowe źródło wymagań
  /// </summary>
  [Metaclass(Order="1.2")]
  public class ExtraSource : Source
  {
    /// <summary>
    /// Informacje o publikacji (tytuł, wydawnictwo, akt prawny, rok etc.)
    /// </summary>
    public string Publication { get; set; }
  }
}
