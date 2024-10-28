using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurApp.WinForm
{
    public partial class AzimuthForm : Form
    {
        public AzimuthForm()
        {
            InitializeComponent();
            this.textBox_xA.TextChanged += TextBox_xA_TextChanged1;
            this.textBox_yA.TextChanged += TextBox_yA_TextChanged;
            this.textBox_xB.TextChanged += TextBox_xB_TextChanged;
            this.textBox_yB.TextChanged += TextBox_yB_TextChanged;
        }

        private void TextBox_xA_TextChanged1(object? sender, EventArgs e)
        {
            if (double.TryParse(this.textBox_xA.Text, out double xA) != true)
            {
                errorProvider1.SetError(textBox_xA, "输入的不是有效数据！");
            }
            else
            { errorProvider1.SetError(textBox_xA, null); }
        }

        private void TextBox_yA_TextChanged(object? sender, EventArgs e)
        {
            if (double.TryParse(this.textBox_yA.Text, out double yA) != true)
            {
                errorProvider1.SetError(textBox_yA, "输入的不是有效数据！");
            }
            else
            { errorProvider1.SetError(textBox_yA, null); }
        }

        private void TextBox_xB_TextChanged(object? sender, EventArgs e)
        {
            if (double.TryParse(this.textBox_xB.Text, out double xB) != true)
            {
                errorProvider1.SetError(textBox_xB, "输入的不是有效数据！");
            }
            else
            { errorProvider1.SetError(textBox_xB, null); }
        }

        private void TextBox_yB_TextChanged(object? sender, EventArgs e)
        {
            if (double.TryParse(this.textBox_yB.Text, out double yB) != true)
            {
                errorProvider1.SetError(textBox_yB, "输入的不是有效数据！");
            }
            else
            {
                errorProvider1.SetError(textBox_xB, null);
            }
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            double xA = double.Parse(this.textBox_xA.Text);
            double yA = double.Parse(this.textBox_yA.Text);
            double xB = double.Parse(this.textBox_xB.Text);
            double yB = double.Parse(this.textBox_yB.Text);

            var az = ZXY.SurMath.Azimuth(xA, yA, xB, yB);

            this.textBox_a.Text = ZXY.SurMath.RadianToDmsString(az.a);
            this.textBox_d.Text = $"{az.d:0.###}";

            this.label_az.Text = $"{textBox_AName.Text} -> {textBox_BName.Text} 坐标方位角";
        }
    }
}