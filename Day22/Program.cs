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
            Console.WriteLine("Winning Score Part 1 = " + score);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            Queue<int> PlayerOneDeck = new Queue<int>();
            Queue<int> PlayerTwoDeck = new Queue<int>();
            HashSet<(Queue<int>, Queue<int>)> states = new HashSet<(Queue<int>, Queue<int>)>();
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
            bool OneWin = false;
            while (PlayerOneDeck.Count > 0 && PlayerTwoDeck.Count > 0)
            {
                if (states.Any(s => Enumerable.SequenceEqual(s.Item1, PlayerOneDeck) && Enumerable.SequenceEqual(s.Item2, PlayerTwoDeck)))
                {
                    OneWin = true;
                    break;
                }
                states.Add((new Queue<int>(PlayerOneDeck), new Queue<int>(PlayerTwoDeck)));
                int a = PlayerOneDeck.Dequeue();
                int b = PlayerTwoDeck.Dequeue();
                if (a <= PlayerOneDeck.Count && b <= PlayerTwoDeck.Count)
                {
                    Queue<int> tmpA = new Queue<int>(PlayerOneDeck);
                    Queue<int> tmpB = new Queue<int>(PlayerTwoDeck);
                    Queue<int> newOne = new Queue<int>();
                    Queue<int> newTwo = new Queue<int>();
                    for (int i = 0; i < a; i++)
                    {
                        newOne.Enqueue(tmpA.Dequeue());
                    }
                    for (int i = 0; i < b; i++)
                    {
                        newTwo.Enqueue(tmpB.Dequeue());
                    }
                    OneWin = Recurse(newOne, newTwo);
                    if (OneWin)
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
                else if (a > b)
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
            if (OneWin)
            {
                while (PlayerOneDeck.Count > 0)
                {
                    int multi = PlayerOneDeck.Count();
                    score += multi * PlayerOneDeck.Dequeue();
                }
            }
            else
            {
                while (PlayerTwoDeck.Count > 0)
                {
                    int multi = PlayerTwoDeck.Count();
                    score += multi * PlayerTwoDeck.Dequeue();
                }
            }
            Console.WriteLine("Winning Score Part 2 = " + score);
        }
        static bool Recurse(Queue<int> PlayerOneDeck, Queue<int> PlayerTwoDeck)
        {
            HashSet<(Queue<int>, Queue<int>)> states = new HashSet<(Queue<int>, Queue<int>)>();
            bool OneWin = false;
            while (PlayerOneDeck.Count > 0 && PlayerTwoDeck.Count > 0)
            {
                if (states.Any(s => Enumerable.SequenceEqual(s.Item1, PlayerOneDeck) && Enumerable.SequenceEqual(s.Item2, PlayerTwoDeck)))
                {
                    OneWin = true;
                    break;
                }
                states.Add((new Queue<int>(PlayerOneDeck), new Queue<int>(PlayerTwoDeck)));
                int a = PlayerOneDeck.Dequeue();
                int b = PlayerTwoDeck.Dequeue();
                if (a <= PlayerOneDeck.Count && b <= PlayerTwoDeck.Count)
                {
                    Queue<int> tmpA = new Queue<int>(PlayerOneDeck);
                    Queue<int> tmpB = new Queue<int>(PlayerTwoDeck);
                    Queue<int> newOne = new Queue<int>();
                    Queue<int> newTwo = new Queue<int>();
                    for (int i = 0; i < a; i++)
                    {
                        newOne.Enqueue(tmpA.Dequeue());
                    }
                    for (int i = 0; i < b; i++)
                    {
                        newTwo.Enqueue(tmpB.Dequeue());
                    }
                    OneWin = Recurse(newOne, newTwo);
                    if (OneWin)
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
                else if (a > b)
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
            return OneWin || PlayerOneDeck.Count > 0;
        }
    }
}
