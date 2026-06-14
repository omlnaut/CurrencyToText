using backend.lib;
using NUnit.Framework;

namespace BackendTests;

[TestFixture]
public class GermanConverterTests
{
    [TestCase(0, "null Dollar")]
    [TestCase(1, "ein Dollar")]
    [TestCase(9, "neun Dollar")]
    [TestCase(11, "elf Dollar")]
    [TestCase(12, "zwölf Dollar")]
    [TestCase(15, "fünfzehn Dollar")]
    public void SpecialConversions(decimal number, string target)
    {
        Assert.That(GermanConverter.ToCurrency(number), Is.EqualTo(target));
    }

    [TestCase(20, "zwanzig Dollar")]
    [TestCase(21, "einundzwanzig Dollar")]
    [TestCase(32, "zweiunddreißig Dollar")]
    [TestCase(43, "dreiundvierzig Dollar")]
    [TestCase(54, "vierundfünfzig Dollar")]
    [TestCase(65, "fünfundsechzig Dollar")]
    [TestCase(76, "sechsundsiebzig Dollar")]
    [TestCase(87, "siebenundachtzig Dollar")]
    [TestCase(98, "achtundneunzig Dollar")]
    [TestCase(99, "neunundneunzig Dollar")]
    public void Sub100Conversions(decimal number, string target)
    {
        Assert.That(GermanConverter.ToCurrency(number), Is.EqualTo(target));
    }

    [TestCase(100, "einhundert Dollar")]
    [TestCase(156, "einhundertsechsundfünfzig Dollar")]
    [TestCase(227, "zweihundertsiebenundzwanzig Dollar")]
    public void Sub1000Conversions(decimal number, string target)
    {
        string actual = GermanConverter.ToCurrency(number);
        Assert.That(actual, Is.EqualTo(target));
    }

    [TestCase(1_000, "eintausend Dollar")]
    [TestCase(124_506, "einhundertvierundzwanzigtausendfünfhundertsechs Dollar")]
    [TestCase(385_200, "dreihundertfünfundachtzigtausendzweihundert Dollar")]
    public void Above1000Conversions(decimal number, string target)
    {
        string actual = GermanConverter.ToCurrency(number);
        Assert.That(actual, Is.EqualTo(target));
    }

    [TestCase(1_000_000, "eine Million Dollar")]
    [TestCase(100_000_001, "einhundert Millionen ein Dollar")]
    [TestCase(
        894_124_506,
        "achthundertvierundneunzig Millionen einhundertvierundzwanzigtausendfünfhundertsechs Dollar"
    )]
    [TestCase(
        998_385_200,
        "neunhundertachtundneunzig Millionen dreihundertfünfundachtzigtausendzweihundert Dollar"
    )]
    public void FullRangeConversions(decimal number, string target)
    {
        string actual = GermanConverter.ToCurrency(number);
        Assert.That(actual, Is.EqualTo(target));
    }

    [TestCase(0, "null Dollar")]
    [TestCase(1, "ein Dollar")]
    [TestCase(25.1, "fünfundzwanzig Dollar und zehn Cent")]
    [TestCase(0.01, "null Dollar und ein Cent")]
    [TestCase(45_100, "fünfundvierzigtausendeinhundert Dollar")]
    [TestCase(
        999_999_999.99,
        "neunhundertneunundneunzig Millionen neunhundertneunundneunzigtausendneunhundertneunundneunzig Dollar und neunundneunzig Cent"
    )]
    public void ExamplesFromTask(decimal number, string target)
    {
        Assert.That(GermanConverter.ToCurrency(number), Is.EqualTo(target));
    }

    [TestCase(-1)]
    [TestCase(1000000000)]
    [TestCase(999_999_999.991)]
    public void OutOfRange(decimal number)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => GermanConverter.ToCurrency(number));
    }
}
