using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day02
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
            string _input = File.ReadAllText("Input.txt");
            List<string> passwords = _input.Split('\n').ToList();
            int count = 0;
            foreach (string s in passwords)
            {
                string[] parts = s.Split(" ");
                int[] range = parts[0].Split("-").Select(int.Parse).ToArray();
                char c = parts[1][0];
                int charCount = 0;
                foreach(char x in parts[2])
                {
                    if(x == c)
                    {
                        charCount++;
                    }
                }
                if(charCount >= range[0] && charCount <= range[1])
                {
                    count++;
                }
            }            
            Console.WriteLine("Good Passwords Part1: " + count);
        }

        static void Part2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> passwords = _input.Split('\n').ToList();
            int count = 0;
            foreach (string s in passwords)
            {
                string[] parts = s.Split(" ");
                int[] range = parts[0].Split("-").Select(int.Parse).ToArray();
                char c = parts[1][0];
                if (parts[2][range[0]-1] == c ^ parts[2][range[1] - 1] == c)
                {
                    count++;
                }
            }
            Console.WriteLine("Good Passwords Part2: " + count);
        }
    }
}
