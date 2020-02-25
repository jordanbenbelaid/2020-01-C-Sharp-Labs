using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using lab_37_northwind_core;

namespace lab_26_NUnit_tests
{
    class NorthwindTests
    {
        [SetUp]

        public void SetUp()
        {

        }

        [Test]
        public void NorthwindDummyTest()
        {
            var instance = new DatabaseTests();

            var actual = instance.Tests();

            Assert.AreEqual(actual, 91);
        }
        //Tests go here


        //Morning test to check product length
        [Test]
        public void NorthwindLengthTest()
        {
            var instance = new DatabaseTests();

            var actual = instance.ProductTest();

            Assert.AreEqual(actual, 77);
        }

        [Test]
        public void NorthwindAddingTest()
        {
            var instance = new DatabaseTests();

            var actual = instance.Tests2();

            Assert.AreEqual(actual, 92);
        }

        [Test]
        public void NorthwindRemovingTest()
        {
            var instance = new DatabaseTests();

            var actual = instance.Tests3();

            Assert.AreEqual(actual, 91);
        }
    }
}
