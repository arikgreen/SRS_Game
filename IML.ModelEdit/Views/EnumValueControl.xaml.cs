using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IML.ModelEdit
{
  /// <summary>
  /// Kontrolka wartości typu wyliczeniowego
  /// </summary>
  public partial class EnumValueControl : MVVM.BaseViewModelControl
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public EnumValueControl ()
    {
      InitializeComponent();
    }
  }
}
