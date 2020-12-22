using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day19
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
            int maxLength = messages.Max(x => x.Length);
            Dictionary<int, HashSet<string>> rules = new Dictionary<int, HashSet<string>>();
            tmpData = new List<string>(data);
            while (data.Count > 0)
            {
                foreach (var s in tmpData)
                {
                    var l = s.Split(": ");
                    var o = l[1].Split(" ");
                    if (o.All(c => c == l[0] || (int.TryParse(c, out int i) && rules.ContainsKey(int.Parse(c)) ||
                                    (c.Length == 3 && char.IsLetter(c[1])) || c[0] == '|')))
                    {
                        string f = "";
                        HashSet<string> ff = new HashSet<string>();
                        HashSet<string> ffFinal = new HashSet<string>();
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
                                        var ffTmp = new HashSet<string>();
                                        foreach (var m in ff)
                                        {
                                            ffTmp.Add(m + r.First());
                                        }
                                        ff = ffTmp;
                                    }
                                    else
                                    {
                                        var ffTmp = new HashSet<string>();
                                        foreach (var m in r)
                                        {
                                            var ffTmp2 = new HashSet<string>();
                                            foreach (var mm in ff)
                                            {
                                                ffTmp2.Add(mm + m);
                                            }
                                            ffTmp.UnionWith(ffTmp2);
                                        }
                                        ff = ffTmp;
                                    }
                                }
                                else if (c[0] == '|')
                                {
                                    ffFinal.UnionWith(ff);
                                    ff = new HashSet<string>();
                                }
                                else if (char.IsLetter(c[1]))
                                {
                                    var tmpFF = new List<string>();
                                    foreach (var m in ff)
                                    {
                                        tmpFF.Add(m + c[1]);
                                    }
                                    ff = new HashSet<string>(tmpFF);
                                }
                                else Console.WriteLine("Something Broke!");
                            }

                        }
                        ffFinal.UnionWith(ff);
                        rules.Add(int.Parse(l[0]), ffFinal);
                        data.Remove(s);
                    }
                }
                tmpData = new List<string>(data);
            }
            var rule = rules[0];
            var rule8 = rules[8];
            var rule42 = rules[42];
            var rule31 = rules[31];
            int count = 0;
            List<string> possibleMatches = new List<string>();
            foreach (var s in messages)
            {
                if (rule.Any(r => r == s)) count++;
                else if (s.Length > 24 && (s.Length - 24) % 8 == 0) possibleMatches.Add(s);
            }
            var tmpPoss = new List<string>(possibleMatches);
            foreach (var s in tmpPoss.Where(x => x.Length == 32))
            {
                var one = s.Substring(0, 8);
                var two = s[8..];
                if (rule8.Any(r => r == one) && rule.Any(r => r == two)) count++;
                possibleMatches.Remove(s);
            }
            tmpPoss = new List<string>(possibleMatches);
            foreach (var s in tmpPoss.Where(x => x.Length == 40))
            {
                var one = s.Substring(0, 8);
                var two = s.Substring(8, 8);
                var three = s[16..];
                if (rule8.Any(r => r == one) && rule8.Any(r => r == two) && rule.Any(r => r == three)) count++;
                else
                {
                    if (RuleCheck(s.Substring(0, 8), rule8) &&
                        RuleCheck(s.Substring(8, 8), rule42) &&
                        RuleCheck(s.Substring(16, 8), rule42) &&
                        RuleCheck(s.Substring(24, 8), rule31) &&
                        RuleCheck(s.Substring(32, 8), rule31)) count++;

                }
                possibleMatches.Remove(s);
            }
            tmpPoss = new List<string>(possibleMatches);
            foreach (var s in tmpPoss.Where(x => x.Length == 48))
            {
                if (RuleCheck(s.Substring(0, 8), rule8) &&
                    RuleCheck(s.Substring(8, 8), rule8) &&
                    RuleCheck(s.Substring(16, 8), rule42) &&
                    RuleCheck(s.Substring(24, 8), rule42) &&
                    RuleCheck(s.Substring(32, 8), rule31) &&
                    RuleCheck(s.Substring(40, 8), rule31)) count++;
                else if (RuleCheck(s.Substring(0, 8), rule8) &&
                         RuleCheck(s.Substring(8, 8), rule8) &&
                         RuleCheck(s.Substring(16, 8), rule8) &&
                         RuleCheck(s.Substring(24, 8), rule8) &&
                         RuleCheck(s.Substring(32, 8), rule42) &&
                         RuleCheck(s.Substring(40, 8), rule31)) count++;
                possibleMatches.Remove(s);
            }
            tmpPoss = new List<string>(possibleMatches);
            foreach (var s in tmpPoss.Where(x => x.Length == 56))
            {
                if (RuleCheck(s.Substring(0, 8), rule8) &&
                    RuleCheck(s.Substring(8, 8), rule8) &&
                    RuleCheck(s.Substring(16, 8), rule8) &&
                    RuleCheck(s.Substring(24, 8), rule8) &&
                    RuleCheck(s.Substring(32, 8), rule8) &&
                    RuleCheck(s.Substring(40, 8), rule42) &&
                    RuleCheck(s.Substring(48, 8), rule31)) count++;
                else if (RuleCheck(s.Substring(0, 8), rule8) &&
                         RuleCheck(s.Substring(8, 8), rule8) &&
                         RuleCheck(s.Substring(16, 8), rule8) &&
                         RuleCheck(s.Substring(24, 8), rule42) &&
                         RuleCheck(s.Substring(32, 8), rule42) &&
                         RuleCheck(s.Substring(40, 8), rule31) &&
                         RuleCheck(s.Substring(48, 8), rule31)) count++;
                else if (RuleCheck(s.Substring(0, 8), rule8) &&
                         RuleCheck(s.Substring(8, 8), rule42) &&
                         RuleCheck(s.Substring(16, 8), rule42) &&
                         RuleCheck(s.Substring(24, 8), rule42) &&
                         RuleCheck(s.Substring(32, 8), rule31) &&
                         RuleCheck(s.Substring(40, 8), rule31) &&
                         RuleCheck(s.Substring(48, 8), rule31)) count++;
                possibleMatches.Remove(s);
            }
            tmpPoss = new List<string>(possibleMatches);
            foreach (var s in tmpPoss.Where(x => x.Length == 64))
            {
                if (RuleCheck(s.Substring(0, 8), rule8) &&
                    RuleCheck(s.Substring(8, 8), rule8) &&
                    RuleCheck(s.Substring(16, 8), rule8) &&
                    RuleCheck(s.Substring(24, 8), rule8) &&
                    RuleCheck(s.Substring(32, 8), rule8) &&
                    RuleCheck(s.Substring(40, 8), rule8) &&
                    RuleCheck(s.Substring(48, 8), rule42) &&
                    RuleCheck(s.Substring(56, 8), rule31)) count++;
                else if (RuleCheck(s.Substring(0, 8), rule8) &&
                         RuleCheck(s.Substring(8, 8), rule8) &&
                         RuleCheck(s.Substring(16, 8), rule8) &&
                         RuleCheck(s.Substring(24, 8), rule8) &&
                         RuleCheck(s.Substring(32, 8), rule42) &&
                         RuleCheck(s.Substring(40, 8), rule42) &&
                         RuleCheck(s.Substring(48, 8), rule31) &&
                         RuleCheck(s.Substring(56, 8), rule31)) count++;
                else if (RuleCheck(s.Substring(0, 8), rule8) &&
                         RuleCheck(s.Substring(8, 8), rule8) &&
                         RuleCheck(s.Substring(16, 8), rule42) &&
                         RuleCheck(s.Substring(24, 8), rule42) &&
                         RuleCheck(s.Substring(32, 8), rule42) &&
                         RuleCheck(s.Substring(40, 8), rule31) &&
                         RuleCheck(s.Substring(48, 8), rule31) &&
                         RuleCheck(s.Substring(56, 8), rule31)) count++;
                possibleMatches.Remove(s);
            }
            tmpPoss = new List<string>(possibleMatches);
            foreach (var s in tmpPoss.Where(x => x.Length == 72))
            {
                if (RuleCheck(s.Substring(0, 8), rule8) &&
                    RuleCheck(s.Substring(8, 8), rule8) &&
                    RuleCheck(s.Substring(16, 8), rule8) &&
                    RuleCheck(s.Substring(24, 8), rule8) &&
                    RuleCheck(s.Substring(32, 8), rule8) &&
                    RuleCheck(s.Substring(40, 8), rule8) &&
                    RuleCheck(s.Substring(48, 8), rule8) &&
                    RuleCheck(s.Substring(56, 8), rule42) &&
                    RuleCheck(s.Substring(64, 8), rule31)) count++;
                else if (RuleCheck(s.Substring(0, 8), rule8) &&
                         RuleCheck(s.Substring(8, 8), rule8) &&
                         RuleCheck(s.Substring(16, 8), rule8) &&
                         RuleCheck(s.Substring(24, 8), rule8) &&
                         RuleCheck(s.Substring(32, 8), rule8) &&
                         RuleCheck(s.Substring(40, 8), rule42) &&
                         RuleCheck(s.Substring(48, 8), rule42) &&
                         RuleCheck(s.Substring(56, 8), rule31) &&
                         RuleCheck(s.Substring(64, 8), rule31)) count++;
                else if (RuleCheck(s.Substring(0, 8), rule8) &&
                         RuleCheck(s.Substring(8, 8), rule8) &&
                         RuleCheck(s.Substring(16, 8), rule8) &&
                         RuleCheck(s.Substring(24, 8), rule42) &&
                         RuleCheck(s.Substring(32, 8), rule42) &&
                         RuleCheck(s.Substring(40, 8), rule42) &&
                         RuleCheck(s.Substring(48, 8), rule31) &&
                         RuleCheck(s.Substring(56, 8), rule31) &&
                         RuleCheck(s.Substring(64, 8), rule31)) count++;
                else if (RuleCheck(s.Substring(0, 8), rule8) &&
                         RuleCheck(s.Substring(8, 8), rule42) &&
                         RuleCheck(s.Substring(16, 8), rule42) &&
                         RuleCheck(s.Substring(24, 8), rule42) &&
                         RuleCheck(s.Substring(32, 8), rule42) &&
                         RuleCheck(s.Substring(40, 8), rule31) &&
                         RuleCheck(s.Substring(48, 8), rule31) &&
                         RuleCheck(s.Substring(56, 8), rule31) &&
                         RuleCheck(s.Substring(64, 8), rule31)) count++;
                possibleMatches.Remove(s);
            }
            tmpPoss = new List<string>(possibleMatches);
            foreach (var s in tmpPoss.Where(x => x.Length == 80))
            {
                if (RuleCheck(s.Substring(0, 8), rule8) &&
                    RuleCheck(s.Substring(8, 8), rule8) &&
                    RuleCheck(s.Substring(16, 8), rule8) &&
                    RuleCheck(s.Substring(24, 8), rule8) &&
                    RuleCheck(s.Substring(32, 8), rule8) &&
                    RuleCheck(s.Substring(40, 8), rule8) &&
                    RuleCheck(s.Substring(48, 8), rule8) &&
                    RuleCheck(s.Substring(56, 8), rule8) &&
                    RuleCheck(s.Substring(64, 8), rule42) &&
                    RuleCheck(s.Substring(72, 8), rule31)) count++;
                else if (RuleCheck(s.Substring(0, 8), rule8) &&
                         RuleCheck(s.Substring(8, 8), rule8) &&
                         RuleCheck(s.Substring(16, 8), rule8) &&
                         RuleCheck(s.Substring(24, 8), rule8) &&
                         RuleCheck(s.Substring(32, 8), rule8) &&
                         RuleCheck(s.Substring(40, 8), rule8) &&
                         RuleCheck(s.Substring(48, 8), rule42) &&
                         RuleCheck(s.Substring(56, 8), rule42) &&
                         RuleCheck(s.Substring(64, 8), rule31) &&
                         RuleCheck(s.Substring(72, 8), rule31)) count++;
                else if (RuleCheck(s.Substring(0, 8), rule8) &&
                         RuleCheck(s.Substring(8, 8), rule8) &&
                         RuleCheck(s.Substring(16, 8), rule8) &&
                         RuleCheck(s.Substring(24, 8), rule8) &&
                         RuleCheck(s.Substring(32, 8), rule42) &&
                         RuleCheck(s.Substring(40, 8), rule42) &&
                         RuleCheck(s.Substring(48, 8), rule42) &&
                         RuleCheck(s.Substring(56, 8), rule31) &&
                         RuleCheck(s.Substring(64, 8), rule31) &&
                         RuleCheck(s.Substring(72, 8), rule31)) count++;
                else if (RuleCheck(s.Substring(0, 8), rule8) &&
                         RuleCheck(s.Substring(8, 8), rule8) &&
                         RuleCheck(s.Substring(16, 8), rule42) &&
                         RuleCheck(s.Substring(24, 8), rule42) &&
                         RuleCheck(s.Substring(32, 8), rule42) &&
                         RuleCheck(s.Substring(40, 8), rule42) &&
                         RuleCheck(s.Substring(48, 8), rule31) &&
                         RuleCheck(s.Substring(56, 8), rule31) &&
                         RuleCheck(s.Substring(64, 8), rule31) &&
                         RuleCheck(s.Substring(72, 8), rule31)) count++;
                possibleMatches.Remove(s);
            }
            tmpPoss = new List<string>(possibleMatches);
            foreach (var s in tmpPoss.Where(x => x.Length == 88))
            {
                if (RuleCheck(s.Substring(0, 8), rule8) &&
                    RuleCheck(s.Substring(8, 8), rule8) &&
                    RuleCheck(s.Substring(16, 8), rule8) &&
                    RuleCheck(s.Substring(24, 8), rule8) &&
                    RuleCheck(s.Substring(32, 8), rule8) &&
                    RuleCheck(s.Substring(40, 8), rule8) &&
                    RuleCheck(s.Substring(48, 8), rule8) &&
                    RuleCheck(s.Substring(56, 8), rule8) &&
                    RuleCheck(s.Substring(64, 8), rule8) &&
                    RuleCheck(s.Substring(72, 8), rule42) &&
                    RuleCheck(s.Substring(80, 8), rule31)) count++;
                else if (RuleCheck(s.Substring(0, 8), rule8) &&
                         RuleCheck(s.Substring(8, 8), rule8) &&
                         RuleCheck(s.Substring(16, 8), rule8) &&
                         RuleCheck(s.Substring(24, 8), rule8) &&
                         RuleCheck(s.Substring(32, 8), rule8) &&
                         RuleCheck(s.Substring(40, 8), rule8) &&
                         RuleCheck(s.Substring(48, 8), rule8) &&
                         RuleCheck(s.Substring(56, 8), rule42) &&
                         RuleCheck(s.Substring(64, 8), rule42) &&
                         RuleCheck(s.Substring(72, 8), rule31) &&
                         RuleCheck(s.Substring(80, 8), rule31)) count++;
                else if (RuleCheck(s.Substring(0, 8), rule8) &&
                         RuleCheck(s.Substring(8, 8), rule8) &&
                         RuleCheck(s.Substring(16, 8), rule8) &&
                         RuleCheck(s.Substring(24, 8), rule8) &&
                         RuleCheck(s.Substring(32, 8), rule8) &&
                         RuleCheck(s.Substring(40, 8), rule42) &&
                         RuleCheck(s.Substring(48, 8), rule42) &&
                         RuleCheck(s.Substring(56, 8), rule42) &&
                         RuleCheck(s.Substring(64, 8), rule31) &&
                         RuleCheck(s.Substring(72, 8), rule31) &&
                         RuleCheck(s.Substring(80, 8), rule31)) count++;
                else if (RuleCheck(s.Substring(0, 8), rule8) &&
                         RuleCheck(s.Substring(8, 8), rule8) &&
                         RuleCheck(s.Substring(16, 8), rule8) &&
                         RuleCheck(s.Substring(24, 8), rule42) &&
                         RuleCheck(s.Substring(32, 8), rule42) &&
                         RuleCheck(s.Substring(40, 8), rule42) &&
                         RuleCheck(s.Substring(48, 8), rule42) &&
                         RuleCheck(s.Substring(56, 8), rule31) &&
                         RuleCheck(s.Substring(64, 8), rule31) &&
                         RuleCheck(s.Substring(72, 8), rule31) &&
                         RuleCheck(s.Substring(80, 8), rule31)) count++;
                else if (RuleCheck(s.Substring(0, 8), rule8) &&
                         RuleCheck(s.Substring(8, 8), rule42) &&
                         RuleCheck(s.Substring(16, 8), rule42) &&
                         RuleCheck(s.Substring(24, 8), rule42) &&
                         RuleCheck(s.Substring(32, 8), rule42) &&
                         RuleCheck(s.Substring(40, 8), rule42) &&
                         RuleCheck(s.Substring(48, 8), rule31) &&
                         RuleCheck(s.Substring(56, 8), rule31) &&
                         RuleCheck(s.Substring(64, 8), rule31) &&
                         RuleCheck(s.Substring(72, 8), rule31) &&
                         RuleCheck(s.Substring(80, 8), rule31)) count++;
                possibleMatches.Remove(s);
            }
            Console.WriteLine("Valid messages Part 2 = " + count);
        }
        static bool RuleCheck(string s, HashSet<string> r)
        {
            return r.Any(r => r == s);
        }
    }
}
