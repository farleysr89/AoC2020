using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day18
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
            List<string> data = _input.Split('\n').Select(s => s.Replace(" ", "")).ToList();
            List<long> answers = new List<long>();
            foreach (var s in data)
            {
                if (s == "") continue;
                answers.Add(Evaluate(s));
            }
            long total = 0;
            foreach (var i in answers) total += i;
            Console.WriteLine("Total of answers in Part 1 is " + total);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').Select(s => s.Replace(" ", "")).ToList();
            List<long> answers = new List<long>();
            foreach (var s in data)
            {
                if (s == "") continue;
                answers.Add(Evaluate2(s));
            }
            long total = 0;
            foreach (var i in answers) total += i;
            Console.WriteLine("Total of answers in Part 2 is " + total);
        }

        private static long Evaluate(string s)
        {
            Queue<long> nums = new Queue<long>();
            Queue<char> operators = new Queue<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (long.TryParse(s[i].ToString(), out long x)) nums.Enqueue(x);
                else if (s[i] == '(')
                {
                    int balance = 1;
                    int index = i;
                    foreach (var cc in s[(i + 1)..])
                    {
                        if (cc == '(') balance++;
                        if (cc == ')')
                        {
                            balance--;
                            if (balance == 0)
                            {
                                nums.Enqueue(Evaluate(s.Substring(i + 1, index - i)));
                                break;
                            }
                        }
                        index++;
                    }
                    i = index + 1;
                }
                else if (s[i] == '+' || s[i] == '*')
                {
                    operators.Enqueue(s[i]);
                }
                else
                {
                    Console.WriteLine("Something Broke!");
                }
            }
            long num1 = nums.Dequeue();
            while (nums.Count > 0)
            {
                long num2 = nums.Dequeue();
                char op = operators.Dequeue();
                if (op == '+') num1 += num2;
                else if (op == '*') num1 *= num2;
                else Console.WriteLine("Something Broke!");
            }
            return num1;
        }
        private static long Evaluate2(string s)
        {
            Queue<long> nums = new Queue<long>();
            Queue<char> operators = new Queue<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (long.TryParse(s[i].ToString(), out long x)) nums.Enqueue(x);
                else if (s[i] == '(')
                {
                    int balance = 1;
                    int index = i;
                    foreach (var cc in s[(i + 1)..])
                    {
                        if (cc == '(') balance++;
                        if (cc == ')')
                        {
                            balance--;
                            if (balance == 0)
                            {
                                nums.Enqueue(Evaluate2(s.Substring(i + 1, index - i)));
                                break;
                            }
                        }
                        index++;
                    }
                    i = index + 1;
                }
                else if (s[i] == '+' || s[i] == '*')
                {
                    operators.Enqueue(s[i]);
                }
                else
                {
                    Console.WriteLine("Something Broke!");
                }
            }
            long num1 = nums.Dequeue();
            List<long> multis = new List<long>();
            while (nums.Count > 0)
            {
                long num2 = nums.Dequeue();
                char op = operators.Dequeue();
                if (op == '+') num1 += num2;
                else if (op == '*')
                {
                    multis.Add(num1);
                    num1 = num2;
                }
                else Console.WriteLine("Something Broke!");
            }
            foreach (var m in multis) num1 *= m;
            return num1;
        }
    }
}
