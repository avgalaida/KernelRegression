using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System;

namespace KernelRegression
{
    public static class Distribution
    {
        static Random rand = new Random();
        public static double Gaussian(double mu ,double sigma)
        {
            rand = new Random();
            var randNum = rand.NextDouble();
            var z = Math.Sqrt(-2.0 * Math.Log(randNum)) * Math.Sin(2.0 * Math.PI * rand.NextDouble());
            return mu + (sigma * z);
        }
        public static double Cauchy(double x0, double gamma)
        {
            rand = new Random();
            var randNum = rand.NextDouble();
            var x = x0 + gamma * Math.Tan(Math.PI * (randNum - 0.5));
            return x;
        }

        public static double Laplace(double mu, double b)
        {
            rand = new Random();
            var randNum = rand.NextDouble();
            var u = randNum < 0.5 ? Math.Log(2.0 * randNum) : -Math.Log(2.0 - 2.0 * randNum);
            var x = mu - b * Math.Sign(u) * Math.Log(1.0 - 2.0 * Math.Abs(u));
            return x;
        }

        public static double GetValue(string distribution, double[] parameters)
        {
            switch (distribution)
            {
                case "Gaussian":
                    return Gaussian(parameters[0], parameters[1]);

                case "Cauchy":
                    return Cauchy(parameters[0], parameters[1]);

                case "Laplace":
                    return Laplace(parameters[0], parameters[1]);

                default:
                    throw new ArgumentException("Неизвестный вид распределения.");
            }
        }
    }
}
