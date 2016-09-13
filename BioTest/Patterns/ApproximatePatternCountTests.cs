using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bioinformatics;

namespace BioTest
{
    [TestClass]
    public class ApproximatePatternCountTests
    {
        [TestMethod]
        public void ApproximatePatternCount_Simple()
        {
            NucleotideDna strand = new NucleotideDna("TTTAGAGCCTTCAGAGG");
            Assert.AreEqual(4, strand.ApproximatePatternCount(new NucleotideDna("GAGG"), 2));
        }


        [TestMethod]
        public void ApproximatePatternCount_Test1()
        {
            NucleotideDna strand = new NucleotideDna("AAA");
            Assert.AreEqual(2, strand.ApproximatePatternCount(new NucleotideDna("AA"), 0));
        }


        [TestMethod]
        public void ApproximatePatternCount_Test2()
        {
            NucleotideDna strand = new NucleotideDna("ATA");
            Assert.AreEqual(1, strand.ApproximatePatternCount(new NucleotideDna("ATA"), 1));
        }


        [TestMethod]
        public void ApproximatePatternCount_Test3()
        {
            NucleotideDna strand = new NucleotideDna("GAATCCGCCAAGTACCAAGATGTAAGTGAGGAGCGCTTAGGTCTGTACTGCGCATAAGCCTTAACGCGAAGTATGGATATGCTCCCCGGATACAGGTTTGGGATTTGGCGGTTACCTAAGCTAACGGTGAGACCGATATGACGAGGTTCCTATCTTAATCATATTCACATACTGAACGAGGCGCCCAGTTTCTTCTCACCAATATGTCAGGAAGCTACAGTGCAGCATTATCCACACCATTCCACTTATCCTTGAACGGAAGTCTTATGCGAAGATTATTCTGAGAAGCCCTTGTGCCCTGCATCACGATTTGCAGACTGACAGGGAATCTTAAGGCCACTCAAA");
            Assert.AreEqual(27, strand.ApproximatePatternCount(new NucleotideDna("TACAG"), 2));
        }


        [TestMethod]
        public void ApproximatePatternCount_Test4()
        {
            NucleotideDna strand = new NucleotideDna("GTATGAGCAGGTATGCAGATTGATGGTGTTTCTGAGACGGTTAAGTGTCCTGACTACAAAGTCATCCATTGCCTGACTCCGTAGTTATTGGCTAATGGATTCTACACGAATGAAGAGGGACTTAGTGGGGTAGAATTCCTACACGACCGGCTTAGTTGATATACGCTCCGAGATATGGAGCGGTTCAGGATGTGCAAAGCCTCTGATAGCATATACAAGCGATATGTAGATAAGGATATACGTTTAATATGCGATATCATCCGGCCAGACAAAAGTGTCCACACAGACTATATACTGATATCTGGGGAACCACTCTCATTTCACTGGTGCCAAGTTCCTAGTATGCATAGGCCAGGTGAGTGACGGC");
            Assert.AreEqual(136, strand.ApproximatePatternCount(new NucleotideDna("CTGGG"), 3));
        }

    }
}
