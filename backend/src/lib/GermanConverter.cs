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
        return "";
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

        return "";
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

    private static class Words
    {
        public static string MainCurrency => "Dollar";
        public static string MinorCurrency => "Cent";
        public static string Join => "und";
        public static string Hundred => "hundert";
        public static string Thousand => "tausend";
        public static string MillionSingular => "Million";
        public static string MillionPlural => "Millionen";
        public static string OneSingular => "ein";
        public static string OnePlural => "eins";
    }
}
