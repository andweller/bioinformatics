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
            List<DnaStrand> strands = new List<DnaStrand>
            {
                new DnaStrand("CTCGATGAGTAGGAAAGTAGTTTCACTGGGCGAACCACCCCGGCGCTAATCCTAGTGCCC"),
                new DnaStrand("GCAATCCTACCCGAGGCCACATATCAGTAGGAACTAGAACCACCACGGGTGGCTAGTTTC"),
                new DnaStrand("GGTGTTGAACCACGGGGTTAGTTTCATCTATTGTAGGAATCGGCTTCAAATCCTACACAG")
            };

            int distance = Int32.MaxValue;
            double range = Math.Pow(4, 7) - 1;
            List<DnaStrand> median = new List<DnaStrand>();

            for (int i = 0; i < range; i++)
            {
                DnaStrand pattern = new DnaStrand(NumberToPattern(i, 7));

                int iDistance = Motif.DistanceBetweenPatternsAndStrands(strands, pattern);
                if (distance > iDistance)
                {
                    distance = iDistance;
                    median = new List<DnaStrand>();
                    median.Add(pattern);
                }
                else if (distance == iDistance)
                {
                    median.Add(pattern);
                }
            }

            foreach (DnaStrand strand in median)
                Console.WriteLine(strand);



            Console.ReadLine();
        }


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
