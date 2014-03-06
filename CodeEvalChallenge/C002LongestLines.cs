//using System;
//using System.IO;
//using System.Linq;
//using System.Collections.Generic;
//
//namespace CodeEvalChallenge
//{
//    public class C002LongestLines
//    {
//        static void Main(string[] args)
//        {
//            if (args.Length <= 0)
//            {
//                Console.WriteLine("Usage: <input filename>");
//                return;
//            }
//            var inputFileLines = File.ReadLines(args[0]);
//              
//            bool firstLine = true;
//            int nLines = 0;
//            var output = new SortedSet<string>(new StringLengthComparer());
//
//            foreach (var line in inputFileLines)
//            {
//                if (firstLine)
//                {
//                    nLines = int.Parse(line);
//                    firstLine = false;
//                    continue;
//                }
//
//                output.Add(line);
//            }
//
//            int count = 0;
//            foreach (var line in output)
//            {
//                Console.WriteLine(line);
//                count++;
//                if (count == nLines)
//                    break;
//            }
//        }
//
//        public class StringLengthComparer : IComparer<string>
//        {
//            #region IComparer implementation
//
//            public int Compare(string x, string y)
//            {
//                if (x == y)
//                    return 0;
//                if (x == null)
//                    return 1;
//                if (y == null)
//                    return -1;
//                return y.Length.CompareTo(x.Length);
//            }
//
//            #endregion
//        }
//    }
//}
