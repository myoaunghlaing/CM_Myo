using CM_Quizz;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;

namespace CM_UnitTest
{
    public class CM_QuizzTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIsNullOrEmptyString()
        {
            Assert.IsTrue(Utility.IsNullOrEmptyString(null));
            Assert.IsFalse(Utility.IsNullOrEmptyString("a"));
            Assert.IsTrue(Utility.IsNullOrEmptyString(""));
            Assert.IsFalse(Utility.IsNullOrEmptyString("null"));
        }

        [Test]
        public void TestGetDivisors()
        {
            int[] divisors = Utility.GetDivisors(60);
            Assert.IsNotNull(divisors);
            Assert.IsNotEmpty(divisors);
            Assert.AreEqual(12, divisors.Length);
            Assert.Contains(30, divisors);

            divisors = null;
            divisors = Utility.GetDivisors(42);
            Assert.IsNotNull(divisors);
            Assert.IsNotEmpty(divisors);
            Assert.AreEqual(8, divisors.Length);
            Assert.Contains(14, divisors);
        }
        [Test]
        public void TestGetTriangleArea()
        {
            Assert.AreEqual(6, Utility.GetTriangleArea(3, 4, 5));

            var ex = Assert.Throws<InvalidTriangleException>(() => Utility.GetTriangleArea(-3, 4, 5));
            Assert.That(ex.Message, Is.EqualTo("Length cannot be negative"));

            ex = Assert.Throws<InvalidTriangleException>(() => Utility.GetTriangleArea(3, 4, 15));
            Assert.That(ex.Message, Is.EqualTo("The three sides cannot form a triangle"));
        }

        [Test]
        public void TestGetMostCommonNums()
        {
            int[] mostCommons = Utility.GetMostCommonNums(new int[] { 5, 4, 3, 2, 4, 5, 1, 6, 1, 2, 5, 4 });
            Assert.IsNotNull(mostCommons);
            Assert.IsNotEmpty(mostCommons);
            Assert.AreEqual(2, mostCommons.Length);
            Assert.Contains(5, mostCommons);
            Assert.Contains(4, mostCommons);

            mostCommons = null;
            mostCommons = Utility.GetMostCommonNums(new int[]  { 1, 2, 3, 4, 5, 1, 6, 7 });
            Assert.IsNotNull(mostCommons);
            Assert.IsNotEmpty(mostCommons);
            Assert.AreEqual(1, mostCommons.Length);
            Assert.Contains(1, mostCommons);

            mostCommons = null;
            mostCommons = Utility.GetMostCommonNums(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            Assert.IsNotNull(mostCommons);
            Assert.IsNotEmpty(mostCommons);
            Assert.AreEqual(7, mostCommons.Length);
            Assert.Contains(1, mostCommons);
        }
    }
}