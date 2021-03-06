﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Bioinformatics;

namespace BioTest
{
    [TestClass]
    public class MotifGibbsTests
    {
        //[TestMethod]
        //public void MotifGibbs_Simple()
        //{
        //    List<DnaStrand> strands = new List<DnaStrand>
        //    {
        //        new DnaStrand("TTACCTTAAC"),
        //        new DnaStrand("GATGTCTGTC"),
        //        new DnaStrand("CCGGCGTTAG"),
        //        new DnaStrand("CACTAACGAG"),
        //        new DnaStrand("CGTCAGAGGT")
        //    };

        //    var results = Motif.GibbsSamplerBest(strands, 4, 50, 2000).ToList();

        //    Assert.AreEqual(5, results.Count);
        //    Assert.IsTrue(results.Any(x => x.Dna == "ACCT"));
        //    Assert.IsTrue(results.Any(x => x.Dna == "ATGT"));
        //    Assert.IsTrue(results.Any(x => x.Dna == "GCGT"));
        //    Assert.IsTrue(results.Any(x => x.Dna == "ACGA"));
        //    Assert.IsTrue(results.Any(x => x.Dna == "AGGT"));
        //}



        //[TestMethod]
        //public void MotifGibbs_SimpleSample()
        //{
        //    List<DnaStrand> strands = new List<DnaStrand>
        //    {
        //        new DnaStrand("CGCCCCTCTCGGGGGTGTTCAGTAACCGGCCA"),
        //        new DnaStrand("GGGCGAGGTATGTGTAAGTGCCAAGGTGCCAG"),
        //        new DnaStrand("TAGTACCGAGACCGAAAGAAGTATACAGGCGT"),
        //        new DnaStrand("TAGATCAAGTTTCAGGTGCACGTCGGTGAACC"),
        //        new DnaStrand("AATCCACCAGCTCCACGTGCAATGTTGGCCTA")
        //    };

        //    var results = Motif.GibbsSamplerBest(strands, 8, 100, 2000).ToList();

        //    Assert.AreEqual(5, results.Count);
        //    Assert.IsTrue(results.Any(x => x.Dna == "TCTCGGGG"));
        //    Assert.IsTrue(results.Any(x => x.Dna == "CCAAGGTG"));
        //    Assert.IsTrue(results.Any(x => x.Dna == "TACAGGCG"));
        //    Assert.IsTrue(results.Any(x => x.Dna == "TTCAGGTG"));
        //    Assert.IsTrue(results.Any(x => x.Dna == "TCCACGTG"));
        //}



        //[TestMethod]
        //public void MotifGibbs_Test1()
        //{
        //    List<DnaStrand> strands = new List<DnaStrand>
        //    {
        //        new DnaStrand("TGTGGCACCGACAGGATGCTTCCATACCCTATTTCGACACCCAAAGCGATAAGGTAAGTGGACGGACGTAGTATTCAGATCCCAAACGCCAAGAAAGCTCGACCAAGTTCGGTGTTTCTGCCGTTTGTCGTCAGTCAGCCCCTTGGTGTACAGCGTAGGTCAGATATGATCTCCTTGACTACTCACGTTGCACCTGTGACCGGATTTTCGCGTTTCCGGCCGACGAAGTCTAGTCGGCTCGTGTAAAAGCAGACAACGGTTGTGGGTTGCTGGTTGTCCGCTTCACGAGTGTTATCCGCGGTGGGATCGCCAGAGACTGTGGCACCGACAGG"),
        //        new DnaStrand("ATGCTTCCATACCCTATTTCGACACCCAAAGCGATAAGGTAAGTGGACGGACGTAGTATTCAGATCCCAAACGCCAAGAAAGCTCGACCAAGTTCGGTGTTTCTGCCGTTTGTCGTCAGTCAGCCCCTTGGTGTACAGCGTAGGTCAGATATGATCTCCTTGACTACTCACGTTGCACCTGTGACCGGATTTTCGCGTTTCCGGCCGACGAAGTCTAGTCGGCTCGTGTAAAAGCAGACAACGGTTGTGGGTTGCTGGTTGTCCGCATCTAACTCAAATTATTCACGAGTGTTATCCGCGGTGGGATCGCCAGAGACTGTGGCACCGACAGG"),
        //        new DnaStrand("GTTCATTATCAGTCATCAGGCAGCAATTAACTTGGTCCCCGGGACACTATCTAGCGTTGCTATCTGGTGGTCTCTCCTTCGCGTATGCTGACAAGTCCAGTTTCAATGCTGAAATCTGAAATCAACGGAGGAAATAGCTCAAGTGGCTAGCAGAGTTGCTTGCACGGTCCGTAACTATTATTTGTATTTAGACAGGGTTTGAATCGTCGTCTCTGTCCAAAGATAGGGCATAGGAGCACGTTGTCAACCGTCCAATCTGATCTCAGAAAGGCCGCCCCAGAGCCATCAATGACCGCACGTTGAGCGTGTGCTTTTCGCTGCGTCGGACTGGT"),
        //        new DnaStrand("CTGTAGTCGGGCCTTCACTCGGAAGAGATGATTTCCGCAGCGGCAGCACACGCCCGGACCTTCGCAGGTAAACGGTTTCGGGGAGACACAGAGTCGGCAAACAGGGGACGAGCATCACAGACCAAAGTAGGCCGCGCCTCCTCATAATGTAGGGTTTTACTTTTGGTGGCAAGTTCGGCTGATGTAAGGACCAGAAAGTGTCCCGTCCTTGATACTAAGAACATCGGATAGGATCTTTGTACCATTTAAATGATTGTTCACAAACGCCCCCCCGGCCCAAAGGGGCACCAACGACTAAACCCTCAGGCTCAAATAGCATTTTCAAGTACTGT"),
        //        new DnaStrand("GCGAGAATATTAGCATACAGAGCGTCTCCTCATACAGTAGGAGTTCGGCGACCGGGTTTACATCAGGCTCACGGTAACATAGCACCGGGCGCTTAAAGAACTTTCGACAATGGACGAGCCCAAAGGGGGGTTGAGAGAACAACGCAATGACTTTCACGAAGGAGTATCGCGATACTTGAGAGAGGGAACGGACTTTTAGTACCGTTGCCTGGGACTTTGAATGGAAGAGAAGACTCTTCGCTAATCTTTTTCGGCGTACCCTACAGATCTTCCAAAATGCAAACCTTCTGTATTGGGAGCGTATTCCCACCCTGGTTGGCTGCTTTGTGGTG"),
        //        new DnaStrand("ACAACTGGACCGTGAGGGCAAACCGCCGCACATCCCCGAGCATTTTCCGCATGGGTGTTTGTTAAACTGACAGACCTATGCTGATGGGAGACTGCTCAGGGACGCATCATTTTCAAATTACGATACTGTTTATTGATGGTGGGCTCATGGCGAAACCCAGAGACAGGGGCAACATGCGTCGCTGCGCATATTGCTATTGTTTCAACTGGCTAATGAGTTTTTGGACCTCTTCCCGTAAACCGACCCCGATAAGCAGGCCACTAATTAACCATTCGGATGCAACTGAGGCTTTGTAACGGTAAACTGATGACGGCCAGAGGATACTACAGAAC"),
        //        new DnaStrand("TTTTAGCATGTTGGGGCTAGGGAACTGCCCGCCCCATAGGTGAGGTCACTTATAAAGAAAAAGGTTTTGTGCGAGCGCCGTCCAGCCTGCCACAGTGGGAGCACTACACTCCAAGCATGGCCCGGCGCTGGAGCAGCATTAAAACTAGTCAAGCTAGTGGCACGTCACACGGAGATATTATAGTTGGCTATTGGATTTGTGTGACCAACGCGGCATTTTTTAATTTAAATTAGCATTATATCAGTCCTATGTCTGGGGAACTCTCTCATGACTCCAGCTTTTTTAGGGAAGTATATCAGGCTCTGTTTAGGGGGGATACCGCCCGTAAAGCA"),
        //        new DnaStrand("AGCATATTGCCAATGCGGCGTCTACGCTTAATCACGAGTCGCCGTAGGTGTCGATGTCTGATACTCTCTAGATTGACTAACTCGACGTGGAAGAGCAGCAAGACTATGAGTTTCTCTATCGCAGAGACTGGAGGGGGCGTGCTGCTTCCTACCTTACCGTTCAGCTATTTAAGTCCTCCACTACACTTACAAACGAATTATGTAGCGGTATAGAAATGTCCACACTCGGCAGCGAAAAACCGATGAAATCACTGGGAGATGTCTACGTTTTCAGCTCGGCCTTTAGCGGTATCCGTGTAATAACGCTGAAATGGGCTCAAATTAACCAATAT"),
        //        new DnaStrand("GCTATGGACGAGCGGTATCGTTAATATGACGTGAAGATGTTTTCATCTAGTTAAGGGCTAACGGTTTACTCAGTAGCTTCGGCGACGCGGGCAGAATGAGCTAAATTTACCTTAGGCACGTGACAATGGCTACGGGACCGCTGCCACAACAATAGCTGCGGTTGATACTGCGACCCATCTCTGACTCAGTACTCCCCGCGGGGGTGTGCAGGAAAGAATATCAGGTGTAAATTAGACGCCTAGCCCGAGAGAAGGATAACTTTGGCGTTTTTGATTTGAAGGCCATGTAAGCGAAGTCGTCACCGGGGGGAATACCTCTTCCACAGGATCCG"),
        //        new DnaStrand("CGGACAATCGGCACCCTTGTGCCTCATCTGAAAACGACCCGAATGGGACTGGTCTTCTGATGATCGCACTACACATAACCGGCGAGAACGGGGATGGGGGATGGTCTTGGGTAGGCTCAAATTAAGACAACCGTCTCCGACACGGTTCCCGCACTACTATCGCAGCATACCGACGTCGTAATCCGAGCGCTCAAACTAGGAACGCGTCGCACTTACGGATGTCGCTGATTTTTGAGCGGGGTGAATCCGCAGACCCACTTGTTAACACGGTGTAGAGACAGGCCGTGAAATTGGCGTGGATGTTGTCAACCAATCCGCTTGACTACCGCCCA"),
        //        new DnaStrand("TTAATCGGGGTACCGGCAGTAGGTGCCACAACGAGCAGTAGGTTTTCGCCCTAGGGTCAAGGAATTCCGTAGGACGCATCGCTACAAAGAGTTGGCTACACTGGTTGTCGGCACTAGGACTAGTCCGAGGCGGCAGTCTTTAGGAGGAGGCCGCAATGTTAGTGACAGGCCACGGGTGAGCTTCTAGGCGCCTTAGAAATAGAAACCACAGATTCTTAGCTTTCAAGACACATACTGAGCGCAGCGGCTCGGACGTATCAGGCTCAAACCCGACCCCAGGAATGCCGTGCCTAGACGCAATTTGACACAGGAATGCCGTGCGTCGACCGGTC"),
        //        new DnaStrand("CGCAAAGCGTCGATCTAGGGTGTTAGTGCGGGGACGTGGAGATCCTTAACATGCAGCTTTAAGGGCAACCGTCCGTCTAAGACCGAAGCACTTAGTAGTGTCGGGGCCGGGCACTCGATGATCCAGCAAGCAACTCTCAGCACGATTTACTGGCATGTCCCATGGCCTTCAGAACACCGCAGGTGACCTGTCCGCTGGGACATATGCGTGAAGGAGCGTAGTGGTAATAAGAAGCTATAGTAAAGTGGAGCACAGTTAACTGCGGTTAGTAACCATCATATAAAATCGATCGTACTCAAATTACAAATGCCCAGCATTCCTAGGAGCACGTT"),
        //        new DnaStrand("AGCTAATCGAGGGAAGATTCCGGCTCGGAATTTGACGACGAAAGACACCACCAGTGGACGAAGATCCGAGAATTCATGCCTCGAGTGCAAAGGTTTATAGTGCAGAGTCGGCTGACCACTCTCCCTGGCATTTGACTTACCGCTATCCGAAATTTAGAGTGGAAAACGCCATCACCAGGAGTTCCTGATGACCTCCACGGATCAGGAGAAAATTAGATAAAGAACACGCTATATACTTGCCCATATTTGGCTTAGTAGAATATTCGGATAACCCCGCTCCTGGCGATGATCTATTATACTTATGCTCAAGTCGTGCTATTTAGTTGTGTACT"),
        //        new DnaStrand("TGAGCAGCTATGTTCCGTTATTCATCTATCTGACTCAACATCTTTTAACTATTTTACAACTCGAAGGGTCACATGAGGTCCCCAGATGCGCGCTATTTCGTTTTCTCCAGTGTTAAGATGTGGAGGCGATGCTGGATCGTCGGAGTGTTCCCGGAAGGCGAACCTAGTGAGTTATAGCAGTGTACGCTGCTACATTTGTCCAAGGAGGTGGCCCGCCGCAACTACTCGTACCAAATTCACAGTGTCCGGTCAAACATCAGGCTCAATACAGAATGAACCGTGCCGCGGAGGGTCGTCCGTATGAGCCAGGGGGACCTACCGAATAGGTTTGC"),
        //        new DnaStrand("CCATCTGTCCTATCGTTCCAGACGTGCCACGCTAGAATCGCACCTGTTTTGGATTCAACCTACGATAAGGCTGCAATTGTTACGTCGTACTATTCGTGGCCGGGAACTAATATTGGCAGTTATCATACTATTCATCGACGCACGGGCTGTGTCAGCTTTCCCAGTGAGCAGGCAAGCGGTCAGATGGTCCCATTGGCAACGTGATTCATGCGCCGGGCGTTAACAATTTTGGGAGTAGCGATCATTCTGTTATCGGCAGGCTCAAATTCAAACAATCTGAGCGTTCGATACAACCTTGCTAGCTCACAAGTGGTCTAGGGAAATCCTAACGC"),
        //        new DnaStrand("TGTACCTTCTTAGCCAAGTTTTGCGAGGTATGTTCAATCAGGCTGCGATTAGAGACGGCCATATTTATCCCGTTCGGAGGCCACCCGGTTCTAGTCTGGGCGCGCTCTCCGCCACTCCGCTCCTGGACAGCTACGCGCGTCACAGCAATGACCTCTTAGACCTACATGAGGGCGGCTCTTAATCTTTGAAGCTTCCTATTATTATCCGGAAAGCGACGGTAGCGGTTAGGTGCTGCCGCTTCTCATTCATAACTATTTATTGGGGACCCCTCGCTGCTTAGACCCCGGGTAGTCTATCTAGTACACTCCGACAGTTGCTAGATGCCTCACGC"),
        //        new DnaStrand("GCTCTCGCCGCTGTTACTTAAAAGCCCATATGACAGCTTGCTGGTCCCGCTTGCAAACTGCGAAGTATAATACAGGCTCGCCCATTTTGGCCTCAGCTGGAAAAATTGCCTAAATTCCATGTTCCCGGAGTCGGGGCCGTAGTTATACAACGCGCGGTCACGATACCTAACTTGAAAAGCCCGTGTTCACTTGCGGCGAGAACGGATGCTCGGTCGGTACCAGATATAAATCATTAATATCGCGAACACCACGAGTCACAGATCATCATCAAATTAAACGCGCCAATGATGGATGGCACGTCGGAACGCAGTCGTCGGAGTGGAGAGGCCTC"),
        //        new DnaStrand("CACGGCTTAAAAAGGAGGATTTGGTTTGCTAATGAATAGGAGTTGCGTCCGCCTTGGTGTACGTCTGCCCATGTAGCGTGGAAACAGAAGCGCATCCACCCGAGGTAAGACTTTTCCTGGTACGCACAGTCTCTGAGACATAATCTACGTCGTCCCCGCCAGCGAAGATGAACCTAAAATTAGTGAGAGCTTTGCGGACCAATGTGTCTTATAACCTTACATCGGAAGGAAAACGTCCACGAAATTGGCGAGTAAATGTACGTGCGCATTCAGCTCAAATTAGCTCGTGACCGGTTATGCATAACGTCTGAGTTACCATACCACGTTTTAAT"),
        //        new DnaStrand("TATGTCGGAGCCGATTGAATCCGCGATCACGTTCTTATTCTGGCCCTGGGCCATGGACTATAGACTGCAGTAGCCATCGTGAGGCGGTTAGGAGACAGCGATTTGCACCACGCTTTTCGTTTCTCCCTGAATACGGGTATATCGCACCCTAACAGACTCTTGAACGTGTTGGGTTTGAACGGTACTTCCAAACGACAGTATGCTCCTCAACCCGATACGGATCCCACCGGAAGGAAACTCTGTACCGCAGCTGCTTATGAGAGGGACTTAAGGTGATCAGAAGCAAATTACTATAACCAGCCCAGCGACTTTTCCTGTCAGGAGATGGAGCC"),
        //        new DnaStrand("CGGGTGCCGGCACAGCCCTACCGGAGGAAGACGGATCAGATGCAAATTATTAATTCTCAACGGCGGGCCGTTGATACCTGGGCTCCGACACAGTGTCTATGGAAGCCGCGGCATATGCCTTAGAATGTGTAATTGATTAGGAGTATCCGGACCCTCGCCGGAACCGAAGGCTAGACGGATTTAGGCTACTGATACCCTTCTACTTCAGCGGAACATCTGGAAGGCGTCGTCTCACTAAATCAAGGTTAATACAGGTAGCCCCGAATCGTACGACCCGGTTCCCGTAAACGACAACTTAAACCGGAAGCCAGAGTAATTGCATGGAGTAACAC")
        //    };

        //    var results = Motif.GibbsSamplerBest(strands, 15, 500, 20).ToList();

        //    string visual = "";
        //    foreach (DnaStrand i in results)
        //    {
        //        visual += i.ToString();
        //        visual += "\n";
        //    }
        //    Assert.AreEqual(visual.Trim(), "AGCAGACAACGGTTG ATCTAACTCAAATTA ATCAGGCAGCAATTA CTCAGGCTCAAATAG ATCAGGCTCACGGTA ATCATTTTCAAATTA ATCAGGCTCTGTTTA AATGGGCTCAAATTA ATCAGGTGTAAATTA GGTAGGCTCAAATTA ATCAGGCTCAAACCC ATCGTACTCAAATTA ATCAGGAGAAAATTA ATCAGGCTCAATACA GGCAGGCTCAAATTC ATCAGGCTGCGATTA ATCATCATCAAATTA ATTCAGCTCAAATTA ATCAGAAGCAAATTA ATCAGATGCAAATTA");
        //}
    }
}
