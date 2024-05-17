using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca instrukcję pola tekstowego lub pola blokowego
  /// </summary>
  public partial class FieldInstruction: Item
  {
    /// <summary>
    /// Komenda
    /// </summary>
    [DefaultValue(null)]
    public string Command { get; set; }

    /// <summary>
    /// Lista parametrów
    /// </summary>
    public FieldParameters Parameters 
    { 
      get 
      {
        if (fParameters == null)
          fParameters = new FieldParameters(this);
        return fParameters; 
      }
      set
      { fParameters = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące listę parametrów
    /// </summary>
    protected FieldParameters fParameters;

    /// <summary>
    /// Czy parametry mają być serializowane
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeParameters()
    {
      return fParameters != null && !fParameters.IsEmpty();
    }

    /// <summary>
    /// Lista opcji
    /// </summary>
    public NameValueList Options
    {
      get
      {
        if (fOptions == null)
          fOptions = new NameValueList(this);
        return fOptions;
      }
      set
      { fOptions = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące listę opcji
    /// </summary>
    protected NameValueList fOptions;

    /// <summary>
    /// Czy opcje mają być serializowane
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeOptions ()
    {
      return fOptions != null && !fOptions.IsEmpty();
    }
  }
}
