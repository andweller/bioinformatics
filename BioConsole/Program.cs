using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bioinformatics;
using Bioinformatics.Algorithms;

namespace BioConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int distance = Hamming.Distance("TGACCCGTTATGCTCGAGTTCGGTCAGAGCGTCATTGCGAGTAGTCGTTTGCTTTCTCAAACTCC",
                "GAGCGATTAAGCGTGACAGCCCCAGGGAACCCACAAAACGTGATCGCAGTCCATCCGATCATACA");

            Console.WriteLine("Question 2: Distance = " + distance.ToString());


            DnaStrand question3 = new DnaStrand("CATTCCAGTACTTCGATGATGGCGTGAAGA");
            int skew = question3.CytosineGuanineSkewMaximumIndicies().FirstOrDefault();

            Console.WriteLine("Question 3: Skew Index = " + (skew + 1).ToString());


            DnaStrand question4 = new DnaStrand("CGTGACAGTGTATGGGCATCTTT");
            int count = question4.ApproximatePatternCount(new DnaStrand("TGT"), 1);

            Console.WriteLine("Question 4: Approx Count = " + count.ToString());


            DnaStrand question5 = new DnaStrand("TGCAT");
            int neighbors = NucleotideNeighbors.Neighborhood(question5, 5, 2).Count();

            Console.WriteLine("Question 5: kmer Count = " + neighbors.ToString());

            Console.ReadLine();
        }
    }
}
