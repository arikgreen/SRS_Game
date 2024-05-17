using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Iml.Foundation
{
  public partial class NamedElement
  {
    /// <summary>
    /// Nazwa przyjazna. Tu tożsama z nazwą zwykłą.
    /// </summary>
    [IgnoreDataMember]
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    public virtual string DisplayName
    {
      get { return Name; }
      set { Name = value; }
    }

  }
}
