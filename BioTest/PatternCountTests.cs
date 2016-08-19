using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bioinformatics;

namespace BioTest
{
    [TestClass]
    public class PatternCountTests
    {
        [TestMethod]
        public void PatternCount_Simple()
        {
            DnaStrand strand = new DnaStrand("GCGCG");
            Assert.AreEqual(2, strand.PatternCount(new DnaStrand("GCG")));
        }


        [TestMethod]
        public void PatternCount_Test1()
        {
            DnaStrand strand = new DnaStrand("ACGTACGTACGT");
            Assert.AreEqual(3, strand.PatternCount(new DnaStrand("CG")));
        }


        [TestMethod]
        public void PatternCount_Test2()
        {
            DnaStrand strand = new DnaStrand("AAAGAGTGTCTGATAGCAGCTTCTGAACTGGTTACCTGCCGTGAGTAAATTAAATTTTATTGACTTAGGTCACTAAATACTTTAACCAATATAGGCATAGCGCACAGACAGATAATAATTACAGAGTACACAACATCCAT");
            Assert.AreEqual(4, strand.PatternCount(new DnaStrand("AAA")));
        }


        [TestMethod]
        public void PatternCount_Test3()
        {
            DnaStrand strand = new DnaStrand("AGCGTGCCGAAATATGCCGCCAGACCTGCTGCGGTGGCCTCGCCGACTTCACGGATGCCAAGTGCATAGAGGAAGCGAGCAAAGGTGGTTTCTTTCGCTTTATCCAGCGCGTTAACCACGTTCTGTGCCGACTTT");
            Assert.AreEqual(4, strand.PatternCount(new DnaStrand("TTT")));
        }


        [TestMethod]
        public void PatternCount_Test4()
        {
            DnaStrand strand = new DnaStrand("GGACTTACTGACGTACG");
            Assert.AreEqual(2, strand.PatternCount(new DnaStrand("ACT")));
        }


        [TestMethod]
        public void PatternCount_Test5()
        {
            DnaStrand strand = new DnaStrand("ATCCGATCCCATGCCCATG");
            Assert.AreEqual(5, strand.PatternCount(new DnaStrand("CC")));
        }


        [TestMethod]
        public void PatternCount_Test6()
        {
            DnaStrand strand = new DnaStrand("CTGTTTTTGATCCATGATATGTTATCTCTCCGTCATCAGAAGAACAGTGACGGATCGCCCTCTCTCTTGGTCAGGCGACCGTTTGCCATAATGCCCATGCTTTCCAGCCAGCTCTCAAACTCCGGTGACTCGCGCAGGTTGAGTA");
            Assert.AreEqual(9, strand.PatternCount(new DnaStrand("CTC")));
        }


        [TestMethod]
        public void PatternCount_Test7()
        {
            DnaStrand strand = Load.LoadStrand("datasets//patternCount_dataset.txt");
            Assert.AreEqual(35, strand.PatternCount(new DnaStrand("CTCTAGTCT")));
        }
    }
}
