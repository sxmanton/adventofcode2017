using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay18
{
    public class DuetRunner
    {
        public DuetProgram Program1 { get; } 
        public DuetProgram Program2 { get; }

        private Task _program1CurrentTask;
        private Task _program2CurrentTask;

        private bool _isTerminated =>
            (Program1.IsTerminated && Program2.IsTerminated) ||
            (Program1.IsTerminated && Program2.IsWaitingToReceive) ||
            (Program1.IsWaitingToReceive && Program2.IsTerminated) ||
            (Program1.IsWaitingToReceive && Program2.IsWaitingToReceive);

        public DuetRunner(string instructionFile, long program1id, long program2id)
        {
            Program1 = new DuetProgram(instructionFile, program1id);
            Program2 = new DuetProgram(instructionFile, program2id);
            Program1.SetPartner(Program2);
            Program2.SetPartner(Program1);
        }

        public void RunTillTerminated()
        {
            while (!_isTerminated)
            {
                if (!Program1.IsWaitingToReceive && !Program1.IsTerminated)
                {
                    if (_program1CurrentTask == null || _program1CurrentTask.IsCompleted)
                    {
                        _program1CurrentTask = Task.Run(() => Program1.DoCurrentInstruction());
                    }
                }
                if (!Program2.IsWaitingToReceive && !Program2.IsTerminated)
                {
                    if (_program2CurrentTask == null || _program2CurrentTask.IsCompleted)
                    {
                        _program2CurrentTask = Task.Run(() => Program2.DoCurrentInstruction());
                    }
                }
            }
        }
    }
}
