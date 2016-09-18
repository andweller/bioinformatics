using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bioinformatics;

namespace BioTest
{
    [TestClass]
    public class DnaStrandTests
    {
        [TestMethod]
        public void DnaStrand_BaseCase()
        {
            DnaStrand d = new DnaStrand("");   
        }


        [TestMethod]
        public void DnaStrand_ValidInput1()
        {
            DnaStrand d = new DnaStrand("A");
        }


        [TestMethod]
        public void DnaStrand_ValidInput2()
        {
            DnaStrand d = new DnaStrand("TA");
        }


        [TestMethod]
        public void DnaStrand_ValidInput3()
        {
            DnaStrand d = new DnaStrand("GACCATACTG");
        }


        [TestMethod]
        public void DnaStrand_ValidInput4()
        {
            DnaStrand d = new DnaStrand("GACCA TACTG");
        }


        [TestMethod]
        public void DnaStrand_ValidInput5()
        {
            DnaStrand d = new DnaStrand(" GACCATACTG ");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DnaStrand_InvalidInput1()
        {
            DnaStrand d = new DnaStrand("Ea");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DnaStrand_InvalidInput2()
        {
            DnaStrand d = new DnaStrand("invalid");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DnaStrand_InvalidInput3()
        {
            DnaStrand d = new DnaStrand("ATGC1");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DnaStrand_InvalidInput4()
        {
            DnaStrand d = new DnaStrand("ATGGTACECT");
        }


        [TestMethod]
        public void DnaStrand_Contains1()
        {
            DnaStrand d = new DnaStrand("GACCA");

            Assert.IsTrue(d.Contains(new DnaStrand("AC")));
        }


        [TestMethod]
        public void DnaStrand_Contains2()
        {
            DnaStrand d = new DnaStrand("GACCA");

            Assert.IsFalse(d.Contains(new DnaStrand("CCC")));
        }


        [TestMethod]
        public void DnaStrand_Contains3()
        {
            DnaStrand d = new DnaStrand("GACCA");

            Assert.IsTrue(d.Contains(new DnaStrand("CCC"), 1));
        }

    }
}
