using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bioinformatics;

namespace BioTest
{
    [TestClass]
    public class NucleotideDnaTests
    {
        [TestMethod]
        public void NucleotideDna_BaseCase()
        {
            NucleotideDna d = new NucleotideDna("");   
        }


        [TestMethod]
        public void NucleotideDna_ValidInput1()
        {
            NucleotideDna d = new NucleotideDna("A");
        }


        [TestMethod]
        public void NucleotideDna_ValidInput2()
        {
            NucleotideDna d = new NucleotideDna("TA");
        }


        [TestMethod]
        public void NucleotideDna_ValidInput3()
        {
            NucleotideDna d = new NucleotideDna("GACCATACTG");
        }


        [TestMethod]
        public void NucleotideDna_ValidInput4()
        {
            NucleotideDna d = new NucleotideDna("GACCA TACTG");
        }


        [TestMethod]
        public void NucleotideDna_ValidInput5()
        {
            NucleotideDna d = new NucleotideDna(" GACCATACTG ");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NucleotideDna_InvalidInput1()
        {
            NucleotideDna d = new NucleotideDna("Ea");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NucleotideDna_InvalidInput2()
        {
            NucleotideDna d = new NucleotideDna("invalid");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NucleotideDna_InvalidInput3()
        {
            NucleotideDna d = new NucleotideDna("ATGC1");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NucleotideDna_InvalidInput4()
        {
            NucleotideDna d = new NucleotideDna("ATGGTACECT");
        }

    }
}
