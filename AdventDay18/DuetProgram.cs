using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AdventDay18
{
    public class DuetProgram
    {
        List<Action> _instructions = new List<Action>();
        private int _currentInstructionIndex = 0;
        private long _programId;

        Dictionary<string, long> _registerValues = new Dictionary<string, long>();
        private ManualResetEvent partnerSentValue = new ManualResetEvent(false);
        public bool IsWaitingToReceive { get; private set; } = false;
        public bool IsTerminated => (_currentInstructionIndex < 0 ||
            _currentInstructionIndex > _instructions.Count);
        public List<long> SendQueue = new List<long>();
        public int SentCount { get; private set; } = 0;
        public event EventHandler ValueSent;

        private DuetProgram _partner;

        public DuetProgram(string fileName, long programId)
        {
            using (var reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    _instructions.Add(ParseInstruction(reader.ReadLine()));
                }
            }
            _programId = programId;
            _registerValues["p"] = programId;
        }

        public void OnPartner_ValueSent(object sender, EventArgs e)
        {
            Debug.WriteLine($"program {_programId} got valuesent from partner");
            partnerSentValue.Set();
        }

        public void SetPartner(DuetProgram program)
        {
            _partner = program;
            _partner.ValueSent += OnPartner_ValueSent;
        }

        public void DoCurrentInstruction()
        {
            _instructions[_currentInstructionIndex]();
            _currentInstructionIndex++;
        }

        private Action ParseInstruction(string instruction)
        {
            var instructionParts = instruction.Split(' ');
            var command = instructionParts[0];
            var register = instructionParts[1];

            TryInitializeRegister(register);

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
                    return () => Send(register);
                case "rcv":
                    return () => Receive(register);
                default:
                    throw new ArgumentException("Unrecognized command", command);
            }
        }

        private Action ParseThreePartInstruction(string command, string register, string argument)
        {
            TryInitializeRegister(argument);

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

        private void Send(string registerOrValue)
        {
            Debug.WriteLine($"program {_programId} sending... {SentCount}");
            long value = GetValue(registerOrValue);
            SendQueue.Add(value);
            SentCount++;
            ValueSent?.Invoke(this, null);
        }

        private void Receive(string register)
        { 
            if (_partner.SendQueue.Count == 0)
            {
                Debug.WriteLine($"program {_programId} waiting to receive");
                IsWaitingToReceive = true;
                partnerSentValue.WaitOne();
            }
            partnerSentValue.Reset();
            Debug.WriteLine($"program {_programId} receiving...");
            IsWaitingToReceive = false;
            _registerValues[register] = _partner.SendQueue.First();
            _partner.SendQueue.RemoveAt(0);
        }

        private void Set(string register, string registerOrNumber)
        {
            _registerValues[register] = GetValue(registerOrNumber);
        }

        private void Add(string register, string registerOrNumber)
        {
            _registerValues[register] += GetValue(registerOrNumber);
        }

        private void Multiply(string register, string registerOrNumber)
        {
            _registerValues[register] *= GetValue(registerOrNumber);
        }

        private void Mod(string register, string registerOrNumber)
        {
            _registerValues[register] = _registerValues[register] % GetValue(registerOrNumber);
        }

        private void JumpIfGreaterThanZero(string registerOrNumber, string jump)
        {

            var value = GetValue(registerOrNumber);
            var jumpValue = GetValue(jump);
            if (value > 0)
            {
                _currentInstructionIndex += (int)jumpValue - 1;
            }
        }

        private long GetValue(string registerOrValue)
        {
            if (long.TryParse(registerOrValue, out long value))
            {
                return value;
            }
            return _registerValues[registerOrValue];
        }

        private void TryInitializeRegister(string register)
        {
            if (!long.TryParse(register, out long number)
                && !_registerValues.ContainsKey(register))
            {
                _registerValues.Add(register, 0);
            }
        }
    }
}

