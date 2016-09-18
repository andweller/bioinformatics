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
    }
}
