using System;
using NUnit.Framework;

namespace CodingTask.Test;

public class TimeTest
{
    [TestCase(1, 0, 0, 3600L, TestName = "1H_to_Seconds")]
    [TestCase(0, 1, 0, 60L, TestName = "1M_to_Seconds")]
    [TestCase(2, 30, 45, 9045L, TestName = "ComplexTime_to_Seconds")]
    [TestCase(0, 0, 0, 0L, TestName = "ZeroTime_to_Seconds")]
    [TestCase(25, 0, 0, 90000L, TestName = "TimeOver24H_to_Seconds")]
    public void TimeToTotalSecondsConversionCorrect(int h, int m, int s, long expectedSeconds)
    {
        var time = new Time(h, m, s);
        long actualSeconds = time.TotalSeconds;

        Assert.AreEqual(expectedSeconds, actualSeconds, $"TotalSeconds property returns incorrect value. Expected: {expectedSeconds}, Actual: {actualSeconds}");
    }

    [TestCase(3665L, 1L, 1L, 5L, TestName = "Seconds_to_HMS_1h1m5s")]
    [TestCase(86400L, 24L, 0L, 0L, TestName = "Seconds_to_HMS_24h")]
    [TestCase(0L, 0L, 0L, 0L, TestName = "Seconds_to_HMS_Zero")]
    public void TimeFromTotalSecondsConversionCorrect(long totalSeconds, long expectedH, long expectedM, long expectedS)
    {
        var time = new Time(totalSeconds);

        Assert.AreEqual(expectedH, time.Hours, "Hours property is incorrect");
        Assert.AreEqual(expectedM, time.Minutes, "Minutes property is incorrect");
        Assert.AreEqual(expectedS, time.Seconds, "Seconds property is incorrect");
    }

    [TestCase("1:30:00", "0:30:00", 2L, 0L, 0L, TestName = "Addition_Simple")]
    [TestCase("0:00:50", "0:00:20", 0L, 1L, 10L, TestName = "Addition_RollOverSeconds")]
    [TestCase("23:59:59", "0:00:02", 24L, 0L, 1L, TestName = "Addition_RollOverDays")]
    public void TimeAdditionOperatorCorrect(string t1Str, string t2Str, long expectedH, long expectedM, long expectedS)
    {
        var t1 = Time.Parse(t1Str);
        var t2 = Time.Parse(t2Str);

        var actual = t1 + t2;
        Assert.AreEqual(expectedH, actual.Hours, "Addition: Hours incorrect");
        Assert.AreEqual(expectedM, actual.Minutes, "Addition: Minutes incorrect");
        Assert.AreEqual(expectedS, actual.Seconds, "Addition: Seconds incorrect");
    }

    [TestCase("2:00:00", "0:01:00", 1L, 59L, 0L, 0L, TestName = "Subtraction_Simple")]
    [TestCase("0:00:00", "0:00:20", 0L, 0L, 20L, -20L, TestName = "Subtraction_NegativeResult")]
    public void TimeSubtractionOperatorCorrect(string t1Str, string t2Str, long expectedH, long expectedM, long expectedS, long expectedTotals = 0)
    {
        var t1 = Time.Parse(t1Str);
        var t2 = Time.Parse(t2Str);

        var actual = t1 - t2;
        Assert.AreEqual(expectedH, actual.Hours, "Subtraction: Hours incorrect");
        Assert.AreEqual(expectedM, Math.Abs(actual.Minutes), "Subtraction: Minutes incorrect");
        Assert.AreEqual(expectedS, Math.Abs(actual.Seconds), "Subtraction: Seconds incorrect");

        if (expectedTotals != 0)
        {
            Assert.AreEqual(expectedTotals, actual.TotalSeconds, "Subtraction: Totals incorrect");
        }
    }

    [TestCase(1L, 1L, 5L, "1:01:05", TestName = "ToString_Padding")]
    [TestCase(12L, 34L, 56L, "12:34:56", TestName = "ToString_Normal")]
    [TestCase(0L, 0L, 0L, "0:00:00", TestName = "ToString_Zero")]
    [TestCase(-1L, 0L, -10L, "-1:00:10", TestName = "ToString_Negative")]
    public void TimeToStringCorrect(long h, long m, long s, string expectedString)
    {
        long totalSeconds = (h * 3600L) + (m * 60L) + s;
        var time = new Time(totalSeconds);
        var actualString = time.ToString();
        Assert.AreEqual(expectedString, actualString, "ToString() method returns incorrect string format.");
    }

    [TestCase("1:30:00", 1L, 30L, 0L, TestName = "Parse_FullFormat")]
    [TestCase("10:05:01", 10L, 5L, 1L, TestName = "Parse_WithSingleDigit")]
    [TestCase("25:10:10", 25L, 10L, 10L, TestName = "Parse_Over24h")]
    [TestCase("5:00", 5L, 0L, 0L, TestName = "Parse_NoSeconds")]
    public void TimeParseCorrect(string input, long expectedH, long expectedM, long expectedS)
    {
        var actual = Time.Parse(input);
        Assert.AreEqual(expectedH, actual.Hours, "Parse: Hours incorrect");
        Assert.AreEqual(expectedM, actual.Minutes, "Parse: Minutes incorrect");
        Assert.AreEqual(expectedS, actual.Seconds, "Parse: Seconds incorrect");
    }

    [Test]
    public void TimeAddThrowsExceptionOnNull()
    {
        Time t1 = new Time(1, 0, 0);
        Assert.Throws<ArgumentNullException>(() => t1.Add(null));
    }

    [Test]
    public void TimeSubtractThrowsExceptionOnNull()
    {
        Time t1 = new Time(1, 0, 0);
        Assert.Throws<ArgumentNullException>(() => t1.Subtract(null));
    }
}
