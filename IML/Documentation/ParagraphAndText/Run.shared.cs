using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using System.Windows;
using System.ComponentModel;
using WinDocs = System.Windows.Documents;
using System.Diagnostics;

namespace Iml.Documentation
{

  public partial class Run
  {

    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Run(): base() 
    { 
    }

    /// <summary>
    /// Konstruktor kopiujący
    /// </summary>
    public Run (Run source) : base(source) 
    {
      this.TextFormat = source.TextFormat;
      this.RevisionId = source.RevisionId;
      this.ContentRevisionId = source.ContentRevisionId;
      this.DeleteRevisionId = source.DeleteRevisionId;
      this.LayoutRevisionId = source.LayoutRevisionId;
      this.PropertiesRevisionId = source.PropertiesRevisionId;
    }

    /// <summary>
    /// Czy element jest pusty
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return 
        this.TextFormat==null 
        && this.RevisionId==null
        && this.ContentRevisionId == null
        && this.DeleteRevisionId == null
        && this.LayoutRevisionId == null
        && this.PropertiesRevisionId == null
        && base.IsEmpty();
    }
  
  }
}
