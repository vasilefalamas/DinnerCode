using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimeFactorsGeneration.Tests
{
    [TestClass]
    public class PrimeFactorTests
    {

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void PrimeFactorsGenerate_WhenInputIsNegative_ThrowsArgumentException()
        {
            PrimeFactors.Generate(-10);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void PrimeFactorsGenerate_WhenInputIsZero_ThrowsArgumentException()
        {
            PrimeFactors.Generate(0);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void PrimeFactorsGenerate_WhenInputIs1_ThrowsArgumentException()
        {
            PrimeFactors.Generate(1);
        }

        [TestMethod]
        public void PrimeFactorsGenerate_WhenInputIsPositive_ReturnsPrimeFactorsList()
        {
            CollectionAssert.AreEqual(new List<int> { 3, 59 }, PrimeFactors.Generate(177));
        }

    }
}
