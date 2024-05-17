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
  /// Kontrolka właściwości metaklasy
  /// </summary>
  public partial class PropertyControl : MVVM.BaseViewModelControl
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public PropertyControl ()
    {
      InitializeComponent();
    }
  }
}
