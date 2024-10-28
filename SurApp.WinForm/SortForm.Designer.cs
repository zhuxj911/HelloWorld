namespace SurApp.WinForm
{
    partial class SortForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new System.Windows.Forms.GroupBox();
            textBoxBeforeSort = new System.Windows.Forms.TextBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            radioButtonQuickSort = new System.Windows.Forms.RadioButton();
            radioButtonBubbleSort = new System.Windows.Forms.RadioButton();
            groupBox3 = new System.Windows.Forms.GroupBox();
            textBoxAfterSort = new System.Windows.Forms.TextBox();
            textBoxCount = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            textBoxFrom = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            radioButtonSmallData = new System.Windows.Forms.RadioButton();
            groupBox4 = new System.Windows.Forms.GroupBox();
            groupBoxRandomData = new System.Windows.Forms.GroupBox();
            buttonGenRandomData = new System.Windows.Forms.Button();
            textBoxTo = new System.Windows.Forms.TextBox();
            radioButtonLargeData = new System.Windows.Forms.RadioButton();
            groupBox5 = new System.Windows.Forms.GroupBox();
            textBoxResult = new System.Windows.Forms.TextBox();
            buttonTest = new System.Windows.Forms.Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBoxRandomData.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxBeforeSort);
            groupBox1.Location = new System.Drawing.Point(0, 68);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(797, 112);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "排序前测试数据(前后各10个数据)";
            // 
            // textBoxBeforeSort
            // 
            textBoxBeforeSort.Location = new System.Drawing.Point(6, 22);
            textBoxBeforeSort.Multiline = true;
            textBoxBeforeSort.Name = "textBoxBeforeSort";
            textBoxBeforeSort.Size = new System.Drawing.Size(785, 81);
            textBoxBeforeSort.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButtonQuickSort);
            groupBox2.Controls.Add(radioButtonBubbleSort);
            groupBox2.Location = new System.Drawing.Point(0, 186);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(797, 62);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "排序算法";
            // 
            // radioButtonQuickSort
            // 
            radioButtonQuickSort.AutoSize = true;
            radioButtonQuickSort.Location = new System.Drawing.Point(125, 22);
            radioButtonQuickSort.Name = "radioButtonQuickSort";
            radioButtonQuickSort.Size = new System.Drawing.Size(74, 21);
            radioButtonQuickSort.TabIndex = 0;
            radioButtonQuickSort.Text = "快速排序";
            radioButtonQuickSort.UseVisualStyleBackColor = true;
            // 
            // radioButtonBubbleSort
            // 
            radioButtonBubbleSort.AutoSize = true;
            radioButtonBubbleSort.Checked = true;
            radioButtonBubbleSort.Location = new System.Drawing.Point(6, 22);
            radioButtonBubbleSort.Name = "radioButtonBubbleSort";
            radioButtonBubbleSort.Size = new System.Drawing.Size(74, 21);
            radioButtonBubbleSort.TabIndex = 0;
            radioButtonBubbleSort.TabStop = true;
            radioButtonBubbleSort.Text = "冒泡排序";
            radioButtonBubbleSort.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBoxAfterSort);
            groupBox3.Location = new System.Drawing.Point(0, 327);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(788, 121);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "排序后测试数据(前后各10个数据)";
            // 
            // textBoxAfterSort
            // 
            textBoxAfterSort.Location = new System.Drawing.Point(6, 22);
            textBoxAfterSort.Multiline = true;
            textBoxAfterSort.Name = "textBoxAfterSort";
            textBoxAfterSort.Size = new System.Drawing.Size(776, 93);
            textBoxAfterSort.TabIndex = 0;
            // 
            // textBoxCount
            // 
            textBoxCount.Location = new System.Drawing.Point(44, 12);
            textBoxCount.Name = "textBoxCount";
            textBoxCount.Size = new System.Drawing.Size(92, 23);
            textBoxCount.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 14);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(32, 17);
            label1.TabIndex = 4;
            label1.Text = "个数";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(142, 15);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 17);
            label2.TabIndex = 4;
            label2.Text = "范围：从";
            // 
            // textBoxFrom
            // 
            textBoxFrom.Location = new System.Drawing.Point(204, 14);
            textBoxFrom.Name = "textBoxFrom";
            textBoxFrom.Size = new System.Drawing.Size(120, 23);
            textBoxFrom.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(330, 18);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(20, 17);
            label4.TabIndex = 4;
            label4.Text = "到";
            // 
            // radioButtonSmallData
            // 
            radioButtonSmallData.AutoSize = true;
            radioButtonSmallData.Checked = true;
            radioButtonSmallData.Location = new System.Drawing.Point(11, 25);
            radioButtonSmallData.Name = "radioButtonSmallData";
            radioButtonSmallData.Size = new System.Drawing.Size(74, 21);
            radioButtonSmallData.TabIndex = 5;
            radioButtonSmallData.TabStop = true;
            radioButtonSmallData.Text = "少量数据";
            radioButtonSmallData.UseVisualStyleBackColor = true;
            radioButtonSmallData.Click += radioButtonSmallData_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(groupBoxRandomData);
            groupBox4.Controls.Add(radioButtonLargeData);
            groupBox4.Controls.Add(radioButtonSmallData);
            groupBox4.Location = new System.Drawing.Point(0, 1);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(797, 61);
            groupBox4.TabIndex = 6;
            groupBox4.TabStop = false;
            groupBox4.Text = "测试数据生产方式";
            // 
            // groupBoxRandomData
            // 
            groupBoxRandomData.Controls.Add(buttonGenRandomData);
            groupBoxRandomData.Controls.Add(label2);
            groupBoxRandomData.Controls.Add(label1);
            groupBoxRandomData.Controls.Add(textBoxTo);
            groupBoxRandomData.Controls.Add(textBoxFrom);
            groupBoxRandomData.Controls.Add(label4);
            groupBoxRandomData.Controls.Add(textBoxCount);
            groupBoxRandomData.Location = new System.Drawing.Point(212, 11);
            groupBoxRandomData.Name = "groupBoxRandomData";
            groupBoxRandomData.Size = new System.Drawing.Size(579, 44);
            groupBoxRandomData.TabIndex = 7;
            groupBoxRandomData.TabStop = false;
            // 
            // buttonGenRandomData
            // 
            buttonGenRandomData.Location = new System.Drawing.Point(491, 13);
            buttonGenRandomData.Name = "buttonGenRandomData";
            buttonGenRandomData.Size = new System.Drawing.Size(75, 23);
            buttonGenRandomData.TabIndex = 5;
            buttonGenRandomData.Text = "生成";
            buttonGenRandomData.UseVisualStyleBackColor = true;
            buttonGenRandomData.Click += buttonGenRandomData_Click;
            // 
            // textBoxTo
            // 
            textBoxTo.Location = new System.Drawing.Point(356, 15);
            textBoxTo.Name = "textBoxTo";
            textBoxTo.Size = new System.Drawing.Size(117, 23);
            textBoxTo.TabIndex = 3;
            // 
            // radioButtonLargeData
            // 
            radioButtonLargeData.AutoSize = true;
            radioButtonLargeData.Location = new System.Drawing.Point(108, 25);
            radioButtonLargeData.Name = "radioButtonLargeData";
            radioButtonLargeData.Size = new System.Drawing.Size(98, 21);
            radioButtonLargeData.TabIndex = 5;
            radioButtonLargeData.Text = "大量随机数据";
            radioButtonLargeData.UseVisualStyleBackColor = true;
            radioButtonLargeData.Click += radioButtonLargeData_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(textBoxResult);
            groupBox5.Controls.Add(buttonTest);
            groupBox5.Location = new System.Drawing.Point(0, 254);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new System.Drawing.Size(800, 67);
            groupBox5.TabIndex = 7;
            groupBox5.TabStop = false;
            groupBox5.Text = "时间效率测试";
            // 
            // textBoxResult
            // 
            textBoxResult.Location = new System.Drawing.Point(129, 14);
            textBoxResult.Multiline = true;
            textBoxResult.Name = "textBoxResult";
            textBoxResult.Size = new System.Drawing.Size(662, 47);
            textBoxResult.TabIndex = 1;
            // 
            // buttonTest
            // 
            buttonTest.Location = new System.Drawing.Point(11, 22);
            buttonTest.Name = "buttonTest";
            buttonTest.Size = new System.Drawing.Size(101, 25);
            buttonTest.TabIndex = 0;
            buttonTest.Text = "测试";
            buttonTest.UseVisualStyleBackColor = true;
            buttonTest.Click += buttonTest_Click;
            // 
            // SortForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Name = "SortForm";
            Text = "冒泡排序算的与快速排序算法测试";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBoxRandomData.ResumeLayout(false);
            groupBoxRandomData.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxBeforeSort;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxAfterSort;
        private System.Windows.Forms.RadioButton radioButtonQuickSort;
        private System.Windows.Forms.RadioButton radioButtonBubbleSort;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButtonSmallData;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBoxRandomData;
        private System.Windows.Forms.RadioButton radioButtonLargeData;
        private System.Windows.Forms.TextBox textBoxTo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Button buttonGenRandomData;
    }
}