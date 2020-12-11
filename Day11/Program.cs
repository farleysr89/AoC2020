using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day11
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
            char[,] seats = new char[98, 90];
            int row = 0;
            foreach (var s in data)
            {
                int col = 0;
                foreach (char c in s)
                {
                    seats[row, col] = c;
                    col++;
                }
                row++;
            }
            bool change = true;
            int iterations = 0;
            while (change)
            {
                iterations++;
                change = false;
                char[,] newSeats = (char[,])seats.Clone();
                for (int i = 0; i < 98; i++)
                {
                    for (int h = 0; h < 90; h++)
                    {
                        char c = seats[i, h];
                        if (c == '.') continue;
                        if (c == 'L')
                        {
                            int count = 0;
                            for (int x = i - 1; x <= i + 1; x++)
                            {
                                if (x < 0 || x > 97) continue;
                                for (int y = h - 1; y <= h + 1; y++)
                                {
                                    if (y < 0 || y > 89 || (x == i && y == h)) continue;
                                    if (seats[x, y] == '#')
                                    {
                                        count++;
                                    }
                                }
                            }
                            if (count == 0)
                            {
                                change = true;
                                newSeats[i, h] = '#';
                            }
                        }
                        else if (c == '#')
                        {
                            int count = 0;
                            for (int x = i - 1; x <= i + 1; x++)
                            {
                                if (x < 0 || x > 97) continue;
                                for (int y = h - 1; y <= h + 1; y++)
                                {
                                    if (y < 0 || y > 89 || (x == i && y == h)) continue;
                                    if (seats[x, y] == '#')
                                    {
                                        count++;
                                    }
                                }
                            }
                            if (count >= 4)
                            {
                                change = true;
                                newSeats[i, h] = 'L';
                            }
                        }
                    }
                }
                seats = (char[,])newSeats.Clone();
            }
            int seatCount = 0;
            foreach (var i in seats)
            {
                if (i == '#') seatCount++;
            }
            Console.WriteLine("Filled seats = " + seatCount);
        }
        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
        }
    }
}
