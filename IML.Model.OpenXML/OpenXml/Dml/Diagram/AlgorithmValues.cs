using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("AlgorithmType")]
  public enum AlgorithmValues
  {
    [EnumString("composite")]
    Composite = 0,
    [EnumString("conn")]
    Conn,
    [EnumString("cycle")]
    Cycle = 2,
    [EnumString("hierChild")]
    HierChild,
    [EnumString("hierRoot")]
    HierRoot,
    [EnumString("pyra")]
    Pyra,
    [EnumString("lin")]
    Lin,
    [EnumString("sp")]
    Sp,
    [EnumString("tx")]
    Tx,
    [EnumString("snake")]
    Snake = 9,
  }
}
