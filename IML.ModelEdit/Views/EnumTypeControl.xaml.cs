using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace IML.ModelEdit
{
  /// <summary>
  /// Kontrolka do edycji właściwości metatypu
  /// </summary>
  public partial class EnumTypeControl : MVVM.BaseViewModelControl
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public EnumTypeControl ()
    {
      this.InitializeComponent();
    }

  }
}
