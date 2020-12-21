﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day21
{
    class Program
    {
        static void Main()
        {
            SolvePart1();
            SolvePart2();
        }

        static void SolvePart1()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            Dictionary<string, List<List<string>>> mappings = new Dictionary<string, List<List<string>>>();
            List<List<string>> ingredients = new List<List<string>>();
            foreach (var s in data)
            {
                if (s == "") continue;
                var l = s.Split(" (contains ");
                var i = l[0].Split(" ").ToList();
                ingredients.Add(i);
                var a = l[1].Trim(')').Split(", ");
                foreach (var all in a)
                {
                    if (mappings.ContainsKey(all)) mappings[all].Add(i);
                    else
                    {
                        mappings.Add(all, new List<List<string>> { i });
                    }
                }
            }
            List<string> allergens = new List<string>();
            foreach (var m in mappings)
            {
                List<string> ll = new List<string>();
                foreach (var l in m.Value)
                {
                    if (ll.Count == 0)
                    {
                        ll = l;
                    }
                    else
                    {
                        ll = ll.Intersect(l).ToList();
                    }
                }
                allergens.AddRange(ll);
            }
            int count = 0;
            foreach (var l in ingredients)
            {
                foreach (var i in l)
                {
                    if (!allergens.Contains(i)) count++;
                }
            }
            Console.WriteLine("Total Count = " + count);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
