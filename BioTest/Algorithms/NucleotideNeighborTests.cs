using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bioinformatics;
using Bioinformatics.Algorithms;

namespace BioTest.Algorithms
{
    [TestClass]
    public class NucleotideNeighborTests
    {
        [TestMethod]
        public void ImmediateNeighborsTest_Simple()
        {
            DnaStrand strand = new DnaStrand("ATG");
            var neighbors = NucleotideNeighbors.ImmediateNeighbors(strand);

            Assert.AreEqual<int>(9, neighbors.Count());
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "TTG"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "GTG"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "CTG"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "AAG"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "AGG"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "ACG"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "ATA"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "ATT"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "ATC"));
        }



        [TestMethod]
        public void NeighborsTest_Simple()
        {
            DnaStrand strand = new DnaStrand("ATG");
            var neighbors = NucleotideNeighbors.Neighbors(strand, 1);

            Assert.AreEqual<int>(10, neighbors.Count());
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "ATG"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "TTG"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "GTG"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "CTG"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "AAG"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "AGG"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "ACG"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "ATA"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "ATT"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "ATC"));
        }



        [TestMethod]
        public void NeighborhoodTest_Simple()
        {
            DnaStrand strand = new DnaStrand("ATG");
            var neighbors = NucleotideNeighbors.Neighborhood(strand, 3, 1);

            Assert.AreEqual<int>(10, neighbors.Count());
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "ATG"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "TTG"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "GTG"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "CTG"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "AAG"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "AGG"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "ACG"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "ATA"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "ATT"));
            Assert.IsTrue(neighbors.Any(x => x.ToString() == "ATC"));
        }
    }
}
