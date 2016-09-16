using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioinformatics.Algorithms
{
    internal static class FrequencyArray
    {
        // Computes the frequencies of patterns found within the given strand
        internal static Dictionary<string, int> Generate(string strand, int patternLength)
        {
            Dictionary<string, int> frequencies = new Dictionary<string, int>();
            int buffer = strand.Length - patternLength;

            for (int i = 0; i <= buffer; i++)
            {
                string pattern = strand.Substring(i, patternLength);

                if (frequencies.ContainsKey(pattern))
                    frequencies[pattern]++;
                else
                    frequencies.Add(pattern, 1);
            }

            return frequencies;
        }
    }
}
