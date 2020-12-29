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
                        if (c == 's' && cc == 'e') x++;
                        if (c == 'n' && cc == 'w') x--;
                        if (c == 'n') y++;
                        if (c == 's') y--;
                    }
                    else if (c == 'w') x -= 1;
                    else if (c == 'e') x += 1;
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
                        if (c == 's' && cc == 'e') x++;
                        if (c == 'n' && cc == 'w') x--;
                        if (c == 'n') y++;
                        if (c == 's') y--;
                    }
                    else if (c == 'w') x -= 1;
                    else if (c == 'e') x += 1;
                    if (!tiles.ContainsKey((x, y))) tiles[(x, y)] = false;
                }
                if (tiles.ContainsKey((x, y))) tiles[(x, y)] = !tiles[(x, y)];
                else tiles[(x, y)] = true;
            }
            Console.WriteLine("First count = " + tiles.Where(t => t.Value).Count());
            for (int i = 0; i < 100; i++)
            {
                var tmp = new Dictionary<(int, int), bool>(tiles);
                foreach (var kv in tiles)
                {
                    int count = 0;
                    if (tiles.ContainsKey((kv.Key.Item1 + 1, kv.Key.Item2)))
                    {
                        if (tiles[(kv.Key.Item1 + 1, kv.Key.Item2)] == true) count++;
                    }
                    else
                    {
                        tmp[(kv.Key.Item1 - 1, kv.Key.Item2)] = false;
                    }
                    if (tiles.ContainsKey((kv.Key.Item1 - 1, kv.Key.Item2)))
                    {
                        if (tiles[(kv.Key.Item1 - 1, kv.Key.Item2)] == true) count++;
                    }
                    else
                    {
                        tmp[(kv.Key.Item1 - 1, kv.Key.Item2)] = false;
                    }
                    if (tiles.ContainsKey((kv.Key.Item1, kv.Key.Item2 + 1)))
                    {
                        if (tiles[(kv.Key.Item1, kv.Key.Item2 + 1)] == true) count++;
                    }
                    else
                    {
                        tmp[(kv.Key.Item1, kv.Key.Item2 - 1)] = false;
                    }
                    if (tiles.ContainsKey((kv.Key.Item1, kv.Key.Item2 - 1)))
                    {
                        if (tiles[(kv.Key.Item1, kv.Key.Item2 - 1)] == true) count++;
                    }
                    else
                    {
                        tmp[(kv.Key.Item1, kv.Key.Item2 - 1)] = false;
                    }
                    if (tiles.ContainsKey((kv.Key.Item1 + 1, kv.Key.Item2 + 1)))
                    {
                        if (tiles[(kv.Key.Item1 + 1, kv.Key.Item2 + 1)] == true) count++;
                    }
                    else
                    {
                        tmp[(kv.Key.Item1 + 1, kv.Key.Item2 + 1)] = false;
                    }
                    if (tiles.ContainsKey((kv.Key.Item1 - 1, kv.Key.Item2 - 1)))
                    {
                        if (tiles[(kv.Key.Item1 - 1, kv.Key.Item2 - 1)] == true) count++;
                    }
                    else
                    {
                        tmp[(kv.Key.Item1 - 1, kv.Key.Item2 - 1)] = false;
                    }

                    if (tiles[(kv.Key.Item1, kv.Key.Item2)])
                    {
                        if (count == 0 || count > 2) tmp[(kv.Key.Item1, kv.Key.Item2)] = false;
                    }
                    else
                    {
                        if (count == 2) tmp[(kv.Key.Item1, kv.Key.Item2)] = true;
                    }
                }
                tiles = new Dictionary<(int, int), bool>(tmp);
                Console.WriteLine(i + " count = " + tiles.Where(t => t.Value).Count());
            }

            Console.WriteLine("Final count = " + tiles.Where(t => t.Value).Count());
        }
    }
}
