using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IMLM = Iml.Modeling;
using System.Diagnostics;
using System.Collections.Specialized;
using MVVM;
using Dictionary = MVVM.Dictionary;

namespace IML.ModelEdit
{
  /// <summary>
  /// Kolekcja metaklas metamodelu
  /// </summary>
  public class Metatypes: ViewModelsEditableList<Metatype>
  {

    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Metatypes (): base()
    {
    }

    /// <summary>
    /// Konstruktor inicjujący z metamodelu
    /// </summary>
    /// <param name="metamodel">macierzysty metamodel</param>
    public Metatypes(Metamodel metamodel): base()
    {
      Metamodel = metamodel;
    }

    /// <summary>
    /// Konstruktor inicjujący z metaklasy
    /// </summary>
    /// <param name="metaclass"></param>
    public Metatypes (Metaclass metaclass): base()
    {
      Metamodel = metaclass.Metamodel;
    }


    /// <summary>
    /// Macierzysty metamodel metaklasy
    /// </summary>
    public Metamodel Metamodel { get; private set; }

    public override string Name
    {
      get
      {
        return Metamodel.Name;
      }
      set
      {
        base.Name = value;
      }
    }
    /// <summary>
    /// Kolekcja jest ładowana przez <see cref="LoadFrom"/>
    /// </summary>
    protected override void OnLoad ()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Ładowanie kolekcji za pośrednictwem typu posiadającego właściwość "Metatypes"
    /// </summary>
    public void LoadFrom (Type metamodelType)
    {
      PropertyInfo metatypesProperty = metamodelType.GetProperty("Metatypes",
        BindingFlags.Public | BindingFlags.Static);
      if (metatypesProperty != null)
      {
        #region załadowanie typów
        List<Type> metatypes = (List<Type>)metatypesProperty.GetValue(null, new object[0]);
        foreach (Type type in metatypes)
        {
          Metatype metatype;
          if (type.IsEnum)
            metatype = new EnumType { Metamodel = this.Metamodel };
          else
            metatype = new Metaclass { Metamodel = this.Metamodel };
          metatype.LoadFrom(type);
          Add(metatype);
        }
        #endregion

        #region tworzenie struktury dziedziczenia
        foreach (Metatype metatype in this)
        {
          metatype.ResolveReferences();
          Metaclass baseMetatype = this.FirstOrDefault(item => item.Type == metatype.Type.BaseType) as Metaclass;
          //if (baseMetatype != null)
          //{
          //  metatype.BaseType = new TypeReference(baseMetatype);
          //}
        }
        #endregion

        NotifyPropertyChanged("Metaclasses");
      }

    }

    /// <summary>
    /// Typy są zapamiętywane przez metamodel
    /// </summary>
    protected override void OnStore ()
    {
      if (Metamodel != null)
        Metamodel.Store();
    }

    /// <summary>
    /// Zapisanie zasobów tekstowych elementów w słowniku
    /// </summary>
    public void StoreResourcesTo (Dictionary dictionary)
    {
      foreach (Metatype metatype in this)
        metatype.StoreResourcesTo(dictionary);
    }

    /// <summary>
    /// Kopiowanie do kolekcji IML
    /// </summary>
    /// <param name="target"></param>
    public void CopyTo (IMLM.Types target)
    {
      foreach (Metatype metatype in this)
      {
        IMLM.Type imlMetatype = new IMLM.Type();
        metatype.CopyTo(imlMetatype);
        target.Add(imlMetatype);
      }
    }

    /// <summary>
    /// Odświeżenie zasobów tekstowych
    /// </summary>
    public void RefreshResources ()
    {
      foreach (Metatype metatype in this)
        metatype.LoadResources();
    }

    /// <summary>
    /// Wykonanie komendy utworzenia nowego elementu. 
    /// Ustawia metamodel elementu.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    protected override void NewItemCommand_OnExecute(object sender, CommandEventArgs args)
    {
      base.NewItemCommand_OnExecute(sender, args);
      Metatype item = args.Parameter as Metatype;
      if (item != null)
      {
        item.Metamodel = Metamodel;
      }
    }

    /// <summary>
    /// Komunikat dla potwierdzenia usunięcia elementu
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    protected override string DeleteConfirmMessage(Metatype element)
    {
      if (element is Metaclass)
        return string.Format(MetamodelsStrings.DeleteMetaclassConfirm_1, element.Name);
      if (element is EnumType)
        return string.Format(MetamodelsStrings.DeleteEnumTypeConfirm_1, element.Name);

      return string.Format(MetamodelsStrings.DeleteTypeConfirm_1, element.Name);

    }
  }
}
