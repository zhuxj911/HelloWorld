using System.Windows;

namespace SurWpfLib
{
    /// <summary>
    /// Interaction logic for AzimuthWindow.xaml
    /// </summary>
    public partial class AzimuthWindow : Window
    {
        private AzimuthWindowVM azimuthVM = new AzimuthWindowVM();

        public AzimuthWindow()
        {
            InitializeComponent();
            this.DataContext = azimuthVM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            azimuthVM.CalculateAzimuth();
        }
    }
}