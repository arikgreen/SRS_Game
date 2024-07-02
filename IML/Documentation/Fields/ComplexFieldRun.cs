using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca pole złożone, które może zawierać listę instrukcji 
  /// oraz wyniki zarówno w postaci fragmentów tekstu, jak i akapitów
  /// </summary>
  public partial class ComplexFieldRun: Run
  {

    /// <summary>
    /// Elementy definicji zawarte w OpenXML między "begin" i "separate"
    /// </summary>
    public ContentList Definitions
    {
      get
      {
        if (fDefinitions == null)
          fDefinitions = new ContentList(this);
        return fDefinitions;
      }
      set { fDefinitions = value; if (value != null)  value.SetOwner(this); }
    }

    /// <summary>
    /// Pole przechowujące listę definicji
    /// </summary>
    protected ContentList fDefinitions;

    /// <summary>
    /// Czy elementy definiujące mają być serializowane
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeDefinitions()
    {
      return fDefinitions != null && !fDefinitions.IsEmpty();
    }

    /// <summary>
    /// Lista instrukcji
    /// </summary>
    public FieldInstructions Instructions 
    { 
      get
      {
        if (fInstructions == null)
          fInstructions = new FieldInstructions(this);
        return fInstructions;
      }
      set { fInstructions = value; if (value != null)  value.SetOwner(this); }
    }

    /// <summary>
    /// Pole przechowujące listę instrukcji
    /// </summary>
    protected FieldInstructions fInstructions;

    /// <summary>
    /// Czy trzeba serializować instrukcje
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeInstructions()
    {
      return false;// fInstructions != null && !fInstructions.IsEmpty();
    }

    /// <summary>
    /// Lista wyników. Mogą to być elementy typu <see cref="Run"/> albo <see cref="Block"/>
    /// </summary>
    public FieldResults Results
    {
      get
      {
        if (fResults == null)
          fResults = new FieldResults(this);
        return fResults;
      }
      set { fResults = value; if (value != null)  value.SetOwner(this); }
    }

    /// <summary>
    /// Pole przechowujące listę wyników
    /// </summary>
    protected FieldResults fResults { get; set; }

    /// <summary>
    /// Czy trzeba serializować listę wyników
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeResults ()
    {
      return fResults != null && !fResults.IsEmpty();
    }

    /// <summary>
    /// Format znakowy zakończenia kontrolki
    /// </summary>
    [DefaultValue(null)]
    public TextFormat EndCharTextFormat { get; set; }
  }
}
