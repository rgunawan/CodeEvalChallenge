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

                if (output.Count > 0)
                {
                    Console.WriteLine(String.Join(",", output));
                }
            }
        }

        private static IList<uint> GetPrimes(uint seed)
        {
            var output = new List<uint>();           

            var lastKnown = GettKnownPrimes(seed);

            uint start;
            if (lastKnown.Count > 0)
            {
                output.AddRange(lastKnown);
                start = lastKnown.Last() + 1;
            }
            else
            {
                start = 2;
            }

            for (uint i = start; i < seed; i++)
            {
                if (IsPrime(i))
                {
                    LastKnownPrimes.Add(i);
                    output.Add(i);
                }
            }

            return output;
        }

        private static IList<uint> LastKnownPrimes = new List<uint>();

        static IList<uint> GettKnownPrimes(uint seed)
        {
            var output = new List<uint>();
            if (LastKnownPrimes.Count == 0)
                return output;

            for (int i = 0; i < LastKnownPrimes.Count; i++)
            {
                if (LastKnownPrimes[i] < seed)
                {
                    output.Add(LastKnownPrimes[i]);
                }
                else
                {
                    break;
                }
            }

            return output;
        }

        private static bool IsPrime(uint i)
        {
            for (int j = 0; j < LastKnownPrimes.Count; j++)
            {
                if (i % LastKnownPrimes[j] == 0)
                    return false;
            }
//            for (uint j = 2; j < i; j++)
//            {
//                if (i % j == 0)
//                {
//                    return false;
//                }
//            }

            return true;
        }
    }
}
