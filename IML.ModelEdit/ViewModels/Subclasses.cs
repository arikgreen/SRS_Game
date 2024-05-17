using System;
using MVVM;

namespace IML.ModelEdit
{
  /// <summary>
  /// Kolekcja klas potomnych od danej klasy
  /// </summary>
  public class Subclasses : ViewModelsFilteredEditableList<Metatype>
  {
    public Subclasses(Metaclass owner)
    {
      Owner = owner;
      Source = owner.Metamodel.Metatypes;
      Filter = SubclassesFilter;
    }

    /// <summary>
    /// Klasa macierzysta
    /// </summary>
    public Metaclass Owner { get; protected set; }

    /// <summary>
    /// Filtr sprawdzający, czy element metamodelu należy do kolekcji klas potomnych
    /// </summary>
    private bool SubclassesFilter(object obj)
    {
      Metaclass item = obj as Metaclass;
      if (item != null)
        return (item.BaseType != null && (item.BaseType.Target == Owner));
      else
        return false;
    }

    protected override void NewItemCommand_OnExecute(object sender, CommandEventArgs args)
    {
      base.NewItemCommand_OnExecute(sender, args);
      Metaclass item = args.Parameter as Metaclass;
      item.Metamodel = Owner.Metamodel;
      item.BaseType = new TypeReference(Owner);
    }
  }
}
