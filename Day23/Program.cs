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
            var next = cur == 1 ? 9 : cur - 1;
            int goal = 10;
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
                while (!s.Contains(next.ToString()))
                {
                    next = next == 1 ? 9 : next - 1;
                }
                Console.WriteLine(origS);
                Console.WriteLine(moves);
                Console.WriteLine(next);
                Console.WriteLine("------------------");
                var nextIndex = s.IndexOf(next.ToString());
                s = s.Remove(nextIndex, 1);
                s = next.ToString() + moves + s[1..] + s[0];
                cur = int.Parse(s[0].ToString());
                next = cur == 1 ? 9 : cur - 1;
            }
            Console.WriteLine("Final Output is " + s);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
