using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day14
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
            Console.WriteLine("Total = " + total);
        }
        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
        }
    }
}
