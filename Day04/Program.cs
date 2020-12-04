using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day04
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
            string[] data = _input.Split(new char[] {' ', '\n' });
            List<Passport> passports = new List<Passport>();
            Passport pass = new Passport();
            foreach(string s in data)
            {
                if(s == "")
                {
                    passports.Add(pass);
                    pass = new Passport();
                }
                else
                {
                    var f = s.Split(":");
                    pass.fields.Add(f[0], f[1]);
                }
            }
            Console.WriteLine("Valid passports Part1 = " + passports.Count(p => p.CheckFields()));
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            string[] data = _input.Split(new char[] { ' ', '\n' });
            List<Passport> passports = new List<Passport>();
            Passport pass = new Passport();
            foreach (string s in data)
            {
                if (s == "")
                {
                    passports.Add(pass);
                    pass = new Passport();
                }
                else
                {
                    var f = s.Split(":");
                    pass.fields.Add(f[0], f[1]);
                }
            }
            Console.WriteLine("Valid passports Part2 = " + passports.Count(p => p.ValidateFields()));
        }
    }

    class Passport
    {
        public Dictionary<string, string> fields = new Dictionary<string, string>();

        public bool CheckFields()
        {
            if (!fields.ContainsKey("byr")) return false;
            if (!fields.ContainsKey("iyr")) return false;
            if (!fields.ContainsKey("eyr")) return false;
            if (!fields.ContainsKey("hgt")) return false;
            if (!fields.ContainsKey("hcl")) return false;
            if (!fields.ContainsKey("ecl")) return false;
            if (!fields.ContainsKey("pid")) return false;
            return true;
        }

        public bool ValidateFields()
        {
            if (!CheckFields()) return false;
            var byr = int.Parse(fields["byr"]);
            if (byr < 1920 || byr > 2002) return false;
            var iyr = int.Parse(fields["iyr"]);
            if (iyr < 2010 || iyr > 2020) return false;
            var eyr = int.Parse(fields["eyr"]);
            if (eyr < 2020 || eyr > 2030) return false;
            // Regex from here https://stackoverflow.com/questions/2362153/how-do-i-split-a-string-in-c-sharp-based-on-letters-and-numbers
            Regex re = new Regex("(?<Numeric>[0-9]*)(?<Alpha>[a-zA-Z]*)");
            Match result = re.Match(fields["hgt"]);
            string measure = result.Groups["Alpha"].Value;
            int amount;
            if (!int.TryParse(result.Groups["Numeric"].Value, out amount)) return false;
            if (measure == "cm")
            {
                if (amount < 150 || amount > 193) return false;
            }
            else if (measure == "in")
            {
                if (amount < 59 || amount > 76) return false;
            }
            else return false;
            var hcl = fields["hcl"];          
            if (hcl[0] != '#' || hcl.Length != 7) return false;
            var ecl = fields["ecl"];
            string[] valid = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            if (!valid.Contains(ecl)) return false;
            var pid = fields["pid"];
            result = re.Match(pid);
            if (pid.Length != 9 || result.Groups["Numeric"].Length != 9) return false;
            return true;
        }
    }
}
