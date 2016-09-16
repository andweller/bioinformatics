using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bioinformatics;
using System.Linq;

namespace BioTest.Patterns
{
    [TestClass]
    public class FrequentPatternsWithMismatchesAndReverseComplementsTests
    {
        [TestMethod]
        public void FrequentPatternsWithMismatchesAndReverseComplements_Simple()
        {
            DnaStrand strand = new DnaStrand("ACGTTGCATGTCGCATGATGCATGAGAGCT");
            var patterns = strand.FrequentPatternsWithMismatchesAndReverseComplements(4, 1);

            Assert.AreEqual(2, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "ACAT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "ATGT"));
        }


        [TestMethod]
        public void FrequentPatternsWithMismatchesAndReverseComplements_Test1()
        {
            DnaStrand strand = new DnaStrand("AAAAAAAAAA");
            var patterns = strand.FrequentPatternsWithMismatchesAndReverseComplements(2, 1);

            Assert.AreEqual(2, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "AT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TA"));
        }



        [TestMethod]
        public void FrequentPatternsWithMismatchesAndReverseComplements_Test2()
        {
            DnaStrand strand = new DnaStrand("AGTCAGTC");
            var patterns = strand.FrequentPatternsWithMismatchesAndReverseComplements(4, 2);

            Assert.AreEqual(2, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "AATT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GGCC"));
        }


        [TestMethod]
        public void FrequentPatternsWithMismatchesAndReverseComplements_Test3()
        {
            DnaStrand strand = new DnaStrand("AATTAATTGGTAGGTAGGTA");
            var patterns = strand.FrequentPatternsWithMismatchesAndReverseComplements(4, 0);

            Assert.AreEqual(1, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "AATT"));
        }


        [TestMethod]
        public void FrequentPatternsWithMismatchesAndReverseComplements_Test4()
        {
            DnaStrand strand = new DnaStrand("ATA");
            var patterns = strand.FrequentPatternsWithMismatchesAndReverseComplements(3, 1);

            Assert.AreEqual(20, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "AAA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "AAT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "ACA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "AGA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "ATA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "ATC"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "ATG"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "ATT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "CAT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "CTA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GAT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GTA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TAA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TAC"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TAG"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TAT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TCT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TGT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TTA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TTT"));
        }


        [TestMethod]
        public void FrequentPatternsWithMismatchesAndReverseComplements_Test5()
        {
            DnaStrand strand = new DnaStrand("AAT");
            var patterns = strand.FrequentPatternsWithMismatchesAndReverseComplements(3, 0);

            Assert.AreEqual(2, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "AAT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "ATT"));
        }


        [TestMethod]
        public void FrequentPatternsWithMismatchesAndReverseComplements_Test6()
        {
            DnaStrand strand = new DnaStrand("TAGCG");
            var patterns = strand.FrequentPatternsWithMismatchesAndReverseComplements(2, 1);

            Assert.AreEqual(4, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "CA"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "CC"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GG"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "TG"));
        }


        // Will take a long time to run (approx 30 secs)
        //[TestMethod]
        //public void FrequentPatternsWithMismatchesAndReverseComplements_Test7()
        //{
        //    DnaStrand strand = new DnaStrand("CTTGCCGGCGCCGATTATACGATCGCGGCCGCTTGCCTTCTTTATAATGCATCGGCGCCGCGATCTTGCTATATACGTACGCTTCGCTTGCATCTTGCGCGCATTACGTACTTATCGATTACTTATCTTCGATGCCGGCCGGCATATGCCGCTTTAGCATCGATCGATCGTACTTTACGCGTATAGCCGCTTCGCTTGCCGTACGCGATGCTAGCATATGCTAGCGCTAATTACTTAT");
        //    var patterns = strand.FrequentPatternsWithMismatchesAndReverseComplements(9, 3);

        //    Assert.AreEqual(2, patterns.Count());
        //    Assert.IsTrue(patterns.Any(x => x.ToString() == "AGCGCCGCT"));
        //    Assert.IsTrue(patterns.Any(x => x.ToString() == "AGCGGCGCT"));
        //}


        [TestMethod]
        public void FrequentPatternsWithMismatchesAndReverseComplements_Test8()
        {
            DnaStrand strand = new DnaStrand("TATTATGCCGCCTATGCCGCCGCCGCCGCCTATGAAATGAAGCCGCCTATATGCCTATATGCCGCCGAAGCCATATATTATGCCATTATATTATGAAGAAGAAGAGAAATTATGCCGCCATGCCGCCGCCGAAGCCGAAATTATGAGAAGAATATGAGAGCCGCCATATGAGAGATATGAATTATGCCGAAATGCCGCCTATGAATGAATGAAATGCCTATGAAATGCCTATGAGCC");
            var patterns = strand.FrequentPatternsWithMismatchesAndReverseComplements(7, 3);

            Assert.AreEqual(4, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.ToString() == "ATAAGGC"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "ATATGAT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "ATCATAT"));
            Assert.IsTrue(patterns.Any(x => x.ToString() == "GCCTTAT"));
        }

    }
}
