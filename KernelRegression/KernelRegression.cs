using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace KernelRegression
{
    public static class KernelRegression
    {
        public static double[] Regression(double[] x, double[] y, double h)
        {
            // Расчет ядерной регрессии
            double[] ySmoothed = new double[y.Length];
            for (int i = 0; i < x.Length; i++)
            {
                double sumWeights = 0.0;
                double sumWeightedY = 0.0;
                for (int j = 0; j < x.Length; j++)
                {
                    double weight = Kernel((x[j] - x[i]) / h);
                    sumWeights += weight;
                    sumWeightedY += weight * y[j];
                }
                ySmoothed[i] = sumWeightedY / sumWeights;
            }

            return ySmoothed;
        }

        // Ядерная функция
        private static double Kernel(double u)
        {
            return Math.Exp(-0.5 * u * u) / Math.Sqrt(2.0 * Math.PI);
        }

        public static double[] Regression(ref Sample sample, double h, string kernel)
        {
            var n = sample.n;
            double[] smoothedY = new double[sample.n];

            for (int i = 0; i < n; i++)
            {
                double x = sample.x[i];
                double numerator = 0;
                double denominator = 0;

                for (int j = 0; j < n; j++)
                {
                    double xi = sample.x[j];
                    double yi = sample.y[j];
                    double kernelResult;

                    // Вычисляем значение ядра в зависимости от выбранного типа
                    switch (kernel)
                    {
                        case "gaussian":
                            kernelResult = GaussianKernel((x - xi) / h);
                            break;

                        case "epanechnikov":
                            kernelResult = EpanechnikovKernel((x - xi) / h);
                            break;

                        case "triangular":
                            kernelResult = TriangularKernel((x - xi) / h);
                            break;

                        // Можно добавить другие типы ядер

                        default:
                            throw new ArgumentException("Неизвестный вид ядра.");
                    }

                    numerator += kernelResult * yi;
                    denominator += kernelResult;
                }

                smoothedY[i] = numerator / denominator;
            }

            return smoothedY;
        }

        // Функции ядер

        private static double GaussianKernel(double u)
        {
            return Math.Exp(-0.5 * u * u) / Math.Sqrt(2 * Math.PI);
        }

        private static double EpanechnikovKernel(double u)
        {
            return Math.Abs(u) <= 1 ? 0.75 * (1 - u * u) : 0;
        }

        private static double TriangularKernel(double u)
        {
            return Math.Abs(u) <= 1 ? 1 - Math.Abs(u) : 0;
        }


        public static void Plot(ref Sample sample, string kernel, double h, ref Chart chart)
        {
            int n = sample.n;

            var ySmoothed = Regression(ref sample, h, kernel);



            chart.Series["regression"].Points.Clear();
            for (int i = 0; i < n; i++)
            {
                chart.Series["regression"].Points.AddXY(sample.x[i], ySmoothed[i]);
            }
        }
    }
}
