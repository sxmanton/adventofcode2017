using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventDay13
{
    public class FirewallSimulator
    {
        private Dictionary<int, int> _layerDepths = new Dictionary<int, int>();

        private int MaxLayer => _layerDepths.Keys.Max();

        private const string REGEX = @"(?<layer>\d+): (?<depth>\d+)";
        private Regex _regex = new Regex(REGEX);

        public FirewallSimulator(string layerDepthsFile)
        {
            using (StreamReader reader = new StreamReader(layerDepthsFile))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var kvp = ParseLine(line);
                    _layerDepths.Add(kvp.Key, kvp.Value);
                }
            }
        }

        public int CalculateSeverity(int delay)
        {
            int severity = 0;

            for (int layer = 0; layer <= MaxLayer; layer++)
            {
                if (IsScannerAtTopOfLayer(layer, delay + layer))
                {
                    severity += _layerDepths[layer] * layer;
                }
            }

            return severity;
        }

        public int SmallestDelayToPassThroughWithoutGettingCaught()
        {
            bool gotCaught;
            int delay = -1;
            do
            {
                delay++;
                gotCaught = IsCaughtAtAnyLayer(delay);
            }
            while (gotCaught);

            return delay;
        }

        private bool IsCaughtAtAnyLayer(int delay)
        {
            for (int i = 0; i <= MaxLayer; i++)
            {
                if (IsScannerAtTopOfLayer(i, delay + i))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsScannerAtTopOfLayer(int layer, int time)
        {
            if (!_layerDepths.ContainsKey(layer))
            {
                return false;
            }

            var depth = _layerDepths[layer];

            var loopLength = (depth - 1) * 2;

            var scannerPosition = time % loopLength;

            return scannerPosition == 0;
        }

        private KeyValuePair<int, int> ParseLine(string line)
        {
            var match = _regex.Match(line);

            if (!match.Success)
            {
                throw new ArgumentException("Line did not match expected format", line);
            }

            var layer = int.Parse(match.Groups["layer"].Value);
            var depth = int.Parse(match.Groups["depth"].Value);

            return new KeyValuePair<int, int>(layer, depth);
        }
    }
}
