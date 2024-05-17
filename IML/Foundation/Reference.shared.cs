using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Iml.Foundation
{
  public partial class Reference
  {
/*
    /// <summary>
    /// Pole przechowujące element docelowy
    /// </summary>
    protected Element fTarget;
    /// <summary>
    /// Element docelowy referencji - musi implementować interfejs <see cref="IReferencedElement"/>
    /// </summary>
    #if !SILVERLIGHT
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    #endif
    public Element Target
    {
      get { return fTarget; }
      set
      {
        if (value != fTarget)
        {
          if (fTarget is IReferencedElement)
            (fTarget as IReferencedElement).RemoveIncomingReference (this);
          fTarget = value;
          if (fTarget is IReferencedElement)
            (fTarget as IReferencedElement).AddIncomingReference (this);
        }
      }
    }
*/
    /// <summary>
    /// Napis potrzebny do śledzenia referencji
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      string result = "Reference ";
      if (Semantics != null)
        result = "«" + Semantics + "» " + result;
      if (Target != null)
        result += "to "+Target.ToString ();
      else if (TargetID != Guid.Empty)
        result += "to {" + TargetID + "}";
      else if (TargetRefID != null)
        result += "to [" + TargetRefID +"]";
      else if (TargetName != null)
        result += "\"" + TargetName + "\"";
      return result;
    }
  }
}
