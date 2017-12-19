namespace AdventDay9
{
    public class GroupParser
    {
        public int NumGroups { get; private set; } = 0;

        public int Score { get; private set; } = 0;

        public int NonCancelledGarbageCharacterCount { get; private set; } = 0;

        public void Parse(string input)
        {
            int i = 0;
            int layer = 0;
            bool awaitingGarbageClosingBracket = false;
            while (i < input.Length)
            {
                char current = input[i];
                if (current == '!')
                {
                    i += 2;
                    continue;
                }
                if (awaitingGarbageClosingBracket)
                {
                    if (current == '>')
                    {
                        awaitingGarbageClosingBracket = false;
                    }
                    else
                    {
                        NonCancelledGarbageCharacterCount++;
                    }
                }
                else
                {
                    if (current == '{')
                    {
                        layer++;
                    }
                    if (current == '}')
                    {
                        NumGroups++;
                        Score += layer;
                        layer--;
                    }
                    if (current == '<')
                    {
                        awaitingGarbageClosingBracket = true;
                    }
                }
                i++;
            }
        }
    }
}
