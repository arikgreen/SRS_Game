using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.CSharp;
using System.Windows;
using System.Reflection;

namespace IML.ModelEdit
{
  /// <summary>
  /// Generator kodu CS dla metamodelu
  /// </summary>
  public class CodeBuilder
  {

    /// <summary>
    /// Tworzenie biblioteki DLL dla metamodelu. 
    /// Generowany jest kod źródłowy, który jest potem kompilowany.
    /// </summary>
    /// <param name="metamodel">metamodel, z którego kod jest generowany</param>
    public static CompilerResults Compile (Metamodel metamodel)
    {
      CompilerResults results = null;
      try
      {
        results = CodeBuilder.BuildCode(metamodel);
        if (results.Errors.Count == 0)
        {
          string assemblyName = results.CompiledAssembly.FullName;
          int k = assemblyName.IndexOf(',');
          if (k > 0)
            assemblyName = assemblyName.Substring(0, k);
          assemblyName += ".dll";
        }
        else
          MessageWindow.Show(String.Format(MetamodelsStrings.MetamodelCompilationErrors_1, metamodel.Name), results.Errors);
      }
      catch (Exception exc)
      {
        MessageBox.Show(exc.Message);
      }
      return results;
    }

    /// <summary>
    /// Tworzenie biblioteki DLL dla metamodelu. 
    /// Generowany jest kod źródłowy, który jest potem kompilowany.
    /// </summary>
    /// <param name="metamodel">metamodel, z którego kod jest generowany</param>
    public static CompilerResults BuildCode (Metamodel metamodel)
    {
      string csFilename = Path.Combine(Configurator.ModelsAssemblyPath, metamodel.Namespace + ".cs");
      using (TextWriter writer = new StreamWriter(File.Create(csFilename), new UTF8Encoding(false)))
      {
        GenerateCode(metamodel, writer);
        writer.Flush();
      }
      CompilerResults results = CompileFile(metamodel, csFilename);
      string errFilename = Path.Combine(Configurator.ModelsAssemblyPath, metamodel.Namespace + ".errors");
      if (File.Exists(errFilename))
        File.Delete(errFilename);
      if (results.Errors.Count > 0)
      {
        using (TextWriter writer = new StreamWriter(errFilename))
        {
          foreach (CompilerError error in results.Errors)
          {
            writer.WriteLine(error.ToString());
          }
          writer.Flush();
        }
      }
      return results;
    }

    /// <summary>
    /// Generowanie kodu źródłowego dla metamodelu na podane wyjście. Metoda statyczna - tworzy instancję.
    /// </summary>
    /// <param name="metamodel"></param>
    /// <param name="writer"></param>
    public static void GenerateCode (Metamodel metamodel, TextWriter writer)
    {
      MetamodelCodeGenerator instance = new MetamodelCodeGenerator(writer);
      instance.GenerateCode(metamodel);
    }


    public static string FrameworkPath = @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5";
    public static List<String> ReferencedAssemblies = new List<String>
    {
      "System",
      "System.Core",
      "System.Data",
      "System.Data.DataSetExtensions",
      "System.Data.Entity",
      "System.Runtime.Serialization",
      "System.Security",
      "System.Xaml",
      "System.Xml",
      "System.Xml.Linq",
      "WindowsBase",
    };

    /// <summary>
    /// Kompilowanie kodu z pliku
    /// </summary>
    /// <param name="metamodel"></param>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static CompilerResults CompileFile (Metamodel metamodel, string fileName)
    {
      CSharpCodeProvider codeProvider = new CSharpCodeProvider();
      System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
      parameters.GenerateExecutable = false;
      string tmpFileName = Path.Combine(Configurator.ModelsAssemblyPath, metamodel.Namespace + ".dll.tmp");
      string dllFileName = Path.Combine(Configurator.ModelsAssemblyPath, metamodel.Namespace + ".dll");
      parameters.OutputAssembly = Path.Combine(tmpFileName);
      string imlFileName = Path.Combine(Configurator.ModelsAssemblyPath, "Iml.dll");
      parameters.ReferencedAssemblies.Add(imlFileName);
      foreach (string str in ReferencedAssemblies)
        parameters.ReferencedAssemblies.Add(Path.Combine(FrameworkPath, str + ".dll"));
      CompilerResults results = codeProvider.CompileAssemblyFromFile(parameters, fileName);
      //if (results.Errors.Count == 0)
      //{
      //  try
      //  {
      //    File.Replace(tmpFileName, dllFileName, Path.ChangeExtension(dllFileName, ".~dll"));
      //  }
      //  catch {}
      //  results.CompiledAssembly = Assembly.LoadFile(dllFileName);
      //  metamodel.Assembly = results.CompiledAssembly;
      //} 
      return results;
    }
  }
}
