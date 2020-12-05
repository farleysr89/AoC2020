using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day05
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
            List<string> ticketData = _input.Split('\n').ToList();
            List<Ticket> tickets = new List<Ticket>();
            foreach(string s in ticketData)
            {
                int rNum = 64;
                int cNum = 4;
                int count = 0;
                int minRow = 0;
                int maxRow = 127;
                int minCol = 0;
                int maxCol = 7;

                foreach (char c in s)
                {
                    if(count < 7)
                    {
                        if (c == 'F')
                            maxRow -= rNum;
                        else if (c == 'B')
                            minRow += rNum;
                        rNum /= 2;
                    }
                    else
                    {
                        if (c == 'L')
                            maxCol -= cNum;
                        else if (c == 'R')
                            minCol += cNum;
                        cNum /= 2;
                    }
                    count++;
                }
                tickets.Add(new Ticket { row = minRow, column = minCol });                
            }
            Console.WriteLine("Max Ticket ID = " + tickets.Max(t => t.TicketID()));
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> ticketData = _input.Split('\n').ToList();
            List<Ticket> tickets = new List<Ticket>();
            foreach (string s in ticketData)
            {
                int rNum = 64;
                int cNum = 4;
                int count = 0;
                int minRow = 0;
                int maxRow = 127;
                int minCol = 0;
                int maxCol = 7;

                foreach (char c in s)
                {
                    if (count < 7)
                    {
                        if (c == 'F')
                            maxRow -= rNum;
                        else if (c == 'B')
                            minRow += rNum;
                        rNum /= 2;
                    }
                    else
                    {
                        if (c == 'L')
                            maxCol -= cNum;
                        else if (c == 'R')
                            minCol += cNum;
                        cNum /= 2;
                    }
                    count++;
                }
                tickets.Add(new Ticket { row = minRow, column = minCol });
            }
            List<int> IDs = tickets.Select(t => t.TicketID()).ToList();
            Console.WriteLine("Your Ticket ID = " + IDs.Find(i => IDs.Contains(i + 2) && !IDs.Contains(i + 1)) + 1);
        }
    }

    class Ticket
    {
        public int row;
        public int column;

        public int TicketID()
        {
            return row * 8 + column;
        }
    }
}
