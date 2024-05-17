using MVVM;
using MyLib.Controls;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace IML.ModelEdit
{
  /// <summary>
  /// Kontrolka metamodelu. Umożliwia edycję właściwości metamodelu
  /// </summary>
  public partial class MetamodelControl : MVVM.BaseViewModelControl
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public MetamodelControl ()
    {
      this.InitializeComponent();
    }

  }
}
