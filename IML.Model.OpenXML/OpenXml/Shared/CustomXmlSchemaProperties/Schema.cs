using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.CustomXmlSchemaReferences
{
  [Tag("schema")]
  [Alias("Schema")]
  public class Schema
  {
    [Tag("string")]
    String Uri{ get; set; }

    [Tag("string")]
    String ManifestLocation{ get; set; }

    [Tag("string")]
    String SchemaLocation{ get; set; }

    [Token]
    [Tag("token")]
    String SchemaLanguage{ get; set; }

  }
}
