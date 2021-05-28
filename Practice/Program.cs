using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Practice
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            //var s = new string[] {"w","e","w","e","w","e","w","e","w","e","w","e"};
            //IsValidWalk(s);
            //int[] numbers = {5, 8, 12, 19, 22};
            //Console.WriteLine(SumTwoSmallestNumbers(numbers));
            //return (int)(1 + (Math.Sqrt(5) / 2) - ((1 - (Math.Sqrt(5) / 2)) / Math.Sqrt(5)));
            //Console.WriteLine(ValidatePin("123\n"));
        }

        /// <summary>
        /// Complete the solution so that it reverses the string passed into it.
        /// </summary>
        public static string ReverseString(string str)
        {
            var a = str.ToCharArray();
            Array.Reverse(a);
            return new string(a);
        }

        /// <summary>
        /// An isogram is a word that has no repeating letters,
        /// consecutive or non-consecutive. Implement a function that
        /// determines whether a string that contains only letters is an isogram.
        /// Assume the empty string is an isogram. Ignore letter case.
        /// </summary>
        public static bool IsIsogram(string str)
        {
            System.Collections.Generic.List<char> list = new System.Collections.Generic.List<char>();
            foreach (char l in str.ToLower())
            {
                if (list.Contains(l))
                { return false; }
                else
                { list.Add(l); }
            }
            return true;
        }

        /// <summary>
        /// You arrived ten minutes too early to an appointment,
        /// so you decided to take the opportunity to go for a short walk.
        /// The city provides its citizens with a Walk Generating App on their phones -- everytime you press the button
        /// it sends you an array of one-letter strings representing directions to walk (eg. ['n', 's', 'w', 'e']).
        /// You always walk only a single block for each letter (direction) and you know it takes you one minute to traverse one city block,
        /// so create a function that will return true if the walk the app gives you will
        /// take you exactly ten minutes(you don't want to be early or late!)
        /// and will, of course, return you to your starting point. Return false otherwise.
        /// </summary>
        public static bool IsValidWalk(string[] walk)
        {
            if (walk.Length != 10 )
            { return false; }

            var position = new Vector2(0, 0);
            var dirs = new Dictionary<string, Vector2>
            { { "n", new Vector2(0,  1) }, { "e", new Vector2(1,  0) },
              { "s", new Vector2(0, -1) }, { "w", new Vector2(-1, 0) } };

            foreach (string dir in walk)
            { position += dirs[dir]; }

            return position == new Vector2(0, 0);
        }

        /// <summary>
        /// Create a function that returns the sum of the two lowest
        /// positive numbers given an array of minimum 4 positive integers.
        /// No floats or non-positive integers will be passed.
        /// </summary>
        public static int SumTwoSmallestNumbers(int[] numbers)
        {
            int x = int.MaxValue; int y = int.MaxValue;
            foreach (int n in numbers)
            {
                if (Math.Max(x, y) == x)
                { x = Math.Min(x, n); }
                else
                { y = Math.Min(y, n); }
            }
            return x + y;
        }

        /// <summary>
        /// Write a program that finds the summation of every number from 1 to num.
        /// The number will always be a positive integer greater than 0.
        /// </summary>
        public static int Summation(int num)
        {
            return num * (num + 1) / 2;
        }

        /// <summary>
        /// ATM machines allow 4 or 6 digit PIN codes and PIN codes cannot
        /// contain anything but exactly 4 digits or exactly 6 digits.
        /// </summary>
        public static bool ValidatePin(string pin)
        {
            return new Regex(@"^\d+(?!\n)$").IsMatch(pin) && (pin.Length == 4 || pin.Length == 6);
        }
    }
}