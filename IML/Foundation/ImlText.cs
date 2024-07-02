using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Documents;
using System.Windows.Markup;

namespace Iml.Foundation
{

  /// <summary>
  /// Klasa reprezentująca tekst, który może być prosty lub sformatowany.
  /// Klasa <see cref="ImlText"/> ma atrybut <see cref="Language"/> do określenia języka,
  /// w którym podany był dany tekst.
  /// </summary>
  [KnownType (typeof(Iml.Documentation.RichText))]
  public partial class ImlText: Element
  {
    /// <summary>
    /// Konstruktor domyślny.
    /// </summary>
    public ImlText() 
    { 
    }

    /// <summary>
    /// Konstruktor umożliwiający łatwe utworzenie elementu <see cref="ImlText"/>
    /// zawierającego prosty tekst.
    /// </summary>
    /// <param name="value"></param>
    public ImlText(string value) 
    {
      plainText = value;
    }

    /// <summary>
    /// Konstruktor umożliwiający łatwe utworzenie elementu <see cref="ImlText"/>
    /// w określonym języku zawierającego prosty tekst.
    /// </summary>
    /// <param name="language">język, w którym tworzony jest tekst</param>
    /// <param name="value"></param>
    public ImlText(string language, string value)
    {
      Language = language;
      plainText = value;
    }

    /// <summary>
    /// Identyfikator języka, w którym wyrażony jest dany tekst.
    /// </summary>
    [DataMember]
    [DefaultValue(null)]
    public string Language { get; set; }

    /// <summary>
    /// Prosty tekst zastępujący całą listę bloków
    /// </summary>
    protected string plainText;
    /// <summary>
    /// Prosty tekst zastępujący całą listę bloków
    /// </summary>
    [DataMember]
    public string Text
    {
      get { return GetText(); }
      set { SetText(value); }
    }

    /// <summary>
    /// Tekst prosty będzie serializowany tylko wtedy, 
    /// gdy <see cref="ImlText"/> nie zawiera tekstu sformatowanego.
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeText()
    {
      return IsPlain;
    }

    /// <summary>
    /// Ustawienie prostego tekstu
    /// </summary>
    /// <param name="value"></param>
    public virtual void SetText(string value)
    {
      plainText = value;
    }

    /// <summary>
    /// Pobranie prostego tekstu
    /// Trzeba sprawdzić, czy tekst jest prosty.
    /// </summary>
    /// <returns></returns>
    public virtual string GetText()
    {
      return plainText;
    }

    /// <summary>
    /// Czy element zawiera tylko prosty tekst?
    /// </summary>
    public bool IsPlain
    {
      get { return IsPlainText(); }
    }

    /// <summary>
    /// Czy element zawiera tylko prosty tekst?
    /// </summary>
    protected virtual bool IsPlainText()
    {
      return !String.IsNullOrEmpty(Text);
    }

    /// <summary>
    /// Konwersja jawna na łańcuch (z tekstu prostego)
    /// </summary>
    public override string ToString()
    {
      return GetText();
    }

    /// <summary>
    /// Konwersja niejawna na łańcuch (z tekstu prostego)
    /// </summary>
    public static implicit operator String(ImlText value)
    {
      if (value == null)
        return null;
      return value.GetText();
    }
/*
    /// <summary>
    /// Konwersja niejawna prostego tekstu na <see cref="RichText"/>
    /// </summary>
    public static implicit operator RichText(string value)
    {
      return new RichText(value);
    }
*/ 
  }

}
