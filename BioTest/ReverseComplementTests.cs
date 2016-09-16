﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bioinformatics;
using System.Linq;

namespace BioTest
{
    [TestClass]
    public class ReverseComplementTests
    {
        [TestMethod]
        public void ReverseComplement_Simple()
        {
            DnaStrand strand = new DnaStrand("AAAACCCGGT");
            DnaStrand reverse = strand.ReverseComplement();

            Assert.AreEqual("ACCGGGTTTT", reverse.ToString());
        }


        [TestMethod]
        public void ReverseComplement_Test1()
        {
            DnaStrand strand = new DnaStrand("ACACAC");
            DnaStrand reverse = strand.ReverseComplement();

            Assert.AreEqual("GTGTGT", reverse.ToString());
        }


        [TestMethod]
        public void ReverseComplement_Test2()
        {
            DnaStrand strand = new DnaStrand("GCACTAAAGCACCAGCGAGACTAGACAGTGCCTTACGCTGTATAGGGATAAAAGTTGTCAAGATGACTTGCGGGAATCGTTAGGCTGACACGCACTAATGCTCGCCTTCCGGGTGTTCTGTGAGTACGGTTGATCACGGTCGCCCTGCGGATGTACTACCATGAAAGTTGATCACGTGCCGCGCGCTCCCTAAGCTTAGAAGTTTGCACAATCTGCATTCTATCCTGCCACGCCTTCAATAATAAGTGGTGTATGCAATTTGGAGTCGATCTGGGAACCAACGATTAACTTGGGAAGTGGCTATATCAAAATACGATGTCTTCAGCGTCGCGGTCGACGCTGCGCAACGAACGAAAAGTCCGATGGACCCGAACTCTGATTATACCGAATCTCCGCTTTTACGACTCGCCACATACCGGCATAAGCCATTCTGGGGCTTTGCCCCCTTAGGTCTAGCCCACCCCCGACCTAGCTTGAGCGTGTCACACCCCAACAGCCGCATTACGCCCGCTCACCGACACTTGGCGGTCGTATAAGAAATCCAAAACCGAGACGAAAACTGAAGAATAAGGTTCATTCAGCATTGTGGAGTTGACAACATCAGTATGAGGGTGAGTTGCGTCAAAGTCGAAGAATATGGAGGGTCAAATCACGAGATGTAACATCCACGCGAACACTTAGCTAGTAATCATTTTTCCGTAAAGAGTCGTTGAGTCCGACCAGTTGAAGCTCAGTGTTTATCCGGTAGGGAATTGTAGGATCAACGATAGGGTCGCGGAACCGCCGTATTATAGAAAGAGATAGTCCCAACGTTCTTTATGCACTTCGCTGAGAGAGGGTGACCGGGCACGCAGAGACTTTGGCTTTGTAGCCCCATTCCGCGGCTCTTCGGATACTGACTGAGCTGTAGTCGGCACATCCTTTACAACAAAAAAGCTCATGTCCGAGATTTTAATGGCGGCGCACGGTCACTCGGAGTTGACGAATGCGCAGCGAATCGTTGGTTCCAGATAAAGGCAAGGCTGTGTTACTGTTTCGGAGGGCAATCGTCAACGAGCAAAGATGTTAGAATAGAAATCGGAGCGAGGCTCCCAGCAAATATGAGTTAGGATCTTTTTTGCGAAAGGGTTGGTCTCCATCTCCTCTCGCCTGCGAGCGAGTCCCCGAAGCACGTTCAACCTATTTGATTCGGTGCAGGACACCCTAGATTAGCATACAGGTATAATATCAGGAAGAGTCACCTTTCATTCCCGACCAGTAGGATGTATAGGAATGAGACTATCCAGTTCTTTGTCAGCTCAAGACAGCGTTGGCAATACGGCCGAGTATTGGGGGGAATACCCCGGAACATAGTATTGTGCCTTAGCTATTGCCCTAGATACCACGCGGCCCTTGAGCATTTGTCTACACTTTGGTGATCCTAGGCACCCCGCGCTCGTGGCAACGTCAGCATCTTGTGATAGCAAAGCGTATGTACCTGTAATGTAACATCAAAGTATATCGGCACCCTAGTGGGGGCGAAGGTTGGATCGCTTATCACTCGGGACGACGGTGGTATCCAGCCACAGTGTTGCTCATTAACGACCACACAGCTCTTGGAATCGAGCCATGGACAGGGGACGCCCCAGGATACATGATGTTCCTGTGAGCACAAGCACTATGGCAGGCTTAGAGCTAATTCTTCCATTGGGCCGGTAAGACGCCAGAGAAAGTCACCGGTGTGAGAAAGGGTTTCGTGTGGGGGAGGCGTCAAACAACAAGGATTTACGTCGAACCGATCAGCCCTTGTCTGATTCATTCCAGGTTTAAGCGAGCCCTGGCGGTGACCTCCCGGGGATTCTTGGTGACGATAAGTGTAGACTGGTTTATGACTGTCTATAAGTGCAAGCAGTCCGCGACTCGGCCGCTCCTCAGATCTCGTCCTCCCAATCCTTACGAGGCACTATTCCGGCCCTAAAAACTTACCTACCAACCGGACATAGCGAACGGTCTAAGTTTTCGGAAATTGAATAACACTCGAACAAAGGAGCCCAATACATGGCACAAGCACACATAAAGCTTGGCGCTGCTGACGGCCGGCCCCCACAGCAGGTGGGTATATCAGGATAATGCTCTACCTCCTCGGGGATGACCAGAGACGAACGTTCGGACGCTATTAGTTAGTGGTCGCCCAGATATTCTCCTAATCAAGCCCTCGAAGGCTAGTCTAAATTTTAGCAAAAACTCGTATAGCAGCACATGCGGTAGACTGGGCCTCAGCCAGGTAGAGCTGTGGCTGCACTCGAGCAATCACTACCGTATAGAGTGGTGTTATTTCGGGGTGAATGTCAGGGGTGGTCCAAAATCACAAACACGTCTATTCGCACCCGGGAATGCTCATGTTCCCACGGCGGGCCTGTACAGATGTGAGAGGCAGCGATCATACAAAGTTGCCTGGCCTCCCCACGAACACACGGCGGCCCATTAGGTCTGAACAGGTTTATCGTTAATATATTTTGCGGTGG");
            DnaStrand reverse = strand.ReverseComplement();

            Assert.AreEqual("CCACCGCAAAATATATTAACGATAAACCTGTTCAGACCTAATGGGCCGCCGTGTGTTCGTGGGGAGGCCAGGCAACTTTGTATGATCGCTGCCTCTCACATCTGTACAGGCCCGCCGTGGGAACATGAGCATTCCCGGGTGCGAATAGACGTGTTTGTGATTTTGGACCACCCCTGACATTCACCCCGAAATAACACCACTCTATACGGTAGTGATTGCTCGAGTGCAGCCACAGCTCTACCTGGCTGAGGCCCAGTCTACCGCATGTGCTGCTATACGAGTTTTTGCTAAAATTTAGACTAGCCTTCGAGGGCTTGATTAGGAGAATATCTGGGCGACCACTAACTAATAGCGTCCGAACGTTCGTCTCTGGTCATCCCCGAGGAGGTAGAGCATTATCCTGATATACCCACCTGCTGTGGGGGCCGGCCGTCAGCAGCGCCAAGCTTTATGTGTGCTTGTGCCATGTATTGGGCTCCTTTGTTCGAGTGTTATTCAATTTCCGAAAACTTAGACCGTTCGCTATGTCCGGTTGGTAGGTAAGTTTTTAGGGCCGGAATAGTGCCTCGTAAGGATTGGGAGGACGAGATCTGAGGAGCGGCCGAGTCGCGGACTGCTTGCACTTATAGACAGTCATAAACCAGTCTACACTTATCGTCACCAAGAATCCCCGGGAGGTCACCGCCAGGGCTCGCTTAAACCTGGAATGAATCAGACAAGGGCTGATCGGTTCGACGTAAATCCTTGTTGTTTGACGCCTCCCCCACACGAAACCCTTTCTCACACCGGTGACTTTCTCTGGCGTCTTACCGGCCCAATGGAAGAATTAGCTCTAAGCCTGCCATAGTGCTTGTGCTCACAGGAACATCATGTATCCTGGGGCGTCCCCTGTCCATGGCTCGATTCCAAGAGCTGTGTGGTCGTTAATGAGCAACACTGTGGCTGGATACCACCGTCGTCCCGAGTGATAAGCGATCCAACCTTCGCCCCCACTAGGGTGCCGATATACTTTGATGTTACATTACAGGTACATACGCTTTGCTATCACAAGATGCTGACGTTGCCACGAGCGCGGGGTGCCTAGGATCACCAAAGTGTAGACAAATGCTCAAGGGCCGCGTGGTATCTAGGGCAATAGCTAAGGCACAATACTATGTTCCGGGGTATTCCCCCCAATACTCGGCCGTATTGCCAACGCTGTCTTGAGCTGACAAAGAACTGGATAGTCTCATTCCTATACATCCTACTGGTCGGGAATGAAAGGTGACTCTTCCTGATATTATACCTGTATGCTAATCTAGGGTGTCCTGCACCGAATCAAATAGGTTGAACGTGCTTCGGGGACTCGCTCGCAGGCGAGAGGAGATGGAGACCAACCCTTTCGCAAAAAAGATCCTAACTCATATTTGCTGGGAGCCTCGCTCCGATTTCTATTCTAACATCTTTGCTCGTTGACGATTGCCCTCCGAAACAGTAACACAGCCTTGCCTTTATCTGGAACCAACGATTCGCTGCGCATTCGTCAACTCCGAGTGACCGTGCGCCGCCATTAAAATCTCGGACATGAGCTTTTTTGTTGTAAAGGATGTGCCGACTACAGCTCAGTCAGTATCCGAAGAGCCGCGGAATGGGGCTACAAAGCCAAAGTCTCTGCGTGCCCGGTCACCCTCTCTCAGCGAAGTGCATAAAGAACGTTGGGACTATCTCTTTCTATAATACGGCGGTTCCGCGACCCTATCGTTGATCCTACAATTCCCTACCGGATAAACACTGAGCTTCAACTGGTCGGACTCAACGACTCTTTACGGAAAAATGATTACTAGCTAAGTGTTCGCGTGGATGTTACATCTCGTGATTTGACCCTCCATATTCTTCGACTTTGACGCAACTCACCCTCATACTGATGTTGTCAACTCCACAATGCTGAATGAACCTTATTCTTCAGTTTTCGTCTCGGTTTTGGATTTCTTATACGACCGCCAAGTGTCGGTGAGCGGGCGTAATGCGGCTGTTGGGGTGTGACACGCTCAAGCTAGGTCGGGGGTGGGCTAGACCTAAGGGGGCAAAGCCCCAGAATGGCTTATGCCGGTATGTGGCGAGTCGTAAAAGCGGAGATTCGGTATAATCAGAGTTCGGGTCCATCGGACTTTTCGTTCGTTGCGCAGCGTCGACCGCGACGCTGAAGACATCGTATTTTGATATAGCCACTTCCCAAGTTAATCGTTGGTTCCCAGATCGACTCCAAATTGCATACACCACTTATTATTGAAGGCGTGGCAGGATAGAATGCAGATTGTGCAAACTTCTAAGCTTAGGGAGCGCGCGGCACGTGATCAACTTTCATGGTAGTACATCCGCAGGGCGACCGTGATCAACCGTACTCACAGAACACCCGGAAGGCGAGCATTAGTGCGTGTCAGCCTAACGATTCCCGCAAGTCATCTTGACAACTTTTATCCCTATACAGCGTAAGGCACTGTCTAGTCTCGCTGGTGCTTTAGTGC", reverse.ToString());
        }


        [TestMethod]
        public void ReverseComplement_Test3()
        {
            DnaStrand strand = Load.LoadStrand("datasets//reverseComplement_dataset.txt");
            DnaStrand reverse = strand.ReverseComplement();

            Assert.AreEqual("GAGTTCACCCATCCGCTACCGTGGAAGTTAGAGAATACAATGGTGCGAGACAGCCGCAATTCCACCTCCAGATTCTTGCCGTGGTCGCATAAGTATGCCTGATAGAGTTAGCGCAATGGACAATAGTCGTACTTGACGCCAACGCGCTGAGTTGAAAGATCGCTAGCTTTAAAGTTGGGGATATGTTCCCCACGCTCTCGTTTTGAATCGGGCGATAGCAATCCGCTCAGGCTTGGGAAGTTATCCAATTTGCACCTGCTAATGTATTAGCAAGGGAGCACTGACAGTCGGGAACCATGTATCATCTTGAAACCCCCAATCCTCCATTAAACATGAAGTAGATTATCGCTATAGATGATTTGCTTGCAAGGCCTAAGGATCCAGAGCAATGGTCCGAGGAGGTTGCCCGGAGAGGTCTTATCAAAGCAGGCTCTTCACCCAATGAGCACTTGATAAACGGACGTCCAAGCGCACGTAGTTTTCTTCTTTTCCATAGCTCACATCGACTCGCCGCATTTGTGACGGAGGTCAAAAGTTTGGCTAGGAGGCTGTGCCAACATGTGTGATATAGACGCACATATCGACAATAGGGGGCAAGGTCCAGAGGTGCGAGTATGTAAACGCAGACAGGTGGACCAGTTTACTAAAACACATGTCCCGTTGTTTCTAAAGCTTGTGATTTAAAGTGGTGCCGTTCCCGATTAATCAGGATTGTCCGGGTCCCCCCCTTGTTATACCAGGTCTTCGTCCTTCTCGCGTGGCTGAGATGGACGATAGTCCCGGAATGGCTCCTGTTCGGACGTGCTCTTTGCTGTGCATTGTGCATTCGCAGCGTGCTACGAGAAATTCCTGTCGACAAGCCACCCGGGACGTTGACGAGGACGACCGCCGATGTCTTCGTGTGTTTATGCTAATTTGTCGGTGTAACTCCGATCATACCCCCCCAGGCAACTATCTCCCAAGTCAGGCCGTAGTCACGTTGGCACTCAGCACAAACTTGATCGTAAATGCGGGTCCCGGCATTGTTTTTGTAAATGTGTAATTCCCCGCGAGCGAACCCGGGCACGAGGTCTCACAAGACCCGGAGATGACCACTGAAAAGCGGTAATCGCTCATTGTGGGACCACAAGCCTAAACTCAACCTCACCATAGCCAGTTCCTGTTGTGGAAGAGTTAATCTAGTGTGTAGAGATGCAGAACGACATGCTCGCAATTGGGGCATGGAACCGCCCATTTAAAGCCCTGACATAATTACGTTGCTCATGGTGTTTGAAGCATGGCCTTGGTTTGGCATCCTCCTTTAAGATCGGTCCTTCCCTCTTCACCAGTGGTTCATGGGTCTTGAAGGACGGTTCGCCGCGCCTGCATTCAGCACTGCATGGCTCACGGAGTACGACCGGACCTGCGGCACAGATGTTTAGTTTACTCACTTCACACACAGACGTGGTTCAGACCGTAGGTTAAAGGACTTCTGGTAATGTTCTTCTACAATTGTACTACCAGGCAGGGTTAACTTTATTCCCTGGAATAAATGCTTACTTCAGGCGTTCGGACTATACATCTTCCGCTGAGTGCATATCATTTGTCGCGTATAGGACTGCAAGGCTCATGAATCGCTCTATTTCTAGGACGTCCCAACGGACGGGGTCGTTACATGACCTTGCTGCGGGATAACTCCGATGCGGCCCCTGGCCCTATGTGATCACAATATGCGACTCATATTGTTAGCGTGCACCCCACCTCCGCGCCACTATAGCCACCTTTACATATTTTATGCGCGACTCACTAGCATGTACCGGCTTTGGGTCCTTATGTACTGCATTGAATGCGTGCCTCTACTTTGAGCGCTAGCCACCAACGAGCATGAGATGAGGCATAGCTGGCGACCCGTCTATGATCACAAGATTTGTTGCCATCAAGCTATAACAAACCGCCGTAGACGTGTAGATGAATAGCTGACCAACTTTGAAGTATCGTACATCGGAAGGGAGGCCAACCCATGAAGGAGGTGTCTAAGGCAACTATTGTACGACATTCCGTGGTCACTAGGTGCGCCGCGCCGCTGATCACAACTACTAGGTCCAGTCTAACGGAAATTTAACCCCGGCATTCGTCAGTAAATCACCCGCTTAGTTGCCTCTCATTACAAATCCCGGGCCCCCTGCGCGTTAGTGAGACCTAGCGATTTGGCGCCAGGGCAGGCTTCTCACTCAACATACTCAGAATTCGTGATACTTTAAACTTATAACAAGGGTATGCTGATAACACAGACGATGAGTAACGCGTGGATCGACCCCCACACGCGCGAGTGTTAGAGGACTCTTTGCCGTAGGTTGAGATGGGGATTATTAATGCTGGGAGCACCGTCGGTACCGTGGATGAGCGTCCGATTAATGAAGCGTAGCCGGCCGAATCCTCATGTCACGGGGTAACGCCGCGGTTGTCCGCAGATATGGTTGAGGTTTATAACCGTTCATCAGTCTTGGACATATTGATGCATATGACGCGGAAGTAGTATTGTGTAAGATCTGTATGCCCTTATCTTCTCAATTGTTGACTCTGGCACGAGAGCAGTGGTTGTTTAGGACTCAGGGTCAGCCCATAGAAGTCCCACCTCTCCCTGTATAGGGTATCGACACTAGTTTCAAGGTGAATATAAGCGATATGCATAAATGGTCTGGGGAATAAATAGGCAAGGACTTTATCGCGGTTTCAGTGAAATGCGCACGTCTACCGTCGATTGAATACACCGTCACGAAGCATAAACTACATTCGAATAAATACCATGCACGGCCGCAAGGCACTGCGCTCTGTTTTAAACAGACTTCGAGATTCGAGTGCATATAAGATGACCCTCATACGGCTGCGACGGATTGATGTGCAGTTTAGGGATGATCCCCCACAAATAGCAATAAACATATGGTTGCGTTCACATAAAGTTACCATCCGGCCTCCCTTCCGTGCTCTATCCGGTCGGCACAACTGTGATCGAGCTCAACGGCGGCGGACACTACTTAACGGGATTTCAGGATCAGCGCCGTTGGAGCAACATGCCCGGCAATTCGACATGGTGCGCGAAGTTATCGAGTCAAGCAATTTGTCTGTATAGAGCTCGGAAACAAAACTTTGCTGTTCCAGATTCCTTCGCGATCATAATTGGTGGGGGTTAGTCACTAAGTCCAGAATGGACCCTAGCCTAAGTTCACAGATACTATGCTAGTGTGTTTCTTCGCTTCCGACGTCGTTCTATGGACTATCTTTGGAAATTCGTTCCGCGGACGGGAAGGACTGTTCCTGGGCTTAAAGACGTCCACCTCCAATCGATCATAGGATCGTCGGGATGAGGAAGATGGCTGTTATCCAGCCACAGCAAGCGGTCGGGTTTCGCAGCGCATCGTGCACATAAAGACAAATAAGAGCCAACCCCTTGCGCAGATGTTGACCTGTCAGCTTTTTTGTCCTCGTGCGTGTGCTCGCACCGTGTCTATTCCTTACCGCATGTGTGGTGTATCAAACCTTATAAGCCAGCTCGGTTGAACTGACATTCGTTGCCAGCTCGCCCCGCTCGTTGACCGGATTAGGATGTTACAACCGCGAAGGCGTTTTACTATGTACTTGCTTGGGCTAATAACTCGCGGTCCCCACTATCGGAGCGCCGACGACCCTGGACCACCGAATCATCTGCCACGGTGGACCACAACACACGAGCCGTCAGCTCGTGGTAGACTAGTCTACATCGAGCGCGCCAAGATATGAGACCTAGCGTGCCATGGCCCATCAATTGAATTTACTTCATCCGCCATAGTCATACTGGATCCTGAGGGCTATACTTCTAGAGGGCAATGTCGACTTGGTGTAGAGTGATAGATCGGTCACATTCTTGCTCCAGTTAGGGGAGCGCCGATTCGCATTTGCGGTGAACGAACAAAGTTTCTTAAGTTAGCTTGTTACGGTCAAGCAAACACTCGGTACCGTTGGGCTACTTGCGCCTTAGGACGTTCATTTTCACGTATGGTTTGAGAATGGCCTTGATCCCATGATTAAAATCCCTATCGTCGTGGTTTGAAGGTGCCTCGGGAAACTGCGAGCGAATTCCGCTACTTGTGGTCGACGCCCTGTCCGATGGACGTTTTAATCTCACGGCTAGGTAAAATTTAGTCTTCTGGCCTAGACGACGACCGTAGGTTGAAGCGGTGTGACCGAGCTCTCTAGAAACGAGGCAACGAACAAGCTTTTGACCAAGGATTATAACGGCCCTTGATGGTGGTATCGGTTTGGCTTAAAGGGGGTTGTTAGCACCACCCCTCGCTGTTTCCGTGTGTAAGCATGGCTCAAGGGTTATGTTGGTCGGGCTGCGGTGAGATGCAGCAAGATTTCACCCTGGTTCAATTAGATTGATTTTACGGCCATTCGAGGTCTCCCACAGATGCATGGTCGCTAAACGTGAAAGGTTGTATGTACTAAAAGCTGTTAGACAATGGAACCAAAGCAGGGTGCCGTTGTCGCACCATAGGAGGGCCGATTCGCCTAAGCCTGGCAGTACGATAATCCGAATCGGCGAGGCAGAGATGCGATCTTATAGCCCGTGGTCCGAGCCAACTCTGAGGCTCCGAATTGTTTAATCGTAGGAGGGTAGAGTTGAAGTATTCCGATGGCCTAGGGGATGCCATCCCGTGTGTGCGCGCATTGCGCCAAGTACTCGTAGCCACGACCGATGATACTGGGTGAATGAGTAAAAATGACTAGGACTCTTTGTGTATATCTCACTGCCATAGATTCCCAGACACCACATATCTGCAGGGTAGTACGCGTAGCTCTGAACTCGGATAGGAAACGTGGTGAGAAGATCCTTTCGTGTGGTGGACCAGGACCACTACGGGGTCTAGTTTTAAAATACCCTAGGCTTCCCACGTCTATGACGGATCAAGCTAACGGATTAAGTTCAGGTGTCCCCTATAGATGAGGGCTCTACCTAGCAACTCGGGTCCCTGCAGGCCCCATATGATTATGTCCCCCTGTATCTGGGCTCAAATGGCCCCGGCATGAAAAGTCCCTGCTGACTACGGAACCTACCCTCTAAGCAAACCTGCGCCATGCCTCAGACAACGTAAATGGTAGTAGTATCTTTGTGCGTCTGGAGAGGGAGTCATGAAGATCCCATTGTTAGGCGGGTTTTGGGGTGTACAAAAATTGACTCGAGCTTAGTCACCCTTATCAAAGATGGCCAGACATAACTCGTATCCTTAAACTCTTATCCTGCGGCCCAAACTGCGTGCACACCAAGCAATCCCATACGCACGATCCCAGAGTAGCTTTGGTTGAAGTGTTGCACAGGTCAGTTAGCGGACTATAGTGCACAGGCCGCCGCCGAAGTAATGAGTTATTTAAAATTCTTCATCGCTTAATTATCGCCGTGCCCCATCGATTCTTAGCTATTATCTAAGATAGGGCTTACTTACGGCAGACGGTTCACCCATAACCCGTTTCAGCACCAGGGCCAGCTAGAACTAACACTATTCAAGACCTAGTCTTTCCAACCAAACCGGTACCCAGGCGTGCTCTGTCTGCCAATAAAGTTGAGGCCGGCGATCTTGTAACCCAGATTCGCCCGTGCTTAATTGCCACTCAGTAGGTGAGACTGGGTTCAAATGGGCCTATCAAACGAGATGTGGTGCTTACCCAGCACGGATAGCCTTTTTAGGTACAGTGCAGGGTGGCCGCCTGCTTACCGATGTATGCTCATGAGGTGCAAGTGCGAAGCTTTCCAACAGTAGATAACGAGAGGGTTCTGACCTCAGTGGCCGCTATGACACACCTAGTCGTCAACTTTCTCTAGACAAGGAAAGGCCGTCTACATTCCTGCGGATCTCCATAAGCTCCAGTCTGAGTACTAGTTACCATCAGTCGCTTCCTGAGCCTCAAGCCACGATGGCACATATGGATCATAATGATTCGTTATGGAGCATTGAAAAGTGGGTGACTTACAGTCCTTAACGAATGATAACGCGATGGCCCTCCTGCGCAAGCCCACTCTAATCCCCATATAGTAATTGGGCCACGGTCGCTTAATCCAGAACCGCAAACAACAGCCAGTGGTGTTGGGGCCTCCCGCTTCCAATGTAAGGGCCTTTCATCTTGGAGTAAAATTTTGGAGAAATGTGTAGCGCCCGGTCAACCGCTGAGGACGATGGTGCTTAGGTCCACCGCTTACATAGAAATTGGGAAGGCAGTATGGCCGATTGTTTGACACATTTCCCATGTCCCTGCGCGCCCACTGTGAAGAAGATTCCGGCCGTCCTATGCGCAAGTATTGAAATAGGCATGCTTTAGCACCATTTTTATATATATTGTTAAACTAGTTCATCCAGGTCACCATGAACGCTACCTTCCAGTGCCAACATAATCACCCGGATAGGGCGCATGGCAAGGTTAAGAAAGTAGGCAAATATTAGGGTTGTGTAGTTGCAGTGACATCATTGACTAAGAACCGGGTGTTGCCAGGGTTCACTTGAACCGTAGCAGTGATCGCGATATCTGTGGAATCTGCGATACCCGCTTTGGGTCTGGTTGTACTAATCGCTTTTGTACGTAGTGTATTAAACGCCGAGGTACCACCCACGAGGTGCAAGGCTAAATTAACGGCAACTTTCTGGGCTGGGTTAGTAGATCCTTGCATGATGAACCATGACAGCGGCTCCGCACCCATAAAATTTTTCAAGTATGGTTTAGACGGAAGTTAGCATGAACCGTAAATAAATTCCTATATAGCTAGGACTGGGCCGAATGTGCTAGTCAAGGTGCTGCCGGGGTCAGAACCGCTTGGCTTTTGACCCCGCGTTCTAACCCCCCGCCTTCTGACAAACTAGTATTTGGAGACGCCATCCAGTACGTGAAATGCTCAGGTGAGAACTTTAACTTTCCGCCGTTTGGGAAGCCCGGTCACCTCCTCTTATTAAACCGCACATAAGATCGCGAATACTCCATTAGGGGGGTAGCCACCCGCAGTTCCGCTGAAGCGCATTTACGAGGATTTGGCAGTTTCTCTGTTCAGCAGGCGGATACTAAAAGCGCAAACTTCGCGCGATGATGCGTAAGTGTTAGGGCAGGGGGAGGAAATAAGATTGGAGGTACCAGCTGTATATAACAAATGTGAGAAACTATTGGTTCGTGCAAGCACCTCCAGGTGAGTCCCGTCAGCAGACAGCCATAATTACGTTACAGTCGGTAGGGCCTTCATTGTTTAGCGTAGCTACTGAAGGCCTCCGGCCCGCTCACATTCAGCCTGTGACTTACACCGTAACCAGGCACTACATATATACCTGGAGAACCATCCGCGATCCCCACATAACTTCGTATGATCGTCCACTCCAGTTGAGTTATTGGGTGTGAGCTACCCCATTTTACTGGTGCATGCAATATAGAGATTAGTATTCATTAACCGAGCATTTGATAATATCATCTCATCAGTATGCAACGGTAAGATATTCACTTCCCTGGCCCGAACGTCCTACTAGTCATAAGAACTAAAAGGCGCCTGTTTATATGTCTAAATACTGTGAAGCAACTCGTTTTATCAGCCTCCGAATGGACATCACGAGCGCAATAGCGCCTCCAGTTCGTTAGTACGAGCGATCAGGCCTCGAATGAAGCGGATCAATCCGGTCTTATCTTTCGTGCTAGATTGTCGCGGATAGAGCGCCCCTCACGACGGCAACCGTTGTAGGGCGCTACAGGACGGCTTCTGGTACTCCTTCCGTCAAAAATATTGATCATCCGACGGCCCCAGAGGGTTCCACCTAGCAAATTTAATTGGACGCAGGGATGCGACTGTACGGCTGGGTCATGTTAGGCCACTTGCAACGATAGCTTGCAGGAACCCGAATCTACCTACGTTCCTCTGACTTTTGACATTCGTCGAAGGAGGTGAACACCCCAACCATTCTGGTCTTACTCAACGGGATCCGACCATCTTCAAAATCAGTGGAATGCAAAGCAAACCGAGCTTGAGTTTGTCCTAGTTTGCTGTAAAGTTGTGTTTCGGCCAACTGAAATCGCAGCCAGTACTGCGCCAAGACAAGCAACCCTCCAATAAAGGGGGATAGCTCATGCGTTAATACCCCTCGCCCCCGTATGACGCATCGGTCTAATTCATAATAACCGGATAGGCAGAGTATCTGCCCTGCCGTTGAATATCACGACCACGTCTTCTGTCGATGTGGACACTAGTCAGCTTGTCGCGACCTAGACTCCTAGCCCGCTGGCGCGCGGCCTTCGTAGCGTTAGGCGAAGCACTGAAAAAGAAAATATTCTTATGCCACTACATAACGGTCATCCGACCCACAGACGTGCCAGAAAAGATTTTCGTCGACAGCTCACTTACATGGCCCCATACCAAAGTCCTCAATATTAGATACGACGCGCGATGAACCCCGATACAACAACCGTTCTGACGCTGCCACTGGGGTCTCGGACACTTATGGATCACAACACCTCGGTGGCCCAGGGAGCATCACCCTCCGCGAAAGCTCACCCTCACATCCTACGGATGAAGCGATACGCGGACTCGCCGCACGGTCGCGGCAACAGTGGTGCCGGGAGACAAGTACTTTGGTGCGGGTCGGGCGACGGGAACTTTGACTTGTTTCGGGACGATTGCTGTTTCGACCATCCTGGTACCTGGGGACGTATATTGGGGCGCCGAAGAGAACAGCGGAGAGGAACGATAGCGAGGGTAGTCTAAGTTTACGGGTGATGTGGACACTCACACGGTAGACATAATTCGTGATTGGGGCAGTCGATTATGGCTCACCTGAAATCTAAGCGACCGTCCGAACGTACTGAGATTAGCTCTGTGCCGCCCAGGACGCAGCTGTCAACTCCAGTCACGTGATTACGCATGACCCAGTTCTTTTCGTAGTAAAGCCCAATAGGGCGCATGCTCGGCCTACCTCGTCAATACCCGCCTTACAGGTTTCAGCAGTCCTTCCCAGAGTAGAATCTCCGTTAATCGAAACTTAGAGTGCGTTCTGAAGTCGATACCGACCCATTGAAAATGGCTCCTATAGGAGATTTAGTGGTGAAGGATGAAGCAACGTCGTCTCTGGTTATTCATAGTTAACCAAGCAAACTTAGGCCGAACTGAAGGGTGTACGAGTTTCTATGCCTCTAATAAATGAACATGTGGTGGTATTGTATCCACCTATCATTGAGGGTCTGGTAGGGCAGACCCACAGCGTCTGTCTTAGGTGTTTTAATACATTGATGAATCAATGAATGAGTTGGGAGAAACCAGTCCCTACTTACTGATGTCTAGCTGTAATATATAATAGTATCGCCTGGCCTGTACTAGCGAGGCGCCGTACCGAACGTGACTCAAGATACTCACCCGCAGTTAGCGGGACTTACCCAGCCCTCTTTTGCCCCCAGAAAAATAGCTAATTTTGTAACTCTTTCCTATCTGGGTATTCACCTTATAGCTAATCGGGAAGTCCTATCAGTAGGGGACTCAGAGTCCTACATCTCAACACCTGATTCAGTACTACTGACCTAGACCACTTGAGACGAGGCTTGGTTCTTTGTAAGGATTAAACTAGTCGCACAGCGACGTTC", reverse.ToString());
        }
    }
}
