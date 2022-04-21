using System;
using System.Collections.Generic;

namespace SameHashCode
{
  internal class Program
  {
    static void Main()
    {
      var strings = GenerateStrings();

      Console.WriteLine($"Strings \"{strings.s1}\", \"{strings.s2}\", \"{strings.s3}\" have the hashcode {strings.s1.GetHashCode()}");

      Console.WriteLine($"Test {(TestStrings(strings.s1, strings.s2, strings.s3) ? "succeeded" : "failed")}");
    }

    private static (string s1, string s2, string s3) GenerateStrings()
    {
      //The average count of hascodes generated before having a positive match is about 4 000 000
      var hashCodes = new Dictionary<int, List<string>>(4000000);

      int i = 0;

      while (true)
      {
        //Generate a string, we could use other methods such as Random, Path.GetRandomFileName, Guid.NewGuid
        string str = (i++).ToString();
        int hashCode = str.GetHashCode();

        //We keep a list of strings for a given hashcode
        List<string> strings;
        if (!hashCodes.TryGetValue(hashCode, out strings))
          hashCodes[hashCode] = strings = new List<string>(3);

        strings.Add(str);

        //Once we have a list of three strings, we have a match
        if (strings.Count == 3)
          return (strings[0], strings[1], strings[2]);
      }
    }

    private static bool TestStrings(string stringA, string stringB, string stringC)
    {
      return stringA.GetHashCode() == stringB.GetHashCode() && !String.Equals(stringA, stringB) &&
             stringB.GetHashCode() == stringC.GetHashCode() && !String.Equals(stringB, stringC) &&
             !String.Equals(stringA, stringC);

    }
  }
}
