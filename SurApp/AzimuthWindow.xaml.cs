using System.Windows;

namespace SurApp
{
    /// <summary>
    /// Interaction logic for AzimuthWindow.xaml
    /// </summary>
    public partial class AzimuthWindow : Window
    {
        private AzimuthWindowVM azimuthUI = new AzimuthWindowVM();

        public AzimuthWindow()
        {
            InitializeComponent();

            this.DataContext = azimuthUI;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            azimuthUI.CalculateAzimuth();
        }
    }
}
