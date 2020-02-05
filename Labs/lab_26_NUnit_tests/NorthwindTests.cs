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


    }
}
