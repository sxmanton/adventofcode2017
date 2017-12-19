using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventDay7
{
    public class Program
    {
        static void Main(string[] args)
        {
            var programs = ProgramListParser.GetProgramModelsFromFile("input.txt");
            var bottom = FindBottomMost(programs);

            var unbalanced = FindTopmostUnbalancedProgram(programs);
            var desiredWeight = GetNecessaryWeightToBalance(unbalanced);

            Console.WriteLine("Bottom-most: {0}", bottom.Name);

            Console.WriteLine("Program {0} needs to be {1} for balance", unbalanced.Name, desiredWeight);
            Console.ReadLine();
        }

        public static ProgramModel FindBottomMost(List<ProgramModel> programs)
        {
            return programs.First(pm => pm.Parent == null);
        }

        public static int GetNecessaryWeightToBalance(ProgramModel topmostUnbalanced)
        {
            var desiredWeight = GetModeWeightOfChildren(topmostUnbalanced.Parent);

            var diff = desiredWeight - topmostUnbalanced.WeightIncludingAllChildren;

            return topmostUnbalanced.Weight + diff;
        }

        public static ProgramModel FindTopmostUnbalancedProgram(List<ProgramModel> programs)
        {
            var bottom = FindBottomMost(programs);

            var unbalanced = FindUnbalancedChild(bottom);
            while (unbalanced.Children.Any())
            {
                var unbalancedChild = FindUnbalancedChild(unbalanced);
                if (unbalancedChild == null)
                {
                    break;
                }
                unbalanced = unbalancedChild;
            }

            return unbalanced;
        }

        private static ProgramModel FindUnbalancedChild(ProgramModel program)
        {
            var modeWeight = GetModeWeightOfChildren(program);

            if (program.Children.All(p => p.WeightIncludingAllChildren == modeWeight))
            {
                return null;
            }

            return program.Children.First(p => p.WeightIncludingAllChildren != modeWeight);
        }

        private static int GetModeWeightOfChildren(ProgramModel program)
        {
            return program.Children.GroupBy(p => p.WeightIncludingAllChildren).
                OrderByDescending(g => g.Count()).
                Select(g => g.Key).FirstOrDefault();
        }
    }
}
