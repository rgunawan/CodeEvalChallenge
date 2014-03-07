using System;
using System.IO;
using System.Collections.Generic;

namespace CodeEvalChallenge
{
    public class C024StringSearching
    {
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                var strings = line.Split(new [] { ',' });

                bool stringFound = Match(strings[0], strings[1]);

                if (stringFound)
                    Console.WriteLine("true");
                else
                    Console.WriteLine("false");
            }
        }

        static IEnumerable<string> GetPatterns(string pattern)
        {
            var output = new List<string>();
            var chunk = new List<char>();

            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] == '\\' && pattern.Length > i + 1 && pattern[i + 1] == '*')
                {
                    chunk.Add('*');
                    i++;
                }
                else if (pattern[i] == '*')
                {
                    if (chunk.Count > 0)
                    {
                        output.Add(string.Join("", chunk));
                        chunk.Clear();
                    }
                }
                else
                {
                    chunk.Add(pattern[i]);
                }                
            }

            if (chunk.Count > 0)
            {
                output.Add(string.Join("", chunk));
            }

            return output;
        }

        static bool Match(string str, string toMatch)
        {
            var patterns = GetPatterns(toMatch);

            int index = 0;
            foreach (var pattern in patterns)
            {
                int foundIndex = Find(str, index, pattern);
                if (foundIndex == -1)
                {
                    return false;
                }
                else
                {
                    index = foundIndex + pattern.Length + 1;
                }
            }

            return true;

        }

        static int Find(string str, int start, string pattern)
        {
            for (int i = start; i < str.Length; i++)
            {
                if (str[i] == pattern[0] && str.Length - i >= pattern.Length)
                {
                    if (FindExact(str, i, pattern))
                        return i;
                }
            }

            return -1;
        }

        static bool FindExact(string str, int start, string pattern)
        {
            for (int i = 0; i < pattern.Length; i++)
            {
                if (str[start + i] != pattern[i])
                    return false;
            }
            return true;
        }
    }
}

