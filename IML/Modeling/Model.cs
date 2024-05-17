using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iml.Foundation;

namespace Iml.Modeling
{
  /// <summary>
  /// Klasa modelu. Określa listę elementów semantycznych.
  /// Lista metamodeli określa jakie elementy semantyczne mogą się pojawić w tym modelu.
  /// </summary>
  public class Model: Item
  {
    /// <summary>
    /// Lista metamodeli - określa jakie elementy semantyczne mogą się pojawić w tym modelu.
    /// </summary>
    public Metamodels Metamodels
    {
      get
      {
        if (fMetamodels == null)
          fMetamodels = new Metamodels(this);
        return fMetamodels;
      }
      set { fMetamodels = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące listę elementów semantycznych
    /// </summary>
    protected Metamodels fMetamodels;

    /// <summary>
    /// Lista elementów semantycznych należących do tego modelu
    /// </summary>
    public SemanticElements Elements
    {
      get
      {
        if (fElements == null)
          fElements = new SemanticElements(this);
        return fElements;
      }
      set { fElements = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące listę elementów semantycznych
    /// </summary>
    protected SemanticElements fElements;
  }
}
