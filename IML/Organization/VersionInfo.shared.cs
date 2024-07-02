using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Iml.Organization
{
  public partial class VersionInfo
  {
    /// <summary>
    /// Macierzysty dokument
    /// </summary>
    [Editable(false)]
    public DocumentInfo DocumentInfo { get { return Owner as DocumentInfo; } }

  }
}