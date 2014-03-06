using System;
using System.IO;

namespace CodeEvalChallenge
{
    public class C052TextDollar
    {
        static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                Console.WriteLine(GetText(int.Parse(line)));
            }
        }

        static string GetText(int i)
        {
            var dollarText = i > 1 ? "Dollars" : "Dollars"; // the spec says always plural ...
            var output = string.Empty;
            output += Textify(i, 6, "Million");
            output += Textify(i, 3, "Thousand");
            output += TextifyHundreds(i % 1000);
            return output + dollarText;
        }

        static string Textify(int i, int minPower, string text)
        {
            int lowerLimit = (int)Math.Pow(10, minPower);
            if (i < (lowerLimit))
                return string.Empty;
            int number = (i % (1000 * lowerLimit)) / lowerLimit;

            var numberText = TextifyHundreds(number);
            if (!string.IsNullOrWhiteSpace(numberText))
                return TextifyHundreds(number) + text;
            return string.Empty;
        }

        static string TextifyHundreds(int i)
        {
            if (i < 100)
                return TextifyTens(i);
            int index = (i % 1000) / 100;
            return Ones[index] + "Hundred" + TextifyTens(i);
        }

        static string TextifyTens(int i)
        {
            int tens = i % 100;
            if (tens >= 20)
                return TextifyRegularTens(tens);
            else
                return TextifyTeens(tens);
        }

        static string TextifyRegularTens(int tens)
        {
            int index = tens / 10;
            return Tens[index] + TextifyOnes(tens);
        }

        static string TextifyTeens(int tens)
        {
            return Ones[tens];
        }

        static string TextifyOnes(int i)
        {
            int number = i % 10;

            return number == 0
                    ? string.Empty
                    : Ones[number];
        }

        private static string[] Tens = new [] { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        private static string[] Ones = new [] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
    }
}

