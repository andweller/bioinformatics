using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Returns the nucleotide strand in char format
        /// </summary>
        public string Dna
        {
            get { return _strand; }
        }



        /// <summary>
        /// Counts the number of times the given pattern appears in the strand
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
        /// Scans the strand for the most frequent patterns that appear
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
        /// Computes the reverse complement of the nucleotide strand
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
        /// in the nucleotide strand
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
        /// Searches the strand for clumps of patterns.
        /// </summary>
        /// <param name="patternLength">The length of patterns to find</param>
        /// <param name="windowSize">The window size in which to find clumps</param>
        /// <param name="minOccurance">The minimum number of times the pattern should appear in the window</param>
        /// <returns></returns>
        public IEnumerable<NucleotideDna> PatternClumps(int patternLength, int windowSize, int minOccurance)
        {
            List<string> matches = new List<string>();

            int buffer = Dna.Length - patternLength;

            for (int scanIndex = 0; scanIndex <= buffer; scanIndex++)
            {
                string pattern = Dna.Substring(scanIndex, patternLength);

                if (!matches.Contains(pattern))
                {
                    int count = 0;
                    int bound = (scanIndex + windowSize) - patternLength;
                    int windowIndex = scanIndex;

                    while (windowIndex <= bound && windowIndex <= buffer)
                    {
                        if (Dna.Substring(windowIndex, patternLength) == pattern)
                            count++;
                        windowIndex++;
                    }

                    if (count >= minOccurance)
                        matches.Add(pattern);
                }
            }

            return matches.Select(m => new NucleotideDna(m));
        }
        


        public override string ToString()
        {
            return Dna;
        }
    }
}
