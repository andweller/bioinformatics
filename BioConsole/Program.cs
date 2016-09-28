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
                new DnaStrand("TGACGTTC"),
                new DnaStrand("TAAGAGTT"),
                new DnaStrand("GGACGAAA"),
                new DnaStrand("CTGTTCGC")
            };


            List<DnaStrand> patterns = new List<DnaStrand>
            {
                new DnaStrand("TGA"),
                new DnaStrand("GTT"),
                new DnaStrand("GAA"),
                new DnaStrand("TGT")
            };

            var profile = Motif.GenerateProfile(patterns, true);

            Console.Write("Profile A: ");
            foreach (double c in profile['A'])
                Console.Write(c.ToString() + " ");
            Console.WriteLine();

            Console.Write("Profile C: ");
            foreach (double c in profile['C'])
                Console.Write(c.ToString() + " ");
            Console.WriteLine();


            Console.Write("Profile G: ");
            foreach (double c in profile['G'])
                Console.Write(c.ToString() + " ");
            Console.WriteLine();

            Console.Write("Profile T: ");
            foreach (double c in profile['T'])
                Console.Write(c.ToString() + " ");
            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine("Most Probable k-mers");
            foreach (DnaStrand strand in strands)
                Console.WriteLine(Motif.ProfileMostProbablePattern(strand, 3, profile));



            Console.ReadLine();
        }
    }
}
