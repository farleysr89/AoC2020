using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day09
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
            List<int> nums = _input.Split('\n').Select(x => int.Parse(x)).ToList();
        }
        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
        }
    }
}
