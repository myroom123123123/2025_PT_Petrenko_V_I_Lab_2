using System;
using CodingTask;
using NUnit.Framework;

namespace CodingTask.Test
{
    [TestFixture]
    public class TimeTests
    {
        [Test]
        [TestCase(1, 2, 3, "01:02:03")]
        [TestCase(-1, -2, -3, "-01:02:03")]
        [TestCase(0, 0, 0, "00:00:00")]
        [TestCase(12, 59, 59, "12:59:59")]
        public void ToStringReturnsCorrectFormat(int h, int m, int s, string expected)
        {
            Time t = new(h, m, s);
            Assert.AreEqual(expected, t.ToString());
        }

        [Test]
        [TestCase(1, 2, 3, 3723)]
        [TestCase(-1, -2, -3, -3723)]
        [TestCase(0, 0, 0, 0)]
        [TestCase(2, 0, 0, 7200)]
        public void ToSecondsReturnsCorrectValue(int h, int m, int s, int expected)
        {
            Time t = new(h, m, s);
            Assert.AreEqual(expected, t.ToSeconds());
        }

        [Test]
        [TestCase(3723, 1, 2, 3)]
        [TestCase(-3723, -1, -2, -3)]
        [TestCase(0, 0, 0, 0)]
        [TestCase(7200, 2, 0, 0)]
        public void FromSecondsCreatesCorrectTime(int seconds, int eh, int em, int es)
        {
            Time t = Time.FromSeconds(seconds);
            Assert.AreEqual(eh, t.Hours);
            Assert.AreEqual(em, t.Minutes);
            Assert.AreEqual(es, t.Seconds);
        }

        [Test]
        public void AdditionWorksCorrectly()
        {
            Time t1 = new(1, 2, 3);
            Time t2 = new(2, 3, 4);
            Time sum = t1.Add(t2);
            Assert.AreEqual(new Time(3, 5, 7).ToString(), sum.ToString());

            Time t3 = new(-1, -2, -3);
            Time sum2 = t1.Add(t3);
            Assert.AreEqual(new Time(0, 0, 0).ToString(), sum2.ToString());
        }

        [Test]
        public void SubtractionWorksCorrectly()
        {
            Time t1 = new(3, 5, 7);
            Time t2 = new(1, 2, 3);
            Time diff = t1.Subtract(t2);
            Assert.AreEqual(new Time(2, 3, 4).ToString(), diff.ToString());

            Time t3 = new(-1, -2, -3);
            Time diff2 = t1.Subtract(t3);
            Assert.AreEqual(new Time(4, 7, 10).ToString(), diff2.ToString());
        }
    }
}
