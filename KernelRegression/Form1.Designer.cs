namespace KernelRegression
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mainDistributionComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.hNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.bNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.aNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.functionComboBox = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.noiseDistributionComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.mainPercentNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.noisePercentNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPercentNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noisePercentNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Location = new System.Drawing.Point(6, 421);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(280, 124);
            this.listBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(367, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Новая выборка";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.hNumericUpDown);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nNumericUpDown);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.bNumericUpDown);
            this.groupBox1.Controls.Add(this.aNumericUpDown);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.functionComboBox);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 551);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Задайте:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.noisePercentNumericUpDown);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.mainPercentNumericUpDown);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.noiseDistributionComboBox);
            this.groupBox2.Controls.Add(this.mainDistributionComboBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(6, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(367, 212);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Распределение:";
            // 
            // mainDistributionComboBox
            // 
            this.mainDistributionComboBox.FormattingEnabled = true;
            this.mainDistributionComboBox.Location = new System.Drawing.Point(125, 35);
            this.mainDistributionComboBox.Name = "mainDistributionComboBox";
            this.mainDistributionComboBox.Size = new System.Drawing.Size(221, 32);
            this.mainDistributionComboBox.TabIndex = 2;
            this.mainDistributionComboBox.SelectedIndexChanged += new System.EventHandler(this.mainDistributionComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 24);
            this.label6.TabIndex = 1;
            this.label6.Text = "Шумовое: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Основное: ";
            // 
            // hNumericUpDown
            // 
            this.hNumericUpDown.DecimalPlaces = 2;
            this.hNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.hNumericUpDown.Location = new System.Drawing.Point(55, 129);
            this.hNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.hNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.hNumericUpDown.Name = "hNumericUpDown";
            this.hNumericUpDown.Size = new System.Drawing.Size(66, 29);
            this.hNumericUpDown.TabIndex = 13;
            this.hNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.hNumericUpDown.ValueChanged += new System.EventHandler(this.hNumericUpDown_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "h = ";
            // 
            // nNumericUpDown
            // 
            this.nNumericUpDown.Location = new System.Drawing.Point(186, 92);
            this.nNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nNumericUpDown.Name = "nNumericUpDown";
            this.nNumericUpDown.Size = new System.Drawing.Size(66, 29);
            this.nNumericUpDown.TabIndex = 11;
            this.nNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nNumericUpDown.ValueChanged += new System.EventHandler(this.nNumericUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Размер выборки: ";
            // 
            // bNumericUpDown
            // 
            this.bNumericUpDown.DecimalPlaces = 1;
            this.bNumericUpDown.Location = new System.Drawing.Point(319, 64);
            this.bNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.bNumericUpDown.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.bNumericUpDown.Name = "bNumericUpDown";
            this.bNumericUpDown.Size = new System.Drawing.Size(54, 29);
            this.bNumericUpDown.TabIndex = 9;
            this.bNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.bNumericUpDown.ValueChanged += new System.EventHandler(this.bNumericUpDown_ValueChanged);
            // 
            // aNumericUpDown
            // 
            this.aNumericUpDown.DecimalPlaces = 1;
            this.aNumericUpDown.Location = new System.Drawing.Point(259, 64);
            this.aNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.aNumericUpDown.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.aNumericUpDown.Name = "aNumericUpDown";
            this.aNumericUpDown.Size = new System.Drawing.Size(54, 29);
            this.aNumericUpDown.TabIndex = 8;
            this.aNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            -2147483648});
            this.aNumericUpDown.ValueChanged += new System.EventHandler(this.aNumericUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Интервал исследования:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "f(x) = ";
            // 
            // functionComboBox
            // 
            this.functionComboBox.FormattingEnabled = true;
            this.functionComboBox.Location = new System.Drawing.Point(80, 26);
            this.functionComboBox.Name = "functionComboBox";
            this.functionComboBox.Size = new System.Drawing.Size(206, 32);
            this.functionComboBox.TabIndex = 5;
            this.functionComboBox.Text = "sinc(x)";
            this.functionComboBox.SelectedIndexChanged += new System.EventHandler(this.functionComboBox_SelectedIndexChanged);
            this.functionComboBox.TextChanged += new System.EventHandler(this.functionComboBox_TextChanged);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(398, 12);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(703, 551);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            this.chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseClick);
            // 
            // noiseDistributionComboBox
            // 
            this.noiseDistributionComboBox.FormattingEnabled = true;
            this.noiseDistributionComboBox.Location = new System.Drawing.Point(125, 112);
            this.noiseDistributionComboBox.Name = "noiseDistributionComboBox";
            this.noiseDistributionComboBox.Size = new System.Drawing.Size(221, 32);
            this.noiseDistributionComboBox.TabIndex = 3;
            this.noiseDistributionComboBox.SelectedIndexChanged += new System.EventHandler(this.noiseDistributionComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 24);
            this.label7.TabIndex = 4;
            this.label7.Text = "% = ";
            // 
            // mainPercentNumericUpDown
            // 
            this.mainPercentNumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.mainPercentNumericUpDown.Location = new System.Drawing.Point(60, 72);
            this.mainPercentNumericUpDown.Name = "mainPercentNumericUpDown";
            this.mainPercentNumericUpDown.Size = new System.Drawing.Size(66, 29);
            this.mainPercentNumericUpDown.TabIndex = 14;
            this.mainPercentNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.mainPercentNumericUpDown.ValueChanged += new System.EventHandler(this.mainPercentNumericUpDown_ValueChanged);
            // 
            // noisePercentNumericUpDown
            // 
            this.noisePercentNumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.noisePercentNumericUpDown.Location = new System.Drawing.Point(60, 150);
            this.noisePercentNumericUpDown.Name = "noisePercentNumericUpDown";
            this.noisePercentNumericUpDown.Size = new System.Drawing.Size(66, 29);
            this.noisePercentNumericUpDown.TabIndex = 16;
            this.noisePercentNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.noisePercentNumericUpDown.ValueChanged += new System.EventHandler(this.noisePercentNumericUpDown_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 24);
            this.label8.TabIndex = 15;
            this.label8.Text = "% = ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 575);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Непараметрическая регрессия Галайда А. В.";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPercentNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noisePercentNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox functionComboBox;
        private System.Windows.Forms.NumericUpDown bNumericUpDown;
        private System.Windows.Forms.NumericUpDown aNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown hNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox mainDistributionComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox noiseDistributionComboBox;
        private System.Windows.Forms.NumericUpDown noisePercentNumericUpDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown mainPercentNumericUpDown;
        private System.Windows.Forms.Label label7;
    }
}

