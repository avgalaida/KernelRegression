using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using org.mariuszgromada.math.mxparser;

namespace KernelRegression
{
    public partial class Form1 : Form
    {
        Sample sample;
        string kernel;
        double h;
        int n;
        double a;
        double b;
        string function;
        string mainDistribution;
        double[] mainDistributionParams;
        int mainPersent;
        int noisePersent;
        string noiseDistribution;
        double[] noiseDistributionParams;

        public Form1()
        {
            InitializeComponent();

            var data = new Series("data")
            {
                ChartType = SeriesChartType.Point,
                BorderWidth = 3,
                Color = Color.Blue,
                LegendText = "Выборка"
            };

            var regression = new Series("regression")
            {
                ChartType = SeriesChartType.Spline,
                BorderWidth = 3,
                Color = Color.Red,
                LegendText = "Регрессия"
            };

            //var function = new Series("function")
            //{
            //    ChartType = SeriesChartType.Spline,
            //    BorderWidth = 3,
            //    BorderDashStyle = ChartDashStyle.Dash,
            //    Color = Color.FromArgb(31, 119, 180),
            //    LegendText = "Фукнция"
            //};

            //chart1.Series.Add(function);
            chart1.Series.Add(regression);
            chart1.Series.Add(data);


            //chart1.Legends[0].Enabled = false;
            //chart1.ChartAreas[0].AxisX.Title = "x";
            //chart1.ChartAreas[0].AxisY.Title = "y";
            DisableMajorGrid(ref chart1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sample = new Sample(n, a, b, function, mainPersent, mainDistribution, mainDistributionParams, noisePersent, noiseDistribution, noiseDistributionParams);
            Plot();
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            double xValue = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
            double yValue = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);
            sample.Add(new Sample.Point(xValue, yValue)); 

            Plot();
        }

        void Plot()
        {
            sample.Plot(ref chart1);
            KernelRegression.Plot(ref sample, kernel,h, ref chart1);
        }

        void DisableMajorGrid(ref Chart plt)
        {
            plt.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            plt.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            plt.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            plt.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            //chart1.Series["function"].Points.Clear();
            //for (double x = a; x < b; x += 0.1)
            //{
            //    chart1.Series["function"].Points.AddXY(x, Fun(x));
            //}
        }

        private void functionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            function = functionComboBox.Text.Replace(',', '.');
            sample = new Sample(n, a, b, function, mainPersent, mainDistribution, mainDistributionParams, noisePersent, noiseDistribution, noiseDistributionParams);
            Plot();
        }

        private void functionComboBox_TextChanged(object sender, EventArgs e)
        {
            function = functionComboBox.Text.Replace(',', '.');
            sample = new Sample(n, a, b, function, mainPersent, mainDistribution, mainDistributionParams, noisePersent, noiseDistribution, noiseDistributionParams);
            Plot();
        }

        private void aNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            a = (double) aNumericUpDown.Value;
            sample = new Sample(n, a, b, function, mainPersent, mainDistribution, mainDistributionParams, noisePersent, noiseDistribution, noiseDistributionParams);
            Plot();
        }

        private void bNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            b = (double) bNumericUpDown.Value;
            sample = new Sample(n, a, b, function, mainPersent, mainDistribution, mainDistributionParams, noisePersent, noiseDistribution, noiseDistributionParams);
            Plot();
        }

        private void nNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            n = (int) nNumericUpDown.Value;
            sample = new Sample(n, a, b, function, mainPersent, mainDistribution, mainDistributionParams, noisePersent, noiseDistribution, noiseDistributionParams);
            Plot();
        }

        private void hNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            h = (double) hNumericUpDown.Value;
            Plot();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            function = functionComboBox.Text.Replace(',', '.');
            a = (double)aNumericUpDown.Value;
            b = (double)bNumericUpDown.Value;
            n = (int)nNumericUpDown.Value;
            h = (double)hNumericUpDown.Value;

            mainDistribution = "Gaussian";
            noiseDistribution = "Gaussian";

            mainPersent = (int) mainPercentNumericUpDown.Value;
            noisePersent = (int) noisePercentNumericUpDown.Value;

            mainDistributionParams = new double[] { 0, 1 };
            noiseDistributionParams = new double[] { 0, 1 };
            kernel = "epanechnikov";

            mainDistributionComboBox.Items.Add("Нормальное");
            mainDistributionComboBox.Items.Add("Коши");
            mainDistributionComboBox.Items.Add("Лапласа");
            noiseDistributionComboBox.Items.Add("Нормальное");
            noiseDistributionComboBox.Items.Add("Коши");
            noiseDistributionComboBox.Items.Add("Лапласа");
            mainDistributionComboBox.SelectedIndex = 0;
            noiseDistributionComboBox.SelectedIndex = 0;

            Plot();
        }

        private void mainDistributionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (mainDistributionComboBox.SelectedIndex)
            {
                case 0:
                    mainDistribution = "Gaussian";
                    break;
                case 2:
                    mainDistribution = "Cauchy";
                    break;
                case 3:
                    mainDistribution = "Laplace";
                    break;
            }
            sample = new Sample(n, a, b, function, mainPersent, mainDistribution, mainDistributionParams, noisePersent, noiseDistribution, noiseDistributionParams);
            Plot();
        }

        private void noiseDistributionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (noiseDistributionComboBox.SelectedIndex)
            {
                case 0:
                    noiseDistribution = "Gaussian";
                    break;
                case 2:
                    noiseDistribution = "Cauchy";
                    break;
                case 3:
                    noiseDistribution = "Laplace";
                    break;
            }
            sample = new Sample(n, a, b, function, mainPersent, mainDistribution, mainDistributionParams, noisePersent, noiseDistribution, noiseDistributionParams);
            Plot();
        }

        private void mainPercentNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            mainPersent = (int)mainPercentNumericUpDown.Value;
            sample = new Sample(n, a, b, function, mainPersent, mainDistribution, mainDistributionParams, noisePersent, noiseDistribution, noiseDistributionParams);
            Plot();
        }

        private void noisePercentNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            noisePersent = (int)mainPercentNumericUpDown.Value;
            sample = new Sample(n, a, b, function, mainPersent, mainDistribution, mainDistributionParams, noisePersent, noiseDistribution, noiseDistributionParams);
            Plot();
        }
    }
}
