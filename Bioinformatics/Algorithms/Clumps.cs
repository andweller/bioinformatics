using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioinformatics.Algorithms
{
    internal static class Clumps
    {

        // Pattern Clump Search Algorithm
        // Implementation: Sliding window with frequency array
        // Running Time: O(n)
        //
        // A window of given length is slid along the strand string
        // 
        // The patterns within the window are recorded in a frequency array
        // which matches patterns to the number of times it appears in the window
        // 
        // When a pattern is found enough times in a window, it is recorded
        // 
        // The set of cummulative matches is returned to the caller

        /// <summary>
        /// Returns clumped patterns found in the given strand. O(n) running time.
        /// </summary>
        /// <param name="strand">The strand to search</param>
        /// <param name="patternLength">The length of patterns to find</param>
        /// <param name="windowSize">The window size in which to find clumps</param>
        /// <param name="minOccurance">The minimum number of times the pattern should appear in the window</param>

        internal static IEnumerable<NucleotideDna> SlidingPatternClumps(string strand, int patternLength, int windowSize, int minOccurance)
        {
            Dictionary<string, int> frequencies = InitializeFrequencies(strand.Substring(0, windowSize), patternLength);

            List<string> matches = frequencies.Where(x => x.Value >= minOccurance)
                                              .Select(x => x.Key)
                                              .ToList();

            int buffer = strand.Length - windowSize;

            for (int scanIndex = 1; scanIndex <= buffer; scanIndex++)
            {
                string firstPattern = strand.Substring(scanIndex - 1, patternLength);
                frequencies[firstPattern]--;

                string lastPattern = strand.Substring(scanIndex + windowSize - patternLength, patternLength);
                if (frequencies.ContainsKey(lastPattern))
                    frequencies[lastPattern]++;
                else
                    frequencies.Add(lastPattern, 1);

                if (frequencies[lastPattern] >= minOccurance && !matches.Contains(lastPattern))
                    matches.Add(lastPattern);
            }

            return matches.Select(m => new NucleotideDna(m));
        }



        // Computes the frequencies of patterns found within the given strand
        private static Dictionary<string, int> InitializeFrequencies(string strand, int patternLength)
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
