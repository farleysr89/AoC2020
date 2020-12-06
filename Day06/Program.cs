using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day06
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
            List<HashSet<char>> forms = new List<HashSet<char>>();
            HashSet<char> form = new HashSet<char>();
            foreach(string s in data)
            {
                if(s == "")
                {
                    forms.Add(form);
                    form = new HashSet<char>();
                }
                else
                {
                    foreach(char c in s)
                    {
                        form.Add(c);
                    }
                }
            }
            Console.WriteLine("Count = " + forms.Select(f => f.Count).Sum());
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            List<List<HashSet<char>>> groups = new List<List<HashSet<char>>>();
            List<HashSet<char>> forms = new List<HashSet<char>>();
            HashSet<char> form = new HashSet<char>();
            foreach (string s in data)
            {
                if (s == "")
                {
                    groups.Add(forms);
                    forms = new List<HashSet<char>>();
                }
                else
                {
                    foreach (char c in s)
                    {
                        form.Add(c);
                    }
                    forms.Add(form);
                    form = new HashSet<char>();
                }
            }
            int count = 0;
            foreach(var g in groups)
            {
                var f = g.First();
                foreach(char c in f)
                {
                    if(g.All(a => a.Contains(c)))
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine("Count = " + count);
        }
    }
}
