namespace backend.lib;

public static class Converter
{
    /// <summary>
    /// Interprets given number as dollars and cents,
    /// then converts into written-word representation in english.
    /// </summary>
    /// <param name="number">Accepted range: [0, 999.999.999,99]</param>
    /// <exception cref="ArgumentOutOfRangeException">When number is out of bounds</returns>
    public static string ToCurrency(decimal number)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(number, 0);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(number, 999_999_999.99m);

        var (dollars, cents) = ConversionUtility.SplitOnDecimal(number);
        var dollarStr = ConvertDollars(dollars);
        if (cents == 0)
            return dollarStr;

        var centsStr = ConvertCents(cents);
        return string.Join(" ", dollarStr, centsStr);
    }

    private static string ConvertCents(int cents)
    {
        var centsStr = ConvertBelow100(cents);
        var currency = cents == 1 ? Words.MinorCurrencySingular : Words.MinorMainCurrencyPlural;

        return $"{Words.Join} {centsStr} {currency}";
    }

    private static string ConvertDollars(int number)
    {
        if (number == 0)
            return $"{SpecialNumbers[0]} {Words.MainCurrencyPlural}";
        if (number == 1)
            return $"{SpecialNumbers[1]} {Words.MainCurrencySingular}";

        var parts = new List<string>();
        var (remainder, firstTriplet) = Math.DivRem(number, 1000);
        if (firstTriplet > 0)
            parts.Add(ConvertBelow1000(firstTriplet));

        if (remainder > 0)
        {
            (remainder, var secondTriplet) = Math.DivRem(remainder, 1000);
            if (secondTriplet > 0)
                parts.Add($"{ConvertBelow1000(secondTriplet)} thousand");

            if (remainder > 0)
                parts.Add($"{ConvertBelow1000(remainder)} million");
        }

        parts.Reverse();
        var numberStr = string.Join(" ", parts);

        return string.Join(" ", numberStr, Words.MainCurrencyPlural);
    }

    private static string ConvertBelow1000(int number)
    {
        var (hundred, belowHundred) = Math.DivRem(number, 100);

        var belowHundredStr = ConvertBelow100(belowHundred);
        if (hundred == 0)
            return belowHundredStr;

        var hundredStr = $"{SpecialNumbers[hundred]} hundred";
        if (belowHundred == 0)
            return hundredStr;

        return string.Join(" ", hundredStr, belowHundredStr);
    }

    private static string ConvertBelow100(int number)
    {
        if (number < 20)
            return SpecialNumbers[number];

        var (ten, one) = Math.DivRem(number, 10);
        var tenStr = Tens[ten];
        if (one == 0)
            return tenStr;

        var oneStr = SpecialNumbers[one];
        return $"{tenStr}-{oneStr}";
    }

    private static string[] SpecialNumbers =>
        [
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "ten",
            "eleven",
            "twelve",
            "thirteen",
            "fourteen",
            "fifteen",
            "sixteen",
            "seventeen",
            "eighteen",
            "nineteen",
        ];

    private static Dictionary<int, string> Tens =>
        new()
        {
            { 2, "twenty" },
            { 3, "thirty" },
            { 4, "forty" },
            { 5, "fifty" },
            { 6, "sixty" },
            { 7, "seventy" },
            { 8, "eighty" },
            { 9, "ninety" },
        };

    private static class Words
    {
        public static string MainCurrencySingular => "dollar";
        public static string MainCurrencyPlural => "dollars";
        public static string MinorCurrencySingular => "cent";
        public static string MinorMainCurrencyPlural => "cents";
        public static string Join => "and";
    }
}
