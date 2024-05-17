using System;
using System.Diagnostics;
using System.Windows;
using MVVM;

namespace IML.ModelEdit
{
  /// <summary>
  /// Kontrolka dla wartości typu wyliczeniowego
  /// </summary>
  public partial class EnumValuesControl : MVVM.BaseListBoxControl
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public EnumValuesControl ()
    {
      InitializeComponent();
      //DataContextChanged += This_DataContextChanged;
    }

    //void This_DataContextChanged (object sender, DependencyPropertyChangedEventArgs args)
    //{
    //  if (DataContext is EnumType)
    //    ItemViewModel = BaseViewModel = DataContext as EnumType;
    //}

  }
}
