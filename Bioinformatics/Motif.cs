using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bioinformatics.Algorithms;

namespace Bioinformatics
{
    public static class Motif
    {
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


        //MotifEnumeration(Dna, k, d)
        //Patterns ← an empty set
        //for each k-mer Pattern in Dna
        //    for each k-mer Pattern’ differing from Pattern by at most d
        //      mismatches
        //        if Pattern' appears in each string from Dna with at most d
        //        mismatches
        //            add Pattern' to Patterns
        //remove duplicates from Patterns
        //return Patterns
    }
}
