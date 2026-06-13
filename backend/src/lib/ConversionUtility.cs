namespace backend.lib;

public static class ConversionUtility
{
    /// <summary>
    /// number>=0
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static (int, int) SplitOnDecimal(decimal number)
    {
        var (whole, fraction) = Math.DivRem((long)(number * 100), 100);

        return ((int)whole, (int)fraction);
    }

    /// <summary>
    /// number>=0. Returns groups starting with lowest, i.e. 123_456 -> [456,123]
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static int[] GroupByThousands(int number)
    {
        var parts = new List<int>();

        do
        {
            (number, var group) = Math.DivRem(number, 1000);
            parts.Add(group);
        } while (number > 0);

        return [.. parts];
    }
}
