using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day25
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
            long publicKeyA = long.Parse(data.First());
            data.Remove(publicKeyA.ToString());
            long publicKeyB = long.Parse(data.First());
            long loopSizeA = LoopSize(publicKeyA);
            long loopSizeB = LoopSize(publicKeyB);
            long answerA = GetEncryptionKey(publicKeyA, loopSizeB);
            long answerB = GetEncryptionKey(publicKeyB, loopSizeA);
            if (answerA != answerB) Console.WriteLine("Something broke!");
            else Console.WriteLine("Encryption Key = " + answerA);
        }

        static void SolvePart2()
        {
            Console.WriteLine("");
        }
        static long LoopSize(long i)
        {
            long count = 0;
            long x = 1;
            while (x != i)
            {
                x *= 7;
                x %= 20201227;
                count++;
            }
            return count;
        }
        static long GetEncryptionKey(long subject, long loops)
        {
            long i = 1;
            for (long x = 0; x < loops; x++)
            {
                i *= subject;
                i %= 20201227;
            }
            return i;
        }
    }
}
