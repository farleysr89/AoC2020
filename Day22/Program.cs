using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day22
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
            Queue<int> PlayerOneDeck = new Queue<int>();
            Queue<int> PlayerTwoDeck = new Queue<int>();
            bool done = false;
            foreach (var s in data)
            {
                if (s.Contains("Player")) continue;
                else if (s == "") done = true;
                else if (!done)
                    PlayerOneDeck.Enqueue(int.Parse(s));
                else
                    PlayerTwoDeck.Enqueue(int.Parse(s));
            }
            while (PlayerOneDeck.Count > 0 && PlayerTwoDeck.Count > 0)
            {
                int a = PlayerOneDeck.Dequeue();
                int b = PlayerTwoDeck.Dequeue();
                if (a > b)
                {
                    PlayerOneDeck.Enqueue(a);
                    PlayerOneDeck.Enqueue(b);
                }
                else
                {
                    PlayerTwoDeck.Enqueue(b);
                    PlayerTwoDeck.Enqueue(a);
                }
            }
            int score = 0;
            while (PlayerOneDeck.Count > 0)
            {
                int multi = PlayerOneDeck.Count();
                score += multi * PlayerOneDeck.Dequeue();
            }
            while (PlayerTwoDeck.Count > 0)
            {
                int multi = PlayerTwoDeck.Count();
                score += multi * PlayerTwoDeck.Dequeue();
            }
            Console.WriteLine("Winning Score = " + score);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
