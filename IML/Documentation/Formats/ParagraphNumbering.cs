using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
  /// <summary>
  /// Odwołanie się do sposobu numerowania w akapicie
  /// </summary>
  public partial class ParagraphNumbering : Format
  {

    /// <summary>
    /// Zwraca typ formatu
    /// </summary>
    public override FormatType Type
    {
      get { return FormatType.List; }
    }


    /// <summary> numer poziomu (od 1)</summary>
    [DefaultValue(null)]
    public int? Level { get; set; }

    /// <summary> Identyfikator numerowania konkretnego</summary>
    [DefaultValue(null)]
    public int? NumId { get; set; }

    /// <summary> Numerowanie konkretne - z listy numerowań</summary>
    [DefaultValue(null)]
    public NumberingInstance ConcreteNum { get; set; }
  }

}
