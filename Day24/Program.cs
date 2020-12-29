using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day24
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
            Dictionary<(int, int), bool> tiles = new Dictionary<(int, int), bool>();
            foreach (var s in data)
            {
                int x = 0, y = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    var c = s[i];
                    if (c == 'n' || c == 's')
                    {
                        var cc = s[++i];
                        if (cc == 'e') x++;
                        if (cc == 'w') x--;
                        if (c == 'n') y++;
                        if (c == 's') y--;
                    }
                    else if (c == 'w') x -= 2;
                    else if (c == 'e') x += 2;
                }
                if (tiles.ContainsKey((x, y))) tiles[(x, y)] = !tiles[(x, y)];
                else tiles[(x, y)] = true;
            }
            Console.WriteLine("Final count = " + tiles.Where(t => t.Value).Count());
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
