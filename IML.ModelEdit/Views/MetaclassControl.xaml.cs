using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace IML.ModelEdit
{
  /// <summary>
  /// Kontrolka do edycji właściwości klasy
  /// </summary>
  public partial class MetaclassControl : MVVM.BaseViewModelControl
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public MetaclassControl ()
    {
      this.InitializeComponent();
    }

  }
}
