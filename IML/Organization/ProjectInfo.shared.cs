using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Iml.Organization
{
  public partial class ProjectInfo
  {
    /// <summary>
    /// Macierzyste rozwiązanie
    /// </summary>
    [Editable(false)]
    public SolutionInfo Solution { get { return Owner as SolutionInfo; } }

    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      return Name;
    }
   }
}