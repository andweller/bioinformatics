using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Bioinformatics;

namespace BioTest
{
    [TestClass]
    public class MotifMostProbableTests
    {
        [TestMethod]
        public void MotifMostProbable_Simple()
        {
            DnaStrand strand = new DnaStrand("ACCTGTTTATTGCCTAAGTTCCGAACAAACCCAATATAGCCCGAGGGCCT");

            Dictionary<char, List<double>> profile = new Dictionary<char, List<double>>
            {
                {'A', new List<double> { 0.2, 0.2, 0.3, 0.2, 0.3 } },
                {'C', new List<double> { 0.4, 0.3, 0.1, 0.5, 0.1 } },
                {'G', new List<double> { 0.3, 0.3, 0.5, 0.2, 0.4 } },
                {'T', new List<double> { 0.1, 0.2, 0.1, 0.1, 0.2 } }
            };

            DnaStrand mostProbable = Motif.ProfileMostProbablePattern(strand, 5, profile);

            Assert.AreEqual("CCGAG", mostProbable.Dna);
        }



        [TestMethod]
        public void MotifMostProbable_Test1()
        {
            DnaStrand strand = new DnaStrand("AGCAGCTTTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATCTGAACTGGTTACCTGCCGTGAGTAAAT");

            Dictionary<char, List<double>> profile = new Dictionary<char, List<double>>
            {
                {'A', new List<double> { 0.7, 0.2, 0.1, 0.5, 0.4, 0.3, 0.2, 0.1 } },
                {'C', new List<double> { 0.2, 0.2, 0.5, 0.4, 0.2, 0.3, 0.1, 0.6 } },
                {'G', new List<double> { 0.1, 0.3, 0.2, 0.1, 0.2, 0.1, 0.4, 0.2 } },
                {'T', new List<double> { 0.0, 0.3, 0.2, 0.0, 0.2, 0.3, 0.3, 0.1 } }
            };

            DnaStrand mostProbable = Motif.ProfileMostProbablePattern(strand, 8, profile);

            Assert.AreEqual("AGCAGCTT", mostProbable.Dna);
        }



        [TestMethod]
        public void MotifMostProbable_Test2()
        {
            DnaStrand strand = new DnaStrand("TTACCATGGGACCGCTGACTGATTTCTGGCGTCAGCGTGATGCTGGTGTGGATGACATTCCGGTGCGCTTTGTAAGCAGAGTTTA");

            Dictionary<char, List<double>> profile = new Dictionary<char, List<double>>
            {
                {'A', new List<double> { 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.1, 0.2, 0.3, 0.4, 0.5 } },
                {'C', new List<double> { 0.3, 0.2, 0.1, 0.1, 0.2, 0.1, 0.1, 0.4, 0.3, 0.2, 0.2, 0.1 } },
                {'G', new List<double> { 0.2, 0.1, 0.4, 0.3, 0.1, 0.1, 0.1, 0.3, 0.1, 0.1, 0.2, 0.1 } },
                {'T', new List<double> { 0.3, 0.4, 0.1, 0.1, 0.1, 0.1, 0.0, 0.2, 0.4, 0.4, 0.2, 0.3 } }
            };

            DnaStrand mostProbable = Motif.ProfileMostProbablePattern(strand, 12, profile);

            Assert.AreEqual("AAGCAGAGTTTA", mostProbable.Dna);
        }



        [TestMethod]
        public void MotifMostProbable_Test3()
        {
            DnaStrand strand = new DnaStrand("TGCCCGAGCTATCTTATGCGCATCGCATGCGGACCCTTCCCTAGGCTTGTCGCAAGCCATTATCCTGGGCGCTAGTTGCGCGAGTATTGTCAGACCTGATGACGCTGTAAGCTAGCGTGTTCAGCGGCGCGCAATGAGCGGTTTAGATCACAGAATCCTTTGGCGTATTCCTATCCGTTACATCACCTTCCTCACCCCTA");

            Dictionary<char, List<double>> profile = new Dictionary<char, List<double>>
            {
                {'A', new List<double> { 0.364, 0.333, 0.303, 0.212, 0.121, 0.242 } },
                {'C', new List<double> { 0.182, 0.182, 0.212, 0.303, 0.182, 0.303 } },
                {'G', new List<double> { 0.121, 0.303, 0.182, 0.273, 0.333, 0.303 } },
                {'T', new List<double> { 0.333, 0.182, 0.303, 0.212, 0.364, 0.152 } }
            };

            DnaStrand mostProbable = Motif.ProfileMostProbablePattern(strand, 6, profile);

            Assert.AreEqual("TGTCGC", mostProbable.Dna);
        }



        [TestMethod]
        public void MotifMostProbable_Test4()
        {
            DnaStrand strand = new DnaStrand("CTGTAAGCAAGCTATTGTTTGATTCTACTATTTTCAAGGAGTGGGCTATGGAAGAGATACTGCCACCCTATTGACATCCATGTCACTAGGGACGGAATCAGGAGAGCCTTCTAGCCTTGACGTTATTAACCGGCTGAACGTTGAAGAGTGTTAATCACACTGGCCGCAGCCTCAAGGTCGTCAGTATCTTAAATCTGGATTATTCCATCAGGCACGTGTAAGAGGAGCCAACAAGGTTCGGATGAGTCCCGCAAGACTGCTGACTGCGACCACAGTTGCATGACGCCCCGAGGGGAGCAGGTAGAAATTCAATGAGAGTACGCACGCACACTTGCGCAGTCAGGTGCCTTTCGGAGGCGTTTTACGGCACAAAGGCTTCAAAGCTGAGCCCTCCTACTGTGCCCGACTCACGGCTAGATTCCATGTGCACCTCCGAGGCTCGCACCGAGTTAGGATTAGATACCGCATGGATTGGCAGGCTGAACCAAAATGTCCGGCGTCAGTATTCGAGATTATATGCACCGGGCCAGCATGGGGCTGTGGCTAGACGATGTCTAATTGCTACACTGTCTGAGAGGTGTCTTCAATAGTACATGGTTGCGGTGTATAGGAGACGTCTGCAAGAATCGAATTGCAATCCCGTTGGCAGGCGACTTCCGCGCCGGAGATGTAGGGGATGGGAAGGTGAGGACGGTTCATCTATTGTAACACACGATTTGTGGCTTGATACGTGCGCCTGCAAGCCAGAAGCTACAAGATCGACGTTTATATACTGGTTACTTCGTCGTTCAACGATGGTACACGAGGCATTGGGATGATGGTACCCAATAATCTCCCGAGTTTAACGTGGCTTACCGTTGCGACGGAGCAGATAATTGACCGGCAGTTACGGAATATCAACTCGACCTTGGTCCTTACGCTGCCTGCCGAGTATCAAGACGCCCTGCCGAATTTTCAGATTTATTGACGATTCAATCTCCCCGTGGATAATTCGCGATCT");

            Dictionary<char, List<double>> profile = new Dictionary<char, List<double>>
            {
                {'A', new List<double> { 0.25, 0.211, 0.276, 0.237, 0.184, 0.211, 0.263, 0.316, 0.276, 0.224, 0.237, 0.263, 0.211 } },
                {'C', new List<double> { 0.237, 0.105, 0.303, 0.303, 0.303, 0.25, 0.263, 0.237, 0.184, 0.289, 0.303, 0.224, 0.211 } },
                {'G', new List<double> { 0.237, 0.342, 0.197, 0.224, 0.329, 0.382, 0.197, 0.276, 0.342, 0.211, 0.224, 0.276, 0.329 } },
                {'T', new List<double> { 0.276, 0.342, 0.224, 0.237, 0.184, 0.158, 0.276, 0.171, 0.197, 0.276, 0.237, 0.237, 0.25 } }
            };

            DnaStrand mostProbable = Motif.ProfileMostProbablePattern(strand, 13, profile);

            Assert.AreEqual("CTTGCGCAGTCAG", mostProbable.Dna);
        }
    }
}
