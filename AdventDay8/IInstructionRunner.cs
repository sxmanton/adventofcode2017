using System.Collections.Generic;

namespace AdventDay8
{
    public interface IInstructionRunner
    {
        void ApplyInstructions(string filePath);
        Dictionary<string, int> Registers { get; }
        int HighestValueEver { get; }
    }
}
