using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        static void Part1()
        {
            string _input = File.ReadAllText("Input01.txt");
            List<int> entries = _input.Split('\n').Select(int.Parse).ToList();
            int x = 0;
            foreach (int i in entries)
            {
                if (entries.Any(e => 2020 - i == e))
                {
                    x = i;
                    break;
                }
            }
            int y = 2020 - x;
            Console.WriteLine("x = " + x + " y = " + y + " solution = " + x * y);
        }

        static void Part2()
        {
            string _input = File.ReadAllText("Input.txt");
            int[] entries = _input.Split('\n').Select(int.Parse).ToArray();
            int x = 0, y = 0, z = 0;
            for(int i = 0; i < entries.Length - 2; i++)
            {
                for(int j = i + 1; j < entries.Length - 1; j++)
                {
                    for (int k = j + 1; k < entries.Length; k++)
                    {
                        if(entries[i] + entries[j] + entries[k] == 2020)
                        {
                            x = entries[i];
                            y = entries[j];
                            z = entries[k];
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("x = " + x + " y = " + y + " z = " + z + " solution = " + x * y * z);

        }
    }
}
