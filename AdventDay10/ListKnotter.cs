using System.Collections.Generic;

namespace AdventDay10
{
    public class ListKnotter<T>
    {
        private readonly List<T> _originalList;
        

        public ListKnotter(List<T> list)
        {
            _originalList = list;
        }

        public List<T> ApplyTwists(List<int> lengths, int repetitions)
        {
            var twistedList = new List<T>(_originalList);
            var skip = 0;
            var currentPosition = 0;

            for (int rep = 0; rep < repetitions; rep++)
            {
                for (int i = 0; i < lengths.Count; i++)
                {
                    var length = lengths[i];
                    var selected = twistedList.GetRangeCircular(currentPosition, length);
                    selected.Reverse();
                    twistedList.ReplaceRangeCircular(selected, currentPosition);
                    currentPosition += length + skip;
                    skip++;
                }
            }            

            return twistedList;
        }
    }
}
