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
            Console.WriteLine("accumulator = " + acc);
        }
        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
        }
        }
}
