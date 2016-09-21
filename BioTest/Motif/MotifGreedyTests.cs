﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Bioinformatics;

namespace BioTest
{
    [TestClass]
    public class MotifGreedyTests
    {
        [TestMethod]
        public void MotifGreedy_Simple()
        {
            List<DnaStrand> strands = new List<DnaStrand>
            {
                new DnaStrand("GGCGTTCAGGCA"),
                new DnaStrand("AAGAATCAGTCA"),
                new DnaStrand("CAAGGAGTTCGC"),
                new DnaStrand("CACGTCAATCAC"),
                new DnaStrand("CAATAATATTCG")
            };

            var results = Motif.GreedyMotifSearch(strands, 3).ToList();

            Assert.AreEqual(5, results.Count);
            Assert.IsTrue(results.Any(x => x.Dna == "CAG"));
            Assert.IsTrue(results.Any(x => x.Dna == "CAG"));
            Assert.IsTrue(results.Any(x => x.Dna == "CAA"));
            Assert.IsTrue(results.Any(x => x.Dna == "CAA"));
            Assert.IsTrue(results.Any(x => x.Dna == "CAA"));
        }



        [TestMethod]
        public void MotifGreedy_Test1()
        {
            List<DnaStrand> strands = new List<DnaStrand>
            {
                new DnaStrand("GCCCAA"),
                new DnaStrand("GGCCTG"),
                new DnaStrand("AACCTA"),
                new DnaStrand("TTCCTT")
            };

            var results = Motif.GreedyMotifSearch(strands, 3).ToList();

            Assert.AreEqual(4, results.Count);
            Assert.IsTrue(results.Any(x => x.Dna == "GCC"));
            Assert.IsTrue(results.Any(x => x.Dna == "GCC"));
            Assert.IsTrue(results.Any(x => x.Dna == "AAC"));
            Assert.IsTrue(results.Any(x => x.Dna == "TTC"));
        }



        [TestMethod]
        public void MotifGreedy_Test2()
        {
            List<DnaStrand> strands = new List<DnaStrand>
            {
                new DnaStrand("GAGGCGCACATCATTATCGATAACGATTCGCCGCATTGCC"),
                new DnaStrand("TCATCGAATCCGATAACTGACACCTGCTCTGGCACCGCTC"),
                new DnaStrand("TCGGCGGTATAGCCAGAAAGCGTAGTGCCAATAATTTCCT"),
                new DnaStrand("GAGTCGTGGTGAAGTGTGGGTTATGGGGAAAGGCAGACTG"),
                new DnaStrand("GACGGCAACTACGGTTACAACGCAGCAACCGAAGAATATT"),
                new DnaStrand("TCTGTTGTTGCTAACACCGTTAAAGGCGGCGACGGCAACT"),
                new DnaStrand("AAGCGGCCAACGTAGGCGCGGCTTGGCATCTCGGTGTGTG"),
                new DnaStrand("AATTGAAAGGCGCATCTTACTCTTTTCGCTTTCAAAAAAA")
            };

            var results = Motif.GreedyMotifSearch(strands, 5).ToList();

            Assert.AreEqual(8, results.Count);
            Assert.IsTrue(results.Any(x => x.Dna == "GAGGC"));
            Assert.IsTrue(results.Any(x => x.Dna == "TCATC"));
            Assert.IsTrue(results.Any(x => x.Dna == "TCGGC"));
            Assert.IsTrue(results.Any(x => x.Dna == "GAGTC"));
            Assert.IsTrue(results.Any(x => x.Dna == "GCAGC"));
            Assert.IsTrue(results.Any(x => x.Dna == "GCGGC"));
            Assert.IsTrue(results.Any(x => x.Dna == "GCGGC"));
            Assert.IsTrue(results.Any(x => x.Dna == "GCATC"));
        }



        [TestMethod]
        public void MotifGreedy_Test3()
        {
            List<DnaStrand> strands = new List<DnaStrand>
            {
                new DnaStrand("GCAGGTTAATACCGCGGATCAGCTGAGAAACCGGAATGTGCGT"),
                new DnaStrand("CCTGCATGCCCGGTTTGAGGAACATCAGCGAAGAACTGTGCGT"),
                new DnaStrand("GCGCCAGTAACCCGTGCCAGTCAGGTTAATGGCAGTAACATTT"),
                new DnaStrand("AACCCGTGCCAGTCAGGTTAATGGCAGTAACATTTATGCCTTC"),
                new DnaStrand("ATGCCTTCCGCGCCAATTGTTCGTATCGTCGCCACTTCGAGTG")
            };

            var results = Motif.GreedyMotifSearch(strands, 6).ToList();

            Assert.AreEqual(5, results.Count);
            Assert.IsTrue(results.Any(x => x.Dna == "GTGCGT"));
            Assert.IsTrue(results.Any(x => x.Dna == "GTGCGT"));
            Assert.IsTrue(results.Any(x => x.Dna == "GCGCCA"));
            Assert.IsTrue(results.Any(x => x.Dna == "GTGCCA"));
            Assert.IsTrue(results.Any(x => x.Dna == "GCGCCA"));
        }



        [TestMethod]
        public void MotifGreedy_Test4()
        {
            List<DnaStrand> strands = new List<DnaStrand>
            {
                new DnaStrand("GACCTACGGTTACAACGCAGCAACCGAAGAATATTGGCAA"),
                new DnaStrand("TCATTATCGATAACGATTCGCCGGAGGCCATTGCCGCACA"),
                new DnaStrand("GGAGTCTGGTGAAGTGTGGGTTATGGGGCAGACTGGGAAA"),
                new DnaStrand("GAATCCGATAACTGACACCTGCTCTGGCACCGCTCTCATC"),
                new DnaStrand("AAGCGCGTAGGCGCGGCTTGGCATCTCGGTGTGTGGCCAA"),
                new DnaStrand("AATTGAAAGGCGCATCTTACTCTTTTCGCTTAAAATCAAA"),
                new DnaStrand("GGTATAGCCAGAAAGCGTAGTTAATTTCGGCTCCTGCCAA"),
                new DnaStrand("TCTGTTGTTGCTAACACCGTTAAAGGCGGCGACGGCAACT")
            };

            var results = Motif.GreedyMotifSearch(strands, 5).ToList();

            Assert.AreEqual(8, results.Count);
            Assert.IsTrue(results.Any(x => x.Dna == "GCAGC"));
            Assert.IsTrue(results.Any(x => x.Dna == "TCATT"));
            Assert.IsTrue(results.Any(x => x.Dna == "GGAGT"));
            Assert.IsTrue(results.Any(x => x.Dna == "TCATC"));
            Assert.IsTrue(results.Any(x => x.Dna == "GCATC"));
            Assert.IsTrue(results.Any(x => x.Dna == "GCATC"));
            Assert.IsTrue(results.Any(x => x.Dna == "GGTAT"));
            Assert.IsTrue(results.Any(x => x.Dna == "GCAAC"));
        }



        [TestMethod]
        public void MotifGreedy_Test5()
        {
            List<DnaStrand> strands = new List<DnaStrand>
            {
                new DnaStrand("GATGGACCGGGCCATACATGGTGACACGCATCAGAAAGCTGTCCCCGTGCCTTATGCGCTGTCTGTTAGTACATCTCTCTCAATGGCCGTATTTTCAGAACAAGTATCACTTGGATCATCATCTACTCGACGGAGGGCGCGCAAGTGGGTATCTCG"),
                new DnaStrand("TAAAAAGGTATAAGGGAGTCATATCCGCAGTCCTAGTGACCTTTCCCGGCCCTAGCAGTGCTCCGATAGCCCATGGATGAGACGTAACTCGGCTACTGTTTGTGACTCAAGATAGTTGCCGTCGATATCTCGGATTCTGCTTATCGTGTTACGAGC"),
                new DnaStrand("AACCACGAGTACCTCTGTCGTGGTCCTTCACCAGGACTCGAAATTTGGCTCACGCCCAACGCCAAGATTACGTCGATCGTTCCTGTTGATATCTCGCCGCATATCAGGTTTATACTGATCGGCTCAGTGATTGTTAATCATCGGCGCGGGTTGTCA"),
                new DnaStrand("TGTCATGTGCGGATACAGTGGTGACACCAGGTCACCTCCGACCTAAAAGCGTTCAAGGTATGGCCCGAAGAGGTAGGTATCTCTTGTGCCCGCTGCTGCTATCACTCCCTGTGAGCCCCGACACGAATGTTAAACCAGTTTATATTCGCTCGTCAT"),
                new DnaStrand("AACCTAAACCCTTGCTTCCCACCATCCCTGCGAAGCAACCTTATCCGTAGTTCAGTCGCGCTGAACTCGGAAAGTGCGCTCACGAGATTCTAACTTACACTTGTTTAAGTACCACGTCCGGTGGATATCGCTGGCGTTGAAGGATAGTTCTGGTTA"),
                new DnaStrand("GTGCCCGATATGCCCGTCAGGGTTGAAGTCTGGGAAGTCGTTATCCCAAACGAAATACCCCGTTCGCAGGCGTGATGTATATCCTGATTAGTACCGCGTATAATATTAGTTTCGCACAGGAGCGTGCTTGTTTTGGGTCATGGATTGGGTACAGCA"),
                new DnaStrand("TAGTCTTCGAGGCATCTACCTGCGACCGAGCTTGCGATCCAAAAGCATACCCATGAAGTTTGCAAATCTTTCTTAGAGCTACAGGTAGATATCCCTGGGCCGGTAACTAGTAATATGTACAGTTTAGTTGTCCTGTACAATACTGATTGGAGTCAG"),
                new DnaStrand("AGGAGACGTGTTTGGTAGGCGCTCGACCCTTACCCCCCTATCTCGACTGGCATTGGACGTCCTCAGACTGGTGGATTTGACCTAGTGGTTATCACGCACATGGGAGAACCCGGTCAGAATACATCCTGTTACAGTCAGACGCCGGGTCATTCGCAA"),
                new DnaStrand("TGTGGGGATCGTCTGATTCATCGACGTCATGGAAACGGGGACGGGCCAGTGGTTATCCCATGCTGCCTTTTAGGAATTCTAGGAGGCGTTCCTAAATAGCTCGCCCGACGATATCCTACTTGATTGTGGCGGTATACCTTGCTGAACCTCGCAGTA"),
                new DnaStrand("CGCAGTGCACTAGTGGCTATCGCCTTTCTATCCCTGAGGCGTTTGCGTTATAAGATCACTCTGTCGGTGTGAAACCACTGAGTCACACTGACCGGTCGACTGGCCCGTCATATGCAAGTTGAAACGCTTACTGCCGGGTATCGCTCTAAGCTCGAC"),
                new DnaStrand("TACTCGTAACTTCAAAATCTCGTAGGGTCTGCAGAGTAAGAATCCCGGATACTTCAACATTATCGATTCGTCAAGACGTGCGGAGTGGATATCCCTTATTCCTATACGTCACAAGCCGCGGTCAAGTCGCTTACGCACGGTAGAGCGGGAAACCCT"),
                new DnaStrand("GCTCTAGTACGCCACAGTGCCAGTACATGACCTCACGAGCCGCCACTTACGTTGATATGTTATAAATCACTAGTTTCGTTGGTACAAACAATAAGTGAGAAGCAATGAGCAACTTATCTCATAAAAAGTGTGGTCGTTATCACACATGACATAAAC"),
                new DnaStrand("GAGACGGTCGTAGAAATTTGCGCTTGCTCGTATCTCAGTATCCTTCAAAGATTGAACCGGATCGCGGCGGCTAATATTGAAATCCTTAGACTTAACGTTGGTATCACTTTAGAATTTCTGACTTGAGGGTAGTGACTAGACAATCATGATGGAAGA"),
                new DnaStrand("GATCGGTGGCAGTTGAATTAAGACTAGTTATCCCCTGCTTACACTTTTTCCGCCCGGACACGTGTGACGGTAGTTGATATCTCTCAAGTATCCCGACTTCACGTACGATGCCACCCATCTCCGGCAAACACACTTCTATAATATCGTGGAGCCGAA"),
                new DnaStrand("GTAGGTATCACCAGAGTTCTCTCGGTATGTGGCGCTAAAACCTCTTAGAGTATGAAGGGTGAAGACCAAGCTCATACCACCCCTATATAGGGCTAATTAATTCCACATCCAGGCAAGATGTCACCCTACAGGTCGCTCACTTGTGGAGAACATCAC"),
                new DnaStrand("GTGGCTATCGCTGTGATCCGTCACACAAAATCAACTTTGTAGTATTTTGGGTAGTCGGGATAACGCGTGGTCTAAGGTGAGCTGCCTTTGATCCGTTGGGTGGCTACCTTGCAAGTTACCGGCTTGTCACTAGATATAACCGGAAGTCTCTGCAAA"),
                new DnaStrand("TGAGCAGACCCGACAAAGGCCATGACTTCAAAACCGGTTGTGCAGCGACAGGTACTTTAAGTACGGCACCATTAATATCGCTATACTTACGAGTTAGTGGGTATCTCATGCAAACAAACTGCTACTAGGAACTTAGACGAACTTACCAGGAGGATT"),
                new DnaStrand("AGTGATCTGAGCATAGTATACTGAGAACGTGTGTGTGACCCCTCCAGCGTCCCCGGCTACTGTTCCAGATCCTAACTAATTACTGCTAGCGATCTGGTCGATATCGCTACGGAACGAAGCCGTACAATCGCCCAGAAGCGGTTAGTCAAGGGCGTT"),
                new DnaStrand("CAAAATGGGAGTACTTCTCGTAGAATAATTCGTCTGTAATTCCTAGGTTCCATAGATAGGCCTCGATAGTGAAATTCCTTCATGCCCCGAGGTGGCGTTGATATCTCCTTTCTAAGCGGTACCCTTAAGAGTACTCGCGATGGGCTTATCCTCCTC"),
                new DnaStrand("GTTGGTATCACCCCCAATCCTCTTAGTTTACACTGTAAGATTAACGTCAGGGTGTTGTGGATGGCTTTTCTAATTTAGGTCCTCGGGATGCTCAGGTGTTACTATCGGACTGAGTGAATGTAAGTCCGGGTATCAGCCATGAAACCACTGGAGATC"),
                new DnaStrand("CCTCGGAAAACGTCGTAAGTGGTATCACAATCCACTAGTCACGGAGGGCGGTGAGTGTCTCGATGCTCAACCCCCAACCCTCAGATGAGGCTATCTGTAGGTATCACTTACGTCACTACGGGGAACAGCTCGCCTTAAGTGTAGGCTAGGTATATG"),
                new DnaStrand("GGCGGCTCCATCCGATGTGACGGATTTCATGAGGCACAAGCGCTTCACTCCCTATTTGGCTCGTGACAAAGTTCAACGGCTTTGCAGATATCCATGGTCGTTATCCCGGTGGTGAACCTACCGTCAAGTCTCTACAGTGCGCGAAGTGTCCCGGGC"),
                new DnaStrand("TACTAGTATAAGTTCCGAGCCAAATGGATGGCCCAGGCGCACTAGTGTTAGAAGGATTCGGGCTGTAGGTACATCAAGCTCGAATTTGTCCCACGTCATTCTGGGCCACCCGGACCACAGAAGACCTCTCTCTGTGCCGACGGTGTGGTTATCACG"),
                new DnaStrand("GTGGTTATCACCGGGATCGAATACAGATACGTCTGGTACATGCCTTGTCATTATTCATACGCCCCCTGGGCCAACAATCCTTTGTCAACCGCGGTCAAAAAGGTAACTAGGATCGGCTTGATCTCTAATTCCGGACTGTTCACCACGGGTCGACCG"),
                new DnaStrand("CATCACGCAATGCGAACGACTGAAGAAGGCAAGGACAGTTACGCAACCTATCATGCGTAGATCAAGGTAATCGGGACCGGTCTGGAATTTAGGAGTGTTGTTATCGCAACCTGCGATCATAACATCCTCTTATTGCCTATAAACCGACCCTGACCG")
            };

            var results = Motif.GreedyMotifSearch(strands, 12).ToList();

            Assert.AreEqual(25, results.Count);
            Assert.IsTrue(results.Any(x => x.Dna == "AGTGGGTATCTC"));
            Assert.IsTrue(results.Any(x => x.Dna == "TAAAAAGGTATA"));
            Assert.IsTrue(results.Any(x => x.Dna == "AACCACGAGTAC"));
            Assert.IsTrue(results.Any(x => x.Dna == "TGTCATGTGCGG"));
            Assert.IsTrue(results.Any(x => x.Dna == "AACCTAAACCCT"));
            Assert.IsTrue(results.Any(x => x.Dna == "AGTCGTTATCCC"));
            Assert.IsTrue(results.Any(x => x.Dna == "AGTAATATGTAC"));
            Assert.IsTrue(results.Any(x => x.Dna == "AGTGGTTATCAC"));
            Assert.IsTrue(results.Any(x => x.Dna == "AGTGGTTATCCC"));
            Assert.IsTrue(results.Any(x => x.Dna == "AGTGGCTATCGC"));
            Assert.IsTrue(results.Any(x => x.Dna == "AGTGGATATCCC"));
            Assert.IsTrue(results.Any(x => x.Dna == "AGTGAGAAGCAA"));
            Assert.IsTrue(results.Any(x => x.Dna == "AGTGACTAGACA"));
            Assert.IsTrue(results.Any(x => x.Dna == "TAAGACTAGTTA"));
            Assert.IsTrue(results.Any(x => x.Dna == "TATGAAGGGTGA"));
            Assert.IsTrue(results.Any(x => x.Dna == "AGTCGGGATAAC"));
            Assert.IsTrue(results.Any(x => x.Dna == "AGTGGGTATCTC"));
            Assert.IsTrue(results.Any(x => x.Dna == "AGCGGTTAGTCA"));
            Assert.IsTrue(results.Any(x => x.Dna == "AGTGAAATTCCT"));
            Assert.IsTrue(results.Any(x => x.Dna == "TGTGGATGGCTT"));
            Assert.IsTrue(results.Any(x => x.Dna == "TGTAGGTATCAC"));
            Assert.IsTrue(results.Any(x => x.Dna == "TGCAGATATCCA"));
            Assert.IsTrue(results.Any(x => x.Dna == "TGTGGTTATCAC"));
            Assert.IsTrue(results.Any(x => x.Dna == "TGTCATTATTCA"));
            Assert.IsTrue(results.Any(x => x.Dna == "TGCGTAGATCAA"));
        }



        [TestMethod]
        public void MotifGreedy_Test6()
        {
            List<DnaStrand> strands = new List<DnaStrand>
            {
                new DnaStrand("CTCTATTCTAAGAGTAACCATTTGGTTGGGGCGTCTCGACCATCACGGATCCCAGTGCAGTACGTCACGCCGACGCGGGACCCTTACTGTTCTTGGGTCCCCGCGTGACACTGCCCACCGTGCTAGGAGTCTTCAGCGTCCGGTTTTTGTCAAGTT"),
                new DnaStrand("CCCAAACACCCAGGCGAAGCGCTCCTGTTTGTCTGCGCGACTGTCCCATGTCTATTCCACGTCCCAAATCCGACACCCGCAATAAATCTATATGCGTACCATACGCCGAACTCTTAGCCTAAATTGTAGGCCTGTAACACTCTGATTTCTAGACGC"),
                new DnaStrand("TCACGATCTGACCGTGTTGTTAGAGCCTATAACCGAGAGTCGCCTGCTTCGTCATTACATTACTGTACACCGAATCCGCTTTCATTCTCAAAACCTCGACTGATGTTGAGAGCAGAGCAGGTGATCAATGTGATCAATAACAGACTCCAGTCAACG"),
                new DnaStrand("CCCATGCATACTTACGTGGATAGGTTCAGCTTACACTAGGAAACTCTCCTAGGCGAACCCCGTCAGTGTTTTTACCATACTCCGGTGCACTGCAATTGATTCTAAGCGCATTCCAACGTGAATAGGATACCCGTCTATACGCTGCAGCCCCTGCCG"),
                new DnaStrand("GGCGCGGTTGCTACAACCGGCTGCGGGGAGGTACCGCCACTTCGAAAGATTCATTTGGTCTTGACAGTGTTCCGCCTCATATCATACAAGACCCCGTGTATCCTAGTCCTGCGCGATGAAGTCACTAAGACGGGCCACTTTGACACGCGGCTGCCT"),
                new DnaStrand("CCTCGGATGGCGTATACGCTCACCATTCGGCCTGGGCAAAGTATTAATTTACCCGCGCGCAACGGACCCGATTTGGTTGTGTCATACATTACCCCGATACCGAAGCCACATGTAGACAATGATCATTCACATGAAGGCGGGTTCTTATAGAGCGAT"),
                new DnaStrand("AACGCGAAGTGGCGTTTTTCAATGATGTTCGAGCCCAGTCGGTTTTCAGTCTAGCAGCCTAACTAAACCTGCACAATCTGTATGTTAATCAGCTCATCATACCTAAGTTACTTGACACCGTAACTGGTTTCGGGTCCGCTGGGACGGTCGATTGAT"),
                new DnaStrand("GCACAGGACTTCATCCTAGAAGTCTTCCTAGCGAATAAAGCGCGATGACTCGTACTCCTCATCCCATCACCTTACTCCACTCCGTTTTGGAGGAGTAAGCCAGCCTATGTTGGCTTCTCCATTTGTATAATTTAATTCCTTTCCGTGGCACGCGCT"),
                new DnaStrand("TACATAACGCCGAGCCAGAGGCTTTCGATTGGCCTCGCCACGAGCACGTTCCTTCGCAAGCGATACACCGAGAGTTATCTGCAATGACTAATTGCAATGCTGCTACAATAGTATTCTCTACACTAAGCCAAGCAGCTAAAAGGAATGTTAACCTAC"),
                new DnaStrand("CCAATGCGCTGGACCAAGTGCCGGTGCCGTCCCGACGAGTCCCGCAATCATGTGATCCTGGGCGGATATGATCCTGATGGTTTGTATGCAGAACGCGGTGCTGTATTTTACGATACACCGTCTACATTCATACCATACACGCGACGCTCCCCAGCT"),
                new DnaStrand("CCACATGCCTTGACTGGTTGCCGTTACATAACACCGGAAGATTCCCGACAAGTTACCAAGTTCCGAGTAGGGGAGCCGAGGATACTTTTAGGAACAGCCGATGGGAGCAACTTAATACGCAGTGATATTTTATAAAATACATTATATTCGAGGGCA"),
                new DnaStrand("AAGCGATAGACAGGGTCTGAACCTGCATCTCTCGACTTGGTCCCAGGCGAATAAGGCATTCAAATGCTATAGCCTACTTGCTTGTAACACAGTGCGTACTGAACCCCGTTTGGACCTATCGCACGTCACCTTTGCCCCATGCCGATCCCTTAGTGT"),
                new DnaStrand("TAGCGAGGGCGAAGCCCAGATCCGCAAGATACGCATGAGCCAATGTATTCGGGCTTCTTGCAAAAGGGCTGGTACACTACGCCGGTCCCGGCAAACGGCGAACTCCTGCTTCACACAAGCGACTACCACACTGGGGCCAATCATCCAATAATATCC"),
                new DnaStrand("CGCCGAGGCCGAATAGCGTCCGCCTCGCCCTTATCGGTGTCAACGTGACGGCCAGATTTTATTCATATAGCGTTATCGTAAGTCAGAAAATTATCCCCTATGTCCACTTGAATATCAGCGATTGCGGTCGGCTACCTGACGCCGCAAGCCTGCGAG"),
                new DnaStrand("GATCTTCTACCATGGCTTATGAGCTGCACTGTCCTACGCTACTGCAGCCGAGGAGCACGGTAACGACAGGCTAGAGTAGAGAACCGGCTTGGCATCTACCCCACTCCGATCATTGATCTATCGAAATGGCGCATGGTCACCACTTCCTAGTCGAAA"),
                new DnaStrand("TTCAACTGGGTCACTCCCCCAGCTCGCGGTGCGACTGAGAGCACACAGTGTGTGACTTTCGCGGGTCCGATAGGGCTACCTAACTACGTAACGCCGTATACATGCCTTTCTGACGTACAGCACATGCGTCGGTATTCCCAATGGCTGAGCTGAATC"),
                new DnaStrand("GGGCGCCATCCATACCCTACACCGAACAACCCAAGTCTGGCGGCATGCAGCATTTCACTTCCTAGGTTTATACAACGACTCGGTCCAAGGGAGATGGAGTTCTTCTGAATCCACGACTACCTCTATCGGCTCTAACGATCTTTGCGCCGAGAACTC"),
                new DnaStrand("GCACTACTCCCTACCCGTACACTACCAGCGTAATTGACTTATACTATTAAACCTGAGCAAAGGTAGTTCTCAAAGAACCCCTGGTACTAGCCCCGGATGAAAGCGTATGTTGCGAGTCGAGTCGCAGGAGCTTACATAACCCCGGTTGGAACTGCG"),
                new DnaStrand("ATTTACCCTGGCAGCTCAGCGGCATTCCAATACTTCGACGTAGAACCGTTAACAAACAGTGATACTGCCCTAGATGCTCACCCCCGGCGCGGCAATTATTTACGTACCCCACTGAAGTCCCATGCTCCAGGGTACACCACGCCGTGTGGTGCCCGA"),
                new DnaStrand("GGGATACGAGGATTGCGAGCACGAGCCACACGCGCTTTGGCTCCTGTTTTTGACGCATAAGGCGAGATGTGATAATGTCCCAATTAAATTGAACTATACCCGACGCCGGCTAGCCCACGGCCTAAACGGGAATGGGAACCCGAAACTCGCGAGATA"),
                new DnaStrand("GAGCCTTAGGATGGGAGCCTAGACTTTTAGCAAAAACCCACGCCCTTAGAGACCGCAAACCGGGCTCGGTCATAAAAGCGGTGTAGCTATCCGAAGAGATCGCGGACGTATGCTGTTATTAACTCTGGTTATTACAAGACACCGTGCAGTAATGAT"),
                new DnaStrand("ACGTTCGACAACGTATTGGAAGCTATCTCACGCGTCGCTCTACTTCCCTACACGACCCCGGCAAAGCGCGCGCCACCTAACATTCCTGTTACGAGACAGTGTGGGATGCACTGGGTTCCAGGTATATTGGCAGGAGGGCATTCTCTGGGGACATAA"),
                new DnaStrand("AAGGCAACCTAAGCGAATTTAGTGCTATCATTCTGTGTCACATATAGACACTGACAATGGAATCGGAAGAGCTCTTAATGTTGACAAAATCGCAAATACCTTACTCCGCGGACTTTTGGTGCCTGAGGGTGTACCTCGGCAGACCGTAGGAAACCA"),
                new DnaStrand("CTAGACAACAAATACAACACGCCGTCACGAGGGGTTGGGGTGCCGCCATGTAGGGCAATTGTGGACAAATTAGCAGGGCACCATCACCCTTGTGGACCCAACGCGAAATTCCTGCTTCCAAATCGCAGCAACGCCTGAGTTGCCATGCTTCTCAGC"),
                new DnaStrand("TTCCGTACAATGATATGACTTACGGACTAATAATGAGGCGCCACGTTACATACCTCAGCAAGTGAGAGAACGAAGGAGTTACTCCCCGTCCACATTCATCATAATCGCTACTCTACCCCGACTTGTTAGGTTTGCTCCTGTGCAACGGCTTGGGCC")
            };

            var results = Motif.GreedyMotifSearch(strands, 12).ToList();

            string visual = "";
            foreach (DnaStrand i in results)
            {
                visual += i.ToString();
                visual += " ";
            }
            Assert.AreEqual(visual.Trim(), "AGTGCAGTACGT CCCAAACACCCA TCACGATCTGAC AGCGCATTCCAA ACAAGACCCCGT CCCCGATACCGA AGCCCAGTCGGT ACTCCACTCCGT CCACGAGCACGT CCAATGCGCTGG ACCAAGTTCCGA ACTGAACCCCGT ACACTACGCCGG CGCCGAGGCCGA ACCCCACTCCGA CCCCCAGCTCGC ACCCTACACCGA ACCCCGGTTGGA ACACCACGCCGT ACCCGACGCCGG ACAAGACACCGT ACACGACCCCGG TCTGTGTCACAT ACAACACGCCGT ACTCTACCCCGA");
        }



        [TestMethod]
        public void MotifGenerateProfile_Test1()
        {
            var profile = Motif.GenerateProfile(new List<DnaStrand>
            {
                new DnaStrand("TCGGGGGTTTTT"),
                new DnaStrand("CCGGTGACTTAC"),
                new DnaStrand("ACGGGGATTTTC"),
                new DnaStrand("TTGGGGACTTTT"),
                new DnaStrand("AAGGGGACTTCC"),
                new DnaStrand("TTGGGGACTTCC"),
                new DnaStrand("TCGGGGATTCAT"),
                new DnaStrand("TCGGGGATTCCT"),
                new DnaStrand("TAGGGGAACTAC"),
                new DnaStrand("TCGGGTATAACC")
            });


            Assert.IsTrue(profile['A'][0] == 0.2);
            Assert.IsTrue(profile['A'][1] == 0.2);
            Assert.IsTrue(profile['A'][2] == 0.0);
            Assert.IsTrue(profile['A'][3] == 0.0);
            Assert.IsTrue(profile['A'][4] == 0.0);
            Assert.IsTrue(profile['A'][5] == 0.0);
            Assert.IsTrue(profile['A'][6] == 0.9);
            Assert.IsTrue(profile['A'][7] == 0.1);
            Assert.IsTrue(profile['A'][8] == 0.1);
            Assert.IsTrue(profile['A'][9] == 0.1);
            Assert.IsTrue(profile['A'][10] == 0.3);
            Assert.IsTrue(profile['A'][11] == 0.0);


            Assert.IsTrue(profile['C'][0] == 0.1);
            Assert.IsTrue(profile['C'][1] == 0.6);
            Assert.IsTrue(profile['C'][2] == 0.0);
            Assert.IsTrue(profile['C'][3] == 0.0);
            Assert.IsTrue(profile['C'][4] == 0.0);
            Assert.IsTrue(profile['C'][5] == 0.0);
            Assert.IsTrue(profile['C'][6] == 0.0);
            Assert.IsTrue(profile['C'][7] == 0.4);
            Assert.IsTrue(profile['C'][8] == 0.1);
            Assert.IsTrue(profile['C'][9] == 0.2);
            Assert.IsTrue(profile['C'][10] == 0.4);
            Assert.IsTrue(profile['C'][11] == 0.6);


            Assert.IsTrue(profile['G'][0] == 0.0);
            Assert.IsTrue(profile['G'][1] == 0.0);
            Assert.IsTrue(profile['G'][2] == 1.0);
            Assert.IsTrue(profile['G'][3] == 1.0);
            Assert.IsTrue(profile['G'][4] == 0.9);
            Assert.IsTrue(profile['G'][5] == 0.9);
            Assert.IsTrue(profile['G'][6] == 0.1);
            Assert.IsTrue(profile['G'][7] == 0.0);
            Assert.IsTrue(profile['G'][8] == 0.0);
            Assert.IsTrue(profile['G'][9] == 0.0);
            Assert.IsTrue(profile['G'][10] == 0.0);
            Assert.IsTrue(profile['G'][11] == 0.0);


            Assert.IsTrue(profile['T'][0] == 0.7);
            Assert.IsTrue(profile['T'][1] == 0.2);
            Assert.IsTrue(profile['T'][2] == 0.0);
            Assert.IsTrue(profile['T'][3] == 0.0);
            Assert.IsTrue(profile['T'][4] == 0.1);
            Assert.IsTrue(profile['T'][5] == 0.1);
            Assert.IsTrue(profile['T'][6] == 0.0);
            Assert.IsTrue(profile['T'][7] == 0.5);
            Assert.IsTrue(profile['T'][8] == 0.8);
            Assert.IsTrue(profile['T'][9] == 0.7);
            Assert.IsTrue(profile['T'][10] == 0.3);
            Assert.IsTrue(profile['T'][11] == 0.4);
        }



        [TestMethod]
        public void MotifScore_Test1()
        {
            var score = Motif.Score(new List<DnaStrand>
            {
                new DnaStrand("TCGGGGGTTTTT"),
                new DnaStrand("CCGGTGACTTAC"),
                new DnaStrand("ACGGGGATTTTC"),
                new DnaStrand("TTGGGGACTTTT"),
                new DnaStrand("AAGGGGACTTCC"),
                new DnaStrand("TTGGGGACTTCC"),
                new DnaStrand("TCGGGGATTCAT"),
                new DnaStrand("TCGGGGATTCCT"),
                new DnaStrand("TAGGGGAACTAC"),
                new DnaStrand("TCGGGTATAACC")
            }, 12);


            Assert.AreEqual<int>(30, score);
        }
    }
}
