using System;
using System.Collections.Generic;

namespace Iml.Model.Requirements
{
  /// <summary>
  /// Model wymagań. Udostępnia metaklasy tego modelu.
  /// </summary>
  public class RequirementsModel: Iml.Modeling.Metamodel
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
          metatypes = Iml.Modeling.Metamodel.GetMetatypes();
        return metatypes;
      }
    }

  }
}
