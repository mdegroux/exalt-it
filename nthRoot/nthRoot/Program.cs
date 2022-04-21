using System;

namespace nthRoot
{
  internal class Program
  {
    static void Main(string[] args)
    {
      TestNthRoot(3404825447, 7, 23);
      TestNthRoot(203733960.46299, 5, 45.9);
    }

    public static void TestNthRoot(double number, int n, double result)
    {
      var nth = GetNthRoot(number, n);
      Console.WriteLine($"root {n} of {number} is {nth}");
      Console.WriteLine($"Test {(nth == result ? "succeeded" : "failed")}");
    }


    public static double GetNthRoot(double number, int n)
    {
      //This algorithm is based on Newton's method: https://en.wikipedia.org/wiki/Nth_root#Computing_principal_roots

      // always the given number, simply return it
      if (n == 1)
        return number;

      //We initialize the seed (x0)
      double x = 1;

      //next we iterate until we have a good precision
      double delta;
      do
      {
        delta = x; // keep previous iteration value
        x = (((n - 1d) / n) * x) + (number / (n * Pow(x, n - 1))); // compute xn iteration
        delta -= x; //keep compute delta with previous iteration and current iteration
      }
      while (Abs(delta) > 0.0000001); //continue while it's imprecise

      return x;
    }

    private static double Pow(double number, int n)
    {
      double result = 1;
      for (int i = 1; i <= n; i++)
      {
        result *= number;
      }

      return result;
    }

    private static double Abs(double number)
    {
      if (number > 0)
        return number;

      return number * -1;
    }
  }
}
