using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenge
{
    class FizzBuzz
    {
        //static void Main(string[] args)
        //{
        //    if (args.Length <= 0)
        //    {
        //        Console.WriteLine("Usage: <input filename>");
        //        return;
        //    }
        //    var inputFileLines = File.ReadLines(args[0]);

        //    bool firstLine = true;
        //    foreach (var line in inputFileLines)
        //    {
        //        if (firstLine)
        //        { firstLine = false; }
        //        else
        //        { Console.WriteLine(string.Empty); }

        //        var param = GetParameters(line);

        //        for (int i = 1; i <= param.NumberCount; i++)
        //        {
        //            if (i > 1) Console.Write(" ");

        //            bool isFizz = false;
        //            bool isBuzz = false;

        //            if (i % param.Divisor0 == 0)
        //            {
        //                isFizz = true;
        //                Console.Write("F");
        //            }

        //            if (i % param.Divisor1 == 0)
        //            {
        //                isBuzz = true;
        //                Console.Write("B");
        //            }

        //            if (!isFizz && !isBuzz)
        //            { Console.Write(i); }
        //        }


        //    }

        //}

        //private static Parameters GetParameters(string line)
        //{
        //    var args = line.Split(new[] { ' ' }, 3);
        //    return new Parameters
        //    {
        //        Divisor0 = int.Parse(args[0]),
        //        Divisor1 = int.Parse(args[1]),
        //        NumberCount = int.Parse(args[2])
        //    };
        //}

        //public struct Parameters
        //{
        //    public int Divisor0 { get; set; }
        //    public int Divisor1 { get; set; }
        //    public int NumberCount { get; set; }
        //}
    }
}
