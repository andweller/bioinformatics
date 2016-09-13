using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bioinformatics.Algorithms;

namespace Bioinformatics
{
    /// <summary>
    /// A Dna Strand
    /// </summary>
    public class NucleotideDna
    {
        private string _strand;


        #region Initialization

        /// <summary>
        /// Creates a new DNA strand
        /// </summary>
        /// <param name="strand">A string of 'A' 'T' 'G' 'C' chars</param>
        /// <exception cref="ArgumentException">Throws upon invalid input</exception>
        public NucleotideDna(string strand)
        {
            _strand = verifyInput(strand);
        }



        // Verify the given input to ensure that only valid Dna chars are allowed.
        // Trims whitespace
        // Throws ArgumentException upon invalid input
        private string verifyInput(string inputStrand)
        {
            StringBuilder s = new StringBuilder(inputStrand.Length);

            foreach (char c in inputStrand)
            {
                char uc = Char.ToUpper(c);
                if (uc == 'A' || uc == 'T' || uc == 'G' || uc == 'C')
                {
                    s.Append(uc);
                }
                else if (!Char.IsWhiteSpace(uc))
                {
                    throw new ArgumentException("Dna Strand contains invalid characters. Valid characters: 'A', 'C', 'T', 'G'");
                }
            }

            return s.ToString();
        }


        #endregion


        /// <summary>
        /// Returns the nucleotide strand in char format.
        /// </summary>
        public string Dna
        {
            get { return _strand; }
        }



        /// <summary>
        /// Counts the number of times the given pattern appears in the strand.
        /// Running Time: O(n)
        /// </summary>
        /// <param name="pattern">The pattern to search for</param>
        public int PatternCount(NucleotideDna pattern)
        {
            int count = 0;
            string pattern_str = pattern.ToString();

            int patternLength = pattern_str.Length;
            int buffer = Dna.Length - patternLength;

            for (int i = 0; i <= buffer; i++)
            {
                if (Dna.Substring(i, patternLength) == pattern_str)
                    count++;
            }

            return count;
        }


        /// <summary>
        /// Scans the strand for the most frequent patterns that appear.
        /// Running Time: O(n)
        /// </summary>
        /// <param name="k">The length of patterns to search for</param>
        public IEnumerable<NucleotideDna> FrequentPatterns(int k)
        {
            Dictionary<string, int> patternCounts = new Dictionary<string, int>();

            int buffer = Dna.Length - k;

            for (int i = 0; i <= buffer; i++)
            {
                string pattern = Dna.Substring(i, k);
                if (!patternCounts.ContainsKey(pattern))
                    patternCounts.Add(pattern, PatternCount(new NucleotideDna(pattern)));
            }

            int maxCount = patternCounts.Values.Max();

            var maxPatterns = patternCounts.Where(p => p.Value == maxCount);
            return maxPatterns.Select(p => new NucleotideDna(p.Key));
        }



        /// <summary>
        /// Computes the reverse complement of the nucleotide strand.
        /// Running Time: O(n)
        /// </summary>
        public NucleotideDna ReverseComplement()
        {
            StringBuilder reverse = new StringBuilder(Dna.Length);

            for (int i = (Dna.Length - 1); i >= 0; i--)
            {
                char c = Dna[i];

                if (c == 'A')
                    reverse.Append('T');
                else if (c == 'T')
                    reverse.Append('A');
                else if (c == 'C')
                    reverse.Append('G');
                else if (c == 'G')
                    reverse.Append('C');
            }

            return new NucleotideDna(reverse.ToString());
        }



        /// <summary>
        /// Returns the starting index of any occurances of the given pattern
        /// in the nucleotide strand.
        /// Running Time: O(n)
        /// </summary>
        /// <param name="pattern">Pattern to search for</param>
        public IEnumerable<int> PatternMatchesIndicies(NucleotideDna pattern)
        {
            List<int> matches = new List<int>();
            int patternLength = pattern.Dna.Length;
            int buffer = Dna.Length - patternLength;

            for (int i = 0; i <= buffer; i++)
            {
                if (Dna.Substring(i, patternLength) == pattern.Dna)
                    matches.Add(i);
            }

            return matches;
        }



        /// <summary>
        /// Returns the starting index of any approximate matches of the given pattern.
        /// </summary>
        /// <param name="pattern">Pattern to search for</param>
        /// <param name="maxDifferences">The maximum number of differences between a match and mismatch</param>
        /// <returns></returns>
        public IEnumerable<int> ApproximatePatternMatchesIndicies(NucleotideDna pattern, int maxDifferences)
        {
            List<int> matches = new List<int>();
            int patternLength = pattern.Dna.Length;
            int buffer = Dna.Length - patternLength;

            for (int i = 0; i <= buffer; i++)
            {
                int distance = Hamming.Distance(Dna.Substring(i, patternLength), pattern.Dna);
                if (distance <= maxDifferences)
                    matches.Add(i);
            }

            return matches;
        }



        /// <summary>
        /// Searches the strand for clumps of patterns.
        /// Running Time: O(n)
        /// </summary>
        /// <param name="patternLength">The length of patterns to find</param>
        /// <param name="windowSize">The window size in which to find clumps</param>
        /// <param name="minOccurance">The minimum number of times the pattern should appear in the window</param>
        /// <returns></returns>
        public IEnumerable<NucleotideDna> PatternClumps(int patternLength, int windowSize, int minOccurance)
        {
            return Algorithms.Clumps.SlidingPatternClumps(_strand, patternLength, windowSize, minOccurance);
        }



        /// <summary>
        /// Scans the strand for differences in Cytosine Guanine balance.
        /// The skew maximizes where more Cytosine appears than Guanine.
        /// Returns indicies where the skew maximizes.
        /// Running Time: O(n)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> CytosineGuanineSkewMaximumIndicies()
        {
            int maximum = Int32.MinValue;
            List<int> locations = new List<int>();
            int currentSkew = 0;

            for (int index = 0; index < _strand.Length; index++)
            {
                char nucleotide = _strand[index];

                if (nucleotide == 'C')
                    currentSkew++;
                else if (nucleotide == 'G')
                    currentSkew--;

                if (currentSkew > maximum)
                {
                    maximum = currentSkew;
                    locations.Clear();
                    locations.Add(index);
                }
                else if (currentSkew == maximum)
                {
                    locations.Add(index);
                }
            }

            return locations;
        }



        public override string ToString()
        {
            return Dna;
        }
    }
}
