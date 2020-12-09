using Microsoft.Win32;
using System.Windows;

namespace SurApp
{
  /// <summary>
  /// MainWindow.xaml 的交互逻辑
  /// </summary>
  public partial class MainWindow : Window
  {
    private ProjWindowVM vm = new ProjWindowVM();
    public MainWindow()
    {
      InitializeComponent();
      this.DataContext = vm;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      AzimuthWindow win = new AzimuthWindow();
      win.Show();
    }

    private void MenuItem_Open_Click(object sender, RoutedEventArgs e)
    {
      vm.Open();
    }

    private void MenuItem_Save_Click(object sender, RoutedEventArgs e)
    {
      vm.Save();
    }

    private void MenuItem_SaveAs_Click(object sender, RoutedEventArgs e)
    {
      vm.SaveAs();
    }
  }
}
