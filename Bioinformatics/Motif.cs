﻿using System;
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
            // Returns first subpattern if no probable matches are found
            DnaStrand pattern = strand.SubStrand(0, patternLength);

            double mostProbable = 0.0;
            int buffer = strand.Dna.Length - patternLength;

            // Iterate through each possible k-length pattern in strand
            for (int index = 0; index <= buffer; index++)
            {
                DnaStrand substrand = strand.SubStrand(index, patternLength);

                double testProbability = 1.0;

                // Calculate the probability of the given substring using the profile
                for (int subIndex = 0; subIndex < patternLength; subIndex++)
                {
                    double value = profile[substrand.Dna[subIndex]][subIndex];
                    testProbability *= value;
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
        /// Generate a profile probability map for the given patterns.
        /// </summary>
        /// <param name="patterns">A collection of patterns. Assumes each pattern has the same length.</param>
        /// <param name="pseudoCounts">When true, calculates profile using small pseudo values in place of zero probabilities</param>
        /// <returns></returns>
        public static Dictionary<char, List<double>> GenerateProfile(IEnumerable<DnaStrand> patterns, bool pseudoCounts = true)
        {
            int patternLength = patterns.First().Dna.Length;
            if (patterns.Any(x => x.Dna.Length != patternLength))
                throw new ArgumentException("All patterns must have equal lengths");

            // Generate an empty profile
            Dictionary<char, List<double>> profile = new Dictionary<char, List<double>>
            {
                {'A', Enumerable.Range(0, patternLength).Select(x => 0.0).ToList() },
                {'C', Enumerable.Range(0, patternLength).Select(x => 0.0).ToList() },
                {'G', Enumerable.Range(0, patternLength).Select(x => 0.0).ToList() },
                {'T', Enumerable.Range(0, patternLength).Select(x => 0.0).ToList() }
            };

            // Find each occurance of the nucleotides and update the profile
            for (int index = 0; index < patternLength; index++)
            {
                foreach (DnaStrand pattern in patterns)
                {
                    char nucleotide = pattern.Dna[index];
                    profile[nucleotide][index]++;
                }
            }

            int numOfPatterns = patterns.Count();

            Func<double, double> average;

            if (pseudoCounts == true)
                average = x => (x + 1) / (numOfPatterns + 1);
            else
                average = x => x / numOfPatterns;

            // Calculates the average for the final profile
            return new Dictionary<char, List<double>>
            {
                {'A', profile['A'].Select(average).ToList() },
                {'C', profile['C'].Select(average).ToList() },
                {'G', profile['G'].Select(average).ToList() },
                {'T', profile['T'].Select(average).ToList() }
            };
        }



        /// <summary>
        /// Calculates a motif score based on the sum of unpopular nucleotide occurances
        /// </summary>
        /// <param name="strands">Strands to score</param>
        /// <param name="strandLength">The length of every strand in the strands collection.</param>
        /// <returns></returns>
        public static int Score(IEnumerable<DnaStrand> strands, int strandLength)
        {
            int score = 0;

            for (int index = 0; index < strandLength; index++)
            {
                Dictionary<char, int> nucleotideCounts = new Dictionary<char, int>
                {
                    {'A', 0 },
                    {'C', 0 },
                    {'G', 0 },
                    {'T', 0 }
                };

                foreach (DnaStrand strand in strands)
                {
                    nucleotideCounts[strand.Dna[index]]++;
                }

                score += (strands.Count() - nucleotideCounts.Values.Max());
            }

            return score;
        }



        /// <summary>
        /// Searches for probable motifs using a Greedy approach.
        /// </summary>
        /// <param name="strands">Strands to search against</param>
        /// <param name="patternLength">The pattern length to search for</param>
        /// <param name="pseudoCounts">When true, calculates using small pseudo values in place of zero probabilities</param>
        /// <returns></returns>
        public static IEnumerable<DnaStrand> GreedyMotifSearch(IEnumerable<DnaStrand> strands, int patternLength, bool pseudoCounts = true)
        {
            DnaStrand firstStrand = strands.First();
            int buffer = firstStrand.Dna.Length - patternLength;

            List<DnaStrand> bestMotifs = null;
            int bestScore = Int32.MaxValue;

            // Iterate through each possible pattern in the first strand
            for (int index = 0; index <= buffer; index++)
            {
                List<DnaStrand> motifs = new List<DnaStrand>();
                motifs.Add(firstStrand.SubStrand(index, patternLength));

                // Build a collection of motifs based on previous iterations
                foreach (DnaStrand strand in strands.Skip(1))
                {
                    var profile = GenerateProfile(motifs, pseudoCounts);
                    motifs.Add(ProfileMostProbablePattern(strand, patternLength, profile));
                }

                int newScore = Score(motifs, motifs.First().Dna.Length);

                if (newScore < bestScore)
                {
                    bestMotifs = motifs;
                    bestScore = newScore;
                }
            }

            return bestMotifs;
        }



        /// <summary>
        /// Searches for approximate motifs using a random approach
        /// </summary>
        /// <param name="strands">Strands to search against</param>
        /// <param name="patternLength">The pattern length to search for</param>
        /// <param name="iterations">The number of random iterations to perform</param>
        /// <returns></returns>
        public static IEnumerable<DnaStrand> RandomizedMotifSearch(IEnumerable<DnaStrand> strands, int patternLength, int iterations = 1000)
        {
            IEnumerable<DnaStrand> bestMotifs = null;
            int bestScore = Int32.MaxValue;

            while (iterations-- > 0)
            {
                var results = RandomizedMotifSearch_Iter(strands, patternLength);

                int score = Score(results, patternLength);

                if (score < bestScore)
                {
                    bestScore = score;
                    bestMotifs = results;
                }
            }

            return bestMotifs;
        }



        // A single iteration of the randomized search algorithm
        private static IEnumerable<DnaStrand> RandomizedMotifSearch_Iter(IEnumerable<DnaStrand> strands, int patternLength)
        {
            List<DnaStrand> motifs = SelectRandomPatterns(strands, patternLength).ToList();
            List<DnaStrand> bestMotifs = motifs;
            int bestScore = Int32.MaxValue;

            while (true)
            {
                var profile = GenerateProfile(motifs);

                motifs.Clear();

                foreach (DnaStrand strand in strands)
                {
                    motifs.Add(ProfileMostProbablePattern(strand, patternLength, profile));
                }

                int score = Score(motifs, patternLength);

                if (score < bestScore)
                {
                    bestScore = score;
                    bestMotifs = motifs;
                }
                else
                    break;
            }
            
            return bestMotifs;
        }



        /// <summary>
        /// Searches for approximate motifs using Gibbs random samplling
        /// </summary>
        /// <param name="strands">Strands to search against</param>
        /// <param name="patternLength">The pattern length to search for</param>
        /// <param name="iterations">The number of Gibbs Sampling iterations per scenario</param>
        /// <param name="scenarios">The number of scenarios to run</param>
        /// <returns></returns>
        public static IEnumerable<DnaStrand> GibbsSampler(IEnumerable<DnaStrand> strands, int patternLength, int iterations, int scenarios)
        {
            IEnumerable<DnaStrand> bestResult = GibbsSamplerIter(strands, patternLength, iterations);
            int bestScore = Score(bestResult, patternLength);

            for (int scenario = 1; scenario < scenarios; scenario++)
            {
                IEnumerable<DnaStrand> result = GibbsSamplerIter(strands, patternLength, iterations);
                int score = Score(result, patternLength);

                if (score < bestScore)
                {
                    bestScore = score;
                    bestResult = result;
                }
            }

            return bestResult;
        }



        // A Gibbs Sampler scenario
        private static IEnumerable<DnaStrand> GibbsSamplerIter(IEnumerable<DnaStrand> strands, int patternLength, int iterations)
        {
            List<DnaStrand> motifs = SelectRandomPatterns(strands, patternLength).ToList();
            List<DnaStrand> bestMotifs = motifs;
            int bestScore = Int32.MaxValue;
            Random rand = new Random();

            for (int iter = 1; iter <= iterations; iter++)
            {
                int index = rand.Next(0, strands.Count());
                var profile = GenerateProfile(motifs, true);
                motifs[index] = FindGibbsPattern(strands.ElementAt(index), patternLength, profile);

                int score = Score(motifs, patternLength);

                if (score <= bestScore)
                {
                    bestScore = score;
                    bestMotifs = motifs;
                }
            }

            return bestMotifs;
        }



        // Finds a pattern for the given strand based on Gibbs Sampling the profile probabilities
        private static DnaStrand FindGibbsPattern(DnaStrand strand, int patternLength, Dictionary<char, List<double>> profile)
        {
            List<double> probabilities = new List<double>();

            int buffer = strand.Dna.Length - patternLength;
            double sum = 0;

            // Iterate through each possible k-length pattern in strand
            for (int index = 0; index <= buffer; index++)
            {
                DnaStrand substrand = strand.SubStrand(index, patternLength);

                double testProbability = 1.0;

                // Calculate the probability of the given substring using the profile
                for (int subIndex = 0; subIndex < patternLength; subIndex++)
                {
                    double value = profile[substrand.Dna[subIndex]][subIndex];
                    testProbability *= value;
                }

                sum += testProbability;
                probabilities.Add(testProbability);
            }

            Random rand = new Random();
            double result = rand.NextDouble() * sum;

            double finder = 0;
            DnaStrand pattern = null;

            // Find the weighted random result
            for (int index = 0; index <= buffer && finder < result; index++)
            {
                finder += probabilities[index];
                if (finder > result)
                    pattern = strand.SubStrand(index, patternLength);
            }

            return pattern;
        }



        /// <summary>
        /// Selects one pattern from each given strand at random
        /// </summary>
        /// <param name="strands">The strands to generate patterns from</param>
        /// <param name="patternLength">The length of patterns to generate</param>
        /// <returns></returns>
        private static IEnumerable<DnaStrand> SelectRandomPatterns(IEnumerable<DnaStrand> strands, int patternLength)
        {
            List<DnaStrand> patterns = new List<DnaStrand>();
            Random rGenerator = new Random();

            foreach (DnaStrand strand in strands)
                patterns.Add(strand.SubStrand(rGenerator.Next(0, strands.First().Dna.Length - patternLength), patternLength));

            return patterns;
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
