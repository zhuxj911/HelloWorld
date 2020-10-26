using System.Windows;

namespace SurApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double xA = double.Parse(this.textBox_xA.Text);
            double yA = double.Parse(this.textBox_yA.Text);
            double xB = double.Parse(this.textBox_xB.Text);
            double yB = double.Parse(this.textBox_yB.Text);

            var az = ZXY.SurMath.Azimuth(xA, yA, xB, yB);

            //double dx = xB - xA;
            //double dy = yB - yA;
            //double a = Math.Atan2(dy, dx) + (dy < 0 ? 1 : 0) * TWOPI;
            //double d = Math.Sqrt(dx * dx + dy * dy);

            this.textBox_a.Text = ZXY.SurMath.RadtoString(az.a);
            this.textBox_d.Text = $"{az.d:0.###}";

            this.label_az.Content = $"{textBox_AName.Text} -> {textBox_BName.Text} 坐标方位角";
        }
    }
}
