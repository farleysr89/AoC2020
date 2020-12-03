using System;
using System.Collections.Generic;
using System.IO;

namespace Day03
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
            string[] map = _input.Split('\n');
            while (map[0].Length <= map.Length * 3)
            {
                for (int i = 0; i < map.Length; i++)
                {
                    map[i] += map[i];
                }
            }
            int x = 0, y = 0, count = 0;
            while (y < map.Length)
            {
                if (map[y][x] == '#') count++;
                x += 3;
                y++;
            }
            Console.WriteLine(count);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            string[] map = _input.Split('\n');
            while (map[0].Length <= map.Length * 7)
            {
                for (int i = 0; i < map.Length; i++)
                {
                    map[i] += map[i];
                }
            }
            List<int> results = new List<int>();
            List<XY> slopes = new List<XY>();
            slopes.Add(new XY { x = 1, y = 1 });
            slopes.Add(new XY { x = 3, y = 1 });
            slopes.Add(new XY { x = 5, y = 1 });
            slopes.Add(new XY { x = 7, y = 1 });
            slopes.Add(new XY { x = 1, y = 2});

            foreach (XY slope in slopes)
            {
                int x = 0, y = 0, count = 0;
                while (y < map.Length)
                {
                    if (map[y][x] == '#') count++;
                    x += slope.x;
                    y += slope.y;
                }
                results.Add(count);
            }
            long total = 1;
            foreach (int r in results)
            {
                total *= r;
                Console.WriteLine("Result = " + r);
            }
            Console.WriteLine("Total = " + total);
        }
    }

    class XY
    {
        public int x, y;
    }
}
