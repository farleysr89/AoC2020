using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day14
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
            string mask = "";
            long[] memory = new long[100000];
            foreach (var s in data)
            {
                string[] line = s.Split(" ");
                if (line[0] == "mask") mask = line[2];
                else
                {
                    long value = long.Parse(line[2]);
                    string binary = Convert.ToString(value, 2).PadLeft(36, '0');
                    string final = "";
                    for (int i = 0; i < 36; i++)
                    {
                        final += mask[i] == 'X' ? binary[i] : mask[i];
                    }
                    value = Convert.ToInt64(final, 2);
                    string address = line[0].Split("[")[1];
                    address = address.Remove(address.Length - 1, 1);
                    memory[int.Parse(address)] = value;
                }
            }
            long total = 0;
            foreach (var i in memory.Where(x => x != 0))
            {
                total += i;
            }
            Console.WriteLine("Total Part 1 = " + total);
        }
        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            string mask = "";
            Dictionary<string, long> memory = new Dictionary<string, long>();
            foreach (var s in data)
            {
                string[] line = s.Split(" ");
                if (line[0] == "mask") mask = line[2];
                else
                {
                    long value = long.Parse(line[2]);
                    List<string> final = new List<string> { "" };
                    string address = line[0].Split("[")[1];
                    address = address.Remove(address.Length - 1, 1);
                    string binary = Convert.ToString(long.Parse(address), 2).PadLeft(36, '0');
                    for (int i = 0; i < 36; i++)
                    {
                        if (mask[i] == 'X')
                        {
                            List<string> tmp = new List<string>();
                            foreach (var t in final)
                            {
                                tmp.Add(t + "0");
                                tmp.Add(t + "1");
                            }
                            final = new List<string>(tmp);
                        }
                        else
                        {
                            List<string> tmp = new List<string>();
                            foreach (var t in final)
                            {
                                tmp.Add(t + (mask[i] == '0' ? binary[i] : "1"));
                            }
                            final = new List<string>(tmp);
                        }
                    }
                    foreach (var t in final)
                    {
                        //long add = Convert.ToInt64(t, 2);
                        memory[t] = value;
                    }
                }
            }
            long total = 0;
            foreach (var i in memory)
            {
                total += i.Value;
            }
            Console.WriteLine("Total Part 2 = " + total);
        }
    }
}
