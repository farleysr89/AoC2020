using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day17
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
            Dictionary<(int, int, int), char> cubes = new Dictionary<(int, int, int), char>();
            int x = 0, y = 0, z = 0;
            foreach (var s in data)
            {
                if (s == "") continue;
                x = 0;
                foreach (var c in s)
                {
                    cubes.Add((x, y, z), c);
                    x++;
                }
                y++;
            }
            for (x = -6; x < 14; x++)
            {
                for (y = -6; y < 14; y++)
                {
                    for (z = -6; z < 7; z++)
                    {
                        if (!cubes.ContainsKey((x, y, z))) cubes.Add((x, y, z), '.');
                    }
                }
            }
            for (int i = 0; i < 6; i++)
            {
                var newCubes = new Dictionary<(int, int, int), char>(cubes);
                foreach (var cube in cubes)
                {
                    var count = CheckNeighbors(cube.Key, cubes);
                    if (cube.Value == '#' && (count != 2 && count != 3)) newCubes[cube.Key] = '.';
                    if (cube.Value == '.' && count == 3) newCubes[cube.Key] = '#';
                }
                cubes = new Dictionary<(int, int, int), char>(newCubes);
            }
            Console.WriteLine("Total active cubes = " + cubes.Where(c => c.Value == '#').Count());
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            Dictionary<(int, int, int, int), char> cubes = new Dictionary<(int, int, int, int), char>();
            int x = 0, y = 0, z = 0, w = 0;
            foreach (var s in data)
            {
                if (s == "") continue;
                x = 0;
                foreach (var c in s)
                {
                    cubes.Add((x, y, z, w), c);
                    x++;
                }
                y++;
            }
            for (x = -6; x < 14; x++)
            {
                for (y = -6; y < 14; y++)
                {
                    for (z = -6; z < 7; z++)
                    {
                        for (w = -6; w < 7; w++)
                        {
                            if (!cubes.ContainsKey((x, y, z, w))) cubes.Add((x, y, z, w), '.');
                        }
                    }
                }
            }
            for (int i = 0; i < 6; i++)
            {
                var newCubes = new Dictionary<(int, int, int, int), char>(cubes);
                foreach (var cube in cubes)
                {
                    var count = CheckNeighbors4D(cube.Key, cubes);
                    if (cube.Value == '#' && (count != 2 && count != 3)) newCubes[cube.Key] = '.';
                    if (cube.Value == '.' && count == 3) newCubes[cube.Key] = '#';
                }
                cubes = new Dictionary<(int, int, int, int), char>(newCubes);
            }
            Console.WriteLine("Total active cubes 4D = " + cubes.Where(c => c.Value == '#').Count());
        }

        static int CheckNeighbors((int, int, int) key, Dictionary<(int, int, int), char> cubes)
        {
            int count = 0;
            for (int x = key.Item1 - 1; x <= key.Item1 + 1; x++)
            {
                for (int y = key.Item2 - 1; y <= key.Item2 + 1; y++)
                {
                    for (int z = key.Item3 - 1; z <= key.Item3 + 1; z++)
                    {
                        if ((x, y, z) == key) continue;
                        if (!cubes.ContainsKey((x, y, z))) continue;
                        if (cubes[(x, y, z)] == '#') count++;
                    }
                }
            }
            return count;
        }
        static int CheckNeighbors4D((int, int, int, int) key, Dictionary<(int, int, int, int), char> cubes)
        {
            int count = 0;
            for (int x = key.Item1 - 1; x <= key.Item1 + 1; x++)
            {
                for (int y = key.Item2 - 1; y <= key.Item2 + 1; y++)
                {
                    for (int z = key.Item3 - 1; z <= key.Item3 + 1; z++)
                    {
                        for (int w = key.Item4 - 1; w <= key.Item4 + 1; w++)
                        {
                            if ((x, y, z, w) == key) continue;
                            if (!cubes.ContainsKey((x, y, z, w))) continue;
                            if (cubes[(x, y, z, w)] == '#') count++;
                        }
                    }
                }
            }
            return count;
        }
    }
}
