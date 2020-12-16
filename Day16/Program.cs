using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day16
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
            List<string> data = _input.Split('\n').ToList();
            List<Rule> rules = new List<Rule>();
            List<Ticket> tickets = new List<Ticket>();
            bool rulesDone = false;
            int invalidTotal = 0;
            foreach (var s in data)
            {
                if (rulesDone == false)
                {
                    if (s == "") rulesDone = true;
                    else
                    {
                        var line = s.Split(":");
                        var name = line[0];
                        line = line[1].Trim().Split(" ");
                        var first = line[0].Split("-").Select(i => int.Parse(i)).ToArray();
                        var second = line[2].Split("-").Select(i => int.Parse(i)).ToArray();
                        var r = new Rule { title = name };
                        r.ranges.Add(new Tuple<int, int>(first[0], first[1]));
                        r.ranges.Add(new Tuple<int, int>(second[0], second[1]));
                        rules.Add(r);
                    }
                }
                else
                {
                    if (s == "" || s == "your ticket:" || s == "nearby tickets:") continue;
                    if (!tickets.Any())
                    {
                        var vals = s.Split(",");
                        tickets.Add(new Ticket { mine = true, values = vals.Select(i => int.Parse(i)).ToArray() });
                    }
                    else
                    {
                        var vals = s.Split(",");
                        tickets.Add(new Ticket { mine = false, values = vals.Select(i => int.Parse(i)).ToArray() });
                    }
                }
            }
            foreach (var t in tickets.Where(x => !x.mine))
            {
                foreach (var v in t.values)
                {
                    if (!rules.Any(r => r.ranges.Any(rr => v >= rr.Item1 && v <= rr.Item2))) invalidTotal += v;
                }
            }
            Console.WriteLine("Invalid total = " + invalidTotal);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
        }
    }
    class Rule
    {
        public string title;
        public List<Tuple<int, int>> ranges = new List<Tuple<int, int>>();
    }
    class Ticket
    {
        public bool mine;
        public int[] values = new int[20];
    }
}
