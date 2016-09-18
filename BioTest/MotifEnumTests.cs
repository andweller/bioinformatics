using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Bioinformatics;
using Bioinformatics.Algorithms;

namespace BioTest
{
    [TestClass]
    public class MotifEnumTests
    {
        [TestMethod]
        public void MotifEnumBruteTests_Simple()
        {
            List<DnaStrand> strands = new List<DnaStrand>();
            strands.Add(new DnaStrand("ATTTGGC"));
            strands.Add(new DnaStrand("TGCCTTA"));
            strands.Add(new DnaStrand("CGGTATC"));
            strands.Add(new DnaStrand("GAAAATT"));

            var patterns = Motif.BruteEnumeration(strands, 3, 1);

            Assert.AreEqual(4, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.Dna == "ATA"));
            Assert.IsTrue(patterns.Any(x => x.Dna == "ATT"));
            Assert.IsTrue(patterns.Any(x => x.Dna == "GTT"));
            Assert.IsTrue(patterns.Any(x => x.Dna == "TTT"));
        }


        [TestMethod]
        public void MotifEnumBruteTests_Test1()
        {
            List<DnaStrand> strands = new List<DnaStrand>();
            strands.Add(new DnaStrand("ACGT"));
            strands.Add(new DnaStrand("ACGT"));
            strands.Add(new DnaStrand("ACGT"));
            strands.Add(new DnaStrand("ACGT"));

            var patterns = Motif.BruteEnumeration(strands, 3, 0);

            Assert.AreEqual(2, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.Dna == "ACG"));
            Assert.IsTrue(patterns.Any(x => x.Dna == "CGT"));
        }



        [TestMethod]
        public void MotifEnumBruteTests_Test2()
        {
            List<DnaStrand> strands = new List<DnaStrand>();
            strands.Add(new DnaStrand("AAAAA"));
            strands.Add(new DnaStrand("AAAAA"));
            strands.Add(new DnaStrand("AAAAA"));

            var patterns = Motif.BruteEnumeration(strands, 3, 1);

            Assert.AreEqual(10, patterns.Count());
            Assert.IsTrue(patterns.Any(x => x.Dna == "AAA"));
            Assert.IsTrue(patterns.Any(x => x.Dna == "AAC"));
            Assert.IsTrue(patterns.Any(x => x.Dna == "AAG"));
            Assert.IsTrue(patterns.Any(x => x.Dna == "AAT"));
            Assert.IsTrue(patterns.Any(x => x.Dna == "ACA"));
            Assert.IsTrue(patterns.Any(x => x.Dna == "AGA"));
            Assert.IsTrue(patterns.Any(x => x.Dna == "ATA"));
            Assert.IsTrue(patterns.Any(x => x.Dna == "CAA"));
            Assert.IsTrue(patterns.Any(x => x.Dna == "GAA"));
            Assert.IsTrue(patterns.Any(x => x.Dna == "TAA"));
        }



        [TestMethod]
        public void MotifEnumBruteTests_Test4()
        {
            List<DnaStrand> strands = new List<DnaStrand>();
            strands.Add(new DnaStrand("AAAAA"));
            strands.Add(new DnaStrand("AAAAA"));
            strands.Add(new DnaStrand("AAAAA"));

            var patterns = Motif.BruteEnumeration(strands, 3, 3);

            Assert.AreEqual(64, patterns.Count());
        }



        [TestMethod]
        public void MotifEnumBruteTests_Test5()
        {
            List<DnaStrand> strands = new List<DnaStrand>();
            strands.Add(new DnaStrand("AAAAA"));
            strands.Add(new DnaStrand("AAAAA"));
            strands.Add(new DnaStrand("AACAA"));

            var patterns = Motif.BruteEnumeration(strands, 3, 0);

            Assert.AreEqual(0, patterns.Count());
        }



        [TestMethod]
        public void MotifEnumBruteTests_Test6()
        {
            List<DnaStrand> strands = new List<DnaStrand>();
            strands.Add(new DnaStrand("AACAA"));
            strands.Add(new DnaStrand("AAAAA"));
            strands.Add(new DnaStrand("AAAAA"));

            var patterns = Motif.BruteEnumeration(strands, 3, 0);

            Assert.AreEqual(0, patterns.Count());
        }



        [TestMethod]
        public void MotifEnumBruteTests_Test7()
        {
            List<DnaStrand> strands = new List<DnaStrand>();
            strands.Add(new DnaStrand("TCTGAGCTTGCGTTATTTTTAGACC"));
            strands.Add(new DnaStrand("GTTTGACGGGAACCCGACGCCTATA"));
            strands.Add(new DnaStrand("TTTTAGATTTCCTCAGTCCACTATA"));
            strands.Add(new DnaStrand("CTTACAATTTCGTTATTTATCTAAT"));
            strands.Add(new DnaStrand("CAGTAGGAATAGCCACTTTGTTGTA"));
            strands.Add(new DnaStrand("AAATCCATTAAGGAAAGACGACCGT"));

            var patterns = Motif.BruteEnumeration(strands, 5, 2);

            string visual = "";
            foreach (DnaStrand d in patterns)
            {
                visual += d.Dna;
                visual += " ";
            }
            Assert.AreEqual(visual.Trim(), "AAACT AAATC AACAC AACAT AACCT AACTA AACTC AACTG AACTT AAGAA AAGCT AAGGT AAGTC AATAC AATAT AATCC AATCT AATGC AATTC AATTG ACAAC ACACA ACACC ACACG ACACT ACAGA ACAGC ACATC ACATG ACCAT ACCCT ACCGT ACCTA ACCTC ACCTG ACCTT ACGAC ACGAG ACGAT ACGCT ACGGT ACGTC ACGTT ACTAA ACTAG ACTAT ACTCA ACTCC ACTCG ACTCT ACTGA ACTGC ACTGT ACTTA ACTTC ACTTT AGAAA AGAAC AGAAG AGAAT AGACA AGACT AGATA AGATC AGCAT AGCCA AGCGT AGCTA AGCTC AGCTG AGCTT AGGAT AGGTA AGGTC AGTAA AGTAC AGTAT AGTCC AGTCG AGTCT AGTGA AGTTG ATAAA ATAAC ATACA ATACC ATAGA ATATA ATATC ATATG ATATT ATCAG ATCCC ATCCG ATCCT ATCGA ATCGC ATCTA ATCTC ATCTG ATGAC ATGAT ATGCA ATGCC ATGGA ATGGC ATGTA ATGTC ATTAA ATTAC ATTAG ATTAT ATTCA ATTCC ATTCG ATTGA ATTGC ATTGG ATTGT ATTTA ATTTC ATTTG ATTTT CAAAG CAACC CAACT CAAGA CAAGC CAATA CAATT CACAC CACAG CACCT CACGT CACTA CACTT CAGAA CAGAC CAGAT CAGGT CAGTA CAGTC CATAA CATAC CATAG CATAT CATCC CATCT CATGA CATGT CATTA CATTG CATTT CCAAG CCATA CCATG CCATT CCCGT CCCTA CCCTT CCGAA CCGAC CCGAT CCGCT CCGGT CCGTA CCGTC CCGTG CCGTT CCTAC CCTAT CCTCA CCTCC CCTTA CCTTC CCTTG CCTTT CGAAA CGAAG CGACA CGACT CGAGT CGATA CGATG CGATT CGCAA CGCAT CGCCA CGCGA CGCTA CGCTC CGCTT CGGAC CGGAT CGGCA CGGTA CGGTC CGGTT CGTAA CGTAC CGTCA CGTCG CGTCT CGTTA CGTTT CTAAC CTAAG CTAAT CTACA CTACC CTACG CTACT CTAGA CTAGC CTAGG CTAGT CTATA CTATC CTATG CTATT CTCAT CTCCG CTCGT CTCTA CTCTT CTGAA CTGAG CTGCA CTGCC CTGTA CTGTT CTTAA CTTAC CTTAG CTTAT CTTCA CTTGA CTTTA CTTTC CTTTG CTTTT GAAAT GAACA GAACT GAAGT GAATG GAATT GACAC GACAT GACCA GACCT GACGT GACTT GAGAA GAGAT GAGCT GATAA GATAC GATAG GATAT GATCA GATCC GATCG GATCT GATGT GATTA GATTC GATTG GATTT GCAAT GCACT GCATC GCATT GCCAT GCCGT GCCTA GCCTT GCGAT GCGGT GCGTC GCGTT GCTAA GCTAC GCTAG GCTAT GCTGA GCTGT GCTTA GCTTT GGAAT GGACA GGATA GGATC GGATT GGCTA GGGAT GGTAC GGTAG GGTAT GGTCA GGTCG GGTTA GTAAA GTAAG GTACA GTACC GTACG GTAGA GTATA GTATC GTATG GTATT GTCAA GTCAG GTCCG GTCCT GTCGA GTCGC GTCGT GTCTA GTCTG GTGAA GTGAG GTGCA GTGCG GTTAA GTTAC GTTAG GTTAT GTTCA GTTCC GTTCG GTTGA GTTTA TAAAC TAAAG TAACA TAACC TAACT TAAGA TAAGC TAATA TAATC TACAC TACAG TACCC TACCG TACCT TACGA TACGC TACGT TACTA TACTC TACTG TAGAA TAGAC TAGAG TAGAT TAGCC TAGCG TAGGA TAGTC TATAA TATAC TATAT TATCA TATCC TATCG TATGA TATGC TATGG TATGT TATTA TATTG TCAAC TCAAT TCACC TCACG TCACT TCAGA TCATA TCATG TCCAA TCCAC TCCAG TCCAT TCCCA TCCCT TCCGA TCCGC TCCGT TCCTA TCCTG TCCTT TCGAA TCGAC TCGAT TCGCC TCGCT TCGGA TCGGC TCGGG TCGGT TCGTC TCTAC TCTAG TCTAT TCTCC TCTCT TCTGG TCTGT TCTTA TCTTT TGAAA TGAAC TGAAT TGACA TGACC TGACT TGAGA TGAGC TGAGT TGATA TGATC TGATG TGATT TGCAA TGCAC TGCAG TGCAT TGCCA TGCCG TGCCT TGCGA TGCGT TGCTT TGGAA TGGAT TGGTA TGTAA TGTAG TGTAT TGTCC TGTCG TGTGG TGTTA TTAAA TTAAC TTAAG TTAAT TTACA TTACC TTACG TTACT TTAGA TTAGC TTAGG TTAGT TTATA TTATC TTATG TTATT TTCAA TTCAC TTCAT TTCCA TTCCC TTCCT TTCGA TTCGG TTCGT TTCTA TTCTG TTGAA TTGAC TTGAG TTGAT TTGCA TTGCG TTGGA TTGGG TTGTG TTTAA TTTAC TTTAG TTTAT TTTCA TTTCC TTTCG TTTGA TTTGG TTTTA TTTTG");

        }



        [TestMethod]
        public void MotifEnumBruteTests_Test8()
        {
            List<DnaStrand> strands = new List<DnaStrand>();
            strands.Add(new DnaStrand("GCACCACATTACGGTGATCGTTTTA"));
            strands.Add(new DnaStrand("TCCAGCGCGATCGGTTAACGGTCCC"));
            strands.Add(new DnaStrand("GGGTACCGGTGTTTGTTAGACTGCC"));
            strands.Add(new DnaStrand("TGTACCCGGTAACCAGGGGGGAAAA"));
            strands.Add(new DnaStrand("ACGGTGGGACGGGAATCCGATACGA"));
            strands.Add(new DnaStrand("ACGGTATGCAGGGTCCACAGAGATA"));

            var patterns = Motif.BruteEnumeration(strands, 5, 1);

            string visual = "";
            foreach (DnaStrand d in patterns)
            {
                visual += d.Dna;
                visual += " ";
            }
            Assert.AreEqual(visual.Trim(), "ACGGG ACGGT CAGTG CCGGT CGGTA CGGTC CGGTG CGGTT CGTTA GCGGT GGACC GGTAA TCGGT");

        }
    }
}
