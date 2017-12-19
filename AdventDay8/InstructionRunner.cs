using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventDay8
{
    public class InstructionRunner : IInstructionRunner
    {
        private const string INSTRUCTION_REGEX = @"(?<reg>\w+) (?<action>inc|dec) (?<value>-*\d+) if (?<cond>.+)";

        private const string CONDITION_REGEX = @"(?<reg>\w+) (?<op>[<>!=]+) (?<value>-*\d+)";

        private Regex _instructionRegex = new Regex(INSTRUCTION_REGEX);

        private Regex _conditionRegex = new Regex(CONDITION_REGEX);

        private int _highestValueEver = 0;

        public Dictionary<string, int> Registers { get; } = new Dictionary<string, int>();

        public int HighestValueEver => _highestValueEver;

        public void ApplyInstructions(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    ApplyInstruction(reader.ReadLine());
                }
            }
        }

        public void ApplyInstruction(string line)
        {
            var match = _instructionRegex.Match(line);

            if (!match.Success)
            {
                throw new ArgumentException("Instruction string did not match regex", line);
                
            }
            var register = match.Groups["reg"].Value;
            var action = match.Groups["action"].Value;
            var value = int.Parse(match.Groups["value"].Value);
            var condition = match.Groups["cond"].Value;

            if (!Registers.ContainsKey(register))
            {
                Registers.Add(register, 0);
            }

            if (ConditionIsTrue(condition))
            {
                switch (action)
                {
                    case "inc":
                        Registers[register] += value;
                        break;
                    case "dec":
                        Registers[register] -= value;
                        break;
                    default:
                        throw new InvalidOperationException("The instruction did not match inc or dec");
                }

                if (Registers[register] > _highestValueEver)
                {
                    _highestValueEver = Registers[register];
                }
            }

        }

        public bool ConditionIsTrue(string condition)
        {
            var match = _conditionRegex.Match(condition);
            if (match.Success)
            {
                var register = match.Groups["reg"].Value;
                var booleanOperator = match.Groups["op"].Value;
                var value = int.Parse(match.Groups["value"].Value);

                switch (booleanOperator)
                {
                    case "<":
                        return GetRegisterValue(register) < value;
                    case ">":
                        return GetRegisterValue(register) > value;
                    case "<=":
                        return GetRegisterValue(register) <= value;
                    case ">=":
                        return GetRegisterValue(register) >= value;
                    case "==":
                        return GetRegisterValue(register) == value;
                    case "!=":
                        return GetRegisterValue(register) != value;
                    default:
                        throw new InvalidOperationException("Boolean operator could not be matched");
                }

            }
            throw new ArgumentException("Condition string did not match regex", condition);
        }

        private int GetRegisterValue(string registerName)
        {
            if (!Registers.ContainsKey(registerName))
            {
                Registers.Add(registerName, 0);
            }
            return Registers[registerName];
        }
    }

}
