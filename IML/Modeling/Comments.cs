using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Modeling
{
  using Iml.Foundation;

  /// <summary>
  /// Komentarz, który może być przypisywany do elementu semantycznego
  /// </summary>
  [CanBelongTo(typeof(ModelElement), Semantics = "annotatedElement", BackwardSemantics = "ownedComment", Subsets = "ownedElement")]
  public partial class Comment : ModelElement
  {
  }


  //[CanContain(typeof(Comment), Semantics="ownedComment", BackwardSemantics="annotatedElement")]
  public abstract partial class ModelElement : SemanticElement
  {
    /// <summary>
    /// Komentarze przypisane do elementu modelowego
    /// </summary>
    //[Content]//(Semantics = "ownedComment", BackwardSemantics = "annotatedElement")]
    public ElementList<Comment> Comments 
    { 
      get
      {
        if (fComments == null)
          fComments = new ElementList<Comment>(this);
        return fComments;
      }
    }
    private ElementList<Comment> fComments;
  }

}
