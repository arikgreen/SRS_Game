using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Organization
{
  /// <summary>
  /// Lista wersji dla dokumentu
  /// </summary>
  public partial class VersionList: ItemList<VersionInfo>
  {
    /// <summary>
    /// Konstruktor właściwy
    /// </summary>
    /// <param name="owner"></param>
    public VersionList(Object owner) : base(owner) { }
  }
}
