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
            List<string> data = _input.Split('\n').ToList();
            List<Rule> rules = new List<Rule>();
            List<Ticket> tickets = new List<Ticket>();
            bool rulesDone = false;
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
                    if (!rules.Any(r => r.ranges.Any(rr => v >= rr.Item1 && v <= rr.Item2)))
                    {
                        t.valid = false;
                    }
                }
            }
            tickets = tickets.Where(t => t.valid).ToList();
            HashSet<string>[] validators = new HashSet<string>[20];
            var ruleList = rules.Select(r => r.title);
            for (int i = 0; i < 20; i++)
            {
                validators[i] = ruleList.ToHashSet();
            }
            foreach (var t in tickets)
            {
                int i = 0;
                foreach (var v in t.values)
                {
                    foreach (var r in rules.Where(x => validators[i].Contains(x.title)))
                    {
                        if (!r.ranges.Any(rr => v >= rr.Item1 && v <= rr.Item2)) validators[i].Remove(r.title);
                    }
                    i++;
                }
            }
            bool any = true;
            while (any)
            {
                any = false;
                foreach (var v in validators.Where(x => x.Count == 1))
                {
                    foreach (var vv in validators.Where(vv => vv != v && vv.Contains(v.First())))
                    {
                        vv.Remove(v.First());
                        any = true;
                    }
                }
            }
            long departTotal = 1;
            var tick = tickets.Where(t => t.mine).First();
            for (int i = 0; i < 20; i++)
            {
                if (validators[i].First().Contains("departure")) departTotal *= tick.values[i];
            }
            Console.WriteLine("Invalid total = " + departTotal);
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
        public bool valid = true;
    }
}
