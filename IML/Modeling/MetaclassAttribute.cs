using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib.OrdNumbers;

namespace Iml.Modeling
{
  /// <summary>
  /// Atrybut wskazujący na to, że klasa należy do metamodelu
  /// </summary>
  public class MetaclassAttribute: Attribute
  {
    /// <summary>
    /// Kolejność na liście (liczba porządkowa)
    /// </summary>
    public string Order { get; set; }
  }
}
