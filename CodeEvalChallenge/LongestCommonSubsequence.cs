//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CodeEvalChallenge
//{
//    class LongestCommonSubsequence
//    {
//        static void Main(string[] args)
//        {
//            if (args.Length <= 0)
//            {
//                Console.WriteLine("Usage: <input filename>");
//                return;
//            }
//            var inputFileLines = File.ReadLines(args[0]);

//            foreach (var line in inputFileLines.Where(l => !string.IsNullOrWhiteSpace(l)))
//            {
//                var param = GetParameters(line);

//                if (string.IsNullOrWhiteSpace(param.Seq0) || string.IsNullOrWhiteSpace(param.Seq1))
//                {
//                    break;
//                }

//                var output = FindLcs(param.Seq0, param.Seq1);

//                if (!string.IsNullOrWhiteSpace(output))
//                {
//                    Console.WriteLine(output);
//                }
//            }
//        }

//        private static string FindLcs(string seq0, string seq1)
//        {
//            var output = string.Empty;

//            for (int i = 0; i < seq0.Length; i++)
//            {
//                var index = seq1.IndexOf(seq0[i]);

//                if (index > -1)
//                {
//                    if (i + 1 < seq0.Length && index + 1 < seq1.Length)
//                    {
//                        var lcs = FindLcs(seq0.Substring(i + 1), seq1.Substring(index + 1));

//                        if (output.Length - 1 < lcs.Length)
//                        {
//                            output = seq0[i] + lcs;
//                        }
//                    }
//                    if (output == string.Empty)
//                    {
//                        output = seq0[i] + string.Empty;
//                    }
//                }
//            }

//            return output;
//        }

//        private static Parameters GetParameters(string line)
//        {
//            var args = line.Split(new[] { ';' }, 2);
//            if (args.Length == 2)
//            {
//                return new Parameters
//                {
//                    Seq0 = args[0],
//                    Seq1 = args[1]
//                };
//            }
//            return new Parameters();
//        }

//        public struct Parameters
//        {
//            public string Seq0 { get; set; }

//            public string Seq1 { get; set; }
//        }
//    }

//}
