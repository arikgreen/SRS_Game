using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Markup;
using System;
using System.Runtime.Serialization;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle ("IML")]
[assembly: AssemblyDescription ("")]
[assembly: AssemblyConfiguration ("")]
[assembly: AssemblyCompany ("QHTA")]
[assembly: AssemblyProduct ("IML")]
[assembly: AssemblyCopyright ("Copyright © Jarosław Kuchta 2012")]
[assembly: AssemblyTrademark ("")]
[assembly: AssemblyCulture ("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible (false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid ("e98c52ee-0f83-4417-87fc-2758de56771a")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion ("1.0.0.0")]
[assembly: AssemblyFileVersion ("1.0.0.0")]

[assembly: XmlnsDefinition ("http://schemas.iml.org", "Iml.Foundation")]
[assembly: XmlnsDefinition("http://schemas.iml.org", "Iml.Documentation")]
[assembly: XmlnsDefinition("http://schemas.iml.org", "Iml.Modeling")]
[assembly: XmlnsDefinition("http://schemas.iml.org", "Iml.Documentation.Drawings")]
[assembly: CLSCompliant(true)]
[assembly: ContractNamespace("http://schemas.iml.org", ClrNamespace = "Iml.Foundation")]
[assembly: ContractNamespace("http://schemas.iml.org", ClrNamespace = "Iml.Documentation")]
[assembly: ContractNamespace("http://schemas.iml.org", ClrNamespace = "Iml.Documentation.Drawings")]
