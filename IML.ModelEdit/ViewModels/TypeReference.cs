using System;
using MVVM;


namespace IML.ModelEdit
{
  /// <summary>
  /// Referencja do typu. Zawiera dodatkową właściwość <see cref="IsList"/>
  /// </summary>
  public class TypeReference: Reference
  {

    /// <summary>
    /// Konstruktor domyślny nie powinien być wywoływany
    /// </summary>
    public TypeReference()
    {
      throw new NotImplementedException(MetamodelsStrings.ReferenceDefaultConstructorError);
    }

    /// <summary>
    /// Konstruktor inicjujący z metatypem jako elementem docelowym
    /// </summary>
    /// <param name="target">typ docelowy (model widoku)</param>
    /// <param name="isList">czy typ ma być traktowany jako lista</param>
    public TypeReference(ViewModelBase target, bool isList = false): base(target)
    {
    }

    /// <summary>
    /// Konstruktor inicjujący z typem jako elementem docelowym
    /// </summary>
    /// <param name="type">typ docelowy</param>
    /// <param name="isList">czy typ ma być traktowany jako lista</param>
    public TypeReference(Type type, bool isList = false)
      : base()
    {
      fTargetType = type;
    }

    /// <summary>
    /// Typ docelowy
    /// </summary>
    public Type TargetType
    {
      get
      {
        if (Target is Metatype)
          return (Target as Metatype).Type;
        return fTargetType;
      }
    }
    protected Type fTargetType;

    /// <summary>
    /// Znacznik listy
    /// </summary>
    public bool IsList
    {
      get { return fIsList; }
      set
      {
        if (fIsList != value)
        {
          NotifyPropertyChanged("IsList");
        }
      }
    }
    /// <summary>
    /// Pole przechowujące znacznik listy
    /// </summary>
    protected bool fIsList;

    #region metody porównywania referencji do typu

    /// <summary>
    /// Referencje do typu są równe, gdy ich typy docelowe są równe.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public override bool Equals(object other)
    {
      if (other is TypeReference)
        return this.TargetType == (other as TypeReference).TargetType;
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
      if (TargetType != null)
        return TargetType.GetHashCode();
      return 0;
    }

    #endregion

    /// <summary>
    /// Dla potrzeb śledzenia
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      string result = this.GetType().Name;
      if (Target != null)
        result += " to " + Target.ToString();
      else
        result += " to " + TargetType.ToString();
      return result;
    }

    /// <summary>
    /// Nazwa pobierana z typu docelowego
    /// </summary>
    public override string TargetName
    {
      get
      {
        string result = null;
        if (Target != null)
          result = Target.Name;
        else if (TargetType != null)
          result = TargetType.Name;
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
  }
}
