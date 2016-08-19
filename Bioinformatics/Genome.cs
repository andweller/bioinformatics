using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioinformatics
{
    public class Genome
    {
        private NucleotideDna _strand;


        /// <summary>
        /// Creates a new Genome with the given input strand
        /// </summary>
        /// <param name="strand">Input Dna strand</param>
        public Genome (NucleotideDna strand)
        {
            _strand = strand;
        }



        /// <summary>
        /// Creates a new Genome with the given input strand
        /// </summary>
        /// <param name="inputStrand">A string of 'A' 'T' 'G' 'C' chars</param>
        /// <exception cref="ArgumentException">Throws upon invalid input</exception>
        public Genome(string inputStrand) : 
            this(new NucleotideDna(inputStrand)) { }



        public override string ToString()
        {
            return _strand.ToString();
        }
    }
}
