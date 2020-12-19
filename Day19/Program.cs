using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day19
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
            List<string> messages = new List<string>();
            var tmpData = new List<string>(data);
            bool middle = false;
            foreach (var s in tmpData)
            {
                if (s == "")
                {
                    middle = true;
                    data.Remove(s);
                    continue;
                }
                else if (middle)
                {
                    messages.Add(s);
                    data.Remove(s);
                }
            }
            Dictionary<int, string> rules = new Dictionary<int, string>();
            tmpData = new List<string>(data);
            while (data.Count > 0)
            {
                foreach (var s in tmpData)
                {
                    var l = s.Split(": ");
                    var o = l[1].Split(" ");
                    if (o.All(c => (int.TryParse(c, out int i) && rules.ContainsKey(int.Parse(c)) ||
                                    (c.Length == 3 && char.IsLetter(c[1])) || c[0] == '|')))
                    {
                        string f = "";
                        foreach (var c in o)
                        {
                            if (int.TryParse(c, out int i)) f += rules[int.Parse(c)];
                            else if (c[0] == '|') f += c[0];
                            else if (char.IsLetter(c[1])) f += c[1];
                            else Console.WriteLine("Something Broke!");

                        }
                        rules.Add(int.Parse(l[0]), f);
                        data.Remove(s);
                    }
                }
                tmpData = new List<string>(data);
            }
            var rule = rules[0];
            int count = 0;
            foreach (var s in messages)
            {
                //Figure out matching
            }
            Console.WriteLine("");
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
