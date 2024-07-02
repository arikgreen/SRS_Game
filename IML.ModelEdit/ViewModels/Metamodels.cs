using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using MVVM;
using IMLM = Iml.Modeling;

namespace IML.ModelEdit
{
  /// <summary>
  /// Model widoku listy metamodeli
  /// </summary>
  public class Metamodels: ViewModelsEditableList<Metamodel>
  {

    /// <summary>
    /// Zaimplementowana metoda ładowania danych
    /// </summary>
    protected override void OnLoad ()
    {
      Type baseImlType = typeof(IMLM.ModelElement);
      Assembly assembly = Assembly.GetAssembly(baseImlType);
      Metamodel metamodel = new Metamodel { 
        Assembly = assembly, 
        Namespace="IML",
        Name="Modeling", 
        IsProtected = true };
      Metaclass metatype = new Metaclass { Metamodel = metamodel };
      metatype.LoadFrom(baseImlType);
      metamodel.Metatypes.Add(metatype);
      metamodel.LoadResources();
      Add(metamodel);

      ResourceSet rs = KnownMetamodels.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, true);
      foreach (DictionaryEntry entry in rs)
      {
        metamodel = new Metamodel { Name = (String)entry.Key, Namespace="Iml.Model."+(string)entry.Key };
        Add(metamodel);
        metamodel.Load();
      }
    }

    /// <summary>
    /// Na razie niezaimplementowana
    /// </summary>
    protected override void OnStore ()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Odświeżenie zasobów tekstowych
    /// </summary>
    public void RefreshResources ()
    {
      //foreach (VM.Metamodel metamodel in this)
      //  metamodel.RefreshResources();
      //if (CurrentItem != null && SelectedItem != null)
      //  SelectedItem.CopyTo(CurrentItem);
    }

    /// <summary>
    /// Podaje bazową metaklasę dla wszystkich metaklas
    /// </summary>
    /// <returns></returns>
    public Metatype GetBaseMetaclass()
    {
      Metamodel baseMetamodel = this.FirstOrDefault();
      if (baseMetamodel != null)
        return baseMetamodel.Metatypes.FirstOrDefault();
      return null;

    }
  }
}
