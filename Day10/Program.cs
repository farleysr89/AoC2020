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
            Console.WriteLine("Solution to part 1 is : " + ones * threes);
        }
        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<int> data = _input.Split('\n').Select(s => int.Parse(s)).ToList();
            data.Add(0);
            data.Add(data.Max() + 3);
            data.Sort();
            int prev = -1;
            List<List<int>> subGroups = new List<List<int>>();
            List<int> sub = new List<int>();
            foreach(int i in data)
            {
                if (prev == -1)
                {
                    prev = i;
                    sub.Add(i);
                }
                else
                {
                    if(i - prev == 1)
                    {
                        sub.Add(i);
                        prev = i;
                    }
                    else
                    {
                        subGroups.Add(sub);
                        sub = new List<int>();
                        sub.Add(i);
                        prev = i;
                    }
                }
            }
            subGroups.Add(sub);
            long answer = 1;
            foreach(var s in subGroups)
            {
                if(s.Count == 1 || s.Count == 2)
                {
                    continue;
                }
                if(s.Count == 3)
                {
                    answer *= 2;
                    continue;
                }
                if(s.Count == 4)
                {
                    answer *= 4;
                    continue;
                }
                if(s.Count == 5)
                {
                    answer *= 7;
                    continue;
                }
            }
            Console.WriteLine("Solution to part 2 is " + answer);
        }
    }
}
