using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa oznaczająca pole w Wordzie. Składa się z pola instrukcji i pola tekstowego.
  /// </summary>
  [ContentProperty("Content")]
  public partial class SimpleFieldRun: DocumentContent
  {
    /// <summary>
    /// Czy pole jest zablokowane
    /// </summary>
    public bool? IsLocked { get; set; }

    /// <summary>
    /// Czy pole wymaga przeliczenia
    /// </summary>
    public bool? IsDirty { get; set; }

    /// <summary>
    /// Instrukcja dla pola
    /// </summary>
    //[DefaultValue(null)]
    public FieldInstruction Instruction
    {
      get { return fInstruction; }
      set { fInstruction = value; }
    }

    /// <summary>
    /// Pole przechowujące instrukcję
    /// </summary>
    protected FieldInstruction fInstruction;

    /// <summary>
    /// Czy instrukcja ma być serializowana
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeInstruction()
    {
      return false;// fInstruction != null && fText == null;
    }

    /// <summary>
    /// Tekst instrukcji
    /// </summary>
    [DefaultValue(null)]
    public string Text 
    { 
      get; 
      set; 
    }
    /// <summary>
    /// Pole przechowujące tekst instrukcji
    /// </summary>
    protected string fText;

    /// <summary>
    /// Zawartość pola
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ContentList Content
    {
      get
      {
        if (fContent == null)
          fContent = new ContentList(this);
        return fContent;
      }
      //set { fContent = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące zawartość
    /// </summary>
    protected ContentList fContent;

    /// <summary>
    /// Czy zawartość ma być serializowana
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeContent()
    {
      return fContent != null && !fContent.IsEmpty();
    }

    /// <summary>
    /// Pole nie może być puste. Musi być włączane do akapitu
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return Instruction == null
          && Text == null;
    }

    /// <summary>
    /// Kod skrótu na podstawie zawartości
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      if (fHashCode == null)
      {
        int hash = 0;
        if (Content != null)
          hash += Content.GetHash();
        if (RevisionId != null)
        {
          int val;
          if (int.TryParse(RevisionId, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val))
            hash += val;
        }
        if (Collection != null)
          hash = Collection.MakeHashUnique(hash);
        fHashCode = hash;
      }
      return (int)fHashCode;
    }
    /// <summary>
    /// Pole przechowujące kod skrótu
    /// </summary>
    protected int? fHashCode = null;
  }
}
