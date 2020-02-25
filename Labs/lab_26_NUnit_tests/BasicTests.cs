using System;
using NUnit;
using NUnit.Framework;
using lab_27_test_addition;
using lab_28_code_to_pass_tests;

namespace lab_26_NUnit_tests
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        create code for live demo
    //    }
    //}

    class NUnit_Tests
    {
        //CREATE UNIFORM TESTING ENVIRONMENT - PERHAPS LOAD STARTUP INFO FROM RABBIT
        [SetUp]

        public void Setup()
        {

        }

        [TestCase(1, 2, 3)]
        [TestCase(3, 6, 9)]
        [TestCase(5, 7, 12)]
        [TestCase(2, 2, 4)]
        [TestCase(1000, 2000, 3000)]
        public void TestAdditionDemo(int a, int b, int expected)
        {
            //Arrange - setup test ready to run (possibly create instances of test classes)
            var instance = new Addition();

            //Act - run the code to get an actual value
            var actual = instance.AddTwoNumbers(a, b);

            //Assert - assert.AreEqual(actual,expected);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(2, 2, 2)]
        [TestCase(3, 3, 9)]
        public void Sum2DArrayTest(int numrows, int numcolumns, int expected)
        {
            var instance = new Basic_Tests();

            var actual = instance.Test_100_Sum_2D_Array(numrows, numcolumns);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 3, 3, 27)]
        [TestCase(4, 4, 4, 96)]
        public void Sum3DArrayTest(int x, int y, int z, int expected)
        {
            var instance = new Basic_Tests();

            var actual = instance.Test_120_Sum_3D_Cube(x, y, z);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1, 1, 0)] 
        [TestCase(3, 3, 3, 27)]
        [TestCase(4, 4, 4, 216)]

        public void Sum3DArrayTestWarmUp(int x, int y, int z, int expected)
        {
            var instance = new Basic_Tests();

            var actual = instance.Warm_Up_3D_Array(x, y, z);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 1)]
        [TestCase(3, 5)]
        [TestCase(4, 14)]
        public void SumOfSquares(int array, int expected)
        {
            var instance = new Basic_Tests();

            var actual = instance.Test_125_Build_Array_And_Return_Sum_Of_Squares(array);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int [] { 1, 2, 3, 4 }, 52)]
        public void LoopsWithArrays(int[] array, int expected)
        {
            var instance = new Basic_Tests();

            var actual = instance.Test_126_Loops(array);

            Assert.AreEqual(expected, actual);
        }
    }
}
