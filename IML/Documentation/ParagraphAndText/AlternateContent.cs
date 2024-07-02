using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace Iml.Documentation
{
  /// <summary>
  /// Element, który może zawierać w sobie zawartość alternatywną
  /// (kilka alternatywnych elementów)
  /// </summary>
  [ContentProperty("Choices")]
  public partial class AlternateContent: DocumentContent
  {
    /// <summary>
    /// Ustalony kod skrótu 
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      int hash = "AltErnatEContEnt".GetHashCode();
      if (Collection != null)
        hash = Collection.MakeHashUnique(hash);
      return hash;
    }

    /// <summary>
    /// Lista alternatyw
    /// </summary>
    public AlternateChoices Choices 
    { 
      get
      {
        if (fChoices == null)
          fChoices = new AlternateChoices(this);
        return fChoices;
      }
      set { fChoices = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące listę alternatyw
    /// </summary>
    protected AlternateChoices fChoices;

    /// <summary>
    /// Czy alternatywy mają być serializowane
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeContent()
    {
      return fChoices != null && !fChoices.IsEmpty();
    }

    /// <summary>
    /// Czy element jest pusty?
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return !ShouldSerializeContent();
    }
  }
}
