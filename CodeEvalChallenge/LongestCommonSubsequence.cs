using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenge
{
    class LongestCommonSubsequence
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.WriteLine("Usage: <input filename>");
                return;
            }
            var inputFileLines = File.ReadLines(args[0]);

            foreach (var line in inputFileLines)
            {
                var param = GetParameters(line);

                var output = FindLcs(param.Seq0, param.Seq1);

                if (!string.IsNullOrWhiteSpace(output))
                { Console.WriteLine(output); }
            }
        }

        private static string FindLcs(string seq0, string seq1)
        {
            var output = string.Empty;
            for (int i = 0; i < seq0.Length; i++)
            {
                var cs = FindCommonString(seq0.Substring(i), seq1);
                if (cs.Length > output.Length)
                { output = cs; }
            }

            return output;
        }

        private static string FindCommonString(string substring, string seq1)
        {
            var output = string.Empty;
            foreach (char t in substring)
            {
                var index = seq1.IndexOf(t);
                if (index > -1)
                {
                    output += t;
                    if (index < seq1.Length)
                    { seq1 = seq1.Substring(index + 1); }
                    else
                    {
                        break;
                    }
                }
            }
            return output;
        }

        private static Parameters GetParameters(string line)
        {
            var args = line.Split(new[] { ';' }, 2);
            return new Parameters
            {
                Seq0 = args[0],
                Seq1 = args[1]
            };
        }

        public struct Parameters
        {
            public string Seq0 { get; set; }
            public string Seq1 { get; set; }
        }
    }
}
