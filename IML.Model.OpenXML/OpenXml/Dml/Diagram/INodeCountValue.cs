using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("NodeCount")]
  public interface INodeCountValue
  {
    Int32 AsInt32{ get; set; }

  }
}
