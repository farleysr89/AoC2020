using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day20
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
            List<string> image = new List<String>();
            var t = new Tile();
            List<Tile> tiles = new List<Tile>();
            foreach (var s in data)
            {
                if (s == "")
                {
                    t.image = image.ToArray();
                    image = new List<string>();
                    tiles.Add(t);
                    t = new Tile();
                    continue;
                }
                if (s.Contains("Tile"))
                {
                    var l = s.Split(" ")[1].Split(":");
                    t.id = int.Parse(l[0]);
                }
                else
                {
                    image.Add(s);
                }
            }
            foreach (var tile in tiles)
            {
                tile.PopulateSides();
            }
            foreach (var tile in tiles)
            {
                foreach (var s in tile.sides)
                {
                    foreach (var tile2 in tiles.Where(x => x.id != tile.id))
                    {
                        if (tile2.sides.Any(x => x == s || x == new string(s.Reverse().ToArray())))
                        {
                            tile.sideMatches++;
                            break;
                        }
                    }
                }
            }
            long product = 1;
            foreach (var tile in tiles.Where(y => y.sideMatches == 2))
            {
                product *= tile.id;
            }

            Console.WriteLine("Product of corners is " + product);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            List<string> image = new List<String>();
            var t = new Tile();
            List<Tile> tiles = new List<Tile>();
            int count = 0;
            foreach (var s in data)
            {
                if (s == "")
                {
                    count = 0;
                    t.image = image.ToArray();
                    image = new List<string>();
                    tiles.Add(t);
                    t = new Tile();
                    continue;
                }
                if (s.Contains("Tile"))
                {
                    var l = s.Split(" ")[1].Split(":");
                    t.id = int.Parse(l[0]);
                }
                else
                {
                    if (count != 0 && count != 9)
                        image.Add(s.Substring(1, 8));
                    count++;
                }
            }
            count = 0;
            foreach (var tile in tiles)
            {
                foreach (var s in tile.image)
                {
                    foreach (var c in s)
                    {
                        if (c == '#') count++;
                    }
                }
            }

            Console.WriteLine("Total count is " + count);
        }
    }
    class Tile
    {
        public int id;
        public string[] image;
        public string[] sides = new string[4];
        public int sideMatches = 0;
        public void PopulateSides()
        {
            sides[0] = image[0];
            sides[1] = image[^1];
            string one = "";
            string two = "";
            foreach (var s in image)
            {
                one += s[0];
                two += s[^1];
            }
            sides[2] = one;
            sides[3] = two;
        }
    }
}
