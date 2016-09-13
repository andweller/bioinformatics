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
            NucleotideDna strand = new NucleotideDna("GCGCG");
            Assert.AreEqual(2, strand.PatternCount(new NucleotideDna("GCG")));
        }


        [TestMethod]
        public void PatternCount_Test1()
        {
            NucleotideDna strand = new NucleotideDna("ACGTACGTACGT");
            Assert.AreEqual(3, strand.PatternCount(new NucleotideDna("CG")));
        }


        [TestMethod]
        public void PatternCount_Test2()
        {
            NucleotideDna strand = new NucleotideDna("AAAGAGTGTCTGATAGCAGCTTCTGAACTGGTTACCTGCCGTGAGTAAATTAAATTTTATTGACTTAGGTCACTAAATACTTTAACCAATATAGGCATAGCGCACAGACAGATAATAATTACAGAGTACACAACATCCAT");
            Assert.AreEqual(4, strand.PatternCount(new NucleotideDna("AAA")));
        }


        [TestMethod]
        public void PatternCount_Test3()
        {
            NucleotideDna strand = new NucleotideDna("AGCGTGCCGAAATATGCCGCCAGACCTGCTGCGGTGGCCTCGCCGACTTCACGGATGCCAAGTGCATAGAGGAAGCGAGCAAAGGTGGTTTCTTTCGCTTTATCCAGCGCGTTAACCACGTTCTGTGCCGACTTT");
            Assert.AreEqual(4, strand.PatternCount(new NucleotideDna("TTT")));
        }


        [TestMethod]
        public void PatternCount_Test4()
        {
            NucleotideDna strand = new NucleotideDna("GGACTTACTGACGTACG");
            Assert.AreEqual(2, strand.PatternCount(new NucleotideDna("ACT")));
        }


        [TestMethod]
        public void PatternCount_Test5()
        {
            NucleotideDna strand = new NucleotideDna("ATCCGATCCCATGCCCATG");
            Assert.AreEqual(5, strand.PatternCount(new NucleotideDna("CC")));
        }


        [TestMethod]
        public void PatternCount_Test6()
        {
            NucleotideDna strand = new NucleotideDna("CTGTTTTTGATCCATGATATGTTATCTCTCCGTCATCAGAAGAACAGTGACGGATCGCCCTCTCTCTTGGTCAGGCGACCGTTTGCCATAATGCCCATGCTTTCCAGCCAGCTCTCAAACTCCGGTGACTCGCGCAGGTTGAGTA");
            Assert.AreEqual(9, strand.PatternCount(new NucleotideDna("CTC")));
        }


        [TestMethod]
        public void PatternCount_Test7()
        {
            NucleotideDna strand = Load.LoadStrand("datasets//patternCount_dataset.txt");
            Assert.AreEqual(35, strand.PatternCount(new NucleotideDna("CTCTAGTCT")));
        }
    }
}
