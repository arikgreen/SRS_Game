using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
  /// <summary>
  /// Referencja do stylu
  /// </summary>
  public partial class StyleRef
  {
    /// <summary>
    /// Identyfikator stylu
    /// </summary>
    public string StyleId { get; set; }
    /// <summary>
    /// Styl przywoływany
    /// </summary>
    public Style Target { get; set; }

    /// <summary>
    /// Element właścicielski referencji
    /// </summary>
    public object Owner { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public bool IsResolved 
    { 
      get
      { return Target != null; }
    }
  }
}
