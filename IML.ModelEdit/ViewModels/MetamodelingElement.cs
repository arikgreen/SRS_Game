using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IML.ModelEdit
{
  /// <summary>
  /// Element metamodelowania
  /// </summary>
  public abstract class MetamodelingElement: LocalizedViewModel
  {
    /// <summary>
    /// Czy element wymaga rekompilacji
    /// </summary>
    public virtual bool NeedsCompilation()
    { 
      return false;
    }
  }
}
