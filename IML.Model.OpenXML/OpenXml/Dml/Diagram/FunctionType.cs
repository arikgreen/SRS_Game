using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml.Dml.Diagram
{
  [Tag("when")]
  [Alias("When")]
  public class FunctionType
  {
    [Tag("string")]
    String Name{ get; set; }

    [Tag("functionType")]
    FunctionValues Func{ get; set; }

    [Tag("functionArgument")]
    FunctionArgumentValue Arg{ get; set; }

    [Tag("functionOperator")]
    FunctionOperatorValues Op{ get; set; }

    [Tag("functionValue")]
    FunctionValueValue Val{ get; set; }

  }
}
