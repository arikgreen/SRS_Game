using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Runtime.Serialization;
using WinDocs = System.Windows.Documents;
using System.ComponentModel;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Abstrakcyjna klasa stanowiąca podstawę dla elementów umieszczanych wewnątrz tekstu sformatowanego
  /// </summary>
  [KnownType(typeof(Run))]
  //[KnownType(typeof(Span))]
  public abstract partial class Inline: DocumentContent 
  {

    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Inline () : base () { }

    /// <summary>
    /// Konstruktor kopiujący
    /// </summary>
    public Inline (Inline source) : base(source) 
    {
      //this.Id = source.Id;
    }


    ///// <summary>
    ///// Identyfikator (unikatowy tylko w ramach dokumentu)
    ///// </summary>
    //[DefaultValue(null)]
    //public virtual string Id { get; set; }

    /// <summary>
    /// Czy element jest pusty
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty()
    {
      return true;
    }
  }
}
