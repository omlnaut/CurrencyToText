namespace backend.lib;

public static class Converter
{
    public static string ToCurrency(decimal number)
    {
        // validate
        // - range
        // - either 0 or 2 decimal digits
        var hundreds = (int)number % 100;
        var converted = ConvertBelow100(hundreds);
        return converted + (number == 1 ? " dollar" : " dollars");
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
