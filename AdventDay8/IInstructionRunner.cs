using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay8
{
    public interface IInstructionRunner
    {
        void ApplyInstructions(string filePath);
        Dictionary<string, int> Registers { get; }
        int HighestValueEver { get; }
    }
}
