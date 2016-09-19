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



        /// <summary>
        /// Returns the cummulative distance between the given pattern and matches in the strand collection.
        /// </summary>
        /// <param name="strands">Strands to search against</param>
        /// <param name="pattern">The given pattern</param>
        /// <returns></returns>
        public static int DistanceBetweenPatternsAndStrands(IEnumerable<DnaStrand> strands, DnaStrand pattern)
        {
            int distance = 0;

            foreach (DnaStrand strand in strands)
            {
                int hamming = Int32.MaxValue;

                int buffer = strand.Dna.Length - pattern.Dna.Length;

                for (int index = 0; index <= buffer; index++)
                {
                    string substrand = strand.Dna.Substring(index, pattern.Dna.Length);
                    int subDistance = Hamming.Distance(substrand, pattern.Dna);
                    if (hamming > subDistance)
                        hamming = subDistance;
                }

                distance = distance + hamming;
            }

            return distance;
        }



        /// <summary>
        /// Brute Force implementation to find the median string within the given strands.
        /// </summary>
        /// <param name="strands">Strands to search against</param>
        /// <param name="patternLength">The pattern length to search for</param>
        /// <returns></returns>
        public static DnaStrand MedianString(IEnumerable<DnaStrand> strands, int patternLength)
        {
            int distance = Int32.MaxValue;
            double range = Math.Pow(4, patternLength) - 1;
            DnaStrand median = null;

            for (int i = 0; i < range; i++)
            {
                DnaStrand pattern = new DnaStrand(NumberToPattern(i, patternLength));

                int iDistance = DistanceBetweenPatternsAndStrands(strands, pattern);
                if (distance > iDistance)
                {
                    distance = iDistance;
                    median = pattern;
                }
            }

            return median;
        }



        /// <summary>
        /// Finds the most probable subpattern based on the given profile.
        /// </summary>
        /// <param name="strand">The strand to search against</param>
        /// <param name="patternLength">The length of subpattern to search for</param>
        /// <param name="profile">Assumes keys of 'A' 'C' 'T' 'G' and their probabilities per strand index</param>
        /// <returns></returns>
        public static DnaStrand ProfileMostProbablePattern(DnaStrand strand, int patternLength, Dictionary<char, List<double>> profile)
        {
            DnaStrand pattern = null;
            double mostProbable = 0.0;

            int buffer = strand.Dna.Length - patternLength;

            for (int index = 0; index <= buffer; index++)
            {
                DnaStrand substrand = strand.SubStrand(index, patternLength);

                double testProbability = 1.0;

                for (int subIndex = 0; subIndex < patternLength; subIndex++)
                {
                    testProbability *= profile[substrand.Dna[subIndex]][subIndex];
                }

                if (testProbability > mostProbable)
                {
                    mostProbable = testProbability;
                    pattern = substrand;
                }
            }


            return pattern;
        }



        /// <summary>
        /// Generates a DNA string from a given integer value.
        /// Used as a reverse hash function when generating strand values.
        /// </summary>
        /// <param name="value">The integer hash value</param>
        /// <param name="length">The length of the generated strand</param>
        /// <returns></returns>
        private static string NumberToPattern(int value, int length)
        {
            if (length == 1)
                return "ATGC"[value].ToString();

            int prefix = value / 4;
            int remainder = value % 4;
            char symbol = "ATGC"[remainder];
            string pattern = NumberToPattern(prefix, length - 1);
            return pattern + symbol;
        }

    }
}
