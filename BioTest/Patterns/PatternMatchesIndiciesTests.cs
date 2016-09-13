using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bioinformatics;
using System.Linq;

namespace BioTest
{
    [TestClass]
    public class PatternMatchesIndiciesTests
    {
        [TestMethod]
        public void PatternMatchesIndicies_Simple()
        {
            NucleotideDna strand = new NucleotideDna("GATATATGCATATACTT");
            var matches = strand.PatternMatchesIndicies(new NucleotideDna("ATAT"));

            Assert.AreEqual(3, matches.Count());
            Assert.IsTrue(matches.Contains(1));
            Assert.IsTrue(matches.Contains(3));
            Assert.IsTrue(matches.Contains(9));
        }


        [TestMethod]
        public void PatternMatchesIndicies_Test1()
        {
            NucleotideDna strand = new NucleotideDna("TTTTACACTTTTTTGTGTAAAAA");
            var matches = strand.PatternMatchesIndicies(new NucleotideDna("ACAC"));

            Assert.AreEqual(1, matches.Count());
            Assert.IsTrue(matches.Contains(4));
        }


        [TestMethod]
        public void PatternMatchesIndicies_Test2()
        {
            NucleotideDna strand = new NucleotideDna("AAAGAGTGTCTGATAGCAGCTTCTGAACTGGTTACCTGCCGTGAGTAAATTAAATTTTATTGACTTAGGTCACTAAATACTTTAACCAATATAGGCATAGCGCACAGACAGATAATAATTACAGAGTACACAACATCCAT");
            var matches = strand.PatternMatchesIndicies(new NucleotideDna("AAA"));

            Assert.AreEqual(4, matches.Count());
            Assert.IsTrue(matches.Contains(0));
            Assert.IsTrue(matches.Contains(46));
            Assert.IsTrue(matches.Contains(51));
            Assert.IsTrue(matches.Contains(74));
        }


        [TestMethod]
        public void PatternMatchesIndicies_Test3()
        {
            NucleotideDna strand = new NucleotideDna("AGCGTGCCGAAATATGCCGCCAGACCTGCTGCGGTGGCCTCGCCGACTTCACGGATGCCAAGTGCATAGAGGAAGCGAGCAAAGGTGGTTTCTTTCGCTTTATCCAGCGCGTTAACCACGTTCTGTGCCGACTTT");
            var matches = strand.PatternMatchesIndicies(new NucleotideDna("TTT"));

            Assert.AreEqual(4, matches.Count());
            Assert.IsTrue(matches.Contains(88));
            Assert.IsTrue(matches.Contains(92));
            Assert.IsTrue(matches.Contains(98));
            Assert.IsTrue(matches.Contains(132));
        }


        [TestMethod]
        public void PatternMatchesIndicies_Test4()
        {
            NucleotideDna strand = new NucleotideDna("ATATATA");
            var matches = strand.PatternMatchesIndicies(new NucleotideDna("ATA"));

            Assert.AreEqual(3, matches.Count());
            Assert.IsTrue(matches.Contains(0));
            Assert.IsTrue(matches.Contains(2));
            Assert.IsTrue(matches.Contains(4));
        }


        [TestMethod]
        public void PatternMatchesIndicies_Test5()
        {
            NucleotideDna strand = Load.LoadStrand("datasets//patternMatchesIndicies_dataset.txt");
            var matches = strand.PatternMatchesIndicies(new NucleotideDna("CCCAAATCC"));

            string visual = "";
            foreach (int i in matches)
            {
                visual += i.ToString();
                visual += " ";
            }
            Assert.AreEqual(visual.Trim(), "23 30 72 79 86 102 109 134 206 254 261 278 293 337 357 517 524 557 576 621 651 664 671 696 712 727 734 750 757 777 814 822 948 964 1098 1114 1121 1128 1147 1180 1187 1234 1249 1294 1340 1347 1378 1385 1404 1411 1498 1516 1550 1557 1667 1700 1716 1747 1754 1769 1796 1805 1812 1898 1921 1928 1935 1942 1998 2047 2054 2061 2083 2140 2147 2188 2226 2281 2296 2313 2337 2394 2401 2424 2499 2593 2600 2669 2747 2772 2779 2817 2853 2882 2890 2964 3005 3012 3019 3073 3080 3087 3094 3110 3117 3124 3131 3138 3145 3165 3173 3210 3265 3300 3385 3393 3421 3428 3435 3442 3449 3456 3472 3581 3613 3629 3637 3645 3653 3660 3686 3693 3701 3739 3776 3783 3811 3821 3883 3890 3974 3990 4006 4063 4080 4143 4152 4168 4176 4217 4225 4240 4248 4282 4305 4322 4381 4414 4443 4478 4534 4541 4548 4555 4575 4611 4637 4681 4701 4731 4786 4817 4875 4908 4926 4942 4979 4994 5001 5026 5128 5252 5301 5397 5405 5442 5479 5486 5493 5524 5578 5630 5661 5673 5723 5809 5816 5832 5904 5931 5938 6007 6014 6052 6120 6241 6248 6263 6288 6303 6320 6382 6392 6454 6482 6489 6552 6584 6621 6647 6685 6722 6750 6788 6795 6815 6858 6865 6902 6949 6956 6963 6970 7048 7127 7134 7141 7185 7192 7199 7224 7263 7288 7295 7313 7320 7395 7421 7428 7447 7523 7531 7559 7594 7601 7630 7637 7645 7652 7670 7677 7713 7720 7728 7755 7762 7769 7793 7873 7880 7897 7914 7952 7959 7979 8019 8035 8043 8067 8084");
        }


        [TestMethod]
        public void PatternMatchesIndicies_Vibrio_Cholerae()
        {
            NucleotideDna strand = Load.LoadStrand("genomes//Vibrio_cholerae.txt");
            var matches = strand.PatternMatchesIndicies(new NucleotideDna("CTTGATCAT"));

            string visual = "";
            foreach (int i in matches)
            {
                visual += i.ToString();
                visual += " ";
            }
            Assert.AreEqual(visual.Trim(), "60039 98409 129189 152283 152354 152411 163207 197028 200160 357976 376771 392723 532935 600085 622755 1065555");
        }
    }
}
