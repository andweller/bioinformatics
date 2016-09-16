using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bioinformatics;
using System.Linq;

namespace BioTest
{
    [TestClass]
    public class CytosineGuanineSkewMaxTests
    {
        [TestMethod]
        public void CytoGuanSkewMax_Simple()
        {
            DnaStrand strand = new DnaStrand("TAAAGACTGCCGAGAGGCCAACACGAGTGCTAGAACGAGGGGCGTAAACGCGGGTCCGAT");
            var minLocations = strand.CytosineGuanineSkewMaximumIndicies();

            Assert.AreEqual<int>(2, minLocations.Count());
            Assert.IsTrue(minLocations.Contains(10));
            Assert.IsTrue(minLocations.Contains(23));
        }


        [TestMethod]
        public void CytoGuanSkewMax_Test1()
        {
            DnaStrand strand = new DnaStrand("ACCG");
            var minLocations = strand.CytosineGuanineSkewMaximumIndicies();

            Assert.AreEqual<int>(1, minLocations.Count());
            Assert.IsTrue(minLocations.Contains(2));
        }


        [TestMethod]
        public void CytoGuanSkewMax_Test2()
        {
            DnaStrand strand = new DnaStrand("ACCC");
            var minLocations = strand.CytosineGuanineSkewMaximumIndicies();

            Assert.AreEqual<int>(1, minLocations.Count());
            Assert.IsTrue(minLocations.Contains(3));
        }



        [TestMethod]
        public void CytoGuanSkewMax_Test3()
        {
            DnaStrand strand = new DnaStrand("CCGGGT");
            var minLocations = strand.CytosineGuanineSkewMaximumIndicies();

            Assert.AreEqual<int>(1, minLocations.Count());
            Assert.IsTrue(minLocations.Contains(1));
        }



        [TestMethod]
        public void CytoGuanSkewMax_Test4()
        {
            DnaStrand strand = new DnaStrand("CCGGCCGG");
            var minLocations = strand.CytosineGuanineSkewMaximumIndicies();

            Assert.AreEqual<int>(2, minLocations.Count());
            Assert.IsTrue(minLocations.Contains(1));
            Assert.IsTrue(minLocations.Contains(5));
        }



        [TestMethod]
        public void CytoGuanSkewMax_Test5()
        {
            DnaStrand strand = Load.LoadStrand("datasets//cytoguanMaxSkew_dataset.txt");
            var minLocations = strand.CytosineGuanineSkewMaximumIndicies();

            Assert.AreEqual<int>(5, minLocations.Count());
            Assert.IsTrue(minLocations.Contains(89968));
            Assert.IsTrue(minLocations.Contains(89969));
            Assert.IsTrue(minLocations.Contains(89970));
            Assert.IsTrue(minLocations.Contains(90344));
            Assert.IsTrue(minLocations.Contains(90345));
        }



        [TestMethod]
        public void CytoGuanSkewMax_Test6()
        {
            DnaStrand strand = Load.LoadStrand("datasets//cytoguanMaxSkew_dataset2.txt");
            var minLocations = strand.CytosineGuanineSkewMaximumIndicies();

            Assert.AreEqual<int>(1, minLocations.Count());
            Assert.IsTrue(minLocations.Contains(10738));
        }



        [TestMethod]
        public void CytoGuanSkewMax_E_Coli()
        {
            DnaStrand strand = Load.LoadStrand("genomes//E_coli.txt");
            var minLocations = strand.CytosineGuanineSkewMaximumIndicies();

            Assert.AreEqual<int>(4, minLocations.Count());
            Assert.IsTrue(minLocations.Contains(3923619));
            Assert.IsTrue(minLocations.Contains(3923620));
            Assert.IsTrue(minLocations.Contains(3923621));
            Assert.IsTrue(minLocations.Contains(3923622));

        }
    }
}
