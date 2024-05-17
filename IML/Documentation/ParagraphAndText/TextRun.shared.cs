using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Globalization;


namespace Iml.Documentation
{
  public partial class TextRun
  {
    /// <summary>
    /// konstruktor kopiujący
    /// </summary>
    public TextRun (Run source): base(source)
    {
      if (source is TextRun)
      {
        this.Mode = ((TextRun)source).Mode;
        this.fContent = ((TextRun)source).fContent;
      }
    }

    /// <summary>
    /// Konstruktor tworzący element na podstawie podanego tekstu
    /// </summary>
    /// <param name="text"></param>
    public TextRun(string text): base() 
    {
      Content.Add(new Text(text)); 
    }

    /// <summary>
    /// tryb kodowania
    /// </summary>
    [IgnoreDataMember]
    [XmlIgnore]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TextMode Mode = 0;

    /// <summary>
    /// tekst zakodowany
    /// </summary>
    [IgnoreDataMember]
    [XmlIgnore]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public String EncodedText;

    /// <summary>
    /// Czy fragment tekstowy jest pusty
    /// </summary>
    public override bool IsEmpty()
    {
      return
        !ShouldSerializeContent()
        && base.IsEmpty();
    }

    /// <summary>
    /// Kod skrótu na podstawie zawartości
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      if (fHashCode == null)
      {
        int hash = "TeXtRun".GetHashCode();
        if (Content != null)
          hash += Content.GetHash();
        if (RevisionId!=null)
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
