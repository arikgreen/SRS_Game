using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Iml.Foundation;

namespace Iml.Documentation
{

  /// <summary>
  /// Lista obrazów (dla rysunków i tabel) w dokumencie
  /// </summary>
  public class ImageList: ItemIndex<Image>
  {

    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public ImageList () { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public ImageList (object owner) : base(owner) { }

    /// <summary>
    /// Dodanie obrazu - nazwa pliku jest kluczem
    /// </summary>
    /// <param name="aFile">obraz z dokumentu</param>
    public override void Add(Image aFile)
    {
      base.Add(aFile.FileName, aFile);
    }

    /// <summary>
    /// Podanie listy nazw plików
    /// </summary>
    public string[] GetFilenames ()
    {
      List<string> result = new List<string>();
      foreach (Image file in this)
      {
        result.Add(Path.Combine(file.FilePath,file.FileName));
      }
      return result.ToArray();
    }
  }

}
