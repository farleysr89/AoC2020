using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day23
{
    class Program
    {
        static void Main()
        {
            SolvePart1();
            SolvePart2();
        }

        static void SolvePart1()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            string s = data[0];
            int[] cups = new int[9];
            int index = 0;
            foreach (char c in s)
            {
                cups[index] = int.Parse(c.ToString());
                index++;
            }
            var cur = cups.First();
            var dest = cur == 1 ? 9 : cur - 1;
            int goal = 100;
            index = 0;
            for (int i = 0; i < goal; i++)
            {
                string origS = s;
                string moves = "";
                for (int x = 0; x < 3; x++)
                {
                    moves += s[index + 1];
                    s = s.Remove(index + 1, 1);
                }
                while (!s.Contains(dest.ToString()))
                {
                    dest = dest == 1 ? 9 : dest - 1;
                }
                s = s.Insert(s.IndexOf(dest.ToString()) + 1, moves);
                s = ShiftString(s);
                cur = int.Parse(s[0].ToString());
                dest = cur == 1 ? 9 : cur - 1;
            }
            while (s[0] != '1')
            {
                s = ShiftString(s);
            }
            Console.WriteLine("Final Output is " + s[1..]);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            Console.WriteLine("");
        }
        // Function from here: https://stackoverflow.com/questions/15053461/shifting-a-string-in-c-sharp
        public static string ShiftString(string t)
        {
            return t[1..] + t.Substring(0, 1);
        }
    }
}
