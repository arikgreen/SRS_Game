using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("docPartGallery")]
  [Alias("DocPartGallery")]
  public class DocPartGallery
  {
    [Tag("docPartGallery")]
    DocPartGalleryValues Val{ get; set; }

  }
}
