using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iml.Modeling;
using Type = System.Type;

namespace Iml.Model.UseCases
{
  /// <summary>
  /// Model przypadków użycia. Udostępnia metaklasy tego modelu.
  /// </summary>
  public class UseCasesModel : Metamodel
  {

    private static List<Type> metatypes;
    /// <summary>
    /// Lista metaklas (klas potomnych z elementu semantycznego)
    /// należących do tego modelu.
    /// </summary>
    public new static List<Type> Metatypes
    {
      get
      {
        if (metatypes == null)
          metatypes = Metamodel.GetMetatypes();
        return metatypes;
      }
    }
  }
}

