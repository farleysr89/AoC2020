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
            long[] nums = _input.Split('\n').Select(x => long.Parse(x)).ToArray();
            int index = 25;
            int begin = 0;
            bool found = false;
            long n = 0;
            while (!found)
            {
                n = nums[index];
                bool legal = false;
                foreach (long i in nums.Skip(begin).Take(25))
                {
                    int second = 1;
                    foreach(long x in nums.Skip(begin + second).Take(25 - second))
                    {
                        if(i + x == n)
                        {
                            legal = true;
                            break;
                        }
                    }
                    if (legal)
                    {
                        break;
                    }
                    second++;
                }
                if (!legal)
                {
                    found = true;
                    break;
                }
                index++;
                begin++;

            }
            Console.WriteLine("Illegal number is " + n);
        }
        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
        }
    }
}
