namespace backend.lib;

public static class GermanConverter
{
    public static string ToCurrency(decimal number)
    {
        var (dollars, _) = ConversionUtility.SplitOnDecimal(number);

        var dollarStr = ConvertDollars(dollars);
        return dollarStr;
    }

    private static string ConvertDollars(int dollars)
    {
        if (dollars == 0)
            return $"{SpecialNumbers[0]} {Words.MainCurrency}";
        var groups = ConversionUtility.GroupByThousands(dollars);
        if (groups.Length == 1)
            return $"{ConvertBelow1000(groups[0])} {Words.MainCurrency}";
        if (groups.Length == 2)
            return $"{ConvertBelow1000(groups[1])}{Words.Thousand}{ConvertBelow1000(groups[0])} {Words.MainCurrency}";
        if (groups.Length == 3)
        {
            if (groups[2] == 1)
                return $"{Words.OneFeminine} {Words.MillionSingular} {ConvertBelow1Million(groups[1], groups[0])}";

            return $"{ConvertBelow1000(groups[2])} {Words.MillionPlural} {ConvertBelow1Million(groups[1], groups[0])}";
        }
        return "";
    }

    private static string ConvertBelow1Million(int largeGroup, int smallGroup)
    {
        return (largeGroup, smallGroup) switch
        {
            (0, > 0) => $"{ConvertBelow1000(smallGroup)} {Words.MainCurrency}",
            (> 0, 0) => $"{ConvertBelow1000(largeGroup)}{Words.Thousand} {Words.MainCurrency}",
            (> 0, > 0) =>
                $"{ConvertBelow1000(largeGroup)}{Words.Thousand}{ConvertBelow1000(smallGroup)} {Words.MainCurrency}",
            (0, 0) => $"{Words.MainCurrency}",
            (_, _) => throw new ArgumentOutOfRangeException(),
        };
    }

    private static string ConvertBelow1000(int number)
    {
        var (hundred, belowHundred) = Math.DivRem(number, 100);

        var belowHundredStr = ConvertBelow100(belowHundred);
        if (hundred == 0)
            return belowHundredStr;

        var hundredStr = $"{SpecialNumbers[hundred]}{Words.Hundred}";

        return $"{hundredStr}{belowHundredStr}";
    }

    private static string ConvertBelow100(int number)
    {
        if (number == 0)
            return "";
        if (number < 20)
            return SpecialNumbers[number];

        var (ten, one) = Math.DivRem(number, 10);
        var tenStr = Tens[ten];
        if (one == 0)
            return tenStr;

        var oneStr = SpecialNumbers[one];
        return $"{oneStr}{Words.Join}{tenStr}";
    }

    private static string[] SpecialNumbers =>
        [
            "null",
            "ein",
            "zwei",
            "drei",
            "vier",
            "fünf",
            "sechs",
            "sieben",
            "acht",
            "neun",
            "zehn",
            "elf",
            "zwölf",
            "dreizehn",
            "vierzehn",
            "fünfzehn",
            "sechszehn",
            "siebzehn",
            "achtzehn",
            "neunzehn",
        ];

    private static Dictionary<int, string> Tens =>
        new()
        {
            { 2, "zwanzig" },
            { 3, "dreißig" },
            { 4, "vierzig" },
            { 5, "fünfzig" },
            { 6, "sechzig" },
            { 7, "siebzig" },
            { 8, "achtzig" },
            { 9, "neunzig" },
        };

    private static class Words
    {
        public static string MainCurrency => "Dollar";
        public static string MinorCurrency => "Cent";
        public static string Join => "und";
        public static string Hundred => "hundert";
        public static string Thousand => "tausend";
        public static string MillionSingular => "Million";
        public static string MillionPlural => "Millionen";
        public static string OneFeminine => "eine";
    }
}
