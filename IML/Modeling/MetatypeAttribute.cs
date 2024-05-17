using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib.OrdNumbers;

namespace Iml.Modeling
{
  /// <summary>
  /// Atrybut wskazujący na to, że typ należy do metamodelu
  /// </summary>
  public class MetatypeAttribute : Attribute
  {
    /// <summary>
    /// Kolejność na liście (liczba porządkowa)
    /// </summary>
    public string Order { get; set; }
  }
}
