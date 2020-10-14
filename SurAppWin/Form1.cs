using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurAppWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double xA = double.Parse(this.textBox_xA.Text);
            double yA = double.Parse(this.textBox_yA.Text);
            double xB = double.Parse(this.textBox_xB.Text);
            double yB = double.Parse(this.textBox_yB.Text);

            var az = ZXY.SurMath.Azimuth(xA, yA, xB, yB);

            this.textBox_a.Text = ZXY.SurMath.RadtoString(az.a);
            this.textBox_d.Text = $"{az.d:0.###}";

            this.label_az.Text = $"{textBox_AName.Text} -> {textBox_BName.Text} 坐标方位角";
        }
    }
}
