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
            DnaStrand strand = new DnaStrand("TTTAGAGCCTTCAGAGG");
            Assert.AreEqual(4, strand.ApproximatePatternCount(new DnaStrand("GAGG"), 2));
        }


        [TestMethod]
        public void ApproximatePatternCount_Test1()
        {
            DnaStrand strand = new DnaStrand("AAA");
            Assert.AreEqual(2, strand.ApproximatePatternCount(new DnaStrand("AA"), 0));
        }


        [TestMethod]
        public void ApproximatePatternCount_Test2()
        {
            DnaStrand strand = new DnaStrand("ATA");
            Assert.AreEqual(1, strand.ApproximatePatternCount(new DnaStrand("ATA"), 1));
        }


        [TestMethod]
        public void ApproximatePatternCount_Test3()
        {
            DnaStrand strand = new DnaStrand("GAATCCGCCAAGTACCAAGATGTAAGTGAGGAGCGCTTAGGTCTGTACTGCGCATAAGCCTTAACGCGAAGTATGGATATGCTCCCCGGATACAGGTTTGGGATTTGGCGGTTACCTAAGCTAACGGTGAGACCGATATGACGAGGTTCCTATCTTAATCATATTCACATACTGAACGAGGCGCCCAGTTTCTTCTCACCAATATGTCAGGAAGCTACAGTGCAGCATTATCCACACCATTCCACTTATCCTTGAACGGAAGTCTTATGCGAAGATTATTCTGAGAAGCCCTTGTGCCCTGCATCACGATTTGCAGACTGACAGGGAATCTTAAGGCCACTCAAA");
            Assert.AreEqual(27, strand.ApproximatePatternCount(new DnaStrand("TACAG"), 2));
        }


        [TestMethod]
        public void ApproximatePatternCount_Test4()
        {
            DnaStrand strand = new DnaStrand("GTATGAGCAGGTATGCAGATTGATGGTGTTTCTGAGACGGTTAAGTGTCCTGACTACAAAGTCATCCATTGCCTGACTCCGTAGTTATTGGCTAATGGATTCTACACGAATGAAGAGGGACTTAGTGGGGTAGAATTCCTACACGACCGGCTTAGTTGATATACGCTCCGAGATATGGAGCGGTTCAGGATGTGCAAAGCCTCTGATAGCATATACAAGCGATATGTAGATAAGGATATACGTTTAATATGCGATATCATCCGGCCAGACAAAAGTGTCCACACAGACTATATACTGATATCTGGGGAACCACTCTCATTTCACTGGTGCCAAGTTCCTAGTATGCATAGGCCAGGTGAGTGACGGC");
            Assert.AreEqual(136, strand.ApproximatePatternCount(new DnaStrand("CTGGG"), 3));
        }


        [TestMethod]
        public void ApproximatePatternCount_Test5()
        {
            DnaStrand strand = new DnaStrand("AACAAGCTGATAAACATTTAAAGAG");
            Assert.AreEqual(11, strand.ApproximatePatternCount(new DnaStrand("AAAAA"), 2));
        }

    }
}
