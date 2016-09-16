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
    public class DnaStrand : IEquatable<DnaStrand>, IComparable<DnaStrand>
    {
        private string _strand;


        #region Initialization

        /// <summary>
        /// Creates a new DNA strand
        /// </summary>
        /// <param name="strand">A string of 'A' 'T' 'G' 'C' chars</param>
        /// <exception cref="ArgumentException">Throws upon invalid input</exception>
        public DnaStrand(string strand)
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
        /// Returns a substrand of the current strand
        /// </summary>
        /// <param name="startIndex">Start index of the substrand within the current strand</param>
        /// <param name="length">The length of the substrand</param>
        /// <returns></returns>
        public DnaStrand SubStrand(int startIndex, int length)
        {
            return new DnaStrand(_strand.Substring(startIndex, length));
        }



        /// <summary>
        /// Computes the reverse complement of the nucleotide strand.
        /// Running Time: O(n)
        /// </summary>
        public DnaStrand ReverseComplement()
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

            return new DnaStrand(reverse.ToString());
        }


        #region Pattern Algorithms


        /// <summary>
        /// Returns the number of times the given pattern appears in the strand.
        /// Running Time: O(n)
        /// </summary>
        /// <param name="pattern">The pattern to search for</param>
        public int PatternCount(DnaStrand pattern)
        {
            int count = 0;

            int patternLength = pattern.Dna.Length;
            int buffer = Dna.Length - patternLength;

            for (int index = 0; index <= buffer; index++)
            {
                if (Dna.Substring(index, patternLength) == pattern.Dna)
                    count++;
            }

            return count;
        }



        /// <summary>
        /// Returns the number of times the approximate given pattern appears in the strand.
        /// Counts mismatches up to the given maximum number of differences.
        /// Running Time: O(n)
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="maxDifference">The maximum number of differences between a match and mismatch</param>
        public int ApproximatePatternCount(DnaStrand pattern, int maxDifference)
        {
            int count = 0;

            int patternLength = pattern.Dna.Length;
            int buffer = Dna.Length - patternLength;

            for (int index = 0; index <= buffer; index++)
            {
                int distance = Hamming.Distance(Dna.Substring(index, patternLength), pattern.Dna);
                if (distance <= maxDifference)
                    count++;
            }

            return count;
        }



        /// <summary>
        /// Scans the strand for the most frequent patterns that appear.
        /// Running Time: O(n)
        /// </summary>
        /// <param name="patternLength">The length of patterns to search for</param>
        public IEnumerable<DnaStrand> FrequentPatterns(int patternLength)
        {
            Dictionary<string, int> patternCounts = new Dictionary<string, int>();

            int buffer = Dna.Length - patternLength;

            for (int index = 0; index <= buffer; index++)
            {
                string pattern = Dna.Substring(index, patternLength);
                if (!patternCounts.ContainsKey(pattern))
                    patternCounts.Add(pattern, PatternCount(new DnaStrand(pattern)));
            }

            int maxCount = patternCounts.Values.Max();

            var maxPatterns = patternCounts.Where(p => p.Value == maxCount);
            return maxPatterns.Select(p => new DnaStrand(p.Key));
        }



        /// <summary>
        /// Scans the strand for the most frequent patterns that appears.
        /// Searches all possible kmers that might be mismatched up to the given maximum distance
        /// </summary>
        /// <param name="patternLength">The length of patterns to search for</param>
        /// <param name="maxDifference">The maximum number of differences between a match and mismatch</param>
        public IEnumerable<DnaStrand> FrequentPatternsWithMismatches(int patternLength, int maxDifference)
        {
            IEnumerable<DnaStrand> neighborhood = NucleotideNeighbors.Neighborhood(this, patternLength, maxDifference);

            SortedSet<DnaStrand> frequentPatterns = new SortedSet<DnaStrand>();
            int currentMax = 0;

            foreach (DnaStrand pattern in neighborhood)
            {
                if (!frequentPatterns.Contains(pattern))
                {
                    int frequency = ApproximatePatternCount(pattern, maxDifference);

                    if (frequency == currentMax)
                    {
                        frequentPatterns.Add(pattern);
                    }
                    else if (frequency > currentMax)
                    {
                        currentMax = frequency;
                        frequentPatterns.Clear();
                        frequentPatterns.Add(pattern);
                    }
                }
            }

            return frequentPatterns;
        }



        /// <summary>
        /// Scans the strand for the most frequent patterns that appears.
        /// Searches all possible kmers that might be mismatched up to the given maximum distance.
        /// Includes reverse complements of all pattern combinations.
        /// </summary>
        /// <param name="patternLength">The length of patterns to search for</param>
        /// <param name="maxDifference">The maximum number of differences between a match and mismatch</param>
        /// <returns></returns>
        public IEnumerable<DnaStrand> FrequentPatternsWithMismatchesAndReverseComplements(int patternLength, int maxDifference)
        {
            var patternNeighbors = NucleotideNeighbors.Neighborhood(this, patternLength, maxDifference);
            var reverseNeighbors = NucleotideNeighbors.Neighborhood(this.ReverseComplement(), patternLength, maxDifference);

            SortedSet<DnaStrand> frequentPatterns = new SortedSet<DnaStrand>();
            int currentMax = 0;

            foreach (DnaStrand pattern in patternNeighbors.Concat(reverseNeighbors))
            {
                if (!frequentPatterns.Contains(pattern))
                {
                    int originalFrequency = ApproximatePatternCount(pattern, maxDifference);
                    int reverseFrequency = ApproximatePatternCount(pattern.ReverseComplement(), maxDifference);
                    int frequency = originalFrequency + reverseFrequency;

                    if (frequency == currentMax)
                    {
                        frequentPatterns.Add(pattern);
                    }
                    else if (frequency > currentMax)
                    {
                        currentMax = frequency;
                        frequentPatterns.Clear();
                        frequentPatterns.Add(pattern);
                    }
                }
            }

            return frequentPatterns;
        }



        /// <summary>
        /// Returns the starting index of any occurances of the given pattern
        /// in the nucleotide strand.
        /// Running Time: O(n)
        /// </summary>
        /// <param name="pattern">Pattern to search for</param>
        public IEnumerable<int> PatternMatchesIndicies(DnaStrand pattern)
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
        /// Counts mismatches up to the given maximum number of differences.
        /// </summary>
        /// <param name="pattern">Pattern to search for</param>
        /// <param name="maxDifferences">The maximum number of differences between a match and mismatch</param>
        /// <returns></returns>
        public IEnumerable<int> ApproximatePatternMatchesIndicies(DnaStrand pattern, int maxDifference)
        {
            List<int> matches = new List<int>();
            int patternLength = pattern.Dna.Length;
            int buffer = Dna.Length - patternLength;

            for (int i = 0; i <= buffer; i++)
            {
                int distance = Hamming.Distance(Dna.Substring(i, patternLength), pattern.Dna);
                if (distance <= maxDifference)
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
        public IEnumerable<DnaStrand> PatternClumps(int patternLength, int windowSize, int minOccurance)
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

            Dictionary<string, int> frequencies = FrequencyArray.Generate(_strand.Substring(0, windowSize), patternLength);

            List<string> matches = frequencies.Where(x => x.Value >= minOccurance)
                                              .Select(x => x.Key)
                                              .ToList();

            int buffer = _strand.Length - windowSize;

            for (int scanIndex = 1; scanIndex <= buffer; scanIndex++)
            {
                string firstPattern = _strand.Substring(scanIndex - 1, patternLength);
                frequencies[firstPattern]--;

                string lastPattern = _strand.Substring(scanIndex + windowSize - patternLength, patternLength);
                if (frequencies.ContainsKey(lastPattern))
                    frequencies[lastPattern]++;
                else
                    frequencies.Add(lastPattern, 1);

                if (frequencies[lastPattern] >= minOccurance && !matches.Contains(lastPattern))
                    matches.Add(lastPattern);
            }

            return matches.Select(m => new DnaStrand(m));
        }


        #endregion

        #region Bioinformatic Algorithms

        /// <summary>
        /// Makes a computational prediction of the DNA replication origin point.
        /// Scans a window of given length at the point of maximum Cyto/Guan skew.
        /// Calculates using each pattern combination, its reverse complement, and includes mismatch counts
        /// Assumes that the object contains the entire genetic strand.
        /// </summary>
        /// <param name="skewRange">Window size to search at the skew point.</param>
        /// <param name="patternLength">The length of patterns to search for.</param>
        /// <param name="maxDifference">The maximum number of differences between a match and mismatch</param>
        /// <returns></returns>
        public IEnumerable<DnaStrand> ReplicationOriginPossibilities(int skewRange = 500, int patternLength = 9, int maxDifference = 1)
        {
            var index = CytosineGuanineSkewMaximumIndicies().First();

            SortedSet<DnaStrand> possibilities = new SortedSet<DnaStrand>();

            DnaStrand window = this.SubStrand(index, skewRange);
            var indexPatterns = window.FrequentPatternsWithMismatchesAndReverseComplements(patternLength, maxDifference);

            foreach (DnaStrand pattern in indexPatterns)
            {
                possibilities.Add(pattern);
            }

            return possibilities;
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


        #endregion



        /// <summary>
        /// Returns the string representation of the DNA Strand.
        /// Generates 'A' 'T' 'G' 'C' characters
        /// </summary>
        public override string ToString()
        {
            return Dna;
        }



        // IEquatable Implementation

        bool IEquatable<DnaStrand>.Equals(DnaStrand other)
        {
            return this.Dna.Equals(other.Dna);
        }

        int IComparable<DnaStrand>.CompareTo(DnaStrand other)
        {
            return this.Dna.CompareTo(other.Dna);
        }
    }
}
