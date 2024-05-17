using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace IML.ModelEdit
{
  /// <summary>
  /// Klasa konwertera wartości tekstowej źródła obrazu na ścieżkę pliku png.
  /// Parametrem konwersji może być ścieżka folderów do katalogu obrazów.
  /// </summary>
  class AssemblyValueConverter: IValueConverter
  {
    /// <summary>
    /// Konwersja wprost
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      if (!(value is Assembly))
        return null;
      string str = (value as Assembly).GetName().Name;
      return str;
    }

    /// <summary>
    /// Konwersja wstecz. Niezaimplementowana
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
