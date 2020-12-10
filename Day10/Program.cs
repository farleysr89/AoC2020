using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            SolvePart1();
            SolvePart2();
        }
        static void SolvePart1()
        {
            string _input = File.ReadAllText("Input.txt");
            List<int> data = _input.Split('\n').Select(s => int.Parse(s)).ToList();
            data.Sort();
            int ones = 0;
            int threes = 1;
            int prev = -1;
            foreach (int i in data)
            {
                if (prev == -1)
                {
                    prev = i;
                    if (prev == 1) ones++;
                    else if (prev == 3) threes++;
                }
                else
                {
                    if (i - prev == 1) ones++;
                    else if (i - prev == 3) threes++;
                    prev = i;
                }
            }
            Console.WriteLine("Solution is : " + ones * threes);
        }
        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
        }
    }
}
