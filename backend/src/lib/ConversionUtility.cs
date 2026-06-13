namespace backend.lib;

public static class ConversionUtility
{
    public static (int, int) SplitOnDecimal(decimal number)
    {
        var (whole, fraction) = Math.DivRem((long)(number * 100), 100);

        return ((int)whole, (int)fraction);
    }
}
