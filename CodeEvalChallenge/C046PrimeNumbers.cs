using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenge
{
    class C046PrimeNumbers
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.WriteLine("Usage: <input filename>");
                return;
            }
            var inputFileLines = File.ReadLines(args[0]);

            foreach (var line in inputFileLines.Where(l => !string.IsNullOrWhiteSpace(l)))
            {
                var output = GetPrimes(uint.Parse(line));

                if (!string.IsNullOrWhiteSpace(output))
                {
                    Console.WriteLine(output);
                }
            }
        }

        private static string GetPrimes(uint seed)
        {
            string output = string.Empty;
            bool first = true;
            for (uint i = 2; i < seed; i++)
            {
                if (IsPrime(i))
                {
                    if (first)
                    {
                        first = false;
                        output = i + string.Empty;
                    }
                    else
                    { output += "," + i; }
                }
            }

            return output;
        }

        private static bool IsPrime(uint i)
        {
            for (uint j = 2; j < i; j++)
            {
                if (i % j == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
