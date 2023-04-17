using org.mariuszgromada.math.mxparser;
using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Windows.Forms.DataVisualization.Charting;

namespace KernelRegression
{
    // Класс для выборки
    public class Sample : IEnumerable
    {
        public struct Point
        {
            public double x;
            public double y;

            public Point(double x, double y) : this()
            {
                this.x = Round(x,3);
                this.y = Round(y,3);
            }
        }

        public Point[] sample;
        public double[] x;
        public double[] y;
        public Function f;
        public int n;
        Random random = new Random();

        public Sample(
            int n, double a, double b, 
            string function, 
            int mainPersent, string mainDistribution, double[] mainDistributionParams, 
            int noisePersent ,string noiseDistribution, double[] noiseDistributionParams)
        {
            this.n = n;
            f = new Function("f(x) = " + function);

            sample = new Point[n];
            x = new double[n];
            y = new double[n];

            double t = (b - a) / n;
            t += 0.000001;
            var i = 0;
            for (double x = a; x < b && i < n; x += t, i += 1)
            {
                var point = new Point(
                    x,
                    F(x) +
                    Noise(mainPersent, Distribution.GetValue(mainDistribution, mainDistributionParams)) +
                    Noise(noisePersent, Distribution.GetValue(noiseDistribution, noiseDistributionParams))
                );
                
                this.sample[i] = point;
                this.x[i] = point.x;
                this.y[i] = point.y;
            }
        }

        public void Add(Point point)
        {
            n++;
            Array.Resize(ref sample, n);
            sample[n - 1] = point;
            Array.Sort(sample, (p1, p2) => p1.x.CompareTo(p2.x));

            x = new double[n];
            y = new double[n];
            for (int i = 0; i < n; i++)
            {
                x[i] = sample[i].x;
                y[i] = sample[i].y;
            }
        }

        double Noise(int noisePercent, double value)
        {
            random = new Random();
            int randomNumber = random.Next(0, 101);
            return randomNumber <= noisePercent ? value : 0;
        }

        public void Plot(ref Chart chart)
        {
            chart.Series["data"].Points.Clear();
            foreach (Sample.Point point in sample)
            {
                chart.Series["data"].Points.AddXY(point.x, point.y);
            }

            //var max = x.Max();
            //var min = x.Min();
            //chart.ChartAreas[0].AxisX.Maximum = max;
            //chart.ChartAreas[0].AxisX.Minimum = min;
        }

        public double[] X
        {
            get { return x; }
        }

        public double[] Y
        {
            get { return y; }
        }

        double F(double x)
        {
            return f.calculate(x);
        }
        public IEnumerator GetEnumerator()
        {
            return new SampleEnumerator(sample);
        }
        private class SampleEnumerator : IEnumerator
        {
            private Point[] data;
            private int position = -1;

            public SampleEnumerator(Point[] data)
            {
                this.data = data;
            }

            public object Current
            {
                get
                {
                    return data[position];
                }
            }

            public bool MoveNext()
            {
                position++;
                return (position < data.Length);
            }

            public void Reset()
            {
                position = -1;
            }
        }
        
        static double Round(double val, int n)
        {
            return Convert.ToDouble(val.ToString("n" + n));
        }
    }
}
