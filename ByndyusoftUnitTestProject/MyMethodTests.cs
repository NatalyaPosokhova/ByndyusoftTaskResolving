using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ByndyusoftTask;

namespace ByndyusoftUnitTestProject
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void SimpleTests()
        {
            Assert.AreEqual(1, MyMethod.SumMinArrayElements3(new int[] { 44, -1, 2, 4, 56 }));
            Assert.AreEqual(3, MyMethod.SumMinArrayElements3(new int[] { 1, 2 }));

            int[] testArray = new int[100000000];
            Random randNum = new Random();
            for (int i = 0; i < testArray.Length; i++)
            {
                testArray[i] = randNum.Next(-1000, 1000);
            }
            testArray[222] = -2000;
            testArray[333] = -3000;
            Assert.AreEqual(-5000, MyMethod.SumMinArrayElements3(testArray));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Not enough elements in array.")]
        public void CheckException()
        {
            Assert.IsInstanceOfType(MyMethod.SumMinArrayElements1(new int[] { 1 }), typeof(Exception));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Not enough elements in array.")]
        public void CheckException2()
        {
            Assert.IsInstanceOfType(MyMethod.SumMinArrayElements1(new int[] { }), typeof(Exception));
        }
    }
}
