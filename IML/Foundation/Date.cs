using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Foundation
{
  /// <summary>
  /// Obiektowy typ daty
  /// </summary>
  public partial class Date
  {
    /// <summary>
    /// Przechowywana wartość
    /// </summary>
    public DateTime Value { get; set; }

    /// <summary>
    /// Konwersja z daty i czasu
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator Date(DateTime value)
    {
      return new Date { Value = value };
    }

    /// <summary>
    /// Konwersja na datę i czas
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator DateTime? (Date value)
    {
      if (value!=null)
        return value.Value;
      return null;
    }

    /// <summary>
    /// Konwersja na datę i czas
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator DateTime(Date value)
    {
        if (value != null)
            return value.Value;
        return default(DateTime);       
    }
  }
}
