//using System;
//using System.IO;
//using System.Collections.Generic;
//
//namespace CodeEvalChallenge
//{
//    public class C009StackImplementation
//    {
//        static void Main(string[] args)
//        {
//            foreach (var line in File.ReadLines(args[0]))
//            {
//                var stack = new MyStack();
//                foreach (var item in line.Split(new [] {' '}))
//                {
//                    stack.Push(int.Parse(item));
//                }
//
//                var output = new List<int>();
//                var alt = true;
//                while (stack.Count > 0)
//                {
//                    var item = stack.Pop();
//                    if (alt && item.HasValue)
//                    {
//                        output.Add(item.Value);
//                    }
//
//                    alt = !alt;
//                }
//
//                if (output.Count > 0)
//                {
//                    Console.WriteLine(string.Join(" ", output));
//                }
//            }
//        }
//    }
//
//    public class MyStack
//    {
//        private List<int> _backing = new List<int>();
//
//        public int Count
//        {
//            get { return _backing.Count; }
//        }
//
//        public void Push(int item)
//        {
//            _backing.Add(item);
//        }
//
//        public int? Pop()
//        {
//            if (_backing.Count > 0)
//            {
//                var output = _backing[_backing.Count - 1];
//                _backing.RemoveAt(_backing.Count - 1);
//                return output;
//            }
//            return null;
//        }
//    }
//}
//
