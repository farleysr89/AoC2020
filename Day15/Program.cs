using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day15
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
            List<int> nums = _input.Split(",").Select(s => int.Parse(s)).ToList();
            int count = 1;
            Dictionary<int, Number> calledNums = new Dictionary<int, Number>();
            int prev = 0;
            foreach (var i in nums)
            {
                calledNums.Add(i, new Number { history = new Queue<int>(new[] { count }) });
                count++;
                prev = i;
            }
            while (count <= 2020)
            {
                if (calledNums[prev].history.Count == 1) prev = 0;
                else
                {
                    var occ = calledNums[prev].history.ToArray();
                    var dif = Math.Abs(occ[0] - occ[1]);
                    prev = dif;
                }

                if (calledNums.ContainsKey(prev))
                {
                    calledNums[prev].Add(count);
                }
                else
                {
                    calledNums.Add(prev, new Number { history = new Queue<int>(new[] { count }) });
                }
                count++;
            }
            Console.WriteLine("2020th Number is = " + prev);

        }
        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
        }
    }
    public class Number
    {
        public Queue<int> history = new Queue<int>();
        public void Add(int i)
        {
            if (history.Count < 2) history.Enqueue(i);
            else
            {
                history.Dequeue();
                history.Enqueue(i);
            }
        }
    }
}
