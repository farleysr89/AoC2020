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
            Dictionary<int, List<string>> rules = new Dictionary<int, List<string>>();
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
                        List<string> ff = new List<string>();
                        List<string> ffFinal = new List<string>();
                        foreach (var c in o)
                        {
                            if (!ff.Any())
                            {
                                if (int.TryParse(c, out int x))
                                {
                                    var r = rules[int.Parse(c)];
                                    foreach (var y in r)
                                    {
                                        ff.Add(y);
                                    }
                                }
                                else
                                {
                                    if (c[0] == '|') f += c[0];
                                    else if (char.IsLetter(c[1])) f += c[1];
                                    else Console.WriteLine("Something Broke!");
                                    ff.Add(f);
                                    f = "";
                                }
                            }
                            else
                            {
                                if (int.TryParse(c, out int i))
                                {
                                    var r = rules[int.Parse(c)];
                                    if (r.Count == 1)
                                    {
                                        var ffTmp = new List<string>();
                                        foreach (var m in ff)
                                        {
                                            ffTmp.Add(m + r.First());
                                        }
                                        ff = ffTmp;
                                    }
                                    else
                                    {
                                        var ffTmp = new List<string>();
                                        foreach (var m in r)
                                        {
                                            var ffTmp2 = new List<string>();
                                            foreach (var mm in ff)
                                            {
                                                ffTmp2.Add(mm + m);
                                            }
                                            ffTmp.AddRange(ffTmp2);
                                        }
                                        ff = ffTmp;
                                    }
                                }
                                else if (c[0] == '|')
                                {
                                    ffFinal.AddRange(ff);
                                    ff = new List<string>();
                                }
                                else if (char.IsLetter(c[1]))
                                {
                                    var tmpFF = new List<string>();
                                    foreach (var m in ff)
                                    {
                                        tmpFF.Add(m + c[1]);
                                    }
                                    ff = new List<string>(tmpFF);
                                }
                                else Console.WriteLine("Something Broke!");
                            }

                        }
                        ffFinal.AddRange(ff);
                        rules.Add(int.Parse(l[0]), ffFinal);
                        data.Remove(s);
                    }
                }
                tmpData = new List<string>(data);
            }
            var rule = rules[0];
            int count = 0;
            foreach (var s in messages)
            {
                if (rule.Any(r => r == s)) count++;
            }
            Console.WriteLine("Valid messages Part 1 = " + count);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input2.txt");
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
            Dictionary<int, List<string>> rules = new Dictionary<int, List<string>>();
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
                        List<string> ff = new List<string>();
                        List<string> ffFinal = new List<string>();
                        foreach (var c in o)
                        {
                            if (!ff.Any())
                            {
                                if (int.TryParse(c, out int x))
                                {
                                    var r = rules[int.Parse(c)];
                                    foreach (var y in r)
                                    {
                                        ff.Add(y);
                                    }
                                }
                                else
                                {
                                    if (c[0] == '|') f += c[0];
                                    else if (char.IsLetter(c[1])) f += c[1];
                                    else Console.WriteLine("Something Broke!");
                                    ff.Add(f);
                                    f = "";
                                }
                            }
                            else
                            {
                                if (int.TryParse(c, out int i))
                                {
                                    var r = rules[int.Parse(c)];
                                    if (r.Count == 1)
                                    {
                                        var ffTmp = new List<string>();
                                        foreach (var m in ff)
                                        {
                                            ffTmp.Add(m + r.First());
                                        }
                                        ff = ffTmp;
                                    }
                                    else
                                    {
                                        var ffTmp = new List<string>();
                                        foreach (var m in r)
                                        {
                                            var ffTmp2 = new List<string>();
                                            foreach (var mm in ff)
                                            {
                                                ffTmp2.Add(mm + m);
                                            }
                                            ffTmp.AddRange(ffTmp2);
                                        }
                                        ff = ffTmp;
                                    }
                                }
                                else if (c[0] == '|')
                                {
                                    ffFinal.AddRange(ff);
                                    ff = new List<string>();
                                }
                                else if (char.IsLetter(c[1]))
                                {
                                    var tmpFF = new List<string>();
                                    foreach (var m in ff)
                                    {
                                        tmpFF.Add(m + c[1]);
                                    }
                                    ff = new List<string>(tmpFF);
                                }
                                else Console.WriteLine("Something Broke!");
                            }

                        }
                        ffFinal.AddRange(ff);
                        rules.Add(int.Parse(l[0]), ffFinal);
                        data.Remove(s);
                    }
                }
                tmpData = new List<string>(data);
            }
            var rule = rules[0];
            int count = 0;
            foreach (var s in messages)
            {
                if (rule.Any(r => r == s)) count++;
            }
            Console.WriteLine("Valid messages Part 2 = " + count);
        }
    }
}
