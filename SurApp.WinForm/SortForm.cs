using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXY;

namespace SurApp.WinForm
{
    public partial class SortForm : Form
    {
        private List<int> list = new List<int>() { 9, 3, 1, 4, 15, 2, 7, 8, -13, 6, 5 };
        private int count = 10000;
        private int from = -1000000;
        private int to = 1000000;

        public SortForm()
        {
            InitializeComponent();

            textBoxBeforeSort.Text = string.Join(',', list);
            groupBoxRandomData.Enabled = radioButtonLargeData.Checked;
        }

        private async void buttonTest_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();

            if (radioButtonBubbleSort.Checked)
            {
                //开启线程进行计算，避免阻塞主线程
                await Task.Factory.StartNew(() =>
                {
                    stopwatch.Start();
                    Sort.BubbleSort(list);
                    stopwatch.Stop();
                });
            }
            else if (radioButtonQuickSort.Checked)
            {
                //开启线程进行计算，避免阻塞主线程
                await Task.Factory.StartNew(() =>
                {
                    stopwatch.Start();
                    Sort.QuickSort(list);
                    stopwatch.Stop();
                });
            }
            else
            {
            }

            textBoxResult.Text = $"排序运行时间：{stopwatch.Elapsed}";
            textBoxAfterSort.Text = OutputData(list);
        }

        private void buttonGenRandomData_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text)
                || string.IsNullOrEmpty(textBoxFrom.Text)
                || string.IsNullOrEmpty(textBoxTo.Text))
                return;

            count = Convert.ToInt32(textBoxCount.Text);
            from = Convert.ToInt32(textBoxFrom.Text);
            to = Convert.ToInt32(textBoxTo.Text);

            list.Clear();
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                list.Add(rand.Next(from, to));
            }
            textBoxBeforeSort.Text = OutputData(list);
        }

        private void radioButtonLargeData_Click(object sender, EventArgs e)
        {
            groupBoxRandomData.Enabled = radioButtonLargeData.Checked;

            textBoxCount.Text = count.ToString();
            textBoxFrom.Text = from.ToString();
            textBoxTo.Text = to.ToString();
        }

        private void radioButtonSmallData_Click(object sender, EventArgs e)
        {
            groupBoxRandomData.Enabled = radioButtonLargeData.Checked;
            list = new List<int>() { 9, 3, 1, 4, 15, 2, 7, 8, -13, 6, 5 };
            textBoxBeforeSort.Text = OutputData(list);
        }

        private string OutputData(List<int> list)
        {
            if (list.Count <= 20) //少于20个是数据全部输出
            {
                return string.Join(',', list);
            }
            else //对于超过20个数据的，打印输出前后各10个数据
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Join(",", list.GetRange(0, 10)));

                sb.AppendLine();
                sb.AppendLine("--------------------------------------------------------------------------");

                sb.Append(string.Join(",", list.GetRange(list.Count - 10, 10)));

                return sb.ToString();
            }
        }
    }
}