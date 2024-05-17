using System;
using MVVM;

namespace IML.ModelEdit
{
  /// <summary>
  /// Model widoku referencji do obiektu
  /// </summary>
  public class Reference: DisplayedViewModel
  {
    /// <summary>
    /// Konstruktor domyślny nie powinien być wywoływany
    /// </summary>
    public Reference()
    {
      //throw new NotImplementedException(MetamodelsStrings.ReferenceDefaultConstructorError);
    }

    /// <summary>
    /// Konstruktor inicjujący z elementem docelowym
    /// </summary>
    /// <param name="target"></param>
    public Reference(ViewModelBase target)
    {
      Target = target;
      Target.PropertyChanged += Target_PropertyChanged;
    }

    /// <summary>
    /// Zmiana właściwości elementu docelowego powoduje sygnalizację zmiany właściwości referencji
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    void Target_PropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs args)
    {
      NotifyPropertyChanged(args.PropertyName);
    }

    /// <summary>
    /// Element docelowy referencji
    /// </summary>
    public ViewModelBase Target { get; protected set;}

    /// <summary>
    /// Nazwa pobierana z elementu docelowego
    /// </summary>
    public virtual string TargetName
    {
      get
      {
        string result = null;
        if (Target != null)
          result = Target.Name;
        if (Collection is References)
        {
          ViewModelBase source = (Collection as References).Source;
          if (source is Metatype)
          {
            Metamodel sourceMetamodel = (source as Metatype).Metamodel;
            if (Target is Metatype)
            {
              Metamodel targetMetamodel = (Target as Metatype).Metamodel;
              if (targetMetamodel != sourceMetamodel)
              {
                string targetNamespace = targetMetamodel.Name;
                if (targetNamespace != null)
                  result = targetNamespace + "." + result;
              }
            }
          }
        }
        return result;
      }
    }

    /// <summary>
    /// Nazwa pobierana z elementu docelowego
    /// </summary>
    public override string DisplayName { get { return TargetName;} }

    /// <summary>
    /// Opis pobierany z elementu docelowego
    /// </summary>
    public new string Description
    {
      get 
      {
        string result = null;
        if (Target!=null)
          result = Target.Description; 
        return result;
      }
    }

    #region metody porównywania referencji

    /// <summary>
    /// Referencje są równe, gdy ich elementy docelowe są równe.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public override bool Equals (object other)
    {
      if (other is Reference)
        return this.Target == (other as Reference).Target;
      else
        return base.Equals(other);
    }

    /// <summary>
    /// Metoda wymagana przy nadpisaniu metody <c>Equals</c>
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public override int GetHashCode()
    {
      if (Target!=null)
        return Target.GetHashCode();
      return 0;
    }

    #endregion

    /// <summary>
    /// Dla potrzeb śledzenia
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      string result = this.GetType().Name;
      if (Target != null)
        result += " to " + Target.ToString();
      return result;
    }
  }
}
