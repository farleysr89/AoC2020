using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day07
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
            List<string >data = _input.Split('\n').ToList();
            List<Bag> bags = new List<Bag>();
            foreach(string s in data)
            {
                Bag bag = new Bag();
                var line = s.Split(" bags contain ");
                bag.color = line[0];
                var output = line[1].Split(", ");
                foreach(string x in output)
                {
                    var y = x.Split(" ");
                    if (y[0] != "no")
                    {
                        bag.containedBags.Add(new Output { count = int.Parse(y[0]), color = y[1] + " " + y[2] });
                    }
                }
                bags.Add(bag);
            }
            foreach(var b in bags)
            {
                List<Output> outs = new List<Output>();
                foreach(var o in b.containedBags)
                {
                    var tmp = bags.First(x => x.color == o.color);
                    var tmp2 = new Output {color = tmp.color, containedBags = tmp.containedBags, count = o.count };
                    outs.Add(tmp2);
                }
                b.containedBags = outs;
            }
            HashSet<string> solutions = new HashSet<string>();
            foreach (var b in bags)
            {
                HashSet<string> candidates = new HashSet<string>();
                solutions.UnionWith(ProcessBag(b, solutions, candidates));
            }
            Console.WriteLine("Possibilities = " + solutions.Count);

        }
        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
        }

        static HashSet<string> ProcessBag(Bag b,HashSet<string> solutions, HashSet<string> candidates)
        {
            if (solutions.Contains(b.color) || b.color == "shiny gold")
            {
                solutions.UnionWith(candidates);
                return solutions;
            }
            if (b.containedBags.Count == 0)
            {
                return new HashSet<string>();
            }
            if (b.containedBags.Any(o => o.color == "shiny gold"))
            {
                solutions.UnionWith(candidates);
                solutions.Add(b.color);
                return solutions;
            }
            foreach(var o in b.containedBags)
            {
                var tmp = new HashSet<string>(candidates);
                tmp.Add(b.color);
                solutions.UnionWith(ProcessBag(o, solutions, tmp));
            }
            return solutions;
        }
    }
    class Bag
    {
        public string color;
        public List<Output> containedBags = new List<Output>();
    }

    class Output : Bag
    {
        public int count;
    }
}
