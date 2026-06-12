using backend.lib;

namespace BackendTests;

public class Tests
{
    [TestCase(0, "zero dollars")]
    [TestCase(1, "one dollar")]
    [TestCase(9, "nine dollars")]
    [TestCase(11, "eleven dollars")]
    [TestCase(12, "twelve dollars")]
    [TestCase(15, "fifteen dollars")]
    public void SpecialConversions(decimal number, string target)
    {
        Assert.That(Converter.ToCurrency(number), Is.EqualTo(target));
    }

    [TestCase(20, "twenty dollars")]
    [TestCase(21, "twenty-one dollars")]
    [TestCase(32, "thirty-two dollars")]
    [TestCase(43, "fourty-three dollars")]
    [TestCase(54, "fifty-four dollars")]
    [TestCase(65, "sixty-five dollars")]
    [TestCase(76, "seventy-six dollars")]
    [TestCase(87, "eighty-seven dollars")]
    [TestCase(98, "ninety-eight dollars")]
    [TestCase(99, "ninety-nine dollars")]
    public void Sub100Conversions(decimal number, string target)
    {
        Assert.That(Converter.ToCurrency(number), Is.EqualTo(target));
    }

    [TestCase(100, "one hundred dollars")]
    [TestCase(156, "one hundred fifty-six dollars")]
    [TestCase(227, "two hundred twenty-seven dollars")]
    public void Sub1000Conversions(decimal number, string target)
    {
        string actual = Converter.ToCurrency(number);
        Assert.That(actual, Is.EqualTo(target));
    }

    [TestCase(1_000, "one thousand dollars")]
    [TestCase(124_506, "one hundred twenty-four thousand five hundred six dollars")]
    [TestCase(385_200, "three hundred eighty-five thousand two hundred dollars")]
    public void Above1000Conversions(decimal number, string target)
    {
        string actual = Converter.ToCurrency(number);
        Assert.That(actual, Is.EqualTo(target));
    }

    [TestCase(0, "zero dollars")]
    [TestCase(1, "one dollar")]
    [TestCase(25.1, "twenty-five dollars and ten cents")]
    [TestCase(0.01, "zero dollars and one cent")]
    [TestCase(45_100, "forty - five thousand one hundred dollars")]
    [TestCase(
        999_999_999.99,
        "nine hundred ninety - nine million nine hundred ninety -nine thousand nine hundred"
    )]
    public void ExamplesFromTask(decimal number, string target)
    {
        Assert.That(Converter.ToCurrency(number), Is.EqualTo(target));
    }
}
