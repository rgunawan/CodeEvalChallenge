//using System;
//using System.IO;
//
//namespace CodeEvalChallenge
//{
//    public class C007PrefixExpressions
//    {
//        static void Main(string[] args)
//        {
//            var lines = File.ReadLines(args[0]);
//
//            foreach (var line in lines)
//            {
//                int nextIndex;
//                Console.WriteLine(Evaluate(line.Split(' '), 0, out nextIndex));
//            }
//        }
//
//        static float Evaluate(string[] input, int index, out int nextIndex)
//        {
//            var exp = input[index];
//            if (exp == "*")
//            {
//                return Evaluate(input, index + 1, out nextIndex) * Evaluate(input, nextIndex, out nextIndex);
//            }
//            else if (exp == "/")
//            {
//                return Evaluate(input, index + 1, out nextIndex) / Evaluate(input, nextIndex, out nextIndex);
//            }
//            else if (exp == "+")
//            {
//                return Evaluate(input, index + 1, out nextIndex) + Evaluate(input, nextIndex, out nextIndex);
//            }
//            else
//            {
//                nextIndex = index + 1;
//                return int.Parse(exp);
//            }
//        }
//    }
//}
//
