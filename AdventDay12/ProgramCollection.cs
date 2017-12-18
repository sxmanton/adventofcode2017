using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay12
{
    public class ProgramCollection
    {
        private Dictionary<int, List<int>> _connectedPrograms = new Dictionary<int, List<int>>();

        public void AddProgram(KeyValuePair<int, List<int>> kvp)
        {
            _connectedPrograms.Add(kvp.Key, kvp.Value);
        }

        public List<int> GetConnectedPrograms(int program)
        {
            List<int> connectedPrograms = new List<int>
            {
                program
            };

            AddConnectedPrograms(connectedPrograms, program);

            return connectedPrograms;
        }

        public int GetNumberOfGroups()
        {
            var numGroups = 1;

            List<int> programsAccountedFor = new List<int>();

            programsAccountedFor.AddRange(GetConnectedPrograms(0));

            while (programsAccountedFor.Count < _connectedPrograms.Count)
            {
                var unaccountedForProgram = _connectedPrograms.Keys.First(p => !programsAccountedFor.Contains(p));

                programsAccountedFor.AddRange(GetConnectedPrograms(unaccountedForProgram));

                numGroups++;
            }

            return numGroups;
        }

        private void AddConnectedPrograms(List<int> programs, int program)
        {
            var connected = _connectedPrograms[program];

            foreach (int connectedProgram in connected)
            {

                if (!programs.Contains(connectedProgram))
                {
                    programs.Add(connectedProgram);
                    AddConnectedPrograms(programs, connectedProgram);
                }
            }
        }
    }
}
