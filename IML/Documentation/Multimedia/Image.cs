using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Obraz wynikowy z dokumentu (dla rysunków i tabel). 
  /// Składa się z nazwy pliku i zawartości w postaci tablicy bajtów.
  /// </summary>
  [ContentProperty("Content")]
  public partial class Image: Item
  {
    /// <summary>
    /// Identyfikator obrazu w dokumencie
    /// </summary>
    public override string Id { get; set; }

    /// <summary> Typ mime obrazu</summary>
    [DefaultValue(null)]
    public string MimeType { get; set; }

    /// <summary> Ścieżka obrazu</summary>
    [DefaultValue(null)]
    public string FilePath { get; set; }

    /// <summary> Nazwa pliku obrazu</summary>
    [DefaultValue(null)]
    public string FileName { get; set; }

    /// <summary> Zawartość obrazu</summary>
    //[DefaultValue(null)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public byte[] Bytes { get; set; }

    /// <summary>
    /// Zawartośc obrazu w postaci łańcucha Base64
    /// </summary>
    public string Content 
    {
      get
      {
        return "\n"+Convert.ToBase64String(Bytes, Base64FormattingOptions.InsertLineBreaks)+"\n";
      }
      set
      {
        if (value!=null)
          Bytes = Convert.FromBase64String(value.Replace("\n",""));
      }
    }
    /// <summary> domyślny konstruktor - umożliwia późniejsze podanie nazwy pliku i zawartości</summary>
    public Image() { }

    ///// <summary> konstruktor specyficzny - umożliwia bezpośrednie podanie nazwy pliku i zawartości</summary>
    ///// <param name="mimetype">typ mime, np. "image/png"</param>
    ///// <param name="filepath">ścieżka pliku</param>
    ///// <param name="filename">nazwa pliku</param>
    ///// <param name="content">zawartość w postaci binarnej</param>
    //public Image(string mimetype, string filepath, string filename, byte[] content)
    //{
    //  MimeType = mimetype;
    //  FilePath = filepath;
    //  FileName = filename;
    //  Bytes = content;
    //}

    /// <summary> NieprzetestowanePełna nazwa pliku - tworzona ze ścieżki i nazwy właściwej</summary>
    public string FullFileName
    {
      get { return Path.Combine(FilePath, FileName); }
    }
  }
}
