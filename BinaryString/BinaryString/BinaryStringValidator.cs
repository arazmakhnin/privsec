namespace BinaryString;

public static class BinaryStringValidator
{
    public static bool IsStringGood(string? binaryString)
    {
        ArgumentNullException.ThrowIfNull(binaryString);

        var zerosCount = 0;
        var onesCount = 0;

        foreach (var c in binaryString)
        {
            switch (c)
            {
                case '0':
                    zerosCount++;
                    break;
                case '1':
                    onesCount++;
                    break;
                default:
                    throw new ArgumentException($"Unexpected char in the input string: {c} (0x{(byte)c:X2})");
            }

            if (onesCount < zerosCount)
                return false;
        }

        return zerosCount == onesCount;
    }
}