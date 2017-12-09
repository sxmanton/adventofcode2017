using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdventDay7
{
    public static class ProgramListParser
    {
        private const string REGEX = @"(?<name>\S+)\s+\((?<weight>\d+)\)(?:\s->\s)*(?<children>.*)";
        private static Regex _regex = new Regex(REGEX);

        public static List<ProgramModel> GetProgramModelsFromFile(string file)
        {
            var programList = new List<ProgramModel>();
            using (StreamReader reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    var programModel = ParseLine(reader.ReadLine());
                    programList.Add(programModel);
                }
            }

            foreach (ProgramModel program in programList)
            {
                foreach (string name in program.ChildrenNames)
                {
                    var childProgram = programList.First(p => p.Name == name);
                    program.Children.Add(childProgram);
                    childProgram.Parent = program;
                }
            }

            return programList;
        }

        public static ProgramModel ParseLine(string line)
        {
            var match = _regex.Match(line);
            if (match.Success)
            {
                var programModel = new ProgramModel
                {
                    Name = match.Groups["name"].Value,
                    Weight = int.Parse(match.Groups["weight"].Value)
                };
                var childrenNames = match.Groups["children"].Value;
                if (!string.IsNullOrWhiteSpace(childrenNames))
                {
                    programModel.ChildrenNames.AddRange(childrenNames.Split(',').Select(s => s.Trim()));
                }
                return programModel;
            }
            throw new ArgumentException("Could not parse the line as a ProgramModel");
        }
    }
}
