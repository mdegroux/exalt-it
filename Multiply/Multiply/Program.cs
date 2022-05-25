using System;
using System.Linq;

namespace Multiply
{
  internal class Program
  {
    static void Main(string[] args)
    {
      string product = Multiply( "999","999");
    }
    private static string Multiply(string s1, string s2)
    {
      byte[] result = Enumerable.Repeat((byte)0, s1.Length + s2.Length).ToArray();

      for (int i = s1.Length - 1; i >= 0; i--)
      {
        int carry = 0;
        int n1 = s1[i] - '0';
        int s1Offset = s1.Length - 1 - i;

        for (int j = s2.Length - 1; j >= 0; j--)
        {
          int n2 =s2[j] - '0';
          int s2Offset = s2.Length - 1 - j;

          int product = n1 * n2;
          int sum = product + carry + result[result.Length - s1Offset - s2Offset -1];

          carry = sum / 10;

          result[result.Length - s1Offset - s2Offset -1] = (byte)(sum % 10);
        }

        if (carry > 0)
          result[result.Length - s1Offset - s2.Length -1] += (byte)carry;
      }

      int startIndex = 0;
      while(result[startIndex] == 0)
        startIndex++;

      return new string( result.TakeLast(result.Length - startIndex).Select(c=> (char)(c + '0')).ToArray());
    }
  }
}
