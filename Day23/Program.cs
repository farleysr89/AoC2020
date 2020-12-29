using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day23
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
            string s = data[0];
            Dictionary<long, Cup> cups = new Dictionary<long, Cup>();
            int index = 0;
            Cup prev = null, curr = null, first = null, begin = null;
            foreach (char c in s)
            {
                curr = new Cup { value = int.Parse(c.ToString()) };
                if (curr.value == 1) first = curr;
                if (prev != null) prev.next = curr;
                else begin = curr;
                cups.Add(curr.value, curr);
                prev = curr;
                index++;
            }
            curr.next = begin;
            var cur = cups.First().Value;

            var dest = cur.value == 1 ? 9 : cur.value - 1;
            int goal = 100;
            for (int i = 0; i < goal; i++)
            {
                HashSet<Cup> moves = new HashSet<Cup>();
                moves = new HashSet<Cup> { cur.next, cur.next.next, cur.next.next.next };
                cur.next = cur.next.next.next.next;
                //var tmp = new int[1] { cups[0] };
                //cups = tmp.Concat(cups[4..]).ToArray();
                while (moves.Any(c => c.value == dest))
                {
                    dest = dest == 1 ? 9 : dest - 1;
                }
                //var destIndex = Array.IndexOf(cups, dest);
                //s = s.Insert(s.IndexOf(dest.ToString()) + 1, moves);
                //cups = cups[0..destIndex].Concat(moves).Concat(cups[destIndex..]).ToArray();
                var destCup = cups[dest];
                var n = destCup.next;
                destCup.next = moves.First();
                moves.Last().next = n;


                //s = ShiftString(s);
                //cups = ShiftArray(cups);
                //cur = int.Parse(s[0].ToString());
                cur = cur.next;
                dest = cur.value == 1 ? 9 : cur.value - 1;
            }
            //while (cups[0] != 1)
            //{
            //    cups = ShiftArray(cups);
            //}
            //var firstCup = Array.IndexOf(cups, 1);
            Console.WriteLine("Final Output is " + first.next.value + first.next.next.value + first.next.next.next.value
                                                 + first.next.next.next.next.value + first.next.next.next.next.next.value + first.next.next.next.next.next.next.value
                                                 + first.next.next.next.next.next.next.next.value + first.next.next.next.next.next.next.next.next.value);
            //string _input = File.ReadAllText("Input.txt");
            //List<string> data = _input.Split('\n').ToList();
            //string s = data[0];
            //int[] cups = new int[9];
            //int index = 0;
            //foreach (char c in s)
            //{
            //    cups[index] = int.Parse(c.ToString());
            //    index++;
            //}
            //var cur = cups.First();
            //var dest = cur == 1 ? 9 : cur - 1;
            //int goal = 100;
            //index = 0;
            //for (int i = 0; i < goal; i++)
            //{
            //    string origS = s;
            //    string moves = "";
            //    for (int x = 0; x < 3; x++)
            //    {
            //        moves += s[index + 1];
            //        s = s.Remove(index + 1, 1);
            //    }
            //    while (!s.Contains(dest.ToString()))
            //    {
            //        dest = dest == 1 ? 9 : dest - 1;
            //    }
            //    s = s.Insert(s.IndexOf(dest.ToString()) + 1, moves);
            //    s = ShiftString(s);
            //    cur = int.Parse(s[0].ToString());
            //    dest = cur == 1 ? 9 : cur - 1;
            //}
            //while (s[0] != '1')
            //{
            //    s = ShiftString(s);
            //}
            //Console.WriteLine("Final Output is " + s[1..]);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            string s = data[0];
            Dictionary<long, Cup> cups = new Dictionary<long, Cup>();
            int index = 0;
            Cup prev = null, curr = null, first = null, begin = null;
            foreach (char c in s)
            {
                curr = new Cup { value = int.Parse(c.ToString()) };
                if (curr.value == 1) first = curr;
                if (prev != null) prev.next = curr;
                else begin = curr;
                cups.Add(curr.value, curr);
                prev = curr;
                index++;
            }
            for (int i = index; i < 1000000; i++)
            {
                curr = new Cup { value = i + 1 };
                prev.next = curr;
                cups.Add(curr.value, curr);
                prev = curr;
            }
            curr.next = begin;
            var cur = cups.First().Value;

            var dest = cur.value == 1 ? 1000000 : cur.value - 1;
            int goal = 10000000;
            for (int i = 0; i < goal; i++)
            {
                HashSet<Cup> moves = new HashSet<Cup>();
                moves = new HashSet<Cup> { cur.next, cur.next.next, cur.next.next.next };
                cur.next = cur.next.next.next.next;
                //var tmp = new int[1] { cups[0] };
                //cups = tmp.Concat(cups[4..]).ToArray();
                while (moves.Any(c => c.value == dest))
                {
                    dest = dest == 1 ? 1000000 : dest - 1;
                }
                //var destIndex = Array.IndexOf(cups, dest);
                //s = s.Insert(s.IndexOf(dest.ToString()) + 1, moves);
                //cups = cups[0..destIndex].Concat(moves).Concat(cups[destIndex..]).ToArray();
                var destCup = cups[dest];
                var n = destCup.next;
                destCup.next = moves.First();
                moves.Last().next = n;


                //s = ShiftString(s);
                //cups = ShiftArray(cups);
                //cur = int.Parse(s[0].ToString());
                cur = cur.next;
                dest = cur.value == 1 ? 1000000 : cur.value - 1;
            }
            //while (cups[0] != 1)
            //{
            //    cups = ShiftArray(cups);
            //}
            //var firstCup = Array.IndexOf(cups, 1);
            Console.WriteLine("Final Output is " + first.next.value * first.next.next.value);
            //string _input = File.ReadAllText("Input.txt");
            //List<string> data = _input.Split('\n').ToList();
            //string s = data[0];
            //int[] cups = new int[1000000];
            //int index = 0;
            //foreach (char c in s)
            //{
            //    cups[index] = int.Parse(c.ToString());
            //    index++;
            //}
            //for (int i = index; i < 1000000; i++)
            //{
            //    cups[i] = i + 1;
            //}
            //var cur = cups.First();
            //var dest = cur == 1 ? 1000000 : cur - 1;
            //int goal = 10000000;
            //for (int i = 0; i < goal; i++)
            //{
            //    int[] moves = new int[3];
            //    for (int x = 0; x < 3; x++)
            //    {
            //        moves[x] = cups[1 + x];
            //    }
            //    var tmp = new int[1] { cups[0] };
            //    cups = tmp.Concat(cups[4..]).ToArray();
            //    while (moves.Contains(dest))
            //    {
            //        dest = dest == 1 ? 1000000 : dest - 1;
            //    }
            //    var destIndex = Array.IndexOf(cups, dest);
            //    //s = s.Insert(s.IndexOf(dest.ToString()) + 1, moves);
            //    cups = cups[0..destIndex].Concat(moves).Concat(cups[destIndex..]).ToArray();
            //    //s = ShiftString(s);
            //    cups = ShiftArray(cups);
            //    cur = int.Parse(s[0].ToString());
            //    dest = cur == 1 ? 1000000 : cur - 1;
            //}
            ////while (cups[0] != 1)
            ////{
            ////    cups = ShiftArray(cups);
            ////}
            //var firstCup = Array.IndexOf(cups, 1);
            //Console.WriteLine("Final Output is " + cups[firstCup + 1] * cups[firstCup + 2]);
        }
        // Function from here: https://stackoverflow.com/questions/15053461/shifting-a-string-in-c-sharp
        public static string ShiftString(string t)
        {
            return t[1..] + t.Substring(0, 1);
        }
        public static int[] ShiftArray(int[] t)
        {
            return t[1..].Append(t[0]).ToArray();
        }
    }
    public class Cup
    {
        public Cup next;
        public long value;
    }
}
