using System;

using CustomTestingFramework.Asserts;
using CustomTestingFramework.Attributes;

namespace CustomTestingFramework.Tests
{
    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void TestSumValues()
        {
            int a = 2;
            int b = 3;

            int expectedResult = 5;
            int result = a + b;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestSumValues2()
        {
            int a = 2;
            int b = 3;

            int expectedResult = 6;
            int result = a + b;

            Assert.AreNotEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestSumValues3()
        {
            var a = new string[5];

            Assert.Throws<IndexOutOfRangeException>(
                () => a[12] == "LALala");
        }
    }
}
