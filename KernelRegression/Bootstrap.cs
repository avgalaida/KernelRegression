using MathNet.Numerics.Distributions;
using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernelRegression
{
    static public class Bootstrap
    {
        static Random rand = new Random();
        public static double MSE(double[] actual, double[] predicted)
        {
            double sumSquaredError = 0;
            for (int i = 0; i < actual.Length; i++)
            {
                double error = predicted[i] - actual[i];
                sumSquaredError += error * error;
            }
            double meanSquaredError = sumSquaredError / actual.Length;
            return meanSquaredError;
        }

        public static double R2(double[] actual, double[] predicted)
        {
            double sumSquaredError = 0;
            double sumSquaredTotal = 0;
            double sumPredicted = 0;
            double sumActual = 0;
            for (int i = 0; i < actual.Length; i++)
            {
                double error = predicted[i] - actual[i];
                sumSquaredError += error * error;
                sumSquaredTotal += (actual[i] - Statistics.Mean(actual)) * (actual[i] - Statistics.Mean(actual));
                sumPredicted += predicted[i];
                sumActual += actual[i];
            }
            double meanPredicted = sumPredicted / actual.Length;
            double meanActual = sumActual / actual.Length;
            double r2 = 1 - (sumSquaredError / sumSquaredTotal);
            if (double.IsNaN(r2) || double.IsInfinity(r2))
            {
                r2 = 0;
            }
            return r2;
        }

        public static double RMSE(double[] actual, double[] predicted)
        {
            double sumSquaredError = 0;
            for (int i = 0; i < actual.Length; i++)
            {
                double error = predicted[i] - actual[i];
                sumSquaredError += error * error;
            }
            double meanSquaredError = sumSquaredError / actual.Length;
            double rootMeanSquaredError = Math.Sqrt(meanSquaredError);
            return rootMeanSquaredError;
        }

        public static double MAE(double[] actual, double[] predicted)
        {
            double sumAbsoluteError = 0;
            for (int i = 0; i < actual.Length; i++)
            {
                double error = predicted[i] - actual[i];
                sumAbsoluteError += Math.Abs(error);
            }
            double meanAbsoluteError = sumAbsoluteError / actual.Length;
            return meanAbsoluteError;
        }

        public static Sample.Point[] Bstrp(Sample sample, int numIterations, double h, string kernel)
        {
            var di = new Sample.Point[sample.n];
            double[] coefficients = new double[sample.n];
            double[][] bootstrapCoefficients = new double[numIterations][];
            for (int i = 0; i < numIterations; i++)
            {
                bootstrapCoefficients[i] = new double[sample.n];
            }

            Parallel.For(0, numIterations, i =>
            {
                Sample bootstrapSample = sample.Bootstrap();
                double[] ySmoothed = KernelRegression.Regression(bootstrapSample, h, kernel);
                for (int j = 0; j < sample.n; j++)
                {
                    bootstrapCoefficients[i][j] = ySmoothed[j] / sample.y[j];
                }
            });

            double lowerBound = 0, upperBound = 0;
            for (int i = 0; i < sample.n; i++)
            {
                double[] sortedCoefficients = bootstrapCoefficients.Select(j => j[i]).OrderBy(j => j).ToArray();
                lowerBound = sortedCoefficients[(int)(numIterations * 0.05)];
                upperBound = sortedCoefficients[(int)(numIterations * 0.95)];
                di[i] = new Sample.Point(lowerBound, upperBound);
            }

            return di;
        }

    }
}
