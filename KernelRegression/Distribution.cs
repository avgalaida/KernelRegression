using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System;

namespace KernelRegression
{
    public static class Distribution
    {
        static Random rand = new Random();
        public static double Gaussian(double mu ,double sigma)
        {
            var z = Math.Sqrt(-2.0 * Math.Log(rand.NextDouble())) * Math.Sin(2.0 * Math.PI * rand.NextDouble());
            return mu + (sigma * z);
        }
        public static double Cauchy(double x0, double gamma)
        {
            var randNum = rand.NextDouble();
            var x = x0 + gamma * Math.Tan(Math.PI * (randNum - 0.5));
            return x;
        }

        public static double Laplace(double mu, double b)
        {
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
                    var normal = new MathNet.Numerics.Distributions.Normal(parameters[0], parameters[1]);
                    return normal.Sample();
                case "Cauchy":
                    var cauchy = new MathNet.Numerics.Distributions.Cauchy(parameters[0], parameters[1]);   
                    return cauchy.Sample();

                case "Laplace":
                    var laplace = new MathNet.Numerics.Distributions.Laplace(parameters[0], parameters[1]); 
                    return laplace.Sample();
            }

            return 0;
        }
    }
}
