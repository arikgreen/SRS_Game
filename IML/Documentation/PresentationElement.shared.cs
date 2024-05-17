using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Iml.Foundation;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.ComponentModel.DataAnnotations;

namespace Iml.Documentation
{
	public partial class PresentationElement
	{


    /// <summary>
    /// Referencja do elementu semantycznego będącego przedmiotem prezentacji.
    /// Sama referencja nie jest serializowana, lecz ID przedmiotu prezentacji.
    /// </summary>
    [XmlIgnore]
    [IgnoreDataMember]
    #if !SILVERLIGHT
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    #endif
    public virtual Reference SubjectRef { get; set; }

	}
}
