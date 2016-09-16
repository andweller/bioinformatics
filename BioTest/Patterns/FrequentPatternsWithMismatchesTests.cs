using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bioinformatics;
using System.Linq;

namespace BioTest.Patterns
{
    [TestClass]
    public class FrequentPatternsWithMismatchesTests
    {
        [TestMethod]
        public void FrequentPatternsWithMismatches_Simple()
        {
            DnaStrand strand = new DnaStrand("ACGTTGCATGTCGCATGATGCATGAGAGCT");
            var patterns = strand.FrequentPatternsWithMismatches(4, 1);

            Assert.AreEqual(3, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "ATGC"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GATG"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "ATGT"));
        }


        [TestMethod]
        public void FrequentPatternsWithMismatches_Test1()
        {
            DnaStrand strand = new DnaStrand("AAAAAAAAAA");
            var patterns = strand.FrequentPatternsWithMismatches(2, 1);

            Assert.AreEqual(7, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "AA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "AC"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "AG"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "CA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "AT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TA"));
        }


        [TestMethod]
        public void FrequentPatternsWithMismatches_Test2()
        {
            DnaStrand strand = new DnaStrand("AGTCAGTC");
            var patterns = strand.FrequentPatternsWithMismatches(4, 2);

            Assert.AreEqual(18, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TCTC"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "CGGC"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "AAGC"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TGTG"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GGCC"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "AGGT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "ATCC"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "ACTG"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "ACAC"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "AGAG"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TGTG"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "ATTA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TGAC"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "AATT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "CGTT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GTTC"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GGTA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "AGCA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "CATC"));
        }


        [TestMethod]
        public void FrequentPatternsWithMismatches_Test3()
        {
            DnaStrand strand = new DnaStrand("AATTAATTGGTAGGTAGGTA");
            var patterns = strand.FrequentPatternsWithMismatches(4, 0);

            Assert.AreEqual(1, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GGTA"));
        }



        [TestMethod]
        public void FrequentPatternsWithMismatches_Test4()
        {
            DnaStrand strand = new DnaStrand("ATA");
            var patterns = strand.FrequentPatternsWithMismatches(3, 1);

            Assert.AreEqual(10, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GTA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "ACA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "AAA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "ATC"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "ATA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "AGA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "ATT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "CTA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TTA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "ATG"));
        }



        [TestMethod]
        public void FrequentPatternsWithMismatches_Test5()
        {
            DnaStrand strand = new DnaStrand("AAT");
            var patterns = strand.FrequentPatternsWithMismatches(3, 0);

            Assert.AreEqual(1, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "AAT"));
        }


        [TestMethod]
        public void FrequentPatternsWithMismatches_Test6()
        {
            DnaStrand strand = new DnaStrand("TAGCG");
            var patterns = strand.FrequentPatternsWithMismatches(2, 1);

            Assert.AreEqual(2, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GG"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TG"));
        }


        [TestMethod]
        public void FrequentPatternsWithMismatches_Test7()
        {
            DnaStrand strand = new DnaStrand("CACAGTAGGCGCCGGCACACACAGCCCCGGGCCCCGGGCCGCCCCGGGCCGGCGGCCGCCGGCGCCGGCACACCGGCACAGCCGTACCGGCACAGTAGTACCGGCCGGCCGGCACACCGGCACACCGGGTACACACCGGGGCGCACACACAGGCGGGCGCCGGGCCCCGGGCCGTACCGGGCCGCCGGCGGCCCACAGGCGCCGGCACAGTACCGGCACACACAGTAGCCCACACACAGGCGGGCGGTAGCCGGCGCACACACACACAGTAGGCGCACAGCCGCCCACACACACCGGCCGGCCGGCACAGGCGGGCGGGCGCACACACACCGGCACAGTAGTAGGCGGCCGGCGCACAGCC");
            var patterns = strand.FrequentPatternsWithMismatches(10, 2);

            Assert.AreEqual(2, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GCACACAGAC"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GCGCACACAC"));
        }



        [TestMethod]
        public void FrequentPatternsWithMismatches_Test8()
        {
            DnaStrand strand = new DnaStrand("TAATAACCGTAATAAGGCCCGCCGCCGCCGCCGGGCGTTCCGCCGCCGTAATAAGTTGGCGTTGGCGGCTAACCGGGCGTTTAACCGGGCGGCCCGGGCCCGCCGGGCTAAGTTGTTTAATAAGTTGTTCCGTAAGTTCCGGTTTAACCGTAATAAGTTGGCTAAGGCGTTGTTCCGGTTTAAGGCTAATAATAAGTTGTTCCGTAAGTTGGCTAAGTTCCGCCGCCGGTTGTTCCGTAAGTTTAATAAGGCCCGGTTGGCGTTGGCCCGCCGGTTTAAGGCTAACCGCCGTAACCGTAACCGTAAGGCGTTCCGGTTGGCCCGCCGGTTCCGTAACCGCCGCCGCCG");
            var patterns = strand.FrequentPatternsWithMismatches(5, 3);

            Assert.AreEqual(1, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "CGGGT"));
        }
    }
}
