using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bioinformatics.Algorithms;

namespace Bioinformatics
{
    /// <summary>
    /// Motif searching algorithms
    /// </summary>
    public static class Motif
    {

        /// <summary>
        /// Generates Motif pattern matches from the given Dna strands.
        /// Brute Force approach.
        /// </summary>
        /// <param name="strands">Source strands.</param>
        /// <param name="patternLength">The length of patterns to search for.</param>
        /// <param name="maxDifferences">The maximum number of differences for mismatches.</param>
        /// <returns></returns>
        public static IEnumerable<DnaStrand> BruteEnumeration(IEnumerable<DnaStrand> strands, int patternLength, int maxDifferences)
        {
            SortedSet<DnaStrand> patterns = new SortedSet<DnaStrand>();

            foreach (DnaStrand strand in strands)
            {
                foreach (DnaStrand possibility in NucleotideNeighbors.Neighborhood(strand, patternLength, maxDifferences))
                {
                    if (strands.All(x => x.Contains(possibility, maxDifferences)))
                        patterns.Add(possibility);
                }
            }

            return patterns;
        }

    }
}
