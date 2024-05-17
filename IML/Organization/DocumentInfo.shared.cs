using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Iml.Organization
{
  public partial class DocumentInfo
  {
    /// <summary>
    /// Macierzysty projekt
    /// </summary>
    [Editable(false)]
    [UIHint ("HideField")]
    public ProjectInfo Project { get { return Owner as ProjectInfo; } }

    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return Name;
    }

  }
}