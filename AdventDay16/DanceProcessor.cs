using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay16
{
    public class DanceProcessor
    {
        private readonly string _original;
        
        private List<Func<string, string>> _moves = new List<Func<string, string>>();

        public DanceProcessor(string original, string moves)
        {
            _original = original;
            _moves = moves.Split(',').Select(GetMove).ToList();
        }

        public string DoMoves(int numTimes)
        {
            var current = _original;
            for (int i = 0; i < numTimes; i++)
            {
                current = _moves.Aggregate(current, (state, move) => move(state));

                if (current == _original && i <= numTimes - 1)
                {
                    var loopLength = i + 1;
                    var remainder = numTimes % loopLength;
                    return DoMoves(remainder);
                }
                Console.Write("\r{0}", i);
            }
            Console.WriteLine();
            return current;
        }

        public static Func<string, string> GetMove(string move)
        {
            switch(move.ToLower()[0])
            {
                case 's':
                    var number = move.Substring(1);
                    return new Func<string, string>(order => Spin(order, int.Parse(number)));
                case 'x':
                    var indices = move.Substring(1).Split('/').Select(int.Parse).ToArray();
                    return new Func<string, string>(order => Exchange(order, indices[0], indices[1]));
                case 'p':
                    var names = move.Substring(1).Split('/').ToArray();
                    return new Func<string, string>(order => Partner(order, names[0].First(), names[1].First()));
                default:
                    throw new Exception("Invalid Move");
            }
        }

        public static string ApplyMapping(string original, string result, int numberOfTimes)
        {
            List<int> mapping = new List<int>();

            for (int i = 0; i < original.Length; i++)
            {
                mapping.Add(result.IndexOf(original[i]));
            }

            var last = original;

            for (int i = 0; i < numberOfTimes; i++)
            {
                var current = "";
                foreach (int index in mapping)
                {
                    current += last[index];
                }
                last = current;
            }

            return last;
        }

        public static string Spin(string order, int number)
        {
            var split = order.Length - number;
            return order.Substring(split) + order.Substring(0, split);
        }

        public static string Exchange(string order, int positionA, int positionB)
        {
            var charA = order[positionA];
            var charB = order[positionB];
            var builder = new StringBuilder(order);
            builder[positionA] = charB;
            builder[positionB] = charA;
            return builder.ToString();
        }

        public static string Partner(string order, char nameA, char nameB)
        {
            var positionA = order.IndexOf(nameA);
            var positionB = order.IndexOf(nameB);
            return Exchange(order, positionA, positionB);
        }
    }
}
