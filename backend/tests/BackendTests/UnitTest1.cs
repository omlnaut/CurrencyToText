using backend.lib;

namespace BackendTests;

public class Tests
{
    [TestCase(0, "zero dollars")]
    [TestCase(1, "one dollar")]
    [TestCase(25.1, "twenty-five dollars and ten cents")]
    [TestCase(0.01, "zero dollars and one cent")]
    [TestCase(45_100, "forty - five thousand one hundred dollars")]
    [TestCase(999_999_999.99, "nine hundred ninety - nine million nine hundred ninety -nine thousand nine hundred")]
    public void ExamplesFromTask(decimal number, string target)
    {
        Assert.That(Converter.ToCurrency(number), Is.EqualTo(target));
    }
}