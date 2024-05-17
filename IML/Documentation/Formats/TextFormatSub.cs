using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Zastępcze ustawienia formatu tekstowego
  /// </summary>
  public partial class TextFormatSub: TextFormat
  {
    /// <summary>
    /// Identyfikator formatu
    /// </summary>
    [DefaultValue(null)]
    public new String Id
    {
      get
      {
        //if (fId != null)
          return fId;
        //return Script.GetHashCode().ToString();
      }
      set
      {
        fId = value;
      }
    }

    /// <summary>
    /// Skrypt Unicode, dla którego stosować dany format
    /// </summary>
    [DefaultValue(null)]
    public string Script { get; set; }
  }
}
