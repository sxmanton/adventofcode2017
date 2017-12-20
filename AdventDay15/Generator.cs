using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay15
{
    public class Generator
    {
        private readonly long _seed;
        private long _current;
        private readonly int _factor;
        private readonly int _divisor;
        private readonly int _divisibleBy;

        public Generator(int seed, int factor, int divisibleBy, int divisor = 2147483647)
        {
            _seed = seed;
            _factor = factor;
            _divisor = divisor;
            _divisibleBy = divisibleBy;
            Reset();
        }

        public void Reset()
        {
            _current = _seed;
        }

        public long GetNextValue()
        {
            var product = _current * _factor;
            _current = product % _divisor;
            if (_current % _divisibleBy == 0)
            {
                return _current;
            }
            else return GetNextValue();
        }

        public List<long> GetNextValues(int number)
        {
            var values = new List<long>();
            for (int i = 0; i < number; i++)
            {
                values.Add(GetNextValue());
            }
            return values;
        }
    }

    public class GeneratorA : Generator
    {
        public GeneratorA(int seed) : base(seed, 16807, 1)
        {
        }
    }

    public class GeneratorB : Generator
    {
        public GeneratorB(int seed) : base(seed, 48271, 1)
        {
        }
    }

    public class GeneratorAPart2 : Generator
    {
        public GeneratorAPart2(int seed) : base(seed, 16807, 4)
        { }
    }

    public class GeneratorBPart2 : Generator
    {
        public GeneratorBPart2(int seed) : base(seed, 48271, 8)
        { }
    }
}
