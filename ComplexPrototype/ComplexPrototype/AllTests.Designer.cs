namespace ComplexPrototype
{
    partial class AllTests
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.ButtonB = new System.Windows.Forms.RadioButton();
            this.ButtonA = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BorderlineWidth = 2;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(30, 92);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F);
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(860, 453);
            this.chart1.TabIndex = 27;
            this.chart1.Text = "chart1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F);
            this.label2.Location = new System.Drawing.Point(42, 958);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 25;
            this.label2.Text = "label2";
            // 
            // buttonNext
            // 
            this.buttonNext.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F);
            this.buttonNext.Location = new System.Drawing.Point(43, 262);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(189, 70);
            this.buttonNext.TabIndex = 24;
            this.buttonNext.Text = "Далее";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // ButtonB
            // 
            this.ButtonB.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F);
            this.ButtonB.Location = new System.Drawing.Point(43, 151);
            this.ButtonB.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.ButtonB.Name = "ButtonB";
            this.ButtonB.Size = new System.Drawing.Size(860, 95);
            this.ButtonB.TabIndex = 23;
            this.ButtonB.Text = "Нет";
            this.ButtonB.UseVisualStyleBackColor = true;
            this.ButtonB.CheckedChanged += new System.EventHandler(this.ButtonB_CheckedChanged);
            // 
            // ButtonA
            // 
            this.ButtonA.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F);
            this.ButtonA.Location = new System.Drawing.Point(43, 78);
            this.ButtonA.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.ButtonA.Name = "ButtonA";
            this.ButtonA.Size = new System.Drawing.Size(864, 87);
            this.ButtonA.TabIndex = 22;
            this.ButtonA.Text = "Да";
            this.ButtonA.UseVisualStyleBackColor = true;
            this.ButtonA.CheckedChanged += new System.EventHandler(this.ButtonA_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(38, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(852, 83);
            this.label1.TabIndex = 21;
            this.label1.Text = "label1";
            // 
            // AllTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 562);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.ButtonB);
            this.Controls.Add(this.ButtonA);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Symap", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.Name = "AllTests";
            this.Text = "AllTests";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AllTests_FormClosed);
            this.Load += new System.EventHandler(this.AllTests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.RadioButton ButtonB;
        private System.Windows.Forms.RadioButton ButtonA;
        private System.Windows.Forms.Label label1;
    }
}