using System;
using System.CodeDom.Compiler;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MVVM;
using MyLib.Controls;
using System.Diagnostics;

namespace IML.ModelEdit
{

  /// <summary>
  ///  Kontrolka zarządzania metamodelami
  /// </summary>
  public partial class MetamodelsControl : MVVM.BaseTreeViewControl
  {

    /// <summary>
    ///  Konstruktor inicjujący
    /// </summary>
    public MetamodelsControl (): base()
    {
      this.InitializeComponent();
      DataContextChanged += This_DataContextChanged;
      OnEndEditCommandExecute += EndEditItemCommandExecute;
    }

    void This_DataContextChanged (object sender, DependencyPropertyChangedEventArgs e)
    {
      if (DataContext is Metamodels && Metamodels == null)
        ItemViewModel = Metamodels = (DataContext as Metamodels);
    }

    /// <summary>
    ///  Model widoku kolekcji metamodeli - tożsamy z kontekstem danych
    /// </summary>
    public Metamodels Metamodels
    {
      get { return fMetamodels; }
      set 
      { 
        if (fMetamodels!=value)
        { 
          fMetamodels = value; 
          //NotifyPropertyChanged("Metamodels")
        }
      }
    }
    private Metamodels fMetamodels;

    #region komenda generowania kodu metamodelu

    /// <summary>
    /// Komenda <c>GenerateCode</c>
    /// </summary>
    public static RoutedCommand GenerateCodeCommand = new RoutedCommand();

    /// <summary>
    /// Określenie możliwości wykonania komendy <c>GenerateCode</c>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void GenerateCodeCommandCanExecute (object sender, CanExecuteRoutedEventArgs args)
    {
      Control source = args.OriginalSource as Control;
      object parameter = args.Parameter;
      Metamodel item = parameter as Metamodel;
      args.CanExecute = source != null && item != null;
    }

    /// <summary>
    /// Wykonanie komendy <c>GenerateCode</c>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void GenerateCodeCommandExecute (object sender, ExecutedRoutedEventArgs args)
    {
      Control source = args.OriginalSource as Control;
      if (source != null)
      {
        BaseViewModelControl dataControl = VisualHelper.FindAncestor<BaseViewModelControl>(source);
        if (dataControl != null)
        {
          if (!dataControl.Validate(true))
            return;
        }
      }
      object parameter = args.Parameter;
      //MessageBox.Show(String.Format("({0}).GenerateCodeCommandExecute with Parameter = {1}", source, parameter));
      Metamodel metamodel = parameter as Metamodel;
      if (metamodel != null)
      {
        CompilerResults results = CodeBuilder.Compile(metamodel);
        if (results.Errors.Count == 0)
          MessageBox.Show(String.Format(MetamodelsStrings.MetamodelCompiled_1, metamodel.Name, results.CompiledAssembly.GetName()));
      }
    }
    #endregion

    public void EndEditItemCommandExecute(object sender, CommandRoutedEventArgs args)
    {
      Metamodel metamodel = null;
      if (ItemViewModel is Metamodel)
        metamodel = (ItemViewModel as Metamodel);
      else if (ItemViewModel is Metatype)
        metamodel = (ItemViewModel as Metatype).Metamodel;
      if (metamodel != null)
      {
        MetamodelingElement element = args.Parameter as MetamodelingElement;
        if (element!=null && element.NeedsCompilation())
          metamodel.NeedsRecompilation = true;
      }
    }

    /// <summary>
    /// Reakcja na wybór szablonu dla panelu szczegółów
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void DetailsPanel_TemplateSelected(object sender, TemplateSelectedRoutedEventArgs args)
    {
      if (args.TemplatedItem is Metamodel)
      {
        if (DetailsPanel.Visibility != Visibility.Collapsed)
          DetailsPanel.RaiseEvent(new RoutedEventArgs(DetailsButton.ExpandCollapseEvent));
      }
      else
      {
        if (DetailsPanel.Visibility != Visibility.Visible)
          DetailsPanel.RaiseEvent(new RoutedEventArgs(DetailsButton.ExpandCollapseEvent));
      }
    }
  }
}
