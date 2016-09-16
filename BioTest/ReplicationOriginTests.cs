using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bioinformatics;
using Bioinformatics.Algorithms;

namespace BioTest
{
    [TestClass]
    public class ReplicationOriginTests
    {
        [TestMethod]
        public void ReplicationOrigin_E_Coli()
        {
            DnaStrand strand = Load.LoadStrand("genomes//E_coli.txt");
            var patterns = strand.ReplicationOriginPossibilities(500, 9, 1).ToList();

            Assert.IsTrue(patterns.Any(x => x.Dna == "TTATCCACA"));
        }


        [TestMethod]
        public void ReplicationOrigin_Salmonella_enterica()
        {
            DnaStrand strand = Load.LoadStrand("genomes//Salmonella_enterica.txt");
            var patterns = strand.ReplicationOriginPossibilities(500, 9, 1).ToList();

            Assert.IsTrue(patterns.Any(x => x.Dna == "CCAGGATCC"));
            Assert.IsTrue(patterns.Any(x => x.Dna == "CCCGGATCC"));
            Assert.IsTrue(patterns.Any(x => x.Dna == "CCGGATCCG"));
            Assert.IsTrue(patterns.Any(x => x.Dna == "CGGATCCGG"));
            Assert.IsTrue(patterns.Any(x => x.Dna == "GGATCCGGG"));
            Assert.IsTrue(patterns.Any(x => x.Dna == "GGATCCTGG"));
        }
    }
}
