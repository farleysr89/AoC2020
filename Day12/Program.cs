using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day12
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
            char[] dir = new char[] { 'N', 'W', 'S', 'E' };
            char[] turns = new char[] { 'L', 'R' };
            char forward = 'F';
            int x = 0;
            int y = 0;
            char curDir = 'E';
            foreach (var s in data)
            {
                char c = s[0];
                int i = int.Parse(s[1..]);
                if (dir.Contains(c))
                {
                    if (c == 'N') x += i;
                    else if (c == 'S') x -= i;
                    else if (c == 'E') y += i;
                    else if (c == 'W') y -= i;
                    else
                    {
                        Console.WriteLine("Something Broke!");
                        break;
                    }
                }
                else if (turns.Contains(c))
                {
                    if (i == 180)
                    {
                        if (curDir == 'E') curDir = 'W';
                        else if (curDir == 'W') curDir = 'E';
                        else if (curDir == 'N') curDir = 'S';
                        else if (curDir == 'S') curDir = 'N';
                        else
                        {
                            Console.WriteLine("Something Broke!");
                            break;
                        }
                    }
                    else if (c == 'R')
                    {
                        if (i == 90)
                        {
                            if (curDir == 'E') curDir = 'S';
                            else if (curDir == 'W') curDir = 'N';
                            else if (curDir == 'N') curDir = 'E';
                            else if (curDir == 'S') curDir = 'W';
                            else
                            {
                                Console.WriteLine("Something Broke!");
                                break;
                            }
                        }
                        else if (i == 270)
                        {
                            if (curDir == 'E') curDir = 'N';
                            else if (curDir == 'W') curDir = 'S';
                            else if (curDir == 'N') curDir = 'W';
                            else if (curDir == 'S') curDir = 'E';
                            else
                            {
                                Console.WriteLine("Something Broke!");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Something Broke!");
                            break;
                        }
                    }
                    else if (c == 'L')
                    {
                        if (i == 90)
                        {
                            if (curDir == 'E')
                                curDir = 'N';
                            else if (curDir == 'W')
                                curDir = 'S';
                            else if (curDir == 'N')
                                curDir = 'W';
                            else if (curDir == 'S')
                                curDir = 'E';
                            else
                            {
                                Console.WriteLine("Something Broke!");
                                break;
                            }
                        }
                        else if (i == 270)
                        {
                            if (curDir == 'E') curDir = 'S';
                            else if (curDir == 'W') curDir = 'N';
                            else if (curDir == 'N') curDir = 'E';
                            else if (curDir == 'S') curDir = 'W';
                            else
                            {
                                Console.WriteLine("Something Broke!");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Something Broke!");
                            break;
                        }
                    }
                }
                else if (c == forward)
                {
                    if (curDir == 'N')
                        x += i;
                    else if (curDir == 'S')
                        x -= i;
                    else if (curDir == 'E')
                        y += i;
                    else if (curDir == 'W')
                        y -= i;
                    else
                    {
                        Console.WriteLine("Something Broke!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Something Broke!");
                    break;
                }
            }
            Console.WriteLine("Manhattan Distance " + (Math.Abs(x) + Math.Abs(y)));
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            char[] dir = new char[] { 'N', 'W', 'S', 'E' };
            char[] turns = new char[] { 'L', 'R' };
            char forward = 'F';
            int x = 0;
            int y = 0;
            int wayX = 10;
            int wayY = 1;
            foreach (var s in data)
            {
                char c = s[0];
                int i = int.Parse(s[1..]);
                if (dir.Contains(c))
                {
                    if (c == 'N') wayY += i;
                    else if (c == 'S') wayY -= i;
                    else if (c == 'E') wayX += i;
                    else if (c == 'W') wayX -= i;
                    else
                    {
                        Console.WriteLine("Something Broke!");
                        break;
                    }
                }
                else if (turns.Contains(c))
                {
                    if (i == 180)
                    {
                        wayX = -wayX;
                        wayY = -wayY;
                    }
                    else if (c == 'R')
                    {
                        if (i == 90)
                        {
                            int tmpX = wayX;
                            int tmpY = wayY;
                            wayX = tmpY;
                            wayY = -tmpX;
                        }
                        else if (i == 270)
                        {
                            int tmpX = wayX;
                            int tmpY = wayY;
                            wayX = -tmpY;
                            wayY = tmpX;
                        }
                        else
                        {
                            Console.WriteLine("Something Broke!");
                            break;
                        }
                    }
                    else if (c == 'L')
                    {
                        if (i == 90)
                        {
                            int tmpX = wayX;
                            int tmpY = wayY;
                            wayX = -tmpY;
                            wayY = tmpX;
                        }
                        else if (i == 270)
                        {
                            int tmpX = wayX;
                            int tmpY = wayY;
                            wayX = tmpY;
                            wayY = -tmpX;
                        }
                        else
                        {
                            Console.WriteLine("Something Broke!");
                            break;
                        }
                    }
                }
                else if (c == forward)
                {
                    x += i * wayX;
                    y += i * wayY;
                }
                else
                {
                    Console.WriteLine("Something Broke!");
                    break;
                }
            }
            Console.WriteLine("Manhattan Distance " + (Math.Abs(x) + Math.Abs(y)));
        }
    }
}
