namespace backend.lib;

public static class Converter
{
    public static string ToCurrency(decimal number)
    {
        // validate
        // - range
        // - either 0 or 2 decimal digits
        var thousand = (int)number % 1000;
        var converted = ConvertBelow1000(thousand);
        return converted + (number == 1 ? " dollar" : " dollars");
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
            { 4, "fourty" },
            { 5, "fifty" },
            { 6, "sixty" },
            { 7, "seventy" },
            { 8, "eighty" },
            { 9, "ninety" },
        };
}
