//using System;
//using System.Linq;
//using System.Collections.Generic;
//using System.IO;
//
//namespace CodeEvalChallenge
//{
//    public class C014StringPermutations
//    {
//        static void Main(string[] args)
//        {
//            if (args.Length <= 0)
//            {
//                Console.WriteLine("Usage: <input filename>");
//                return;
//            }
//
//            var inputFileLines = File.ReadLines(args[0]);
//
//            foreach (var line in inputFileLines)
//            {
//                var options = line.ToList();
//                options.Sort();
//
//                Console.WriteLine(string.Join(",", GetPermutations(string.Join("", options))));
//            }
//        }
//
//        static IEnumerable<string> GetPermutations(string options)
//        {
//            if (options.Length == 1)
//            {
//                yield return options;
//                yield break;
//            }
//            for (int i = 0; i < options.Length; i++)
//            {
//                var newOptions = options.Substring(0, i) + options.Substring(i + 1);
//
//                foreach (var p in GetPermutations(newOptions))
//                {
//                    yield return options[i]+ p;
//                }
//            }
//        }
//    }
//}