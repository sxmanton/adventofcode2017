using System.Collections.Generic;
using System.Linq;

namespace AdventDay7
{
    public class ProgramModel
    {
        public string Name { get; set; }

        public ProgramModel Parent { get; set; }

        public List<ProgramModel> Children { get; } = new List<ProgramModel>();

        public List<string> ChildrenNames { get; } = new List<string>();

        public int Weight { get; set; }

        public int WeightIncludingAllChildren => Weight + Children.Sum(c => c.WeightIncludingAllChildren);
    }
}
