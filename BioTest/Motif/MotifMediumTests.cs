using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Bioinformatics;
using Bioinformatics.Algorithms;

namespace BioTest
{
    [TestClass]
    public class MotifMediumTests
    {
        [TestMethod]
        public void MotifMedium_Simple()
        {
            List<DnaStrand> strands = new List<DnaStrand>();
            strands.Add(new DnaStrand("AAATTGACGCAT"));
            strands.Add(new DnaStrand("GACGACCACGTT"));
            strands.Add(new DnaStrand("CGTCAGCGCCTG"));
            strands.Add(new DnaStrand("GCTGAGCACCGG"));
            strands.Add(new DnaStrand("AGTTCGGGACAG"));

            DnaStrand pattern = Motif.MedianString(strands, 3);

            Assert.AreEqual("GAC", pattern.Dna);
        }


        [TestMethod]
        public void MotifMedium_Test1()
        {
            List<DnaStrand> strands = new List<DnaStrand>();
            strands.Add(new DnaStrand("ACGT"));
            strands.Add(new DnaStrand("ACGT"));
            strands.Add(new DnaStrand("ACGT"));

            DnaStrand pattern = Motif.MedianString(strands, 3);

            Assert.AreEqual("ACG", pattern.Dna);
        }


        [TestMethod]
        public void MotifMedium_Test2()
        {
            List<DnaStrand> strands = new List<DnaStrand>();
            strands.Add(new DnaStrand("ATA"));
            strands.Add(new DnaStrand("ACA"));
            strands.Add(new DnaStrand("AGA"));
            strands.Add(new DnaStrand("AAT"));
            strands.Add(new DnaStrand("AAC"));

            DnaStrand pattern = Motif.MedianString(strands, 3);

            Assert.AreEqual("AAA", pattern.Dna);
        }


        [TestMethod]
        public void MotifMedium_Test3()
        {
            List<DnaStrand> strands = new List<DnaStrand>();
            strands.Add(new DnaStrand("AAG"));
            strands.Add(new DnaStrand("AAT"));

            DnaStrand pattern = Motif.MedianString(strands, 3);

            Assert.AreEqual("AAT", pattern.Dna);
        }


        [TestMethod]
        public void MotifMedium_Test4()
        {
            List<DnaStrand> strands = new List<DnaStrand>();
            strands.Add(new DnaStrand("TGATGATAACGTGACGGGACTCAGCGGCGATGAAGGATGAGT"));
            strands.Add(new DnaStrand("CAGCGACAGACAATTTCAATAATATCCGCGGTAAGCGGCGTA"));
            strands.Add(new DnaStrand("TGCAGAGGTTGGTAACGCCGGCGACTCGGAGAGCTTTTCGCT"));
            strands.Add(new DnaStrand("TTTGTCATGAACTCAGATACCATAGAGCACCGGCGAGACTCA"));
            strands.Add(new DnaStrand("ACTGGGACTTCACATTAGGTTGAACCGCGAGCCAGGTGGGTG"));
            strands.Add(new DnaStrand("TTGCGGACGGGATACTCAATAACTAAGGTAGTTCAGCTGCGA"));
            strands.Add(new DnaStrand("TGGGAGGACACACATTTTCTTACCTCTTCCCAGCGAGATGGC"));
            strands.Add(new DnaStrand("GAAAAAACCTATAAAGTCCACTCTTTGCGGCGGCGAGCCATA"));
            strands.Add(new DnaStrand("CCACGTCCGTTACTCCGTCGCCGTCAGCGATAATGGGATGAG"));
            strands.Add(new DnaStrand("CCAAAGCTGCGAAATAACCATACTCTGCTCAGGAGCCCGATG"));

            DnaStrand pattern = Motif.MedianString(strands, 6);

            Assert.AreEqual("CGGCGA", pattern.Dna);
        }



        [TestMethod]
        public void MotifMedium_Test5()
        {
            List<DnaStrand> strands = new List<DnaStrand>();
            strands.Add(new DnaStrand("TAAGCGTTTGTGCGTAGCGTATAAGTCTAACCAACTTGTTGA"));
            strands.Add(new DnaStrand("AGGTTCACGACTTATCTGTACGCGGACCGTCGCTGAATCACA"));
            strands.Add(new DnaStrand("CTAAATATACTTTCAGTCCGGGTATATGCGCAGTGTTCGAAA"));
            strands.Add(new DnaStrand("CTTATCAGAGAGGGCTTGCTAGTCCCTCAATGTTGATATGCG"));
            strands.Add(new DnaStrand("TACGCGTTTCAGCTGCACTCAAATAGATTGATAAACGCGTTA"));
            strands.Add(new DnaStrand("AGTGCGGTACCGATACATTTCGCTCTTTTGCGGGCTTACGCG"));
            strands.Add(new DnaStrand("TACCTTATGGCATACGCGTGGCGTACAAGCTCCTTCGCCGTC"));
            strands.Add(new DnaStrand("CATAAGGATCTAGGCTGGTAGGCGTTTTTAGACCCCTGTTAT"));
            strands.Add(new DnaStrand("ATGGGAGCCCTCCATCGTGCAGCCTACGCGCGGTTATTCCCT"));
            strands.Add(new DnaStrand("TATGCGTGTCCGGGTCGTCTAACGGGTTCGTCTCTCGTCCGT"));

            DnaStrand pattern = Motif.MedianString(strands, 6);

            Assert.AreEqual("TACGCG", pattern.Dna);
        }
    }
}
