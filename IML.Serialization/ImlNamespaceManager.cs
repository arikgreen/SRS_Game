using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Reflection;
using System.Windows.Markup;
using System.Diagnostics;

namespace Iml.Serialization
{
  public class ImlNamespaceManager: XmlNamespaceMappingCollection 
  {

    public HashSet<ClrNamespaceMapping> ClrMapping = new HashSet<ClrNamespaceMapping>(new ClrNamespaceComparer());


    public void AddNamespace(string prefix, string uriString, Assembly assembly)
    {
      base.AddNamespace(prefix,uriString);
      ClrMapping.Add(new ClrNamespaceMapping { Uri = new Uri(uriString), Assembly=assembly });
    }

    public void AddNamespace(string prefix, string uriString, Type aType)
    {
      this.AddNamespace(prefix, uriString, aType.Assembly);
    }

    public void AddNamespace(Assembly rootAssembly, string prefix, string uriString)
    {
      AddNamespace(rootAssembly);
      foreach (AssemblyName aName in rootAssembly.GetReferencedAssemblies())
      {
        Assembly assembly = Assembly.Load(aName);
        AddNamespace(assembly, false);
      }
      if (prefix == null)
        prefix = "";
      AddNamespace(prefix, uriString);
    }

    public void AddNamespace(Assembly assembly, bool autoPrefix = true)
    {
      var ass = (from item in ClrMapping where item.Assembly == assembly select item).FirstOrDefault();
      if (ass != null)
        return;
      object[] attributes = assembly.GetCustomAttributes(typeof(XmlnsDefinitionAttribute), true);
      bool first = autoPrefix;
      foreach (object item in attributes)
      {
        if (item is XmlnsDefinitionAttribute)
        {
          string xmlns = ((XmlnsDefinitionAttribute)item).XmlNamespace;
          AssemblyName aName = new AssemblyName(assembly.FullName);
          if (first)
          {
            if (LookupPrefix(xmlns) == null)
              base.AddNamespace(UniquePrefix(aName), xmlns);
            first = false;
          }
          ClrNamespaceMapping aMapping = new ClrNamespaceMapping { Uri = new Uri(xmlns), Assembly = assembly };
          if (!ClrMapping.Contains(aMapping))
            ClrMapping.Add(aMapping);
        }
      }
    }

    public string UniquePrefix(AssemblyName aName)
    {
      string s = aName.ToString();
      string[] ss = s.Split(',');
      s = ss[0];
      StringBuilder sb = new StringBuilder();
      foreach (char ch in s)
        if (Char.IsUpper(ch))
          sb.Append(Char.ToLower(ch));
      int k = s.Length - 1;
      int m = sb.Length;
      string result = sb.ToString();
      while (this.LookupNamespace(result)!=null)
      {
        sb.Insert(m, s[k]);
        k--;
        if (k == 0) break;
        result = sb.ToString();
      }
      return result;
    }

    public string LookupPrefix(Assembly assembly)
    {
      ClrNamespaceMapping mapping =
      (from item in this.ClrMapping 
        where item.Assembly == assembly select item).FirstOrDefault();
      if (mapping != null)
      {
        string uri = mapping.Uri.OriginalString;
        string result = this.LookupPrefix(uri);
        return result;
      }
      return null;
    }

    public Assembly[] LookupAssemblies(string prefix)
    {
      string uriString = LookupNamespace(prefix);
      Uri searchUri = new Uri(uriString);
      return
      (from item in this.ClrMapping
       where item.Uri == searchUri
       select item.Assembly).ToArray();
    }

    public Assembly[] GetAllAssemblies()
    {
      return (from item in ClrMapping select item.Assembly).Distinct().ToArray();
    }
  }

  public class ClrNamespaceMapping
  {
    public Uri Uri;
    public Assembly Assembly;

    public override string ToString()
    {
      return Assembly.GetName() + " " + Uri.ToString();
    }

    public override bool Equals(object obj)
    {
      if (obj is ClrNamespaceMapping)
      {
        ClrNamespaceMapping m1 = this;
        ClrNamespaceMapping m2 = (ClrNamespaceMapping)obj;
        return (m1.Uri == m2.Uri && m1.Assembly == m2.Assembly);
      }
      else
       return base.Equals(obj);
    }

    public override int GetHashCode()
    {
      string hCode = Uri.ToString() + new AssemblyName(Assembly.FullName).ToString();
      return hCode.GetHashCode();
    }
  }

  class ClrNamespaceComparer : IEqualityComparer<ClrNamespaceMapping>
  {

    public bool Equals(ClrNamespaceMapping m1, ClrNamespaceMapping m2)
    {
      if (m1.Uri == m2.Uri && m1.Assembly == m2.Assembly)
        return true;
      else
        return false;
    }


    public int GetHashCode(ClrNamespaceMapping m)
    {
      string hCode = m.Uri.ToString() + new AssemblyName(m.Assembly.FullName).ToString();
      return hCode.GetHashCode();
    }

  }


}
