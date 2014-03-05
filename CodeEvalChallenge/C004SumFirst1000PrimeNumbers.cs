using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenge
{
    class C004SumFirst1000PrimeNumbers
    {
        static void Main(string[] args)
        {
            var output = GetPrimes(1000);

            Console.WriteLine(output.Aggregate((i, sum) => sum + i));
        }

        private static IEnumerable<uint> GetPrimes(uint totalCount)
        {
            uint i = 2;
            int count = 0;

            while (count < totalCount)
            {
                if (IsPrime(i))
                {
                    LastKnownPrimes.Add(i);
                    yield return i;
                    count++;
                }
                i++;
            }
        }

        private static IList<uint> LastKnownPrimes = new List<uint>();

        static IEnumerable<uint> GettKnownPrimes(uint seed)
        {
            if (LastKnownPrimes.Count == 0)
                yield break;

            for (int i = 0; i < LastKnownPrimes.Count; i++)
            {
                if (LastKnownPrimes[i] < seed)
                {
                    yield return LastKnownPrimes[i];
                }
                else
                {
                    break;
                }
            }
        }

        private static bool IsPrime(uint i)
        {
            for (int j = 0; j < LastKnownPrimes.Count; j++)
            {
                if (i % LastKnownPrimes[j] == 0)
                    return false;
            }

            return true;
        }
    }
}
