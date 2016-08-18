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
    public class DnaStrand
    {
        private string _strand;


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
                if (c == 'A' || c == 'T' || c == 'G' || c == 'C')
                {
                    s.Append(c);
                }
                else if (!Char.IsWhiteSpace(c))
                {
                    throw new ArgumentException("Dna Strand contains invalid characters. Valid characters: 'A', 'C', 'T', 'G'");
                }
            }

            return s.ToString();
        }
    }
}
