using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay18
{
    public class FakeDuetRunner
    {
        List<Action> _instructions = new List<Action>();
        Dictionary<string, long> _registerValues = new Dictionary<string, long>();

        private long _lastSoundedFrequency;
        private long? _lastRecoveredFrequency = null;
        private int _currentInstructionIndex = 0;

        public FakeDuetRunner(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    _instructions.Add(ParseInstruction(reader.ReadLine()));
                }
            }
        }

        public long FirstRecoveredFrequency()
        {
            while (_lastRecoveredFrequency == null && 0 <= _currentInstructionIndex && _currentInstructionIndex < _instructions.Count)
            {
                Debug.Write($"Executing instruction at line {_currentInstructionIndex + 1}: ");
                _instructions[_currentInstructionIndex]();
                _currentInstructionIndex++;
            }
            if (_lastRecoveredFrequency.HasValue)
            {
                return _lastRecoveredFrequency.Value;
            }
            throw new Exception("Program terminated without recovering a frequency");
        }

        private Action ParseInstruction(string instruction)
        {
            var instructionParts = instruction.Split(' ');
            var command = instructionParts[0];
            var register = instructionParts[1];

            InitializeRegister(register);

            switch (instructionParts.Length)
            {
                case 2:
                    return ParseTwoPartInstruction(command, register);
                case 3:
                    return ParseThreePartInstruction(command, register, instructionParts[2]);
                default:
                    throw new ArgumentException("Instruction line did not match any expected format");
            }
        }

        private Action ParseTwoPartInstruction(string command, string register)
        {
            switch (command)
            {
                case "snd":
                    return () => Sound(register);
                case "rcv":
                    return () => Recover(register);
                default:
                    throw new ArgumentException("Unrecognized command", command);
            }
        }

        private void Sound(string register)
        {
            _lastSoundedFrequency = _registerValues[register];
            Debug.WriteLine($"snd {register} {_lastSoundedFrequency}");
        }

        private void Recover(string register)
        {
            Debug.Write($"rcv {register} ");
            if (_registerValues[register] != 0)
            {
                Debug.WriteLine($"recovered {_lastSoundedFrequency}");
                _lastRecoveredFrequency = _lastSoundedFrequency;
            }
            else
            {
                Debug.WriteLine($"skipped");
            }
        }

        private Action ParseThreePartInstruction(string command, string register, string argument)
        {
            if (long.TryParse(argument, out long value))
            {
                return ParseThreePartInstructionWithNumberArgument(command, register, value);
            }
            else
            {
                InitializeRegister(argument);
                return ParseThreePartInstructionWithRegisterArgument(command, register, argument);
            }
        }

        private Action ParseThreePartInstructionWithNumberArgument(string command, string register, long value)
        {
            switch (command)
            {
                case "set":
                    return () => Set(register, value);
                case "add":
                    return () => Add(register, value);
                case "mul":
                    return () => Multiply(register, value);
                case "mod":
                    return () => Mod(register, value);
                case "jgz":
                    return () => JumpIfGreaterThanZero(register, value);
                default:
                    throw new ArgumentException("Unrecognized command", command);
            }
        }

        private Action ParseThreePartInstructionWithRegisterArgument(string command, string register, string argument)
        {
            switch (command)
            {
                case "set":
                    return () => Set(register, argument);
                case "add":
                    return () => Add(register, argument);
                case "mul":
                    return () => Multiply(register, argument);
                case "mod":
                    return () => Mod(register, argument);
                case "jgz":
                    return () => JumpIfGreaterThanZero(register, argument);
                default:
                    throw new ArgumentException("Unrecognized command", command);
            }
        }

        private void Set(string register, long value)
        {
            _registerValues[register] = value;
            Debug.WriteLine($"set {register} {value} => {register} = {_registerValues[register]}");
        }

        private void Add(string register, long value)
        {
            _registerValues[register] += value;
            Debug.WriteLine($"add {register} {value} => {register} = {_registerValues[register]}");
        }

        private void Multiply(string register, long value)
        {
            checked
            {
                _registerValues[register] *= value;
            }
            Debug.WriteLine($"mul {register} {value} => {register} = {_registerValues[register]}");
        }

        private void Mod(string register, long value)
        {
            _registerValues[register] = _registerValues[register] % value;
            Debug.WriteLine($"mod {register} {value} => {register} = {_registerValues[register]}");
        }

        private void JumpIfGreaterThanZero(string register, long value)
        {
            Debug.Write($"jgz {register} {value} ");

            long number;

            if (!long.TryParse(register, out number))
            {
                number = _registerValues[register];
            }
            if (number > 0)
            {
                Debug.WriteLine("jumped");
                _currentInstructionIndex += (int)value - 1;
            }
            else
            {
                Debug.WriteLine("skipped");
            }
        }

        private void Set(string register, string otherRegister)
        {
            Debug.Write($"set {register} {otherRegister} => ");
            Set(register, _registerValues[otherRegister]);
        }

        private void Add(string register, string otherRegister)
        {
            Debug.Write($"add {register} {otherRegister} => ");
            Add(register, _registerValues[otherRegister]);
        }

        private void Multiply(string register, string otherRegister)
        {
            Debug.Write($"mul {register} {otherRegister} => ");
            Multiply(register, _registerValues[otherRegister]);
        }

        private void Mod(string register, string otherRegister)
        {
            Debug.Write($"mod {register} {otherRegister} => ");
            Mod(register, _registerValues[otherRegister]);
        }

        private void JumpIfGreaterThanZero(string register, string otherRegister)
        {
            Debug.Write($"jgz {register} {otherRegister} => ");
            JumpIfGreaterThanZero(register, _registerValues[otherRegister]);
        }

        private void InitializeRegister(string register)
        {
            if (!_registerValues.ContainsKey(register))
            {
                _registerValues.Add(register, 0);
            }
        }
    }
}
