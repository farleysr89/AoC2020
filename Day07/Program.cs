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
            //SolvePart1();
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

            //Need to rethink this

            //foreach(var b in bags)
            //{
            //    List<Output> outs = new List<Output>();
            //    foreach(var o in b.containedBags)
            //    {
            //        var tmp = bags.First(x => x.color == o.color);
            //        var tmp2 = new Output {color = tmp.color, containedBags = tmp.containedBags, count = o.count };
            //        outs.Add(tmp2);
            //    }
            //    b.containedBags = outs;
            //}
            HashSet<string> solutions = new HashSet<string>();
            foreach (var b in bags)
            {
                HashSet<string> candidates = new HashSet<string>();
                solutions.UnionWith(ProcessBag(b, solutions, candidates,bags));
            }
            Console.WriteLine("Possibilities = " + solutions.Count);

        }
        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            List<Bag> bags = new List<Bag>();
            foreach (string s in data)
            {
                Bag bag = new Bag();
                var line = s.Split(" bags contain ");
                bag.color = line[0];
                var output = line[1].Split(", ");
                foreach (string x in output)
                {
                    var y = x.Split(" ");
                    if (y[0] != "no")
                    {
                        bag.containedBags.Add(new Output { count = int.Parse(y[0]), color = y[1] + " " + y[2] });
                    }
                }
                bags.Add(bag);
            }

            long count = 0;                
            count = CountBags(bags.First(b => b.color == "vibrant green"), bags, count);            
            Console.WriteLine("Number of bags in one shiny golden bag = " + count);
        }

        static HashSet<string> ProcessBag(Bag b,HashSet<string> solutions, HashSet<string> candidates,List<Bag> bags)
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
                solutions.UnionWith(ProcessBag(bags.First(x => x.color == o.color), solutions, tmp, bags));
            }
            return solutions;
        }

        static long CountBags(Bag b, List<Bag> bags, long count)
        {
            long tmpCount = count;
            if(b.containedBags.Count == 0) return 1;
            foreach (var o in b.containedBags)
            {
                count += CountBags(bags.First(x => x.color == o.color), bags, tmpCount) * o.count;
            }
            return count;
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
