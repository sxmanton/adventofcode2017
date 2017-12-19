using System;
using System.Collections.Generic;

namespace AdventDay5
{
    public static class JumpMazeCalculator
    {
        public static int StepsToEscape(List<int> originalOffsets, Func<int,int> offsetChange)
        {
            var offsets = new List<int>(originalOffsets);

            int index = 0;
            int stepCount = 0;
            while (index >= 0 && index < offsets.Count)
            {
                var offset = offsets[index];
                offsets[index] = offsetChange(offset);
                index += offset;
                stepCount++;
            }

            return stepCount;
        }

        public static int Part2OffsetChange(int originalOffset)
        {
            if (originalOffset >= 3)
            {
                return originalOffset - 1;
            }
            return originalOffset + 1;
        }
    }
}
