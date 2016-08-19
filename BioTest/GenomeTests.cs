using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bioinformatics;

namespace BioTest
{
    [TestClass]
    public class GenomeTests
    {
        [TestMethod]
        public void Genome_Creation1()
        {
            DnaStrand d = new DnaStrand("GACCATACTG");
            Genome g = new Genome(d);
            Assert.AreEqual<string>("GACCATACTG", g.ToString());
        }


        [TestMethod]
        public void Genome_Creation2()
        {
            Genome g = new Genome("GACCATACTG");
            Assert.AreEqual<string>("GACCATACTG", g.ToString());
        }
    }
}
