using MathNet.Numerics.Statistics;
using org.mariuszgromada.math.mxparser.mathcollection;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using Statistics = MathNet.Numerics.Statistics.Statistics;

namespace KernelRegression
{
    public partial class Form1 : Form
    {
        Sample sample;
        string kernel;
        double[] ySmoothed;
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

            var diU = new Series("diU")
            {
                ChartType = SeriesChartType.Spline,
                BorderWidth = 3,
                //BorderDashStyle = ChartDashStyle.Dash,
                Color = Color.Gray,
                LegendText = "Доврительный интервал"
            };

            var diL = new Series("diL")
            {
                ChartType = SeriesChartType.Spline,
                BorderWidth = 3,
                //BorderDashStyle = ChartDashStyle.Dash,
                Color = Color.Gray,
                LegendText = "Доврительный интервал"
            };

            chart1.Series.Add(data);
            chart1.Series.Add(regression);
            chart1.Series.Add(diU);
            chart1.Series.Add(diL);


            chart1.Legends[0].Enabled = false;
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
            n++;
            Plot();
        }

        void Plot()
        {
            chart1.Series["diU"].Points.Clear();
            chart1.Series["diL"].Points.Clear();
            sample.Plot(ref chart1);
            ySmoothed = KernelRegression.Regression(sample, h, kernel);
            KernelRegression.Plot(ref sample, ref ySmoothed, ref chart1);
            PrintStats();
        }

        void PrintStats()
        {
            listBox1.Items.Clear();

            var actual = sample.y;
            ySmoothed = KernelRegression.Regression(sample, h, kernel);

            listBox1.Items.Add("MSE = " + Sample.Round(Bootstrap.MSE(actual, ySmoothed), 3));
            listBox1.Items.Add("R2 = " + Sample.Round(Bootstrap.R2(actual, ySmoothed), 3));
            listBox1.Items.Add("RMSE = " + Sample.Round(Bootstrap.RMSE(actual, ySmoothed), 3));
            listBox1.Items.Add("MAE = " + Sample.Round(Bootstrap.MAE(actual, ySmoothed), 3));
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
            kernel = "gaussian";

            mainPersent = (int) mainPercentNumericUpDown.Value;
            noisePersent = (int) noisePercentNumericUpDown.Value;

            mainDistributionParams = new double[] { (double)mainParam1NumericUpDown.Value, (double)mainParam2NumericUpDown.Value };
            noiseDistributionParams = new double[] { (double)noiseParam1NumericUpDown.Value, (double)noiseParam2NumericUpDown.Value };

            mainDistributionComboBox.Items.Add("Нормальное");
            mainDistributionComboBox.Items.Add("Коши");
            mainDistributionComboBox.Items.Add("Лапласа");
            mainDistributionComboBox.SelectedIndex = 0;

            noiseDistributionComboBox.Items.Add("Нормальное");
            noiseDistributionComboBox.Items.Add("Коши");
            noiseDistributionComboBox.Items.Add("Лапласа");
            noiseDistributionComboBox.SelectedIndex = 0;

            kernelComboBox.Items.Add("Нормальное");
            kernelComboBox.Items.Add("Епанечникова");
            kernelComboBox.Items.Add("Триангулярное");
            kernelComboBox.SelectedIndex = 0;

            Plot();
        }

        private void mainDistributionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (mainDistributionComboBox.SelectedIndex)
            {
                case 0:
                    mainDistribution = "Gaussian";
                    mainParam1Label.Text = "μ =";
                    mainParam2Label.Text = "σ =";
                    break;
                case 1:
                    mainDistribution = "Cauchy";
                    mainParam1Label.Text = "x0 =";
                    mainParam2Label.Text = "γ =";
                    break;
                case 2:
                    mainDistribution = "Laplace";
                    mainParam1Label.Text = "μ =";
                    mainParam2Label.Text = "b =";
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
                    noiseParam1Label.Text = "μ =";
                    noiseParam2Label.Text = "σ =";
                    break;
                case 1:
                    noiseDistribution = "Cauchy";
                    noiseParam1Label.Text = "x0 =";
                    noiseParam2Label.Text = "γ =";
                    break;
                case 2:
                    noiseDistribution = "Laplace";
                    noiseParam1Label.Text = "μ =";
                    noiseParam2Label.Text = "b =";
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
            noisePersent = (int) noisePercentNumericUpDown.Value;
            sample = new Sample(n, a, b, function, mainPersent, mainDistribution, mainDistributionParams, noisePersent, noiseDistribution, noiseDistributionParams);
            Plot();
        }

        private void kernelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(kernelComboBox.SelectedIndex)
            {
                case 0:
                    kernel = "gaussian";
                    break;
                case 1:
                    kernel = "epanechnikov";
                    break;
                case 2:
                    kernel = "triangular";
                    break;
            }
            Plot();
        }

        private void mainParam1NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            mainDistributionParams = new double[] { (double) mainParam1NumericUpDown.Value, (double)mainParam2NumericUpDown.Value };
            sample = new Sample(n, a, b, function, mainPersent, mainDistribution, mainDistributionParams, noisePersent, noiseDistribution, noiseDistributionParams);
            Plot();
        }

        private void mainParam2NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            mainDistributionParams = new double[] { (double)mainParam1NumericUpDown.Value, (double)mainParam2NumericUpDown.Value };
            sample = new Sample(n, a, b, function, mainPersent, mainDistribution, mainDistributionParams, noisePersent, noiseDistribution, noiseDistributionParams);
            Plot();
        }

        private void noiseParam1NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            noiseDistributionParams = new double[] { (double)noiseParam1NumericUpDown.Value, (double)noiseParam2NumericUpDown.Value };
            sample = new Sample(n, a, b, function, mainPersent, mainDistribution, mainDistributionParams, noisePersent, noiseDistribution, noiseDistributionParams);
            Plot();
        }

        private void noiseParam2NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            noiseDistributionParams = new double[] { (double)noiseParam1NumericUpDown.Value, (double)noiseParam2NumericUpDown.Value };
            sample = new Sample(n, a, b, function, mainPersent, mainDistribution, mainDistributionParams, noisePersent, noiseDistribution, noiseDistributionParams);
            Plot();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //listBox1.Items.Clear();

            //var actual = sample.y;
            //var predicted = KernelRegression.Regression(ref sample, h, kernel);

            //listBox1.Items.Add("MSE = " + Sample.Round(Bootstrap.MSE(actual, predicted), 3));
            //listBox1.Items.Add("R2 = " + Sample.Round(Bootstrap.R2(actual, predicted), 3));
            //listBox1.Items.Add("RMSE = " + Sample.Round(Bootstrap.RMSE(actual, predicted), 3));
            //listBox1.Items.Add("MAE = " + Sample.Round(Bootstrap.MAE(actual, predicted), 3));

            //int numIters = 1000;
            //var di = Bootstrap.Bstrp(ref sample, numIters, h, kernel);
            ////listBox1.Items.Add("BTSRP:");

            //chart1.Series["diU"].Points.Clear();
            //chart1.Series["diL"].Points.Clear();
            //for (int i = 0; i < n; i++)
            //{
            //    var marginOfError = (di[i].y - di[i].x) / 2;
            //    var mean = (di[i].y + di[i].x) / 2;
            //    var u = mean + marginOfError;
            //    var l = mean - marginOfError;

            //    //listBox1.Items.Add(di[i].y);
            //    chart1.Series["diU"].Points.AddXY(sample.x[i], predicted[i] + u);
            //    chart1.Series["diL"].Points.AddXY(sample.x[i], predicted[i] + l);
            //}
            test();
        }

        void test()
        {
            chart1.Series["diU"].Points.Clear();
            chart1.Series["diL"].Points.Clear();

            // Генерация N выборок методом бутстрэпа
            int N = (int) btstrpNumericUpDown.Value;
            double[][] bootstrapSamples = new double[N][];
            Parallel.For(0, N, i =>
            {
                Sample bootstrapSample = sample.Bootstrap();
                bootstrapSamples[i] = KernelRegression.Regression(bootstrapSample, h, kernel);
            });

            // Расчет среднего значения статистики
            double[] meanValues = new double[sample.n];
            Parallel.For(0, sample.n, i =>
            {
                double sum = 0;
                for (int j = 0; j < N; j++)
                {
                    sum += bootstrapSamples[j][i];
                }
                meanValues[i] = sum / N;
            });

            // Расчет стандартного отклонения статистики
            double[] stdDeviations = new double[sample.n];
            Parallel.For(0, sample.n, i =>
            {
                double sum = 0;
                for (int j = 0; j < N; j++)
                {
                    sum += Math.Pow(bootstrapSamples[j][i] - meanValues[i], 2);
                }
                stdDeviations[i] = Math.Sqrt(sum / (N - 1));
            });

            // Вычисление интервалов двух сигм
            double[] lowerBounds = new double[sample.n];
            double[] upperBounds = new double[sample.n];
            Parallel.For(0, sample.n, i =>
            {
                lowerBounds[i] = meanValues[i] - 2 * stdDeviations[i];
                upperBounds[i] = meanValues[i] + 2 * stdDeviations[i];
            });


            for (int i = 0; i < n; i++)
            {
                chart1.Series["diU"].Points.AddXY(sample.x[i], ySmoothed[i] + Math.Abs(upperBounds[i]));
                chart1.Series["diL"].Points.AddXY(sample.x[i], ySmoothed[i] - Math.Abs(lowerBounds[i]));
                //chart1.Series["diL"].Points.AddXY(sample.x[i], ySmoothed[i] - Math.Abs(lowerBounds[i]) + Math.Abs(upperBounds[i]));
            }
        }
        private void addPointbutton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();

            if (form2.DialogResult == DialogResult.OK)
            {
                sample.Add(new Sample.Point(form2.x, form2.y));
                n++;
                Plot();
            }
        }
    }
}
