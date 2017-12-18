using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventDay12
{
    public static class ProgramParser
    {
        private const string REGEX = @"(?<program>\d+) <-> (?<connected>[\d, ]+)";
        private static readonly Regex regEx = new Regex(REGEX);

        public static ProgramCollection ParseFile(string filepath)
        {
            var collection = new ProgramCollection();

            using (StreamReader reader = new StreamReader(filepath))
            {
                while (!reader.EndOfStream)
                {
                    var kvp = ParseLine(reader.ReadLine());
                    collection.AddProgram(kvp);
                }
            }

            return collection;
        }

        private static KeyValuePair<int, List<int>> ParseLine(string line)
        {
            var match = regEx.Match(line);

            if (!match.Success)
            {
                throw new ArgumentException("Line did not match regex", line);
            }

            int program = int.Parse(match.Groups["program"].Value);

            var connectedProgramsString = match.Groups["connected"].Value.Replace(" ", "");

            var connectedPrograms = connectedProgramsString.Split(',').Select(int.Parse);

            return new KeyValuePair<int, List<int>>(program, connectedPrograms.ToList());
        }
    }
}
