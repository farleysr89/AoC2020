using System;
using System.IO;

namespace Day08
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
            string[] commands = _input.Split('\n');
            bool[] visited = new bool[commands.Length];
            int acc = 0;
            int next = 0;
            while (true)
            {
                if (visited[next]) break;
                visited[next] = true;
                string[] command = commands[next].Split(" ");
                switch (command[0])
                {
                    case "acc":
                        int i = int.Parse(command[1]);
                        acc += i;
                        next++;
                        break;
                    case "jmp":
                        int x = int.Parse(command[1]);
                        next += x;
                        break;
                    case "nop":
                        next++;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("accumulator Part1 = " + acc);
        }
        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            string[] commandsOrig = _input.Split('\n');
            int acc = 0;
            bool found = false;
            int index = 0;
            while (!found)
            {
                bool[] visited = new bool[commandsOrig.Length];
                acc = 0;
                int next = 0;
                string[] commands = (string[])commandsOrig.Clone();
                string[] s = commands[index].Split();
                if (s[0] == "jmp")
                {
                    commands[index] = "nop " + s[1];
                    index++;
                }
                else if (s[0] == "nop")
                {
                    commands[index] = "jmp " + s[1];
                    index++;
                }
                else
                {
                    index++;
                    continue;
                }
                while (true)
                {
                    if (next == commandsOrig.Length - 1)
                    {
                        found = true;
                        break;
                    }
                    if (visited[next]) break;
                    visited[next] = true;
                    string[] command = commands[next].Split(" ");
                    switch (command[0])
                    {
                        case "acc":
                            int i = int.Parse(command[1]);
                            acc += i;
                            next++;
                            break;
                        case "jmp":
                            int x = int.Parse(command[1]);
                            next += x;
                            break;
                        case "nop":
                            next++;
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.WriteLine("accumulator Part2 = " + acc);
        }
    }
}
