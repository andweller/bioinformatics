using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bioinformatics;
using System.Linq;

namespace BioTest
{
    [TestClass]
    public class FrequentPatternsTests
    {
        [TestMethod]
        public void FrequentPatterns_Simple()
        {
            NucleotideDna strand = new NucleotideDna("ACGTTGCATGTCGCATGATGCATGAGAGCT");
            var patterns = strand.FrequentPatterns(4);

            Assert.AreEqual(2, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "CATG"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GCAT"));
        }


        [TestMethod]
        public void FrequentPatterns_Test1()
        {
            NucleotideDna strand = new NucleotideDna("TGGTAGCGACGTTGGTCCCGCCGCTTGAGAATCTGGATGAACATAAGCTCCCACTTGGCTTATTCAGAGAACTGGTCAACACTTGTCTCTCCCAGCCAGGTCTGACCACCGGGCAACTTTTAGAGCACTATCGTGGTACAAATAATGCTGCCAC");
            var patterns = strand.FrequentPatterns(3);

            Assert.AreEqual(1, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TGG"));
        }


        [TestMethod]
        public void FrequentPatterns_Test2()
        {
            NucleotideDna strand = new NucleotideDna("CAGTGGCAGATGACATTTTGCTGGTCGACTGGTTACAACAACGCCTGGGGCTTTTGAGCAACGAGACTTTTCAATGTTGCACCGTTTGCTGCATGATATTGAAAACAATATCACCAAATAAATAACGCCTTAGTAAGTAGCTTTT");
            var patterns = strand.FrequentPatterns(4);

            Assert.AreEqual(1, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TTTT"));
        }


        [TestMethod]
        public void FrequentPatterns_Test3()
        {
            NucleotideDna strand = new NucleotideDna("ATACAATTACAGTCTGGAACCGGATGAACTGGCCGCAGGTTAACAACAGAGTTGCCAGGCACTGCCGCTGACCAGCAACAACAACAATGACTTTGACGCGAAGGGGATGGCATGAGCGAACTGATCGTCAGCCGTCAGCAACGAGTATTGTTGCTGACCCTTAACAATCCCGCCGCACGTAATGCGCTAACTAATGCCCTGCTG");
            var patterns = strand.FrequentPatterns(5);

            Assert.AreEqual(1, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "AACAA"));
        }


        [TestMethod]
        public void FrequentPatterns_Test4()
        {
            NucleotideDna strand = new NucleotideDna("CCAGCGGGGGTTGATGCTCTGGGGGTCACAAGATTGCATTTTTATGGGGTTGCAAAAATGTTTTTTACGGCAGATTCATTTAAAATGCCCACTGGCTGGAGACATAGCCCGGATGCGCGTCTTTTACAACGTATTGCGGGGTAAAATCGTAGATGTTTTAAAATAGGCGTAAC");
            var patterns = strand.FrequentPatterns(5);

            Assert.AreEqual(3, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "AAAAT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GGGGT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TTTTA"));
        }


        [TestMethod]
        public void FrequentPatterns_Test5()
        {
            NucleotideDna strand = new NucleotideDna("CGGAAGCGAGATTCGCGTGGCGTGATTCCGGCGGGCGTGGAGAAGCGAGATTCATTCAAGCCGGGAGGCGTGGCGTGGCGTGGCGTGCGGATTCAAGCCGGCGGGCGTGATTCGAGCGGCGGATTCGAGATTCCGGGCGTGCGGGCGTGAAGCGCGTGGAGGAGGCGTGGCGTGCGGGAGGAGAAGCGAGAAGCCGGATTCAAGCAAGCATTCCGGCGGGAGATTCGCGTGGAGGCGTGGAGGCGTGGAGGCGTGCGGCGGGAGATTCAAGCCGGATTCGCGTGGAGAAGCGAGAAGCGCGTGCGGAAGCGAGGAGGAGAAGCATTCGCGTGATTCCGGGAGATTCAAGCATTCGCGTGCGGCGGGAGATTCAAGCGAGGAGGCGTGAAGCAAGCAAGCAAGCGCGTGGCGTGCGGCGGGAGAAGCAAGCGCGTGATTCGAGCGGGCGTGCGGAAGCGAGCGG");
            var patterns = strand.FrequentPatterns(12);

            Assert.AreEqual(14, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "CGGCGGGAGATT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "CGGGAGATTCAA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "CGTGCGGCGGGA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "CGTGGAGGCGTG"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "CGTGGCGTGCGG"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GCGTGCGGCGGG"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GCGTGGAGGCGT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GCGTGGCGTGCG"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GGAGAAGCGAGA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GGAGATTCAAGC"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GGCGGGAGATTC"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GGGAGATTCAAG"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GTGCGGCGGGAG"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TGCGGCGGGAGA"));
        }


        [TestMethod]
        public void FrequentPatterns_Test6()
        {
            NucleotideDna strand = Load.LoadStrand("datasets//frequentPatterns_dataset.txt");
            var patterns = strand.FrequentPatterns(12);

            Assert.AreEqual(11, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "AGATTACCCACC"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GATTACCCACCC"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "ATTACCCACCCG"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TTACCCACCCGT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TACCCACCCGTC"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TGCGGGCAGAGA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GCGGGCAGAGAT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "CGGGCAGAGATT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GGGCAGAGATTA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GGCAGAGATTAC"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GCAGAGATTACC"));     
        }
    }
}
