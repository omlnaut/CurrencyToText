using backend.lib;
using NUnit.Framework;

namespace BackendTests;

[TestFixture]
public class ConversionUtilityTests
{
    [TestCase(123.45, 123, 45)]
    [TestCase(0.89, 0, 89)]
    [TestCase(1, 1, 0)]
    [TestCase(0, 0, 0)]
    [TestCase(123.4578, 123, 45)]
    public void TestSplitOnDecimal(decimal number, int whole, int fraction)
    {
        var (actualWhole, actualFraction) = ConversionUtility.SplitOnDecimal(number);

        Assert.That(actualWhole, Is.EqualTo(whole));
        Assert.That(actualFraction, Is.EqualTo(fraction));
    }

    [TestCase(123, new int[] { 123 })]
    [TestCase(4_123, new int[] { 123, 4 })]
    [TestCase(5_000_123, new int[] { 123, 0, 5 })]
    public void TestGroupByThousands(int number, int[] expected)
    {
        var actual = ConversionUtility.GroupByThousands(number);

        Assert.That(actual, Is.EquivalentTo(expected));
    }
}
