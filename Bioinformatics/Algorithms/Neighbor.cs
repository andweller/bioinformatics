using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioinformatics.Algorithms
{
    public static class NucleotideNeighbors
    {

        /// <summary>
        /// Generates the neighborhood for a given nucleotide strand.
        /// </summary>
        /// <param name="strand">Strand to generate from</param>
        /// <param name="patternLength">The length of neighbor patterns within the strand</param>
        /// <param name="maxDistance">Maximum Hammong distance to generate between patterns</param>
        /// <returns></returns>
        public static IEnumerable<DnaStrand> Neighborhood(DnaStrand strand, int patternLength, int maxDistance)
        {
            SortedSet<DnaStrand> neighbors = new SortedSet<DnaStrand>();
            int buffer = strand.Dna.Length - patternLength;

            for (int index = 0; index <= buffer; index++)
            {
                DnaStrand pattern = strand.SubStrand(index, patternLength);

                if (!neighbors.Contains(pattern))
                {
                    foreach (DnaStrand neighbor in Neighbors(pattern, maxDistance))
                    {
                        neighbors.Add(neighbor);
                    }
                }
            }

            return neighbors;
        }



        /// <summary>
        /// Generates the neighbors of a given pattern up to the given Hammond distance
        /// </summary>
        /// <param name="pattern">The base pattern</param>
        /// <param name="maxDistance">Maximum Hammond distance to generate</param>
        /// <returns></returns>
        public static IEnumerable<DnaStrand> Neighbors(DnaStrand pattern, int maxDistance)
        {
            SortedSet<DnaStrand> neighbors = new SortedSet<DnaStrand>();
            neighbors.Add(pattern);

            int currentDistance = 1;
            SortedSet<DnaStrand> tempList = new SortedSet<DnaStrand>();

            while (currentDistance++ <= maxDistance)
            {
                foreach (DnaStrand iterNeighbor in neighbors)
                {
                    foreach (DnaStrand newNeighbor in ImmediateNeighbors(iterNeighbor))
                    {
                        tempList.Add(newNeighbor);
                    }
                }

                foreach (DnaStrand neighbor in tempList)
                {
                    neighbors.Add(neighbor);
                }

                tempList.Clear();
            }

            return neighbors;
        }



        /// <summary>
        /// Generates the immediate neighbors (Hammond distance = 1) for the given pattern
        /// </summary>
        /// <param name="pattern">The base pattern</param>
        /// <returns></returns>
        public static IEnumerable<DnaStrand> ImmediateNeighbors(DnaStrand pattern)
        {
            List<DnaStrand> neighbors = new List<DnaStrand>();
            StringBuilder patternBuilder = new StringBuilder(pattern.Dna);

            for (int index = 0; index < pattern.Dna.Length; index++)
            {
                char nucleotide = patternBuilder[index];

                if (nucleotide != 'A')
                {
                    patternBuilder[index] = 'A';
                    neighbors.Add(new DnaStrand(patternBuilder.ToString()));
                }
                if (nucleotide != 'T')
                {
                    patternBuilder[index] = 'T';
                    neighbors.Add(new DnaStrand(patternBuilder.ToString()));
                }
                if (nucleotide != 'C')
                {
                    patternBuilder[index] = 'C';
                    neighbors.Add(new DnaStrand(patternBuilder.ToString()));
                }
                if (nucleotide != 'G')
                {
                    patternBuilder[index] = 'G';
                    neighbors.Add(new DnaStrand(patternBuilder.ToString()));
                }

                patternBuilder[index] = nucleotide;
            }

            return neighbors;
        }

    }
}
