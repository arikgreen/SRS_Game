using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Foundation
{
  /// <summary>
  /// Interfejs zapewniający unikatowość elementów (pod względem skrótów)
  /// </summary>
  public interface IUniqueItemsCollection: IList
  {
    /// <summary>
    /// Funkcja zapewniająca unikatowość skrótu
    /// </summary>
    /// <param name="hashCode"></param>
    /// <returns></returns>
    int MakeHashUnique (int hashCode);
  }
}
