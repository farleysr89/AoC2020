using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day13
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
            string[] data = _input.Split('\n');
            int time = int.Parse(data[0]);
            List<string> buses = data[1].Split(",").ToList();
            List<BusLine> busLines = new List<BusLine>();
            foreach (var s in buses)
            {
                if (s == "x") continue;
                busLines.Add(new BusLine { id = int.Parse(s), goal = time });
            }
            var best = busLines.OrderBy(x => x.BoardingTime()).First();
            Console.WriteLine("Solution Part 1 = " + best.BoardingTime() * best.id);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            string[] data = _input.Split('\n');
            List<string> buses = data[1].Split(",").ToList();
            List<BusLine> busLines = new List<BusLine>();
            int index = -1;
            foreach (var s in buses)
            {
                index++;
                if (s == "x") continue;
                busLines.Add(new BusLine { id = int.Parse(s), goal = index });
            }

            long solution = 1;
            long multiplier = 1;
            foreach (var b in busLines)
            {
                solution = Solve(solution, multiplier, b.id, b.goal);
                multiplier *= b.id;
            }
            Console.WriteLine("Solution Part 2 = " + solution);
        }

        static long Solve(long solution, long multiplier, int id, int index)
        {
            while (true)
            {
                solution += multiplier;
                if ((solution + index) % id == 0) break;
            }
            return solution;
        }
    }
    public class BusLine
    {
        public int id;
        public int goal;
        public int BoardingTime()
        {
            return (goal / id + 1) * id - goal;
        }
    }
}
