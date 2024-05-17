using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Organization
{
  /// <summary>
  /// Lista projektów
  /// </summary>
  public partial class ProjectList: ItemList<ProjectInfo>
  {
    /// <summary>
    /// Konstruktor właściwy
    /// </summary>
    /// <param name="owner"></param>
    public ProjectList(Object owner) : base(owner) { }
  }
}
